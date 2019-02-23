using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SGCM.AppData.Infraestrutura;
using SGCM.AppData.Login;
using SGCM.AppData.Usuario;
using SGCM.Models.Account;
using System;
using System.Threading.Tasks;

namespace SGCM.Controllers {

    [Route("[controller]/[action]")]
    [Authorize]
    public class AccountController : Controller
    {

        // GET: /Account/SignIn 
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Signin(string returnUrl = null)
        {
            return View();
        }

        // POST: /Account/SignIn
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Signin(LoginViewModel model, string returnUrl = null)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                ViewData["ReturnUrl"] = returnUrl;

                var objLoginBLL = new LoginBLL();
                var retorno = objLoginBLL.EfetuarLogin(model);

                if (retorno == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: /Account/Signout
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Signout()
        {
            LimparSession();
            return Redirect("/Home/Index");
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser { UserName = model.Username };
        //        //var result = await _userManager.CreateAsync(user, model.Password);
        //        //if (result.Succeeded)
        //        //{
        //        //    //await _signInManager.SignInAsync(user, isPersistent: false);
        //        //    return RedirectToLocal(returnUrl);
        //        //}
        //        //AddErrors(result);
        //    }
        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        [HttpGet]
        [AllowAnonymous]
        public Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return null;
                //return RedirectToAction(nameof(CatalogController.Index), "Catalog");
            }
            //var user = await _userManager.FindByIdAsync(userId);
            //if (user == null)
            //{
            //    throw new ApplicationException($"Unable to load user with ID '{userId}'.");
            //}
            //var result = await _userManager.ConfirmEmailAsync(user, code);
            //return View(result.Succeeded ? "ConfirmEmail" : "Error");
            return null;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            if (code == null)
            {
                throw new ApplicationException("A code must be supplied for password reset.");
            }
            var model = new ResetPasswordViewModel { Code = code };
            return View(model);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return null;
                //return RedirectToAction(nameof(CatalogController.Index), "Catalog");
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        private void LimparSession() {
            HttpContext.Session.SetInt32("idUsuario", 0);
            HttpContext.Session.SetString("usuario", "");

            HttpContext.Session.SetInt32("idPessoa", 0);
            HttpContext.Session.SetInt32("idMedico", 0);
            HttpContext.Session.SetInt32("tipoUsuario", 0);
            HttpContext.Session.SetString("nome", "");
            HttpContext.Session.SetString("cpf", "");
            HttpContext.Session.SetString("rg", "");
            HttpContext.Session.SetString("dataNascimento", "");
            HttpContext.Session.SetString("logradouro", "");
            HttpContext.Session.SetInt32("numero", 0);
            HttpContext.Session.SetString("bairro", "");
            HttpContext.Session.SetString("cidade", "");
            HttpContext.Session.SetString("uf", "");
            HttpContext.Session.SetString("telefoneCelular", "");
            HttpContext.Session.SetString("email", "");

            HttpContext.Session.SetInt32("flUsuarioI", 0);
            HttpContext.Session.SetInt32("flUsuarioC", 0);
            HttpContext.Session.SetInt32("flUsuarioA", 0);
            HttpContext.Session.SetInt32("flUsuarioE", 0);

            HttpContext.Session.SetInt32("flPacienteI", 0);
            HttpContext.Session.SetInt32("flPacienteC", 0);
            HttpContext.Session.SetInt32("flPacienteA", 0);
            HttpContext.Session.SetInt32("flPacienteE", 0);

            HttpContext.Session.SetInt32("flConsultaI", 0);
            HttpContext.Session.SetInt32("flConsultaC", 0);
            HttpContext.Session.SetInt32("flConsultaA", 0);
            HttpContext.Session.SetInt32("flConsultaE", 0);

            HttpContext.Session.SetInt32("flMedicamentoI", 0);
            HttpContext.Session.SetInt32("flMedicamentoC", 0);
            HttpContext.Session.SetInt32("flMedicamentoA", 0);
            HttpContext.Session.SetInt32("flMedicamentoE", 0);

            HttpContext.Session.SetInt32("flExamesI", 0);
            HttpContext.Session.SetInt32("flExamesC", 0);
            HttpContext.Session.SetInt32("flExamesA", 0);
            HttpContext.Session.SetInt32("flExamesE", 0);
        }

        private void CarregarDadosUsuarioParaSession(UsuarioCompletoTO usuarioCompletoTO)
        {
            //HttpContext.Session.SetInt32("ID", usuarioCompletoTO.usuarioTO.ID_Usuario);
            //HttpContext.Session.SetString("Username", usuarioCompletoTO.usuarioTO.Username);
            //HttpContext.Session.SetString("Password", usuarioCompletoTO.usuarioTO.Password);

            //HttpContext.Session.SetInt32("Id_Pessoa", usuarioCompletoTO.pessoaTO.Id_Pessoa);
            //HttpContext.Session.SetInt32("Id_Medico", usuarioCompletoTO.pessoaTO.Id_Medico);
            //HttpContext.Session.SetString("Nome", usuarioCompletoTO.pessoaTO.Nome);
            //HttpContext.Session.SetString("Cpf", usuarioCompletoTO.pessoaTO.Cpf);
            //HttpContext.Session.SetString("Estado", usuarioCompletoTO.pessoaTO.Estado);
            //HttpContext.Session.SetString("Cidade", usuarioCompletoTO.pessoaTO.Cidade);
            //HttpContext.Session.SetString("Bairro", usuarioCompletoTO.pessoaTO.Bairro);
            //HttpContext.Session.SetString("Endereco", usuarioCompletoTO.pessoaTO.Endereco);
            //HttpContext.Session.SetInt32("Numero", usuarioCompletoTO.pessoaTO.Numero);
            //HttpContext.Session.SetString("Telefone_Celular", usuarioCompletoTO.pessoaTO.Telefone_Celular);
            //HttpContext.Session.SetString("Email", usuarioCompletoTO.pessoaTO.Email);
            //HttpContext.Session.SetInt32("Tipo_Usuario", usuarioCompletoTO.pessoaTO.Tipo_Usuario);

            //HttpContext.Session.SetInt32("FlUsuarioI", usuarioCompletoTO.permissoesTO.Fl_Usuario_I);
            //HttpContext.Session.SetInt32("FlUsuarioC", usuarioCompletoTO.permissoesTO.Fl_Usuario_C);
            //HttpContext.Session.SetInt32("FlUsuarioA", usuarioCompletoTO.permissoesTO.Fl_Usuario_A);
            //HttpContext.Session.SetInt32("FlUsuarioE", usuarioCompletoTO.permissoesTO.Fl_Usuario_E);

            //HttpContext.Session.SetInt32("FlPacienteI", usuarioCompletoTO.permissoesTO.Fl_Paciente_I);
            //HttpContext.Session.SetInt32("FlPacienteC", usuarioCompletoTO.permissoesTO.Fl_Paciente_C);
            //HttpContext.Session.SetInt32("FlPacienteA", usuarioCompletoTO.permissoesTO.Fl_Paciente_A);
            //HttpContext.Session.SetInt32("FlPacienteE", usuarioCompletoTO.permissoesTO.Fl_Paciente_E);

            //HttpContext.Session.SetInt32("FlConsultaI", usuarioCompletoTO.permissoesTO.Fl_Paciente_I);
            //HttpContext.Session.SetInt32("FlConsultaC", usuarioCompletoTO.permissoesTO.Fl_Paciente_C);
            //HttpContext.Session.SetInt32("FlConsultaA", usuarioCompletoTO.permissoesTO.Fl_Paciente_A);
            //HttpContext.Session.SetInt32("FlConsultaE", usuarioCompletoTO.permissoesTO.Fl_Paciente_E);

            //HttpContext.Session.SetInt32("FlMedicamentoI", usuarioCompletoTO.permissoesTO.Fl_Medicamento_I);
            //HttpContext.Session.SetInt32("FlMedicamentoC", usuarioCompletoTO.permissoesTO.Fl_Medicamento_C);
            //HttpContext.Session.SetInt32("FlMedicamentoA", usuarioCompletoTO.permissoesTO.Fl_Medicamento_A);
            //HttpContext.Session.SetInt32("FlMedicamentoE", usuarioCompletoTO.permissoesTO.Fl_Medicamento_E);

            //HttpContext.Session.SetInt32("FlExamesI", usuarioCompletoTO.permissoesTO.Fl_Exames_I);
            //HttpContext.Session.SetInt32("FlExamesC", usuarioCompletoTO.permissoesTO.Fl_Exames_C);
            //HttpContext.Session.SetInt32("FlExamesA", usuarioCompletoTO.permissoesTO.Fl_Exames_A);
            //HttpContext.Session.SetInt32("FlExamesE", usuarioCompletoTO.permissoesTO.Fl_Exames_E);
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
    }
}
