using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGCM.Models;
using SGCM.AppData.Usuario;
using SGCM.Models.Account;
using SGCM.Models.UserMessage;
using SGCM.AppData.Login;
using System;

namespace SGCM.Controllers {

    public class HomeController : Controller {

        public IActionResult Index(HomeModel model) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                if ((HttpContext.Session.GetInt32("idUsuario") != null) && (HttpContext.Session.GetInt32("idUsuario") != 0)) {
                    if (HttpContext.Session.GetString("MensagemTitle") != null && HttpContext.Session.GetString("MensagemBody") != null && HttpContext.Session.GetString("MensagemTitle") != "" && HttpContext.Session.GetString("MensagemBody") != "") {
                        ViewBag.MensagemTitle = HttpContext.Session.GetString("MensagemTitle");
                        ViewBag.MensagemBody = HttpContext.Session.GetString("MensagemBody");
                        HttpContext.Session.SetString("MensagemTitle", "");
                        HttpContext.Session.SetString("MensagemBody", "");
                    }
                    CarregarDadosUsuarioParaTela();
                    return View(model);
                } else {
                    var usuarioCookie = getCookie("usuario");
                    var senhaCookie = getCookie("senha");
                    if (usuarioCookie == null) {
                        ViewData["Title"] = "Home";
                        return View();
                    } else {
                        var objLoginBLL = new LoginBLL();
                        var retorno = objLoginBLL.EfetuarLogin(new LoginViewModel { Username = usuarioCookie, Password = senhaCookie });
                        CarregarDadosUsuarioParaSession(retorno);
                        CarregarDadosUsuarioParaTela();
                        return RedirectToAction("Index", "Home");
                    }
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: HomeController";
                ViewBag.MensagemBodyAction = "Action: Index - GET";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        public IActionResult Sobre() {
            //ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contato() {
            //ViewData["Message"] = "Your contact page.";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            ViewData["UserMessage"] = new UserMessage { title = "Erro", userMessage = HttpContext.Session.GetString("UserMessage"), cssClassName = "alert-error" };
            HttpContext.Session.SetString("UserMessage", "");
            return View();
        }

        private void CarregarDadosUsuarioParaSession(UsuarioCompletoTO usuarioCompletoTO)
        {
            HttpContext.Session.SetInt32("idUsuario", usuarioCompletoTO.usuarioTO.idUsuario);
            HttpContext.Session.SetString("usuario", usuarioCompletoTO.usuarioTO.Usuario);

            HttpContext.Session.SetInt32("idPessoa", usuarioCompletoTO.pessoaTO.idPessoa);
            HttpContext.Session.SetInt32("idMedico", usuarioCompletoTO.pessoaTO.idMedico);
            HttpContext.Session.SetInt32("tipoUsuario", usuarioCompletoTO.pessoaTO.tipoUsuario);
            HttpContext.Session.SetString("nome", usuarioCompletoTO.pessoaTO.Nome);
            HttpContext.Session.SetString("cpf", usuarioCompletoTO.pessoaTO.Cpf);
            HttpContext.Session.SetString("rg", usuarioCompletoTO.pessoaTO.Rg);
            HttpContext.Session.SetString("dataNascimento", usuarioCompletoTO.pessoaTO.DataNascimento);
            HttpContext.Session.SetString("logradouro", usuarioCompletoTO.pessoaTO.Logradouro);
            HttpContext.Session.SetInt32("numero", usuarioCompletoTO.pessoaTO.Numero);
            HttpContext.Session.SetString("bairro", usuarioCompletoTO.pessoaTO.Bairro);
            HttpContext.Session.SetString("cidade", usuarioCompletoTO.pessoaTO.Cidade);
            HttpContext.Session.SetString("uf", usuarioCompletoTO.pessoaTO.Uf);
            HttpContext.Session.SetString("telefoneCelular", usuarioCompletoTO.pessoaTO.Telefone_Celular);
            HttpContext.Session.SetString("email", usuarioCompletoTO.pessoaTO.Email);

            HttpContext.Session.SetInt32("flUsuarioI", usuarioCompletoTO.permissoesTO.flUsuarioI);
            HttpContext.Session.SetInt32("flUsuarioC", usuarioCompletoTO.permissoesTO.flUsuarioC);
            HttpContext.Session.SetInt32("flUsuarioA", usuarioCompletoTO.permissoesTO.flUsuarioA);
            HttpContext.Session.SetInt32("flUsuarioE", usuarioCompletoTO.permissoesTO.flUsuarioE);

            HttpContext.Session.SetInt32("flPacienteI", usuarioCompletoTO.permissoesTO.flPacienteI);
            HttpContext.Session.SetInt32("flPacienteC", usuarioCompletoTO.permissoesTO.flPacienteC);
            HttpContext.Session.SetInt32("flPacienteA", usuarioCompletoTO.permissoesTO.flPacienteA);
            HttpContext.Session.SetInt32("flPacienteE", usuarioCompletoTO.permissoesTO.flPacienteE);

            HttpContext.Session.SetInt32("flConsultaI", usuarioCompletoTO.permissoesTO.flPacienteI);
            HttpContext.Session.SetInt32("flConsultaC", usuarioCompletoTO.permissoesTO.flPacienteC);
            HttpContext.Session.SetInt32("flConsultaA", usuarioCompletoTO.permissoesTO.flPacienteA);
            HttpContext.Session.SetInt32("flConsultaE", usuarioCompletoTO.permissoesTO.flPacienteE);

            HttpContext.Session.SetInt32("flMedicamentoI", usuarioCompletoTO.permissoesTO.flMedicamentoI);
            HttpContext.Session.SetInt32("flMedicamentoC", usuarioCompletoTO.permissoesTO.flMedicamentoC);
            HttpContext.Session.SetInt32("flMedicamentoA", usuarioCompletoTO.permissoesTO.flMedicamentoA);
            HttpContext.Session.SetInt32("flMedicamentoE", usuarioCompletoTO.permissoesTO.flMedicamentoE);

            HttpContext.Session.SetInt32("flExamesI", usuarioCompletoTO.permissoesTO.flExamesI);
            HttpContext.Session.SetInt32("flExamesC", usuarioCompletoTO.permissoesTO.flExamesC);
            HttpContext.Session.SetInt32("flExamesA", usuarioCompletoTO.permissoesTO.flExamesA);
            HttpContext.Session.SetInt32("flExamesE", usuarioCompletoTO.permissoesTO.flExamesE);
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
        }

        public string getCookie(string key) {
            return Request.Cookies[key];
        }
    }
}
