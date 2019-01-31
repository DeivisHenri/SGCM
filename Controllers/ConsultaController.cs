using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGCM.AppData.Consulta;
using SGCM.Models.Consulta.CadastroConsultaModel;
using SGCM.Models.Consulta.ConsultarConsultaModel;
using SGCM.Models.Consulta.ConsultaPacienteModel;

namespace SGCM.Controllers {

    public class ConsultaController : Controller {

        //GET: /Consulta/CadastrarConsulta
        [HttpGet]
        public ActionResult CadastrarConsulta() {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flConsultaI"] != 0) {
                        var viewModel = new CadastroConsultaModel();
                        viewModel.paciente = new DadosPaciente();
                        viewModel.pacienteList = new List<DadosPaciente>();
                        viewModel.consulta = new DadosConsulta();
                        return View(viewModel);
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Consulta/CadastrarConsulta'");
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
        public ActionResult CadastrarConsulta(CadastroConsultaModel model) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flConsultaI"] != 0) {
                        var objConsultaBLL = new ConsultaBLL();
                        model.consulta.flagPM = false;

                        if ( model.paciente.idPaciente == 0) {
                            List<ConsultaPacienteModel> retornoPaciente = objConsultaBLL.ConsultarPaciente(model.paciente.Nome, model.paciente.CPF);
                            if (retornoPaciente != null) model.paciente.idPaciente = retornoPaciente[0].idPaciente;
                            else {
                                ViewBag.MensagemTitle = "Erro ao Cadastrar a Consulta";
                                ViewBag.MensagemBody = "O paciente " + model.paciente.Nome + " não existe!";
                                return View();
                            }
                        }                        

                        var retorno = objConsultaBLL.CadastrarConsulta(model);

                        if (retorno == 1) {
                            ViewBag.MensagemTitle = "Sucesso no Cadastro da Consulta";
                            ViewBag.MensagemBody = "Consulta do paciente " + model.paciente.Nome + " cadastrada com sucesso!";
                            ModelState.Clear();
                            return View();
                        } else if (retorno == 2) {
                            ViewBag.MensagemTitle = "Erro ao Cadastrar a Consulta";
                            ViewBag.MensagemBody = "Não é possivel cadastrar uma consulta com a data inferior que a data atual!!";
                            return View();
                        } else if (retorno == 3) {
                            ViewBag.MensagemTitle = "Erro ao Cadastrar a Consulta";
                            ViewBag.MensagemBody = "Não é possivel cadastrar uma consulta com a hora inferior que a hora atual!!";
                            return View();
                        } else if (retorno == 4) {
                            ViewBag.MensagemTitle = "Erro ao Cadastrar a Consulta";
                            ViewBag.MensagemBody = "Já existe uma consulta marcada nessa Data/Hora!";
                            return View();
                        } else if (retorno == 5) {
                            ViewBag.MensagemTitle = "Erro ao Cadastrar a Consulta";
                            ViewBag.MensagemBody = "Não pode cadastrar uma consulta no 'Sábado'!";
                            return View();
                        } else if (retorno == 6 ) {
                            ViewBag.MensagemTitle = "Erro ao Cadastrar a Consulta";
                            ViewBag.MensagemBody = "Não pode cadastrar uma consulta no 'Domingo'!";
                            return View();
                        } else if (retorno == 7) {
                            ViewBag.MensagemTitle = "Erro ao Cadastrar a Consulta";
                            ViewBag.MensagemBody = "A hora da consulta marcada está incorreto, insira uma hora com as seguintes minutagem 'XX:00, XX:15, XX:30, XX:45'!";
                            return View();
                        } else {
                            ViewBag.MensagemTitle = "Erro ao Cadastrar a Consulta";
                            ViewBag.MensagemBody = "Cadastro da consulta do paciente " + model.paciente.Nome + " não realizado!";
                            return View();
                        }
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro ao Cadastrar a Consulta");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem permissão para cadastrar uma consulta!");
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
        public ActionResult ConsultarPaciente(string nome, string cpf) {
            try{
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flPacienteC"] != 0) {
                        var objConsultaBLL = new ConsultaBLL();
                        var retorno = objConsultaBLL.ConsultarPaciente(nome, cpf);

                        return Json(retorno);
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
                ViewBag.MensagemBodyAction = "Action: CadastrarConsulta";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        [HttpGet]
        public ActionResult ConsultarConsulta() {
            try {
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flConsultaC"] != 0) {
                        ConsultarConsultaModel model = new ConsultarConsultaModel();

                        return View(model);
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Consulta/CadastrarConsulta'");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                HttpContext.Session.SetInt32("idPacienteConsulta", -3);
                HttpContext.Session.SetString("exception", ex.Message);
                return RedirectToAction("CadastrarConsulta", "Consulta");
            }
        }

        //public ActionResult ConsultarCpf(string cpf) {
        //    try {
        //        ViewBag.MensagemBody = "";
        //        CarregarDadosUsuarioParaTela();
        //        if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
        //            if ((int)ViewData["flPacienteC"] != 0) {
        //                var objConsultaBLL = new ConsultaBLL();
        //                var retorno = objConsultaBLL.ConsultarPacienteCPF(cpf);

        //                if (retorno != null) {
        //                    return PartialView("/Views/Consulta/Partials/Cadastro/_DadosConsulta.cshtml", retorno);
        //                    //HttpContext.Session.SetInt32("idPacienteConsulta", retorno.paciente.idPaciente);
        //                    //HttpContext.Session.SetString("nomePacienteConsulta", retorno.paciente.Nome);
        //                    //HttpContext.Session.SetString("cpfPacienteConsulta", retorno.paciente.CPF);
        //                    //return RedirectToAction("CadastrarConsulta", "Consulta");
        //                } else {
        //                    return PartialView("/Views/Consulta/Partials/Cadastro/_DadosConsulta.cshtml", null);
        //                    //HttpContext.Session.SetInt32("idPacienteConsulta", -2);
        //                    //return RedirectToAction("CadastrarConsulta", "Consulta");
        //                }
        //            } else {
        //                HttpContext.Session.SetString("MensagemTitle", "Erro");
        //                HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Consulta/CadastrarConsulta'");
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //        else
        //        {
        //            ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
        //            return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
        //        }
        //    } catch (Exception ex) {
        //        HttpContext.Session.SetInt32("idPacienteConsulta", -3);
        //        HttpContext.Session.SetString("exception", ex.Message);
        //        return RedirectToAction("CadastrarConsulta", "Consulta");
        //    }
        //}



        private void CarregarDadosUsuarioParaTela()
        {
            ViewData.Add("idUsuario", HttpContext.Session.GetInt32("idUsuario"));
            ViewData.Add("usuario", HttpContext.Session.GetString("usuario"));
            ViewData.Add("tipoUsuario", HttpContext.Session.GetString("tipoUsuario"));

            ViewData.Add("idPessoa", HttpContext.Session.GetInt32("idPessoa"));
            ViewData.Add("idMedico", HttpContext.Session.GetInt32("idMedico"));
            ViewData.Add("nome", HttpContext.Session.GetString("nome"));
            ViewData.Add("cpf", HttpContext.Session.GetString("cpf"));
            ViewData.Add("rg", HttpContext.Session.GetString("rg"));
            ViewData.Add("sexo", HttpContext.Session.GetString("sexo"));
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

            ViewData.Add("flMedicamentoI", HttpContext.Session.GetInt32("flMedicamentoI"));
            ViewData.Add("flMedicamentoC", HttpContext.Session.GetInt32("flMedicamentoC"));
            ViewData.Add("flMedicamentoA", HttpContext.Session.GetInt32("flMedicamentoA"));
            ViewData.Add("flMedicamentoE", HttpContext.Session.GetInt32("flMedicamentoE"));

            ViewData.Add("flExamesI", HttpContext.Session.GetInt32("flExamesI"));
            ViewData.Add("flExamesC", HttpContext.Session.GetInt32("flExamesC"));
            ViewData.Add("flExamesA", HttpContext.Session.GetInt32("flExamesA"));
            ViewData.Add("flExamesE", HttpContext.Session.GetInt32("flExamesE"));
        }
    }
}
