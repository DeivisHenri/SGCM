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

                            List<int> array2 = new List<int>();

                            array2.Add(retorno.Seis);
                            array2.Add(retorno.SeisMeia);
                            array2.Add(retorno.Sete);
                            array2.Add(retorno.SeteMeia);
                            array2.Add(retorno.Oito);
                            array2.Add(retorno.OitoMeia);
                            array2.Add(retorno.Nove);
                            array2.Add(retorno.NoveMeia);
                            array2.Add(retorno.Nove);
                            array2.Add(retorno.NoveMeia);
                            array2.Add(retorno.Dez);
                            array2.Add(retorno.DezMeia);
                            array2.Add(retorno.Onze);
                            array2.Add(retorno.OnzeMeia);
                            array2.Add(retorno.Doze);
                            array2.Add(retorno.DozeMeia);
                            array2.Add(retorno.Treze);
                            array2.Add(retorno.TrezeMeia);
                            array2.Add(retorno.Quatorze);
                            array2.Add(retorno.QuatorzeMeia);
                            array2.Add(retorno.Quinze);
                            array2.Add(retorno.QuinzeMeia);
                            array2.Add(retorno.Dezesseis);
                            array2.Add(retorno.DezesseisMeia);
                            array2.Add(retorno.Dezessete);
                            array2.Add(retorno.DezesseteMeia);
                            array2.Add(retorno.Dezoito);
                            array2.Add(retorno.DezoitoMeia);

                            ausenciaViewModel.HoraInicio = array2.FindIndex(x => x == 1) - 1;
                            ausenciaViewModel.HoraFinal = array2.FindLastIndex(x => x == 1) - 1;
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
                            ViewBag.MensagemTitle = "Sucesso";
                            ViewBag.MensagemBody = "A ausência foi alterada com sucesso!";
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
        }
    }
}
