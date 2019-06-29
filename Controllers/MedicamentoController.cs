using System;
using X.PagedList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGCM.AppData.Medicamento;
using SGCM.Models.Medicamento;

namespace SGCM.Controllers
{
    public class MedicamentoController : Controller {
        [HttpGet]
        public ActionResult CadastrarMedicamento() {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flMedicamentoI"] != 0) {
                        var viewModel = new CadastrarMedicamentoModel();
                        return View(viewModel);
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Medicamento/CadastrarMedicamento', pois não tem permissão para inserir medicamento!");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: MedicamentoController";
                ViewBag.MensagemBodyAction = "Action: CadastrarMedicamento";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarMedicamento(CadastrarMedicamentoModel model) {
            try {
                if (!ModelState.IsValid) {
                    return View(model);
                }

                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flMedicamentoI"] != 0) {
                        MedicamentoBLL objMedicamentoBLL = new MedicamentoBLL();
                        var retornoCadastrarMedicamento = objMedicamentoBLL.CadastrarMedicamento(model);

                        if (retornoCadastrarMedicamento == 1) {
                            ViewBag.MensagemTitle = "Sucesso";
                            ViewBag.MensagemBody = "Medicamento cadastrado com sucesso!";
                            ModelState.Clear();
                            return View();
                        } else {
                            ViewBag.MensagemTitle = "Erro";
                            ViewBag.MensagemBody = "Ocorreu um erro no cadastro do medicamento '" + model.nomeGenerico + "', favor entrar em contato com o suporte do sistema!";
                            ModelState.Clear();
                            return View();
                        }
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem permissão para cadastrar 'Medicamento'!");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: MedicamentoController";
                ViewBag.MensagemBodyAction = "Action: CadastrarMedicamento";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        [HttpGet]
        public ActionResult ConsultarMedicamento(ConsultarMedicamentoModel model, string pagina) {
            try {
                model.PageCount = 0;
                model.PageNumber = 0;
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                ViewBag.nomeGenerico = "nomeGenerico";
                ViewBag.nomeFabrica = "nomeFabrica";
                ViewBag.fabricante = "fabricante";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flMedicamentoC"] != 0) {
                        MedicamentoBLL objMedicamentoBLL = new MedicamentoBLL();
                        //var viewModel = new ConsultarMedicamentoModel();
                        var sort = 0;

                        if (HttpContext.Session.GetString("flagNomeGenerico") == null) {
                            HttpContext.Session.SetString("flagNomeGenerico", "default");
                        }

                        if (HttpContext.Session.GetString("flagNomeFabrica") == null) {
                            HttpContext.Session.SetString("flagNomeFabrica", "default");
                        }

                        if (HttpContext.Session.GetString("flagFabricante") == null) {
                            HttpContext.Session.SetString("flagFabricante", "default");
                        }

                        if (!String.IsNullOrEmpty(model.sortOrder)) {
                            switch (model.sortOrder) {
                                case "nomeGenerico": {
                                    if (HttpContext.Session.GetString("flagNomeGenerico") == "default") {
                                        HttpContext.Session.SetString("flagNomeGenerico", "ASC");
                                        sort = 1;
                                    } else if (HttpContext.Session.GetString("flagNomeGenerico") == "ASC") {
                                        HttpContext.Session.SetString("flagNomeGenerico", "DESC");
                                        sort = 2;
                                    } else if (HttpContext.Session.GetString("flagNomeGenerico") == "DESC") {
                                        HttpContext.Session.SetString("flagNomeGenerico", "ASC");
                                        sort = 1;
                                    }
                                    break;
                                }
                                case "nomeFabrica": {
                                    if (HttpContext.Session.GetString("flagNomeFabrica") == "default") {
                                        HttpContext.Session.SetString("flagNomeFabrica", "ASC");
                                        sort = 3;
                                    } else if (HttpContext.Session.GetString("flagNomeFabrica") == "ASC") {
                                        HttpContext.Session.SetString("flagNomeFabrica", "DESC");
                                        sort = 4;
                                    } else if (HttpContext.Session.GetString("flagNomeFabrica") == "DESC") {
                                        HttpContext.Session.SetString("flagNomeFabrica", "ASC");
                                        sort = 3;
                                    }
                                    break;
                                }
                                case "fabricante": {
                                    if (HttpContext.Session.GetString("flagFabricante") == "default") {
                                        HttpContext.Session.SetString("flagFabricante", "ASC");
                                        sort = 5;
                                    } else if (HttpContext.Session.GetString("flagFabricante") == "ASC") {
                                        HttpContext.Session.SetString("flagFabricante", "DESC");
                                        sort = 6;
                                    } else if (HttpContext.Session.GetString("flagFabricante") == "DESC") {
                                        HttpContext.Session.SetString("flagFabricante", "ASC");
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
                        
                        var retornoListaMedicamento  = objMedicamentoBLL.ConsultarMedicamento(sort, model.psqNomeGenerico, model.psqNomeFabrica, model.psqFabricante);

                        int pageNumber = 0;
                        if (pagina != null) {
                          pageNumber = Convert.ToInt32(pagina);
                        } else {
                            pageNumber = 1;
                        }

                        if (retornoListaMedicamento != null) {
                            if (HttpContext.Session.GetString("MensagemTitle") != null && HttpContext.Session.GetString("MensagemBody") != null && HttpContext.Session.GetString("MensagemTitle") != "" && HttpContext.Session.GetString("MensagemBody") != "") {
                                ViewBag.MensagemTitle = HttpContext.Session.GetString("MensagemTitle");
                                ViewBag.MensagemBody = HttpContext.Session.GetString("MensagemBody");
                                HttpContext.Session.SetString("MensagemTitle", "");
                                HttpContext.Session.SetString("MensagemBody", "");

                                model.psqFabricante = "";
                                model.psqNomeFabrica = "";
                                model.psqNomeGenerico = "";

                                ModelState.Clear();
                            }

                            model.ListaConsultaMedicamentoModel = retornoListaMedicamento.ToPagedList(pageNumber, 10);

                            return View(model);
                        } else {
                            retornoListaMedicamento = objMedicamentoBLL.ConsultarMedicamento(0, null, null, null);
                            model.ListaConsultaMedicamentoModel = retornoListaMedicamento.ToPagedList(pageNumber, 10);

                            ViewBag.MensagemTitle = "Informação";
                            ViewBag.MensagemBody = "Não existe nenhum registro cadastrado!";

                            return View(model);
                        }
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Medicamento/CadastrarMedicamento', pois não tem permissão para inserir medicamento!");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: MedicamentoController";
                ViewBag.MensagemBodyAction = "Action: ConsultarMedicamento";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        //[HttpGet]
        //public PartialViewResult ConsultarMedicamentoPesquisa(string psqNomeGenerico, string psqNomeFabrica, string psqFabricante) {
        //    try {
        //        ViewBag.MensagemBodyController = "";
        //        ViewBag.MensagemBodyAction = "";
        //        ViewBag.MensagemBody = "";
        //        ViewBag.nomeGenerico = "nomeGenerico";
        //        ViewBag.nomeFabrica = "nomeFabrica";
        //        ViewBag.fabricante = "fabricante";
        //        CarregarDadosUsuarioParaTela();
        //        if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
        //            if ((int)ViewData["flMedicamentoC"] != 0) {
        //                MedicamentoBLL objMedicamentoBLL = new MedicamentoBLL();
        //                var viewModel = new List<ConsultarMedicamentoModel>();
                        
        //                viewModel = objMedicamentoBLL.ConsultarMedicamento(0, psqNomeGenerico, psqNomeFabrica, psqFabricante);

        //                if (viewModel != null) {
        //                    return PartialView(viewModel);
        //                } else {
        //                    ViewBag.MensagemTitle = "Informação";
        //                    ViewBag.MensagemBody = "Não existe nenhum registro cadastrado!";
        //                    ModelState.Clear();
        //                    return PartialView();
        //                }
        //            } else {
        //                HttpContext.Session.SetString("MensagemTitle", "Erro");
        //                HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Medicamento/CadastrarMedicamento', pois não tem permissão para inserir medicamento!");
        //                //return RedirectToAction("Index", "Home");
        //                return null;
        //            }
        //        } else {
        //            ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
        //            //return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
        //            return null;
        //        }
        //    } catch (Exception ex) {
        //        ViewBag.MensagemTitle = "Erro";
        //        ViewBag.MensagemBodyController = "Controller: MedicamentoController";
        //        ViewBag.MensagemBodyAction = "Action: ConsultarMedicamento";
        //        ViewBag.MensagemBody = "Exceção: " + ex.Message;
        //        return PartialView();
        //    }
        //}

        [HttpGet]
        public ActionResult EditarMedicamento(int id) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flMedicamentoA"] != 0) {
                        MedicamentoBLL objMedicamentoBLL = new MedicamentoBLL();
                        var viewModel = new EditarMedicamentoModel();
                        viewModel = objMedicamentoBLL.ConsultarMedicamentoID(id);

                        if (viewModel != null) {
                            return View(viewModel);
                        } else {
                            ViewBag.MensagemTitle = "Informação";
                            ViewBag.MensagemBody = "O 'ID' informado não existe!";
                            ModelState.Clear();
                            return View();
                        }

                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Medicamento/EditarMedicamento', pois não tem permissão para inserir medicamento!");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: MedicamentoController";
                ViewBag.MensagemBodyAction = "Action: EditarMedicamento";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarMedicamento(EditarMedicamentoModel model) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flMedicamentoA"] != 0) {
                        MedicamentoBLL objMedicamentoBLL = new MedicamentoBLL();
                        var viewModel = new EditarMedicamentoModel();
                        var retornoEditarMedicamento = objMedicamentoBLL.EditarMedicamento(model);

                        if(retornoEditarMedicamento == 1) {
                            HttpContext.Session.SetString("MensagemTitle", "Sucesso");
                            HttpContext.Session.SetString("MensagemBody", "O medicamento '" + model.nomeGenerico + "' foi alterado com sucesso!");
                            return RedirectToAction("ConsultarMedicamento", "Medicamento");
                        } else {
                            ViewBag.MensagemTitle = "Erro";
                            ViewBag.MensagemBody = "Ocorreu um erro na tentativa de alterar o medicamento '" + model.nomeGenerico + "', contate o suporte do sistema!";
                            return View();
                        }
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Medicamento/EditarMedicamento', pois não tem permissão para inserir medicamento!");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: MedicamentoController";
                ViewBag.MensagemBodyAction = "Action: ConsultarMedicamento";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirMedicamento(int idMedicamento) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flMedicamentoE"] != 0) {
                        MedicamentoBLL objMedicamentoBLL = new MedicamentoBLL();
                        var viewModel = new EditarMedicamentoModel();
                        var retornoExcluirMedicamento = objMedicamentoBLL.ExcluirMedicamento(idMedicamento);

                        if (retornoExcluirMedicamento == 1) {
                            HttpContext.Session.SetString("MensagemTitle", "Sucesso");
                            HttpContext.Session.SetString("MensagemBody", "O medicamento foi excluido com sucesso!");
                        } else {
                            HttpContext.Session.SetString("MensagemTitle", "Erro");
                            HttpContext.Session.SetString("MensagemBody", "Ocorreu um erro ao tentar excluir o medicamento, favor entrar em contato com o suporte do sistema!");
                        }

                        ModelState.Clear();

                        return Json(retornoExcluirMedicamento);
                        //return RedirectToAction("ConsultarMedicamento", "Medicamento");
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Medicamento/ExcluirMedicamento', pois não tem permissão para inserir medicamento!");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: MedicamentoController";
                ViewBag.MensagemBodyAction = "Action: ConsultarMedicamento";
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
