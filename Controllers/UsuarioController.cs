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
            CarregarDadosUsuarioParaTela();
            if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                if ((int)ViewData["flUsuarioI"] != 0) {

                    ViewData["Title"] = "Cadastro Usuário";
                    var viewModel = new CadastroUsuarioModel();
                    viewModel.usuario = new Models.Usuario.CadastroUsuarioModel.DadosLogin();
                    viewModel.permissoes = new Models.Usuario.CadastroUsuarioModel.DadosPermissoes();
                    viewModel.pessoa = new Models.Usuario.CadastroUsuarioModel.DadosPessoais();

                    return View(viewModel);
                } else {
                    return RedirectToAction("Index", "Home");
                }
            } else {
                ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                //HttpContext.Session.SetString("MensagemErro", "Você não está logado no sistema! Realize o Login antes de acessar essa página!");
                //HttpContext.Session.SetInt32("FlMensagemErro", 1);
                return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] } );
            }
        }

        // POST: /Usuario/CadastroUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroUsuario(CadastroUsuarioModel model)
        {
            try
            {
                if (!ModelState.IsValid) {
                    return View(model);
                }

                model.pessoa.IdMedico = (int)HttpContext.Session.GetInt32("Id_Pessoa");

                var objUsuariosBLL = new UsuarioBLL();
                var retorno = objUsuariosBLL.InserirUsuario(model);

                if (retorno > 0) {
                    HttpContext.Session.SetString("MensagemErro", "Cadastro realizado com sucesso!");
                    HttpContext.Session.SetInt32("FlMensagemErro", 1);
                    return RedirectToAction("Index", "Home");
                    //return View(model);
                } else {
                    //HttpContext.Session.SetString("MensagemErro", "Ocorreu algum!");
                    //HttpContext.Session.SetInt32("FlMensagemErro", 1);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (SqlException exSQL)
            {
                ModelState.AddModelError(string.Empty, exSQL.Message);
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        //GET: /Usuario/ConsultaUsuario
        [HttpGet]
        public ActionResult ConsultaUsuario()
        {
            CarregarDadosUsuarioParaTela();
            if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                if ((int)ViewData["flUsuarioC"] != 0) {

                    ViewData["Title"] = "Consultar Usuário";
                    
                    var objUsuariosBLL = new UsuarioBLL();
                    List<CadastroUsuarioModel> viewModel = objUsuariosBLL.ConsultarUsuario((int) ViewData["idPessoa"]);

                    return View(viewModel);
                } else {
                    HttpContext.Session.SetString("MensagemErro", "Você não tem premissão para acessar a tela de Cadastro de Usuários!");
                    HttpContext.Session.SetInt32("FlMensagemErro", 1);
                    return RedirectToAction("Index", "Home");
                }
            } else {
                HttpContext.Session.SetString("MensagemErro", "Você não está logado no sistema! Realize o Login antes de acessar essa página!");
                HttpContext.Session.SetInt32("FlMensagemErro", 1);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult EditarUsuario(int id) {
            CarregarDadosUsuarioParaTela();
            if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                if ((int)ViewData["flUsuarioA"] != 0) {
                    ViewData["Title"] = "Editar Usuário";

                    var objUsuarioBLL = new UsuarioBLL();
                    EditarUsuarioModel viewModel = objUsuarioBLL.ConsultarUsuarioID(id);
                    
                    if (viewModel.usuario.DatDst == default(DateTime)) {
                        viewModel.pessoa.Status = "1";
                    } else {
                        viewModel.pessoa.Status = "2";
                    }

                    //CarregarDadosUsuarioParaSession(viewModel);

                    return View(viewModel);
                } else {
                    HttpContext.Session.SetString("MensagemErro", "Você não tem premissão para acessar a tela de Edição de Usuários!");
                    HttpContext.Session.SetInt32("FlMensagemErro", 1);
                    return RedirectToAction("Index", "Home");
                }

            } else {
                HttpContext.Session.SetString("MensagemErro", "Você não está logado no sistema! Realize o Login antes de acessar essa página!");
                HttpContext.Session.SetInt32("FlMensagemErro", 1);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarUsuario(EditarUsuarioModel model) {
            CarregarDadosUsuarioParaTela();
            if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                if ((int)ViewData["flUsuarioA"] != 0) {
                    ViewData["Title"] = "Editar Usuário";
                    return View();
                } else {
                    HttpContext.Session.SetString("MensagemErro", "Você não tem premissão para acessar a tela de Edição de Usuários!");
                    HttpContext.Session.SetInt32("FlMensagemErro", 1);
                    return RedirectToAction("Index", "Home");
                }
            } else {
                HttpContext.Session.SetString("MensagemErro", "Você não está logado no sistema! Realize o Login antes de acessar essa página!");
                HttpContext.Session.SetInt32("FlMensagemErro", 1);
                return RedirectToAction("Index", "Home");
            }
        }


        //GET: /Usuario/Relatorio
        [HttpGet]
        public ActionResult Relatorio()
        {
            ViewData["Title"] = "Relatório";

            return View();
        }

        private void CarregarDadosUsuarioParaSession(EditarUsuarioModel usuarioCompletoTO)
        {
            HttpContext.Session.SetInt32("ID", usuarioCompletoTO.usuario.IdUsuario);
            HttpContext.Session.SetString("Username", usuarioCompletoTO.usuario.Username);
            HttpContext.Session.SetString("Password", usuarioCompletoTO.usuario.Password);
            HttpContext.Session.SetString("DatDst", usuarioCompletoTO.usuario.DatDst.ToShortDateString());

            HttpContext.Session.SetInt32("Id_Pessoa", usuarioCompletoTO.pessoa.IdPessoa);
            HttpContext.Session.SetInt32("Id_Medico", usuarioCompletoTO.pessoa.IdMedico);
            HttpContext.Session.SetString("Nome", usuarioCompletoTO.pessoa.Nome);
            HttpContext.Session.SetString("Cpf", usuarioCompletoTO.pessoa.CPF);
            HttpContext.Session.SetString("Estado", usuarioCompletoTO.pessoa.Estado);
            HttpContext.Session.SetString("Cidade", usuarioCompletoTO.pessoa.Cidade);
            HttpContext.Session.SetString("Bairro", usuarioCompletoTO.pessoa.Bairro);
            HttpContext.Session.SetString("Endereco", usuarioCompletoTO.pessoa.Endereco);
            HttpContext.Session.SetInt32("Numero", usuarioCompletoTO.pessoa.Numero);
            HttpContext.Session.SetString("Telefone_Celular", usuarioCompletoTO.pessoa.Telefone_Celular);
            HttpContext.Session.SetString("Email", usuarioCompletoTO.pessoa.Email);
            HttpContext.Session.SetInt32("Tipo_Usuario", Int32.Parse(usuarioCompletoTO.pessoa.TipoUsuario));

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
            ViewData.Add("nome", HttpContext.Session.GetInt32("nome"));
            ViewData.Add("cpf", HttpContext.Session.GetInt32("cpf"));
            ViewData.Add("rg", HttpContext.Session.GetInt32("rg"));
            ViewData.Add("dataNascimento", HttpContext.Session.GetInt32("dataNascimento"));
            ViewData.Add("logradouro", HttpContext.Session.GetInt32("logradouro"));
            ViewData.Add("numero", HttpContext.Session.GetInt32("numero"));
            ViewData.Add("bairro", HttpContext.Session.GetInt32("bairro"));
            ViewData.Add("cidade", HttpContext.Session.GetInt32("cidade"));
            ViewData.Add("uf", HttpContext.Session.GetInt32("uf"));
            ViewData.Add("telefoneCelular", HttpContext.Session.GetInt32("telefoneCelular"));
            ViewData.Add("email", HttpContext.Session.GetInt32("email"));

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