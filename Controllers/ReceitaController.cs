using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using X.PagedList;
using SGCM.Models.Receita;
using SGCM.AppData.Receita;

namespace SGCM.Controllers
{
    public class ReceitaController : Controller {

        [HttpGet]
        public ActionResult MostrarReceita(int id, string sortOrder, string paginaMedicamento, string paginaExame) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flReceitaC"] != 0) {
                        if (id != 0) { 
                            var viewModel = new ReceitaModel();
                            ReceitaBLL receitaBLL = new ReceitaBLL();
                            var buscaPaciente = true;
                            var sortExame = 0;
                            var sortMedicamento = 0;

                            if (HttpContext.Session.GetString("flagNomeGenerico") == null) {
                                HttpContext.Session.SetString("flagNomeGenerico", "default");
                            }

                            if (HttpContext.Session.GetString("flagNomeFabrica") == null) {
                                HttpContext.Session.SetString("flagNomeFabrica", "default");
                            }

                            if (!String.IsNullOrEmpty(sortOrder)) {
                                switch (sortOrder) {
                                    case "nomeGenerico": {
                                            if (HttpContext.Session.GetString("flagNomeGenerico") == "default") {
                                                HttpContext.Session.SetString("flagNomeGenerico", "ASC");
                                                sortMedicamento = 1;
                                            } else if (HttpContext.Session.GetString("flagNomeGenerico") == "ASC") {
                                                HttpContext.Session.SetString("flagNomeGenerico", "DESC");
                                                sortMedicamento = 2;
                                            } else if (HttpContext.Session.GetString("flagNomeGenerico") == "DESC") {
                                                HttpContext.Session.SetString("flagNomeGenerico", "ASC");
                                                sortMedicamento = 1;
                                            }
                                            break;
                                        }
                                    case "nomeFabrica": {
                                            if (HttpContext.Session.GetString("flagNomeFabrica") == "default") {
                                                HttpContext.Session.SetString("flagNomeFabrica", "ASC");
                                                sortMedicamento = 3;
                                            } else if (HttpContext.Session.GetString("flagNomeFabrica") == "ASC") {
                                                HttpContext.Session.SetString("flagNomeFabrica", "DESC");
                                                sortMedicamento = 4;
                                            } else if (HttpContext.Session.GetString("flagNomeFabrica") == "DESC") {
                                                HttpContext.Session.SetString("flagNomeFabrica", "ASC");
                                                sortMedicamento = 3;
                                            }
                                            break;
                                        }
                                    default: {
                                            sortMedicamento = 0;
                                            break;
                                        }
                                }
                            }

                            List<ListaReceitaMedicamentoModel> listaReceitaMedicamento = new List<ListaReceitaMedicamentoModel>();
                            listaReceitaMedicamento = receitaBLL.MostrarReceitaMedicamento(id, sortMedicamento);

                            if (HttpContext.Session.GetString("flagNomeExame") == null) {
                                HttpContext.Session.SetString("flagNomeExame", "default");
                            }

                            if (!String.IsNullOrEmpty(sortOrder)) {
                                switch (sortOrder) {
                                    case "nomeExame": {
                                            if (HttpContext.Session.GetString("flagNomeExame") == "default") {
                                                HttpContext.Session.SetString("flagNomeExame", "ASC");
                                                sortExame = 1;
                                            } else if (HttpContext.Session.GetString("flagNomeExame") == "ASC") {
                                                HttpContext.Session.SetString("flagNomeExame", "DESC");
                                                sortExame = 2;
                                            } else if (HttpContext.Session.GetString("flagNomeExame") == "DESC") {
                                                HttpContext.Session.SetString("flagNomeExame", "ASC");
                                                sortExame = 1;
                                            }
                                            break;
                                        }
                                    default: {
                                            sortExame = 0;
                                            break;
                                        }
                                }
                            }

                            List<ListaReceitaExameModel> listaReceitaExame = new List<ListaReceitaExameModel>();
                            listaReceitaExame = receitaBLL.MostrarReceitaExame(id, sortExame);

                            if (listaReceitaMedicamento.Count != 0) {
                                // BUSCA NOME DO PACIENTE
                                viewModel.NomePaciente = receitaBLL.ConsultaPaciente(listaReceitaMedicamento[0].idPacienteConsulta);
                                buscaPaciente = false;

                                int pageNumberMedicamento = 0;
                                if (paginaMedicamento != null) {
                                    pageNumberMedicamento = Convert.ToInt32(paginaMedicamento);
                                } else {
                                    pageNumberMedicamento = 1;
                                }
                                viewModel.ListaReceitaMedicamentoModel = listaReceitaMedicamento.ToPagedList(pageNumberMedicamento, 15000000);
                            }

                            if (listaReceitaExame.Count != 0) {
                                if (buscaPaciente) { 
                                    // BUSCA NOME DO PACIENTE
                                    viewModel.NomePaciente = receitaBLL.ConsultaPaciente(listaReceitaExame[0].idPacienteConsulta);
                                }

                                int pageNumberExame = 0;
                                if (paginaExame != null) {
                                    pageNumberExame = Convert.ToInt32(paginaExame);
                                } else {
                                    pageNumberExame = 1;
                                }
                                viewModel.ListaReceitaExameModel = listaReceitaExame.ToPagedList(pageNumberExame, 15000000);
                            }

                            return View(viewModel);
                        } else {
                            HttpContext.Session.SetString("MensagemTitle", "Erro");
                            HttpContext.Session.SetString("MensagemBody", "Por favor informar o código da consulta!");
                            return RedirectToAction("Index", "Home");
                        }
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Receita/ReceitaMedicamento', pois não tem permissão para consultar Receituário!");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: ReceitaController";
                ViewBag.MensagemBodyAction = "Action: ReceitaMedicamento";
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