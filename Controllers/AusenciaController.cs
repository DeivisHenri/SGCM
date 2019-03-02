using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGCM.AppData.Ausencia;
using SGCM.Models.Ausencia.CadastrarAusenciaModel;
using SGCM.Models.Ausencia.ConsultarAusenciaModel;
using SGCM.Models.Ausencia.EditarAusenciaModel;
using SGCM.AppData.Infraestrutura.UtilMetodo;

namespace SGCM.Controllers
{
    public class AusenciaController : Controller {

        [HttpGet]
        public ActionResult CadastrarAusencia() {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flConsultaI"] != 0) {
                        var viewModel = new CadastrarAusenciaModel();

                        viewModel.DataInicio = DateTime.Now;
                        viewModel.HoraInicio = 0;
                        viewModel.DataFinal = DateTime.Now;
                        viewModel.HoraFinal = 0;

                        return View(viewModel);
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Consulta/MarcarDataAusencia', pois não tem permissão para inserir consulta");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: ConsultaController";
                ViewBag.MensagemBodyAction = "Action: CadastrarConsulta";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarAusencia(CadastrarAusenciaModel model) {
            try {
                if (!ModelState.IsValid) {
                    //do whatever you want here
                }
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flConsultaI"] != 0) {
                        var objAusenciaBLL = new AusenciaBLL();

                        model.idUsuarioAusencia = Convert.ToInt32(ViewData["idUsuario"]);

                        var retornoMarcarAusencia = objAusenciaBLL.CadastrarAusencia(model);

                        if (retornoMarcarAusencia == 1) {
                            ViewBag.MensagemTitle = "Error";
                            ViewBag.MensagemBody = "A hora inicial informada é mais cedo que a hora atual! Não pode marcar ausência retroativa!";
                            return View();
                        } else if (retornoMarcarAusencia == 2) {
                            ViewBag.MensagemTitle = "Error";
                            ViewBag.MensagemBody = "A data final tem que ser e maior que a data inicial!";
                            return View();
                        } else if (retornoMarcarAusencia == 3) {
                            ViewBag.MensagemTitle = "Error";
                            ViewBag.MensagemBody = "Quando a data inicial for igual a data final, a hora inicial tem que ser mais cedo que a hora final!";
                            return View();
                        } else {
                            ViewBag.MensagemTitle = "Sucesso";
                            ViewBag.MensagemBody = "A ausência para o seguinte período: " +
                                                    new DateTime(model.DataInicio.Year, model.DataInicio.Month, model.DataInicio.Day, UtilMetodo.DescobrirHora(model.HoraInicio)[0], UtilMetodo.DescobrirHora(model.HoraInicio)[1], 0) + " até " +
                                                    new DateTime(model.DataFinal.Year, model.DataFinal.Month, model.DataFinal.Day, UtilMetodo.DescobrirHora(model.HoraFinal)[0], UtilMetodo.DescobrirHora(model.HoraFinal)[1], 0) + " foi realizada com sucesso!";
                            ModelState.Clear();
                            return View();
                        }
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem permissão para consultar Pacientes!");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: ConsultaController";
                ViewBag.MensagemBodyAction = "Action: MarcarDataAusencia";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        [HttpGet]
        public ActionResult ConsultarAusencia() {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flAusenciaC"] != 0) {
                        List<ConsultarAusenciaBancoModel> viewModel = new List<ConsultarAusenciaBancoModel>();
                        AusenciaBLL objAusenciaBLL = new AusenciaBLL();
                        viewModel = objAusenciaBLL.ConsultarAusencia(Convert.ToInt32(ViewData["idUsuario"]));

                        if (HttpContext.Session.GetString("MensagemTitle") != null && HttpContext.Session.GetString("MensagemBody") != null && HttpContext.Session.GetString("MensagemTitle") != "" && HttpContext.Session.GetString("MensagemBody") != "") {
                            ViewBag.MensagemTitle = HttpContext.Session.GetString("MensagemTitle");
                            ViewBag.MensagemBody = HttpContext.Session.GetString("MensagemBody");
                            HttpContext.Session.SetString("MensagemTitle", "");
                            HttpContext.Session.SetString("MensagemBody", "");
                        }

                        return View(viewModel);
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Consulta/MarcarDataAusencia', pois não tem permissão para inserir consulta");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: ConsultaController";
                ViewBag.MensagemBodyAction = "Action: CadastrarConsulta";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditarAusencia(int id) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flAusenciaA"] != 0) {

                        AusenciaBLL objAusenciaBLL = new AusenciaBLL();

                        EditarAusenciaBancoModel retorno = new EditarAusenciaBancoModel();
                        retorno = objAusenciaBLL.ConsultarAusenciaIdAusencia(id);

                        EditarAusenciaViewModel ausenciaViewModel = new EditarAusenciaViewModel();

                        if (retorno != null) {
                            ausenciaViewModel.DataInicio = retorno.DataInicio;
                            ausenciaViewModel.DataFinal = retorno.DataFinal;

                            var horaInicio = 0;
                            Boolean flagHoraIncio = false;

                            if (retorno.Seis == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 1;
                                flagHoraIncio = true;
                            }
                            if (retorno.SeisMeia == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 2;
                                flagHoraIncio = true;
                            }

                            if (retorno.Sete == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 3;
                                flagHoraIncio = true;
                            }
                            if (retorno.SeteMeia == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 4;
                                flagHoraIncio = true;
                            }

                            if (retorno.Oito == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 5;
                                flagHoraIncio = true;
                            }
                            if (retorno.OitoMeia == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 6;
                                flagHoraIncio = true;
                            }

                            if (retorno.Nove == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 7;
                                flagHoraIncio = true;
                            }
                            if (retorno.NoveMeia == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 8;
                                flagHoraIncio = true;
                            }

                            if (retorno.Dez == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 9;
                                flagHoraIncio = true;
                            }
                            if (retorno.DezMeia == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 10;
                                flagHoraIncio = true;
                            }

                            if (retorno.Onze == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 11;
                                flagHoraIncio = true;
                            }
                            if (retorno.OnzeMeia == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 12;
                                flagHoraIncio = true;
                            }

                            if (retorno.Doze == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 13;
                                flagHoraIncio = true;
                            }
                            if (retorno.DozeMeia == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 14;
                                flagHoraIncio = true;
                            }

                            if (retorno.Treze == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 15;
                                flagHoraIncio = true;
                            }
                            if (retorno.TrezeMeia == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 16;
                                flagHoraIncio = true;
                            }

                            if (retorno.Quatorze == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 17;
                                flagHoraIncio = true;
                            }
                            if (retorno.QuatorzeMeia == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 18;
                                flagHoraIncio = true;
                            }

                            if (retorno.Quinze == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 19;
                                flagHoraIncio = true;
                            }
                            if (retorno.QuinzeMeia == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 20;
                                flagHoraIncio = true;
                            }

                            if (retorno.Dezesseis == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 21;
                                flagHoraIncio = true;
                            }
                            if (retorno.DezesseisMeia == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 22;
                                flagHoraIncio = true;
                            }

                            if (retorno.Dezessete == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 23;
                                flagHoraIncio = true;
                            }
                            if (retorno.DezesseteMeia == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 24;
                                flagHoraIncio = true;
                            }

                            if (retorno.Dezoito == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 25;
                                flagHoraIncio = true;
                            }
                            if (retorno.DezoitoMeia == 1 && flagHoraIncio == false)
                            {
                                horaInicio = 26;
                                flagHoraIncio = true;
                            }

                            var horaFinal = 0;
                            if (retorno.Seis == 1) horaFinal = 1;
                            if (retorno.SeisMeia == 1) horaFinal = 2;

                            if (retorno.Sete == 1) horaFinal = 3;
                            if (retorno.SeteMeia == 1) horaFinal = 4;

                            if (retorno.Oito == 1) horaFinal = 5;
                            if (retorno.OitoMeia == 1) horaFinal = 6;

                            if (retorno.Nove == 1)
                            {
                                horaFinal = 7;
                            }
                            if (retorno.NoveMeia == 1)
                            {
                                horaFinal = 8;
                            }

                            if (retorno.Dez == 1)
                            {
                                horaFinal = 9;
                            }
                            if (retorno.DezMeia == 1)
                            {
                                horaFinal = 10;
                            }

                            if (retorno.Onze == 1)
                            {
                                horaFinal = 11;
                            }
                            if (retorno.OnzeMeia == 1)
                            {
                                horaFinal = 12;
                            }

                            if (retorno.Doze == 1)
                            {
                                horaFinal = 13;
                            }
                            if (retorno.DozeMeia == 1)
                            {
                                horaFinal = 14;
                            }

                            if (retorno.Treze == 1)
                            {
                                horaFinal = 15;
                            }
                            if (retorno.TrezeMeia == 1)
                            {
                                horaFinal = 16;
                            }

                            if (retorno.Quatorze == 1)
                            {
                                horaFinal = 17;
                            }
                            if (retorno.QuatorzeMeia == 1)
                            {
                                horaFinal = 18;
                            }

                            if (retorno.Quinze == 1)
                            {
                                horaFinal = 19;
                            }
                            if (retorno.QuinzeMeia == 1)
                            {
                                horaFinal = 20;
                            }

                            if (retorno.Dezesseis == 1)
                            {
                                horaFinal = 21;
                            }
                            if (retorno.DezesseisMeia == 1)
                            {
                                horaFinal = 22;
                            }

                            if (retorno.Dezessete == 1)
                            {
                                horaFinal = 23;
                            }
                            if (retorno.DezesseteMeia == 1)
                            {
                                horaFinal = 24;
                            }

                            if (retorno.Dezoito == 1)
                            {
                                horaFinal = 25;
                            }
                            if (retorno.DezoitoMeia == 1)
                            {
                                horaFinal = 26;
                            }

                            ausenciaViewModel.HoraInicio = horaInicio;
                            ausenciaViewModel.HoraFinal = horaFinal;
                            ausenciaViewModel.idAusencia = id;
                        } else {
                            ViewBag.MensagemTitle = "Erro";
                            ViewBag.MensagemBody = "Ocorreu um erro na hora de consultar a Ausencia com o identificador: " + id;
                            return View();
                        }

                        return View(ausenciaViewModel);
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Consulta/MarcarDataAusencia', pois não tem permissão para inserir consulta");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: ConsultaController";
                ViewBag.MensagemBodyAction = "Action: CadastrarConsulta";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarAusencia(EditarAusenciaViewModel model) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flAusenciaA"] != 0) {
                        AusenciaBLL objAusenciaBLL = new AusenciaBLL();
                        var retornoEditar = objAusenciaBLL.EditarAusencia(model);

                        if (retornoEditar == 1) {
                            ViewBag.MensagemTitle = "Error";
                            ViewBag.MensagemBody = "A hora inicial informada é mais cedo que a hora atual! Não pode marcar ausência retroativa!";
                            return View();
                        } else if (retornoEditar == 2) {
                            ViewBag.MensagemTitle = "Error";
                            ViewBag.MensagemBody = "A data final tem que ser e maior que a data inicial!";
                            return View();
                        } else if (retornoEditar == 3) {
                            ViewBag.MensagemTitle = "Error";
                            ViewBag.MensagemBody = "Quando a data inicial for igual a data final, a hora inicial tem que ser mais cedo que a hora final!";
                            return View();
                        } else if (retornoEditar == 4) {
                            ViewBag.MensagemTitle = "Error";
                            ViewBag.MensagemBody = "Ocorreu um erro durante a edição da data da ausência do médico! Por favor contate o suporte!";
                            return View();
                        } else {
                            HttpContext.Session.SetString("MensagemTitle", "Sucesso");
                            HttpContext.Session.SetString("MensagemBody", "A ausência foi alterada com sucesso!");
                            return RedirectToAction("ConsultarAusencia", "Ausencia");
                        }
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Consulta/MarcarDataAusencia', pois não tem permissão para inserir consulta");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: ConsultaController";
                ViewBag.MensagemBodyAction = "Action: CadastrarConsulta";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        private void CarregarDadosUsuarioParaTela()
        {
            ViewData.Add("idUsuario", HttpContext.Session.GetInt32("idUsuario"));
            ViewData.Add("usuario", HttpContext.Session.GetString("usuario"));

            ViewData.Add("idPessoa", HttpContext.Session.GetInt32("idPessoa"));
            ViewData.Add("idMedico", HttpContext.Session.GetInt32("idMedico"));
            ViewData.Add("tipoUsuario", HttpContext.Session.GetInt32("tipoUsuario"));
            ViewData.Add("nome", HttpContext.Session.GetString("nome"));
            ViewData.Add("cpf", HttpContext.Session.GetString("cpf"));
            ViewData.Add("rg", HttpContext.Session.GetString("rg"));
            ViewData.Add("dataNascimento", HttpContext.Session.GetString("dataNascimento"));
            ViewData.Add("logradouro", HttpContext.Session.GetString("logradouro"));
            ViewData.Add("numero", HttpContext.Session.GetInt32("numero"));
            ViewData.Add("bairro", HttpContext.Session.GetString("bairro"));
            ViewData.Add("cidade", HttpContext.Session.GetString("cidade"));
            ViewData.Add("uf", HttpContext.Session.GetString("uf"));
            ViewData.Add("telefoneCelular", HttpContext.Session.GetString("telefoneCelular"));
            ViewData.Add("email", HttpContext.Session.GetString("email"));

            ViewData.Add("flUsuarioI", HttpContext.Session.GetInt32("flUsuarioI"));
            ViewData.Add("flUsuarioC", HttpContext.Session.GetInt32("flUsuarioC"));
            ViewData.Add("flUsuarioA", HttpContext.Session.GetInt32("flUsuarioA"));
            ViewData.Add("flUsuarioE", HttpContext.Session.GetInt32("flUsuarioE"));

            ViewData.Add("flPacienteI", HttpContext.Session.GetInt32("flPacienteI"));
            ViewData.Add("flPacienteC", HttpContext.Session.GetInt32("flPacienteC"));
            ViewData.Add("flPacienteA", HttpContext.Session.GetInt32("flPacienteA"));
            ViewData.Add("flPacienteE", HttpContext.Session.GetInt32("flPacienteE"));

            ViewData.Add("flConsultaI", HttpContext.Session.GetInt32("flConsultaI"));
            ViewData.Add("flConsultaC", HttpContext.Session.GetInt32("flConsultaC"));
            ViewData.Add("flConsultaA", HttpContext.Session.GetInt32("flConsultaA"));
            ViewData.Add("flConsultaE", HttpContext.Session.GetInt32("flConsultaE"));

            ViewData.Add("flAusenciaI", HttpContext.Session.GetInt32("flAusenciaI"));
            ViewData.Add("flAusenciaC", HttpContext.Session.GetInt32("flAusenciaC"));
            ViewData.Add("flAusenciaA", HttpContext.Session.GetInt32("flAusenciaA"));
            ViewData.Add("flAusenciaE", HttpContext.Session.GetInt32("flAusenciaE"));

            ViewData.Add("flMedicamentoI", HttpContext.Session.GetInt32("flMedicamentoI"));
            ViewData.Add("flMedicamentoC", HttpContext.Session.GetInt32("flMedicamentoC"));
            ViewData.Add("flMedicamentoA", HttpContext.Session.GetInt32("flMedicamentoA"));
            ViewData.Add("flMedicamentoE", HttpContext.Session.GetInt32("flMedicamentoE"));

            ViewData.Add("flExamesI", HttpContext.Session.GetInt32("flExamesI"));
            ViewData.Add("flExamesC", HttpContext.Session.GetInt32("flExamesC"));
            ViewData.Add("flExamesA", HttpContext.Session.GetInt32("flExamesA"));
            ViewData.Add("flExamesE", HttpContext.Session.GetInt32("flExamesE"));

            ViewData.Add("flHistoriaMolestiaAtualI", HttpContext.Session.GetInt32("flHistoriaMolestiaAtualI"));
            ViewData.Add("flHistoriaMolestiaAtualC", HttpContext.Session.GetInt32("flHistoriaMolestiaAtualC"));
            ViewData.Add("flHistoriaMolestiaAtualA", HttpContext.Session.GetInt32("flHistoriaMolestiaAtualA"));
            ViewData.Add("flHistoriaMolestiaAtualE", HttpContext.Session.GetInt32("flHistoriaMolestiaAtualE"));

            ViewData.Add("flHistoriaPatologicaPregressaI", HttpContext.Session.GetInt32("flHistoriaPatologicaPregressaI"));
            ViewData.Add("flHistoriaPatologicaPregressaC", HttpContext.Session.GetInt32("flHistoriaPatologicaPregressaC"));
            ViewData.Add("flHistoriaPatologicaPregressaA", HttpContext.Session.GetInt32("flHistoriaPatologicaPregressaA"));
            ViewData.Add("flHistoriaPatologicaPregressaE", HttpContext.Session.GetInt32("flHistoriaPatologicaPregressaE"));

            ViewData.Add("flHipoteseDiagnosticaI", HttpContext.Session.GetInt32("flHipoteseDiagnosticaI"));
            ViewData.Add("flHipoteseDiagnosticaC", HttpContext.Session.GetInt32("flHipoteseDiagnosticaC"));
            ViewData.Add("flHipoteseDiagnosticaA", HttpContext.Session.GetInt32("flHipoteseDiagnosticaA"));
            ViewData.Add("flHipoteseDiagnosticaE", HttpContext.Session.GetInt32("flHipoteseDiagnosticaE"));

            ViewData.Add("flCondutaI", HttpContext.Session.GetInt32("flCondutaI"));
            ViewData.Add("flCondutaC", HttpContext.Session.GetInt32("flCondutaC"));
            ViewData.Add("flCondutaA", HttpContext.Session.GetInt32("flCondutaA"));
            ViewData.Add("flCondutaE", HttpContext.Session.GetInt32("flCondutaE"));

            ViewData.Add("flIniciarAtendimento", HttpContext.Session.GetInt32("flIniciarAtendimento"));
        }
    }
}
