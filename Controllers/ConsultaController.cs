using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGCM.AppData.Consulta;
using SGCM.Models.Consulta.CadastroConsultaModel;
using SGCM.Models.Consulta.ConsultarConsultaModel;
using SGCM.Models.Consulta.ConsultaPacienteModel;
using SGCM.Models.Consulta.EditarConsultaModel;

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
                        viewModel.paciente = new Models.Consulta.CadastroConsultaModel.DadosPaciente();
                        viewModel.pacienteList = new List<Models.Consulta.CadastroConsultaModel.DadosPaciente>();
                        viewModel.consulta = new Models.Consulta.CadastroConsultaModel.DadosConsulta();

                        viewModel.consulta.DataConsulta = DateTime.Now;

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

        //POST: /Consulta/CadastrarConsulta
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                            List<ConsultaPacienteModel> retornoPaciente = objConsultaBLL.ConsultarPaciente(model.paciente.Nome, model.paciente.CPF, null);
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
                            ViewBag.MensagemBody = "A hora da consulta marcada está incorreto, insira uma hora com as seguintes minutagem 'XX:00, XX:30'!";
                            return View();
                        } else if (retorno == 8) {
                            ViewBag.MensagemTitle = "Erro ao Cadastrar a Consulta";
                            ViewBag.MensagemBody = "Não foi possivel cadastrar uma consulta nessa data, pois o médico estará ausente!";
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

        //POST: /Consulta/ConsultarPaciente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConsultarPaciente(string nome, string cpf) {
            try{
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flPacienteC"] != 0) {
                        var objConsultaBLL = new ConsultaBLL();
                        var retorno = objConsultaBLL.ConsultarPaciente(nome, cpf, null);

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
        
        //GET: /Consulta/ConsultarConsulta
        [HttpGet]
        public ActionResult ConsultarConsulta(string data, int id) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flConsultaC"] != 0) {
                        ConsultarConsultasModel model = new ConsultarConsultasModel();
                        model = InicializarModel(model);

                        ConsultaBLL objConsultaBLL = new ConsultaBLL();

                        var retornomodel = objConsultaBLL.ConsultarConsultas(model, data, id);

                        if (retornomodel == null) {
                            ViewBag.MensagemTitle = "Informação";
                            ViewBag.MensagemBody = "Não existe nenhuma consulta cadastrada!";
                            return View(model);
                        } else {
                            if (HttpContext.Session.GetString("MensagemTitle") != null && HttpContext.Session.GetString("MensagemBody") != null && HttpContext.Session.GetString("MensagemTitle") != "" && HttpContext.Session.GetString("MensagemBody") != "") {
                                ViewBag.MensagemTitle = HttpContext.Session.GetString("MensagemTitle");
                                ViewBag.MensagemBody = HttpContext.Session.GetString("MensagemBody");
                                HttpContext.Session.SetString("MensagemTitle", "");
                                HttpContext.Session.SetString("MensagemBody", "");
                            }
                            model = retornomodel;
                            return View(model);
                        }
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
                ViewBag.MensagemBodyAction = "Action: CadasrarConsulta";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        private ConsultarConsultasModel InicializarModel(ConsultarConsultasModel model) {
            model.quadroSegundaSeis = new QuadroSegundaSeis();
            model.quadroSegundaSeisMeia = new QuadroSegundaSeisMeia();
            model.quadroSegundaSete = new QuadroSegundaSete();
            model.quadroSegundaSeteMeia = new QuadroSegundaSeteMeia();
            model.quadroSegundaOito = new QuadroSegundaOito();
            model.quadroSegundaOitoMeia = new QuadroSegundaOitoMeia();
            model.quadroSegundaNove = new QuadroSegundaNove();
            model.quadroSegundaNoveMeia = new QuadroSegundaNoveMeia();
            model.quadroSegundaDez = new QuadroSegundaDez();
            model.quadroSegundaDezMeia = new QuadroSegundaDezMeia();
            model.quadroSegundaOnze = new QuadroSegundaOnze();
            model.quadroSegundaOnzeMeia = new QuadroSegundaOnzeMeia();
            model.quadroSegundaDoze = new QuadroSegundaDoze();
            model.quadroSegundaDozeMeia = new QuadroSegundaDozeMeia();
            model.quadroSegundaTreze = new QuadroSegundaTreze();
            model.quadroSegundaTrezeMeia = new QuadroSegundaTrezeMeia();
            model.quadroSegundaQuatorze = new QuadroSegundaQuatorze();
            model.quadroSegundaQuatorzeMeia = new QuadroSegundaQuatorzeMeia();
            model.quadroSegundaQuinze = new QuadroSegundaQuinze();
            model.quadroSegundaQuinzeMeia = new QuadroSegundaQuinzeMeia();
            model.quadroSegundaDezesseis = new QuadroSegundaDezesseis();
            model.quadroSegundaDezesseisMeia = new QuadroSegundaDezesseisMeia();
            model.quadroSegundaDezessete = new QuadroSegundaDezessete();
            model.quadroSegundaDezesseteMeia = new QuadroSegundaDezesseteMeia();
            model.quadroSegundaDezoito = new QuadroSegundaDezoito();
            model.quadroSegundaDezoitoMeia = new QuadroSegundaDezoitoMeia();

            model.quadroTercaSeis = new QuadroTercaSeis();
            model.quadroTercaSeisMeia = new QuadroTercaSeisMeia();
            model.quadroTercaSete = new QuadroTercaSete();
            model.quadroTercaSeteMeia = new QuadroTercaSeteMeia();
            model.quadroTercaOito = new QuadroTercaOito();
            model.quadroTercaOitoMeia = new QuadroTercaOitoMeia();
            model.quadroTercaNove = new QuadroTercaNove();
            model.quadroTercaNoveMeia = new QuadroTercaNoveMeia();
            model.quadroTercaDez = new QuadroTercaDez();
            model.quadroTercaDezMeia = new QuadroTercaDezMeia();
            model.quadroTercaOnze = new QuadroTercaOnze();
            model.quadroTercaOnzeMeia = new QuadroTercaOnzeMeia();
            model.quadroTercaDoze = new QuadroTercaDoze();
            model.quadroTercaDozeMeia = new QuadroTercaDozeMeia();
            model.quadroTercaTreze = new QuadroTercaTreze();
            model.quadroTercaTrezeMeia = new QuadroTercaTrezeMeia();
            model.quadroTercaQuatorze = new QuadroTercaQuatorze();
            model.quadroTercaQuatorzeMeia = new QuadroTercaQuatorzeMeia();
            model.quadroTercaQuinze = new QuadroTercaQuinze();
            model.quadroTercaQuinzeMeia = new QuadroTercaQuinzeMeia();
            model.quadroTercaDezesseis = new QuadroTercaDezesseis();
            model.quadroTercaDezesseisMeia = new QuadroTercaDezesseisMeia();
            model.quadroTercaDezessete = new QuadroTercaDezessete();
            model.quadroTercaDezesseteMeia = new QuadroTercaDezesseteMeia();
            model.quadroTercaDezoito = new QuadroTercaDezoito();
            model.quadroTercaDezoitoMeia = new QuadroTercaDezoitoMeia();

            model.quadroQuartaSeis = new QuadroQuartaSeis();
            model.quadroQuartaSeisMeia = new QuadroQuartaSeisMeia();
            model.quadroQuartaSete = new QuadroQuartaSete();
            model.quadroQuartaSeteMeia = new QuadroQuartaSeteMeia();
            model.quadroQuartaOito = new QuadroQuartaOito();
            model.quadroQuartaOitoMeia = new QuadroQuartaOitoMeia();
            model.quadroQuartaNove = new QuadroQuartaNove();
            model.quadroQuartaNoveMeia = new QuadroQuartaNoveMeia();
            model.quadroQuartaDez = new QuadroQuartaDez();
            model.quadroQuartaDezMeia = new QuadroQuartaDezMeia();
            model.quadroQuartaOnze = new QuadroQuartaOnze();
            model.quadroQuartaOnzeMeia = new QuadroQuartaOnzeMeia();
            model.quadroQuartaDoze = new QuadroQuartaDoze();
            model.quadroQuartaDozeMeia = new QuadroQuartaDozeMeia();
            model.quadroQuartaTreze = new QuadroQuartaTreze();
            model.quadroQuartaTrezeMeia = new QuadroQuartaTrezeMeia();
            model.quadroQuartaQuatorze = new QuadroQuartaQuatorze();
            model.quadroQuartaQuatorzeMeia = new QuadroQuartaQuatorzeMeia();
            model.quadroQuartaQuinze = new QuadroQuartaQuinze();
            model.quadroQuartaQuinzeMeia = new QuadroQuartaQuinzeMeia();
            model.quadroQuartaDezesseis = new QuadroQuartaDezesseis();
            model.quadroQuartaDezesseisMeia = new QuadroQuartaDezesseisMeia();
            model.quadroQuartaDezessete = new QuadroQuartaDezessete();
            model.quadroQuartaDezesseteMeia = new QuadroQuartaDezesseteMeia();
            model.quadroQuartaDezoito = new QuadroQuartaDezoito();
            model.quadroQuartaDezoitoMeia = new QuadroQuartaDezoitoMeia();

            model.quadroQuintaSeis = new QuadroQuintaSeis();
            model.quadroQuintaSeisMeia = new QuadroQuintaSeisMeia();
            model.quadroQuintaSete = new QuadroQuintaSete();
            model.quadroQuintaSeteMeia = new QuadroQuintaSeteMeia();
            model.quadroQuintaOito = new QuadroQuintaOito();
            model.quadroQuintaOitoMeia = new QuadroQuintaOitoMeia();
            model.quadroQuintaNove = new QuadroQuintaNove();
            model.quadroQuintaNoveMeia = new QuadroQuintaNoveMeia();
            model.quadroQuintaDez = new QuadroQuintaDez();
            model.quadroQuintaDezMeia = new QuadroQuintaDezMeia();
            model.quadroQuintaOnze = new QuadroQuintaOnze();
            model.quadroQuintaOnzeMeia = new QuadroQuintaOnzeMeia();
            model.quadroQuintaDoze = new QuadroQuintaDoze();
            model.quadroQuintaDozeMeia = new QuadroQuintaDozeMeia();
            model.quadroQuintaTreze = new QuadroQuintaTreze();
            model.quadroQuintaTrezeMeia = new QuadroQuintaTrezeMeia();
            model.quadroQuintaQuatorze = new QuadroQuintaQuatorze();
            model.quadroQuintaQuatorzeMeia = new QuadroQuintaQuatorzeMeia();
            model.quadroQuintaQuinze = new QuadroQuintaQuinze();
            model.quadroQuintaQuinzeMeia = new QuadroQuintaQuinzeMeia();
            model.quadroQuintaDezesseis = new QuadroQuintaDezesseis();
            model.quadroQuintaDezesseisMeia = new QuadroQuintaDezesseisMeia();
            model.quadroQuintaDezessete = new QuadroQuintaDezessete();
            model.quadroQuintaDezesseteMeia = new QuadroQuintaDezesseteMeia();
            model.quadroQuintaDezoito = new QuadroQuintaDezoito();
            model.quadroQuintaDezoitoMeia = new QuadroQuintaDezoitoMeia();

            model.quadroSextaSeis = new QuadroSextaSeis();
            model.quadroSextaSeisMeia = new QuadroSextaSeisMeia();
            model.quadroSextaSete = new QuadroSextaSete();
            model.quadroSextaSeteMeia = new QuadroSextaSeteMeia();
            model.quadroSextaOito = new QuadroSextaOito();
            model.quadroSextaOitoMeia = new QuadroSextaOitoMeia();
            model.quadroSextaNove = new QuadroSextaNove();
            model.quadroSextaNoveMeia = new QuadroSextaNoveMeia();
            model.quadroSextaDez = new QuadroSextaDez();
            model.quadroSextaDezMeia = new QuadroSextaDezMeia();
            model.quadroSextaOnze = new QuadroSextaOnze();
            model.quadroSextaOnzeMeia = new QuadroSextaOnzeMeia();
            model.quadroSextaDoze = new QuadroSextaDoze();
            model.quadroSextaDozeMeia = new QuadroSextaDozeMeia();
            model.quadroSextaTreze = new QuadroSextaTreze();
            model.quadroSextaTrezeMeia = new QuadroSextaTrezeMeia();
            model.quadroSextaQuatorze = new QuadroSextaQuatorze();
            model.quadroSextaQuatorzeMeia = new QuadroSextaQuatorzeMeia();
            model.quadroSextaQuinze = new QuadroSextaQuinze();
            model.quadroSextaQuinzeMeia = new QuadroSextaQuinzeMeia();
            model.quadroSextaDezesseis = new QuadroSextaDezesseis();
            model.quadroSextaDezesseisMeia = new QuadroSextaDezesseisMeia();
            model.quadroSextaDezessete = new QuadroSextaDezessete();
            model.quadroSextaDezesseteMeia = new QuadroSextaDezesseteMeia();
            model.quadroSextaDezoito = new QuadroSextaDezoito();
            model.quadroSextaDezoitoMeia = new QuadroSextaDezoitoMeia();

            model.dataSegundaAusenciaBancoModel = new Models.Consulta.ConsultarConsultaModel.MarcarDataAusenciaBancoModel();
            model.dataTercaAusenciaBancoModel = new Models.Consulta.ConsultarConsultaModel.MarcarDataAusenciaBancoModel();
            model.dataQuartaAusenciaBancoModel = new Models.Consulta.ConsultarConsultaModel.MarcarDataAusenciaBancoModel();
            model.dataQuintaAusenciaBancoModel = new Models.Consulta.ConsultarConsultaModel.MarcarDataAusenciaBancoModel();
            model.dataSextaAusenciaBancoModel = new Models.Consulta.ConsultarConsultaModel.MarcarDataAusenciaBancoModel();

            return model;
        }

        //GET: /Consulta/EditarConsulta/{ID}
        [HttpGet]
        public ActionResult EditarConsulta(int id) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flConsultaA"] != 0) {
                        var objConsultaBLL = new ConsultaBLL();

                        //var retornoPaciente = objConsultaBLL.ConsultarPaciente(null, null, Convert.ToInt32(idPaciente));

                        //if (retornoPaciente.Count == 0) {
                        //    ViewBag.MensagemTitle = "Erro";
                        //    ViewBag.MensagemBody = "Paciente da consulta não cadastrado!";
                        //    return View();
                        //} else if (retornoPaciente.Count > 1) {
                        //    ViewBag.MensagemTitle = "Erro";
                        //    ViewBag.MensagemBody = "Existe mais de uma paciente com esses dados, verifique o paciente indicado!";
                        //    return View();
                        //}

                        ConsultarConsulta consulta = new ConsultarConsulta() {idConsulta = Convert.ToInt32(id) };

                        EditarConsultaModel retornoConsulta = objConsultaBLL.ConsultarConsulta(consulta);

                        if (retornoConsulta.consulta.idConsulta == 0) {
                            ViewBag.MensagemTitle = "Erro";
                            ViewBag.MensagemBody = "A consulta que você está tentando editar, não existe!";
                            return View();
                        } else {
                            EditarConsultaModel model = new EditarConsultaModel();
                            model.consulta = new Models.Consulta.EditarConsultaModel.DadosConsulta();
                            model.paciente = new Models.Consulta.EditarConsultaModel.DadosPaciente();

                            model.consulta.DataConsulta = retornoConsulta.consulta.DataConsulta;
                            model.consulta.idConsulta = retornoConsulta.consulta.idConsulta;
                            model.paciente.CPF = retornoConsulta.paciente.CPF;
                            model.paciente.idPaciente = retornoConsulta.paciente.idPaciente;
                            model.paciente.Nome = retornoConsulta.paciente.Nome;

                            return View(model);
                        }
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro ao Cadastrar a Consulta");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem permissão para cadastrar uma consulta!");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    //ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    ViewData.Add("ReturnUrl", "Home/Index");
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarConsulta(EditarConsultaModel model) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flConsultaA"] != 0) {
                        var objConsultaBLL = new ConsultaBLL();
                        var retornoEditarConsulta = objConsultaBLL.EditarConsulta(model);

                        if (retornoEditarConsulta == 1) {
                            ViewBag.MensagemTitle = "Erro ao Cadastrar a Consulta";
                            ViewBag.MensagemBody = "Não é possivel salvar uma consulta com a data inferior que a data atual!";
                            return View();
                        } else if (retornoEditarConsulta == 2) {
                            ViewBag.MensagemTitle = "Erro ao Cadastrar a Consulta";
                            ViewBag.MensagemBody = "Não é possivel salvar uma consulta com a hora inferior que a hora atual!";
                            return View();
                        } else if (retornoEditarConsulta == 3) {
                            ViewBag.MensagemTitle = "Erro ao Cadastrar a Consulta";
                            ViewBag.MensagemBody = "Ocorreu um erro quando o sistema estava tentando alterar uma consulta!";
                            return View();
                        } else {
                            ViewBag.MensagemTitle = "Sucesso no Cadastro da Consulta";
                            ViewBag.MensagemBody = "Consulta do paciente " + model.paciente.Nome + " cadastrada com sucesso!";
                            return RedirectToAction("ConsultarConsulta", "Consulta");
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
                ViewBag.MensagemBodyAction = "Action: CadastrarConsulta";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        [HttpGet]
        public ActionResult FinalizarConsulta(int id) {
            try {
                //if (TempData("FinalizarConsulta") != null) TempData.Add("FinalizarConsulta", "Finalizar");
                return RedirectToAction("EditarPaciente", "Paciente", new { id = id });
            }
            catch (Exception ex) {
                HttpContext.Session.SetString("MensagemTitle", "Erro");
                HttpContext.Session.SetString("MensagemBody", "Erro ao tentar finalizar a consulta: " + ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult ConsultarRelatorio() {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flConsultaC"] != 0) {
                        var viewModel = new CadastroConsultaModel();
                        viewModel.paciente = new Models.Consulta.CadastroConsultaModel.DadosPaciente();
                        viewModel.pacienteList = new List<Models.Consulta.CadastroConsultaModel.DadosPaciente>();
                        viewModel.consulta = new Models.Consulta.CadastroConsultaModel.DadosConsulta();

                        viewModel.consulta.DataConsulta = DateTime.Now;

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
