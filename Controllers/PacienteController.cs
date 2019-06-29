﻿using SGCM.Models.Paciente.CadastroPacienteModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SGCM.AppData.Paciente;
using System;
using SGCM.Models.Paciente.ConsultarPacienteModel;
using System.Collections.Generic;
using SGCM.Models.Paciente.EditarPacienteModel;
using SGCM.AppData.Consulta;
using X.PagedList;
using SGCM.Models.Paciente.RelatorioPacienteModel;

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
                CarregarDadosUsuarioParaTela();
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
        public ActionResult ConsultarPaciente(ConsultarPacienteModel model, string pagina) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if (ViewData["flPacienteC"] != null && (int)ViewData["flPacienteC"] != 0) {
                        var objPacienteBLL = new PacienteBLL();
                        var viewModel = new ConsultarPacienteModel();
                        var sort = 0;

                        if (HttpContext.Session.GetString("flagNome") == null) {
                            HttpContext.Session.SetString("flagNome", "default");
                        }

                        if (HttpContext.Session.GetString("flagCPF") == null) {
                            HttpContext.Session.SetString("flagCPF", "default");
                        }

                        if (HttpContext.Session.GetString("flagTelefoneCelular") == null) {
                            HttpContext.Session.SetString("flagTelefoneCelular", "default");
                        }

                        if (!String.IsNullOrEmpty(model.sortOrder)) {
                            switch (model.sortOrder) {
                                case "nome": {
                                    if (HttpContext.Session.GetString("flagNome") == "default") {
                                        HttpContext.Session.SetString("flagNome", "ASC");
                                        sort = 1;
                                    } else if (HttpContext.Session.GetString("flagNome") == "ASC") {
                                        HttpContext.Session.SetString("flagNome", "DESC");
                                        sort = 2;
                                    } else if (HttpContext.Session.GetString("flagNome") == "DESC") {
                                        HttpContext.Session.SetString("flagNome", "ASC");
                                        sort = 1;
                                    }
                                    break;
                                }
                                case "cpf": {
                                    if (HttpContext.Session.GetString("flagCPF") == "default") {
                                        HttpContext.Session.SetString("flagCPF", "ASC");
                                        sort = 3;
                                    } else if (HttpContext.Session.GetString("flagCPF") == "ASC") {
                                        HttpContext.Session.SetString("flagCPF", "DESC");
                                        sort = 4;
                                    } else if (HttpContext.Session.GetString("flagCPF") == "DESC") {
                                        HttpContext.Session.SetString("flagCPF", "ASC");
                                        sort = 3;
                                    }
                                    break;
                                }
                                case "telefoneCelular": {
                                    if (HttpContext.Session.GetString("flagTelefoneCelular") == "default") {
                                        HttpContext.Session.SetString("flagTelefoneCelular", "ASC");
                                        sort = 5;
                                    } else if (HttpContext.Session.GetString("flagTelefoneCelular") == "ASC") {
                                        HttpContext.Session.SetString("flagTelefoneCelular", "DESC");
                                        sort = 6;
                                    } else if (HttpContext.Session.GetString("flagTelefoneCelular") == "DESC") {
                                        HttpContext.Session.SetString("flagTelefoneCelular", "ASC");
                                        sort = 5;
                                    }
                                    break;
                                }
                                default: {
                                    sort = 0;
                                    break;
                                }
                            }
                        }

                        var retornoListaPaciente = objPacienteBLL.ConsultarPaciente((int)ViewData["idMedico"], sort, model.psqNome, model.psqCPF, model.psqTelefoneCelular);


                        if (retornoListaPaciente != null) {
                            if (HttpContext.Session.GetString("MensagemTitle") != null && HttpContext.Session.GetString("MensagemBody") != null && HttpContext.Session.GetString("MensagemTitle") != "" && HttpContext.Session.GetString("MensagemBody") != "") {
                                ViewBag.MensagemTitle = HttpContext.Session.GetString("MensagemTitle");
                                ViewBag.MensagemBody = HttpContext.Session.GetString("MensagemBody");
                                HttpContext.Session.SetString("MensagemTitle", "");
                                HttpContext.Session.SetString("MensagemBody", "");
                            }

                            int pageNumber = 0;
                            if (pagina != null) {
                                pageNumber = Convert.ToInt32(pagina);
                            } else {
                                pageNumber = 1;
                            }

                            viewModel.ListaConsultarPacienteModel = retornoListaPaciente.ToPagedList(pageNumber, 10);

                            return View(viewModel);
                        } else {
                            string mensagem = "";
                            mensagem = "Nenhum paciente foi cadastrado pelo Usuário: " + ViewData["nome"];

                            if (model.psqNome != null) mensagem = mensagem + " com o parâmetro 'Nome': " + model.psqNome;
                            if (model.psqCPF != null) mensagem = mensagem + " com o parâmetro 'CPF': " + model.psqCPF;
                            if (model.psqTelefoneCelular != null) mensagem = mensagem + " com o parâmetro 'Telefone Celualr': " + model.psqTelefoneCelular;

                            ViewBag.MensagemTitle = "Informação";
                            ViewBag.MensagemBody = mensagem;

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
            } catch (Exception ex) {
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
                        if (HttpContext.Session.GetString("MensagemTitle") != null && HttpContext.Session.GetString("MensagemBody") != null && HttpContext.Session.GetString("MensagemTitle") != "" && HttpContext.Session.GetString("MensagemBody") != "")
                        {
                            ViewBag.MensagemTitle = HttpContext.Session.GetString("MensagemTitle");
                            ViewBag.MensagemBody = HttpContext.Session.GetString("MensagemBody");
                            HttpContext.Session.SetString("MensagemTitle", "");
                            HttpContext.Session.SetString("MensagemBody", "");
                        }
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

                        if (retorno > 0) {
                            HttpContext.Session.SetString("MensagemTitle", "Sucesso");
                            HttpContext.Session.SetString("MensagemBody", "O paciente " + pacienteModel.Pessoa.Nome + " foi atualizado com sucesso!");
                            return RedirectToAction("ConsultarPaciente", "Paciente");
                        } else {
                            ViewBag.MensagemTitle = "Erro";
                            ViewBag.MensagemBody = "Ocorreu um erro na tentiva de editar o paciente: " + pacienteModel.Pessoa.Nome;
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

        [HttpGet]
        public ActionResult RealizarConsulta(int id) {
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
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: PacienteController";
                ViewBag.MensagemBodyAction = "Action: EditarPaciente/ID - GET";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        [HttpGet]
        public ActionResult RelatorioPaciente() {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flPacienteC"] != 0) {
                        RelatorioPacienteModel viewModel = new RelatorioPacienteModel();
                        return View(viewModel);
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Informação");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Paciente/RelatórioPaciente'");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    HttpContext.Session.SetString("MensagemTitle", "Informação");
                    HttpContext.Session.SetString("MensagemBody", "Você não está logado no sistema! Realize o Login antes de acessar essa página!");
                    return RedirectToAction("Index", "Home");
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: PacienteController";
                ViewBag.MensagemBodyAction = "Action: RelatórioPaciente - GET";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult RelatorioPaciente(RelatorioPacienteModel pacienteModel) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flPacienteC"] != 0) {
                        var objPacienteBLL = new PacienteBLL();
                        var retorno = objPacienteBLL.RelatorioPaciente(pacienteModel, (int)ViewData["idMedico"]);

                        if (retorno != null) {
                            return View(retorno);
                        } else {
                            ViewBag.MensagemTitle = "Erro";
                            ViewBag.MensagemBody = "Ocorreu um erro na consultar o(s) paciente(s) com os parâmetros solicitados!";
                            return View();
                        }
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem permissão para consultar pacientes!");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    HttpContext.Session.SetString("MensagemTitle", "Erro");
                    HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Paciente/RelatorioPaciente'");
                    return RedirectToAction("Index", "Home");
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: PacienteController";
                ViewBag.MensagemBodyAction = "Action: RelatorioPaciente/{PACIENTE} - POST";
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

            ViewData.Add("flReceitaI", HttpContext.Session.GetInt32("flReceitaI"));
            ViewData.Add("flReceitaC", HttpContext.Session.GetInt32("flReceitaC"));
            ViewData.Add("flReceitaA", HttpContext.Session.GetInt32("flReceitaA"));
            ViewData.Add("flReceitaE", HttpContext.Session.GetInt32("flReceitaE"));

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