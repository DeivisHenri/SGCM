using SGCM.Models.Paciente.CadastroPacienteModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SGCM.AppData.Paciente;
using System;
using SGCM.Models.Paciente.ConsultarPacienteModel;
using System.Collections.Generic;
using SGCM.Models.Paciente.EditarPacienteModel;
using SGCM.AppData.Consulta;

namespace SGCM.Controllers
{
    public class PacienteController : Controller {

        //GET: /Paciente/CadastroPaciente
        [HttpGet]
        public ActionResult CadastroPaciente() {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["FlPacienteI"] != 0) {
                        var viewModel = new CadastroPacienteModel();
                        viewModel.pessoa = new Models.Paciente.CadastroPacienteModel.DadosPessoais();

                        return View(viewModel);
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Paciente/CadastroPaciente'");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: PacienteController";
                ViewBag.MensagemBodyAction = "Action: CadastroPaciente - GET";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        //POST: /Paciente/CadastroPaciente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroPaciente(CadastroPacienteModel model) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                if (!ModelState.IsValid) return View(model);

                if ((int)ViewData["FlPacienteI"] != 0) {
                    model.pessoa.IdMedico = (int)HttpContext.Session.GetInt32("idMedico");
                    model.pessoa.IdPessoa = (int)HttpContext.Session.GetInt32("idPessoa");

                    var objPacienteBLL = new PacienteBLL();
                    var retorno = objPacienteBLL.InserirPaciente(model);

                    if (retorno == 2) {
                        ViewBag.MensagemTitle = "Sucesso no Cadastro de Paciente";
                        ViewBag.MensagemBody = "Paciente " + model.pessoa.Nome + " cadastrado com sucesso!";
                        ModelState.Clear();
                        return View();
                    } else {
                        ViewBag.MensagemTitle = "Erro no Cadastro de Paciente";
                        ViewBag.MensagemBody = "Cadastro do paciente " + model.pessoa.Nome + " não realizado!";
                        return View();
                    }
                } else {
                    HttpContext.Session.SetString("MensagemTitle", "Erro");
                    HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem permissão para cadastrar pacientes!");
                    return RedirectToAction("Index", "Home");
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: PacienteController";
                ViewBag.MensagemBodyAction = "Action: CadastroPaciente/{PACIENTE} - POST";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        //GET: /Paciente/ConsultaUsuario
        [HttpGet]
        public ActionResult ConsultarPaciente() {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if (ViewData["flPacienteC"] != null && (int)ViewData["flPacienteC"] != 0) {
                        var objPacienteBLL = new PacienteBLL();
                        List<ConsultarPacienteModel> viewModel = objPacienteBLL.ConsultarPaciente((int)ViewData["idMedico"]);

                        if (viewModel != null) {
                            if (HttpContext.Session.GetString("MensagemTitle") != null && HttpContext.Session.GetString("MensagemBody") != null && HttpContext.Session.GetString("MensagemTitle") != "" && HttpContext.Session.GetString("MensagemBody") != "") {
                                ViewBag.MensagemTitle = HttpContext.Session.GetString("MensagemTitle");
                                ViewBag.MensagemBody = HttpContext.Session.GetString("MensagemBody");
                                HttpContext.Session.SetString("MensagemTitle", "");
                                HttpContext.Session.SetString("MensagemBody", "");
                            }
                            return View(viewModel);
                        } else {
                            ViewBag.MensagemTitle = "Informação";
                            ViewBag.MensagemBody = "Nenhum paciente foi cadastrado pelo Usuário: " + ViewData["nome"];
                            return View();
                        }
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Paciente/ConsultarPaciente'");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    HttpContext.Session.SetString("MensagemBody", "Você não está logado no sistema! Realize o Login antes de acessar essa a página: '" + ViewData["ReturnUrl"] + "' !");
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            }
            catch (Exception ex)
            {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: PacienteController";
                ViewBag.MensagemBodyAction = "Action: ConsultarPaciente - GET";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }

        }

        [HttpGet]
        public ActionResult EditarPaciente(int id) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flPacienteA"] != 0) {
                        var objPacienteBLL = new PacienteBLL();
                        EditarPacienteModel viewModel = objPacienteBLL.ConsultarPacienteID(id);
                        TempData.Clear();

                        return View(viewModel);
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Informação");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Paciente/EditarPaciente'");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    HttpContext.Session.SetString("MensagemTitle", "Informação");
                    HttpContext.Session.SetString("MensagemBody", "Você não está logado no sistema! Realize o Login antes de acessar essa página!");
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: PacienteController";
                ViewBag.MensagemBodyAction = "Action: EditarPaciente/ID - GET";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }

        }

        [HttpPost]
        public ActionResult EditarPaciente(EditarPacienteModel pacienteModel) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flPacienteA"] != 0) {
                        var objPacienteBLL = new PacienteBLL();
                        var retorno = objPacienteBLL.EditarPaciente(pacienteModel);

                        if (retorno == 1) {
                            HttpContext.Session.SetString("MensagemTitle", "Sucesso");
                            HttpContext.Session.SetString("MensagemBody", "O paciente " + pacienteModel.pessoa.Nome + " foi atualizado com sucesso!");
                            return RedirectToAction("ConsultarPaciente", "Paciente");
                        } else {
                            ViewBag.MensagemTitle = "Erro";
                            ViewBag.MensagemBody = "Ocorreu um erro na tentiva de editar o paciente: " + pacienteModel.pessoa.Nome;
                            return View();
                        }
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem permissão para alterar pacientes!");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    HttpContext.Session.SetString("MensagemTitle", "Erro");
                    HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Paciente/EditarPaciente'");
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: PacienteController";
                ViewBag.MensagemBodyAction = "Action: EditarPaciente/{PACIENTE} - POST";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        //[HttpGet]
        //public ActionResult GetPacienteConsulta() {
        //    try {
        //        CarregarDadosUsuarioParaTela();
        //        if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
        //            if ((int)ViewData["flPacienteC"] != 0) {
        //                var objConsultaPacienteBLL = new ConsultaBLL();
        //                var retorno = objConsultaPacienteBLL.GetPacienteConsulta(id);

        //                if (retorno == 1)
        //                {
        //                    HttpContext.Session.SetString("MensagemTitle", "Sucesso");
        //                    HttpContext.Session.SetString("MensagemBody", "O paciente " + pacienteModel.pessoa.Nome + " foi atualizado com sucesso!");
        //                    return RedirectToAction("ConsultarPaciente", "Paciente");
        //                }
        //                else
        //                {
        //                    ViewBag.MensagemTitle = "Erro";
        //                    ViewBag.MensagemBody = "Ocorreu um erro na tentiva de editar o paciente: " + pacienteModel.pessoa.Nome;
        //                    return View();
        //                }
        //            }
        //            else
        //            {
        //                HttpContext.Session.SetString("MensagemTitle", "Erro");
        //                HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem permissão para alterar pacientes!");
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //        else
        //        {
        //            HttpContext.Session.SetString("MensagemTitle", "Erro");
        //            HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Paciente/EditarPaciente'");
        //            return RedirectToAction("Index", "Home");
        //        }
        //    } catch (Exception) {
        //        HttpContext.Session.SetString("MensagemTitle", "Erro");
        //        HttpContext.Session.SetString("MensagemBody", "Ocorreu um erro na tentativa de consultar as consultas marcadas do cliente!");
        //        return RedirectToAction("Index", "Home");
        //    }
        //}

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
        }
    }    
}
