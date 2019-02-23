using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using SGCM.AppData.Usuario;
using System.Collections.Generic;
using SGCM.Models.Usuario.CadastroUsuarioModel;
using SGCM.Models.Usuario.EditarUsuarioModel;

namespace SGCM.Controllers {

    public class UsuarioController : Controller {

        //GET: /Usuario/CadastroUsuario
        [HttpGet]
        public ActionResult CadastroUsuario() {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flUsuarioI"] == 1) {
                        ViewData["Title"] = "Cadastro Usuário";

                        var viewModel = new CadastroUsuarioModel();

                        viewModel.usuario = new Models.Usuario.CadastroUsuarioModel.DadosLogin();
                        viewModel.permissoes = new Models.Usuario.CadastroUsuarioModel.DadosPermissoes();
                        viewModel.pessoa = new Models.Usuario.CadastroUsuarioModel.DadosPessoais();

                        return View(viewModel);
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Usuario/CadastroUsuario'");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    HttpContext.Session.SetString("MensagemBody", "Você não está logado no sistema! Realize o Login antes de acessar essa a página: '" + ViewData["ReturnUrl"] + "' !");
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: UsuarioController";
                ViewBag.MensagemBodyAction = "Action: CadastroUsuario - GET";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        // POST: /Usuario/CadastroUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroUsuario(CadastroUsuarioModel model) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                if (!ModelState.IsValid) return View(model);

                model.pessoa.IdMedico = (int)HttpContext.Session.GetInt32("idPessoa");

                var objUsuariosBLL = new UsuarioBLL();
                var retorno = objUsuariosBLL.InserirUsuario(model);

                if (retorno == 3) {
                    ViewBag.MensagemTitle = "Sucesso";
                    ViewBag.MensagemBody = "Usuário cadastrado com sucesso!";

                    ModelState.Clear();

                    return View();
                } else {
                    ViewBag.MensagemTitle = "Error";
                    ViewBag.MensagemBody = "Ocorreu um erro ao cadastrar um usuário!";
                    return View(model);
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: UsuarioController";
                ViewBag.MensagemBodyAction = "Action: CadastroUsuario - POST";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        //GET: /Usuario/ConsultaUsuario
        [HttpGet]
        public ActionResult ConsultaUsuario() {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    var objUsuariosBLL = new UsuarioBLL();
                    List<CadastroUsuarioModel> viewModel = objUsuariosBLL.ConsultarUsuario((int)ViewData["idPessoa"]);

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
                        ViewBag.MensagemBody = "Não existe nenhum Usuário cadastrado pelo usuário: " + ViewData["nome"];
                        return View();
                    }
                } else {
                    HttpContext.Session.SetString("UserMessage", "Você não está logado no sistema! Realize o Login antes de acessar essa página!");
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: UsuarioController";
                ViewBag.MensagemBodyAction = "Action: ConsultaUsuario - GET";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        //GET: /Usuario/EditarUsuario
        [HttpGet]
        public ActionResult EditarUsuario(int id) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flUsuarioA"] != 0) {
                        ViewData["Title"] = "Editar Usuário";

                        var objUsuarioBLL = new UsuarioBLL();
                        EditarUsuarioModel viewModel = objUsuarioBLL.ConsultarUsuarioID(id);

                        if (viewModel.usuario.DataDesativacao == default(DateTime)) {
                            viewModel.pessoa.Status = "1";
                        } else {
                            viewModel.pessoa.Status = "2";
                        }

                        return View(viewModel);
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro ao Cadastrar a Consulta");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Usuario/EditarUsuario'");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", "Home/Index");
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: UsuarioController";
                ViewBag.MensagemBodyAction = "Action: EditarUsuario/ID - GET";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        //POST: /Usuario/EditarUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarUsuario(EditarUsuarioModel model) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flUsuarioA"] != 0) {
                        var objUsuarioBLL = new UsuarioBLL();
                        var retorno = objUsuarioBLL.EditarUsuario(model);

                        if (retorno == 3) {
                            HttpContext.Session.SetString("MensagemTitle", "Sucesso");
                            HttpContext.Session.SetString("MensagemBody", "O usuário " + model.pessoa.Nome + " foi atualizado com sucesso!");
                            return RedirectToAction("ConsultaUsuario", "Usuario");
                        } else {
                            ViewBag.MensagemTitle = "Erro";
                            ViewBag.MensagemBody = "Ocorreu um erro na tentiva de editar o usuário: " + ViewData["nome"];
                            return View();
                        }
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "Você não tem premissão para acessar a tela de Edição de Usuários!");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: UsuarioController";
                ViewBag.MensagemBodyAction = "Action: EditarUsuario/{USUÁRIO} - POST";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        //GET: /Usuario/Relatorio
        [HttpGet]
        public ActionResult Relatorio()
        {
            ViewData["Title"] = "Relatório";

            return View();
        }

        [HttpPost]
        public ActionResult VerificaUF(string valorCampo)
        {
            switch (valorCampo)
            {
                case "AC":
                    break;
                case "AL":
                    break;
                case "AP":
                    break;
                case "AM":
                    break;
                case "BA":
                    break;
                case "CE":
                    break;
                case "DF":
                    break;
                case "ES":
                    break;
                case "GO":
                    break;
                case "MA":
                    break;
                case "MT":
                    break;
                case "MS":
                    break;
                case "MG":
                    break;
                case "PA":
                    break;
                case "PB":
                    break;
                case "PR":
                    break;
                case "PE":
                    break;
                case "PI":
                    break;
                case "RJ":
                    break;
                case "RN":
                    break;
                case "RS":
                    break;
                case "RO":
                    break;
                case "RR":
                    break;
                case "SC":
                    break;
                case "SP":
                    break;
                case "SE":
                    break;
                case "TO":
                    break;
                default:
                    break;
            }
            return null;
        }

        private void CarregarDadosUsuarioParaSession(EditarUsuarioModel usuarioCompletoTO) {
            HttpContext.Session.SetInt32("idUsuario", usuarioCompletoTO.usuario.IdUsuario);
            HttpContext.Session.SetString("usuario", usuarioCompletoTO.usuario.Username);
            HttpContext.Session.SetInt32("tipoUsuario", Int32.Parse(usuarioCompletoTO.usuario.TipoUsuario));

            HttpContext.Session.SetInt32("idPessoa", usuarioCompletoTO.pessoa.IdPessoa);
            HttpContext.Session.SetInt32("idMedico", usuarioCompletoTO.pessoa.IdMedico);
            HttpContext.Session.SetString("nome", usuarioCompletoTO.pessoa.Nome);
            HttpContext.Session.SetString("cpf", usuarioCompletoTO.pessoa.CPF);
            HttpContext.Session.SetString("rg", usuarioCompletoTO.pessoa.RG);
            HttpContext.Session.SetString("sexo", usuarioCompletoTO.pessoa.Sexo);
            HttpContext.Session.SetString("dataNascimento", usuarioCompletoTO.pessoa.DataNascimento.ToShortDateString());
            HttpContext.Session.SetString("logradouro", usuarioCompletoTO.pessoa.Logradouro);
            HttpContext.Session.SetInt32("numero", usuarioCompletoTO.pessoa.Numero);
            HttpContext.Session.SetString("bairro", usuarioCompletoTO.pessoa.Bairro);
            HttpContext.Session.SetString("cidade", usuarioCompletoTO.pessoa.Cidade);
            HttpContext.Session.SetString("uf", usuarioCompletoTO.pessoa.UF);
            HttpContext.Session.SetString("telefoneCelular", usuarioCompletoTO.pessoa.Telefone_Celular);
            HttpContext.Session.SetString("email", usuarioCompletoTO.pessoa.Email);

            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.FlUsuarioI)) {
                HttpContext.Session.SetInt32("flUsuarioI", 1);
            } else {
                HttpContext.Session.SetInt32("flUsuarioI", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.FlUsuarioC)) {
                HttpContext.Session.SetInt32("flUsuarioC", 1);
            } else {
                HttpContext.Session.SetInt32("flUsuarioC", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.FlUsuarioA)) {
                HttpContext.Session.SetInt32("flUsuarioA", 1);
            } else {
                HttpContext.Session.SetInt32("flUsuarioA", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.FlUsuarioE)) {
                HttpContext.Session.SetInt32("flUsuarioE", 1);
            } else {
                HttpContext.Session.SetInt32("flUsuarioE", 0);
            }

            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.FlPacienteI)) {
                HttpContext.Session.SetInt32("flPacienteI", 1);
            } else {
                HttpContext.Session.SetInt32("flPacienteI", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.FlPacienteC)) {
                HttpContext.Session.SetInt32("flPacienteC", 1);
            } else {
                HttpContext.Session.SetInt32("flPacienteC", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.FlPacienteA)) {
                HttpContext.Session.SetInt32("flPacienteA", 1);
            } else {
                HttpContext.Session.SetInt32("flPacienteA", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.FlPacienteE)) {
                HttpContext.Session.SetInt32("flPacienteE", 1);
            } else {
                HttpContext.Session.SetInt32("flPacienteE", 0);
            }

            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.FlConsultaI)) {
                HttpContext.Session.SetInt32("flConsultaI", 1);
            } else {
                HttpContext.Session.SetInt32("flConsultaI", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.FlConsultaC)) {
                HttpContext.Session.SetInt32("flConsultaC", 1);
            } else {
                HttpContext.Session.SetInt32("flConsultaC", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.FlConsultaA)) {
                HttpContext.Session.SetInt32("flConsultaA", 1);
            } else {
                HttpContext.Session.SetInt32("flConsultaA", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.FlConsultaE)) {
                HttpContext.Session.SetInt32("flConsultaE", 1);
            } else {
                HttpContext.Session.SetInt32("flConsultaE", 0);
            }

            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.FlMedicamentoI)) {
                HttpContext.Session.SetInt32("FlMedicamentoI", 1);
            } else {
                HttpContext.Session.SetInt32("flMedicamentoI", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.FlMedicamentoC)) {
                HttpContext.Session.SetInt32("flMedicamentoC", 1);
            } else {
                HttpContext.Session.SetInt32("flMedicamentoC", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.FlMedicamentoA)) {
                HttpContext.Session.SetInt32("flMedicamentoA", 1);
            } else {
                HttpContext.Session.SetInt32("flMedicamentoA", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.FlMedicamentoE)) {
                HttpContext.Session.SetInt32("flMedicamentoE", 1);
            } else {
                HttpContext.Session.SetInt32("flMedicamentoE", 0);
            }

            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.FlExamesI)) {
                HttpContext.Session.SetInt32("flExamesI", 1);
            } else {
                HttpContext.Session.SetInt32("flExamesI", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.FlExamesC)) {
                HttpContext.Session.SetInt32("flExamesC", 1);
            } else {
                HttpContext.Session.SetInt32("flExamesC", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.FlExamesA)) {
                HttpContext.Session.SetInt32("flExamesA", 1);
            } else {
                HttpContext.Session.SetInt32("flExamesA", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.FlExamesE)) {
                HttpContext.Session.SetInt32("flExamesE", 1);
            } else {
                HttpContext.Session.SetInt32("flExamesE", 0);
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

            ViewData.Add("flConsultaAnteriorI", HttpContext.Session.GetInt32("flConsultaAnteriorI"));
            ViewData.Add("flConsultaAnteriorC", HttpContext.Session.GetInt32("flConsultaAnteriorC"));
            ViewData.Add("flConsultaAnteriorA", HttpContext.Session.GetInt32("flConsultaAnteriorA"));
            ViewData.Add("flConsultaAnteriorE", HttpContext.Session.GetInt32("flConsultaAnteriorE"));

            ViewData.Add("flHistoriaMolestiaAtualI", HttpContext.Session.GetInt32("flHistoriaMolestiaAtualI"));
            ViewData.Add("flHistoriaMolestiaAtualC", HttpContext.Session.GetInt32("flHistoriaMolestiaAtualC"));
            ViewData.Add("flHistoriaMolestiaAtualA", HttpContext.Session.GetInt32("flHistoriaMolestiaAtualA"));
            ViewData.Add("flHistoriaMolestiaAtualE", HttpContext.Session.GetInt32("flHistoriaMolestiaAtualE"));
        }
    }
}