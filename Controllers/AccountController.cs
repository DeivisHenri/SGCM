using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SGCM.AppData.Infraestrutura;
using SGCM.AppData.Login;
using SGCM.Models.Account;
using System;
using System.Threading.Tasks;
using static SGCM.AppData.Infraestrutura.UtilObjetos.UtilObjetos;

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
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
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

        private void LimparSession()
        {
            HttpContext.Session.SetInt32("ID", 0);
            HttpContext.Session.SetString("Username", "");
            HttpContext.Session.SetString("Password", "");

            HttpContext.Session.SetInt32("Id_Pessoa", 0);
            HttpContext.Session.SetString("Nome", "");
            HttpContext.Session.SetString("Cpf", "");
            HttpContext.Session.SetString("Estado", "");
            HttpContext.Session.SetString("Cidade", "");
            HttpContext.Session.SetString("Bairro", "");
            HttpContext.Session.SetString("Endereco", "");
            HttpContext.Session.SetInt32("Numero", 0);
            HttpContext.Session.SetString("Telefone_Celular", "");
            HttpContext.Session.SetString("Email", "");
            HttpContext.Session.SetInt32("Tipo_Usuario", 0);

            HttpContext.Session.SetInt32("FlUsuarioI", 0);
            HttpContext.Session.SetInt32("FlUsuarioC", 0);
            HttpContext.Session.SetInt32("FlUsuarioA", 0);
            HttpContext.Session.SetInt32("FlUsuarioE", 0);

            HttpContext.Session.SetInt32("FlPacienteI", 0);
            HttpContext.Session.SetInt32("FlPacienteC", 0);
            HttpContext.Session.SetInt32("FlPacienteA", 0);
            HttpContext.Session.SetInt32("FlPacienteE", 0);

            HttpContext.Session.SetInt32("FlConsultaI", 0);
            HttpContext.Session.SetInt32("FlConsultaC", 0);
            HttpContext.Session.SetInt32("FlConsultaA", 0);
            HttpContext.Session.SetInt32("FlConsultaE", 0);

            HttpContext.Session.SetInt32("FlMedicamentoI", 0);
            HttpContext.Session.SetInt32("FlMedicamentoC", 0);
            HttpContext.Session.SetInt32("FlMedicamentoA", 0);
            HttpContext.Session.SetInt32("FlMedicamentoE", 0);

            HttpContext.Session.SetInt32("FlExamesI", 0);
            HttpContext.Session.SetInt32("FlExamesC", 0);
            HttpContext.Session.SetInt32("FlExamesA", 0);
            HttpContext.Session.SetInt32("FlExamesE", 0);
        }

        private void CarregarDadosUsuarioParaSession(UsuarioCompletoTO usuarioCompletoTO)
        {
            HttpContext.Session.SetInt32("ID", usuarioCompletoTO.usuarioTO.ID_Usuario);
            HttpContext.Session.SetString("Username", usuarioCompletoTO.usuarioTO.Username);
            HttpContext.Session.SetString("Password", usuarioCompletoTO.usuarioTO.Password);

            HttpContext.Session.SetInt32("Id_Pessoa", usuarioCompletoTO.pessoaTO.Id_Pessoa);
            HttpContext.Session.SetString("Nome", usuarioCompletoTO.pessoaTO.Nome);
            HttpContext.Session.SetString("Cpf", usuarioCompletoTO.pessoaTO.Cpf);
            HttpContext.Session.SetString("Estado", usuarioCompletoTO.pessoaTO.Estado);
            HttpContext.Session.SetString("Cidade", usuarioCompletoTO.pessoaTO.Cidade);
            HttpContext.Session.SetString("Bairro", usuarioCompletoTO.pessoaTO.Bairro);
            HttpContext.Session.SetString("Endereco", usuarioCompletoTO.pessoaTO.Endereco);
            HttpContext.Session.SetInt32("Numero", usuarioCompletoTO.pessoaTO.Numero);
            HttpContext.Session.SetString("Telefone_Celular", usuarioCompletoTO.pessoaTO.Telefone_Celular);
            HttpContext.Session.SetString("Email", usuarioCompletoTO.pessoaTO.Email);
            HttpContext.Session.SetInt32("Tipo_Usuario", usuarioCompletoTO.pessoaTO.Tipo_Usuario);

            HttpContext.Session.SetInt32("FlUsuarioI", usuarioCompletoTO.permissoesTO.Fl_Usuario_I);
            HttpContext.Session.SetInt32("FlUsuarioC", usuarioCompletoTO.permissoesTO.Fl_Usuario_C);
            HttpContext.Session.SetInt32("FlUsuarioA", usuarioCompletoTO.permissoesTO.Fl_Usuario_A);
            HttpContext.Session.SetInt32("FlUsuarioE", usuarioCompletoTO.permissoesTO.Fl_Usuario_E);

            HttpContext.Session.SetInt32("FlPacienteI", usuarioCompletoTO.permissoesTO.Fl_Paciente_I);
            HttpContext.Session.SetInt32("FlPacienteC", usuarioCompletoTO.permissoesTO.Fl_Paciente_C);
            HttpContext.Session.SetInt32("FlPacienteA", usuarioCompletoTO.permissoesTO.Fl_Paciente_A);
            HttpContext.Session.SetInt32("FlPacienteE", usuarioCompletoTO.permissoesTO.Fl_Paciente_E);

            HttpContext.Session.SetInt32("FlConsultaI", usuarioCompletoTO.permissoesTO.Fl_Paciente_I);
            HttpContext.Session.SetInt32("FlConsultaC", usuarioCompletoTO.permissoesTO.Fl_Paciente_C);
            HttpContext.Session.SetInt32("FlConsultaA", usuarioCompletoTO.permissoesTO.Fl_Paciente_A);
            HttpContext.Session.SetInt32("FlConsultaE", usuarioCompletoTO.permissoesTO.Fl_Paciente_E);

            HttpContext.Session.SetInt32("FlMedicamentoI", usuarioCompletoTO.permissoesTO.Fl_Medicamento_I);
            HttpContext.Session.SetInt32("FlMedicamentoC", usuarioCompletoTO.permissoesTO.Fl_Medicamento_C);
            HttpContext.Session.SetInt32("FlMedicamentoA", usuarioCompletoTO.permissoesTO.Fl_Medicamento_A);
            HttpContext.Session.SetInt32("FlMedicamentoE", usuarioCompletoTO.permissoesTO.Fl_Medicamento_E);

            HttpContext.Session.SetInt32("FlExamesI", usuarioCompletoTO.permissoesTO.Fl_Exames_I);
            HttpContext.Session.SetInt32("FlExamesC", usuarioCompletoTO.permissoesTO.Fl_Exames_C);
            HttpContext.Session.SetInt32("FlExamesA", usuarioCompletoTO.permissoesTO.Fl_Exames_A);
            HttpContext.Session.SetInt32("FlExamesE", usuarioCompletoTO.permissoesTO.Fl_Exames_E);
        }

        private void CarregarDadosUsuarioParaTela()
        {
            ViewBag.ID = HttpContext.Session.GetInt32("ID");
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Password = HttpContext.Session.GetString("Password");

            ViewBag.Id_Pessoa = HttpContext.Session.GetInt32("Id_Pessoa");
            ViewBag.Nome = HttpContext.Session.GetString("Nome");
            ViewBag.Cpf = HttpContext.Session.GetString("Cpf");
            ViewBag.Estado = HttpContext.Session.GetString("Estado");
            ViewBag.Cidade = HttpContext.Session.GetString("Cidade");
            ViewBag.Bairro = HttpContext.Session.GetString("Bairro");
            ViewBag.Endereco = HttpContext.Session.GetString("Endereco");
            ViewBag.Numero = HttpContext.Session.GetInt32("Numero");
            ViewBag.Telefone_Celular = HttpContext.Session.GetString("Telefone_Celular");
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Tipo_Usuario = HttpContext.Session.GetInt32("Tipo_Usuario");

            ViewBag.FlUsuarioI = HttpContext.Session.GetInt32("FlUsuarioI");
            ViewBag.FlUsuarioC = HttpContext.Session.GetInt32("FlUsuarioC");
            ViewBag.FlUsuarioA = HttpContext.Session.GetInt32("FlUsuarioA");
            ViewBag.FlUsuarioE = HttpContext.Session.GetInt32("FlUsuarioE");

            ViewBag.FlPacienteI = HttpContext.Session.GetInt32("FlPacienteI");
            ViewBag.FlPacienteC = HttpContext.Session.GetInt32("FlPacienteC");
            ViewBag.FlPacienteA = HttpContext.Session.GetInt32("FlPacienteA");
            ViewBag.FlPacienteE = HttpContext.Session.GetInt32("FlPacienteE");

            ViewBag.FlConsultaI = HttpContext.Session.GetInt32("FlConsultaI");
            ViewBag.FlConsultaC = HttpContext.Session.GetInt32("FlConsultaC");
            ViewBag.FlConsultaA = HttpContext.Session.GetInt32("FlConsultaA");
            ViewBag.FlConsultaE = HttpContext.Session.GetInt32("FlConsultaE");

            ViewBag.FlMedicamentoI = HttpContext.Session.GetInt32("FlMedicamentoI");
            ViewBag.FlMedicamentoC = HttpContext.Session.GetInt32("FlMedicamentoC");
            ViewBag.FlMedicamentoA = HttpContext.Session.GetInt32("FlMedicamentoA");
            ViewBag.FlMedicamentoE = HttpContext.Session.GetInt32("FlMedicamentoE");

            ViewBag.FlExamesI = HttpContext.Session.GetInt32("FlExamesI");
            ViewBag.FlExamesC = HttpContext.Session.GetInt32("FlExamesC");
            ViewBag.FlExamesA = HttpContext.Session.GetInt32("FlExamesA");
            ViewBag.FlExamesE = HttpContext.Session.GetInt32("FlExamesE");
        }
    }
}
