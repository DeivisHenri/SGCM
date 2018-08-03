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

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Username };
                //var result = await _userManager.CreateAsync(user, model.Password);
                //if (result.Succeeded)
                //{
                //    //await _signInManager.SignInAsync(user, isPersistent: false);
                //    return RedirectToLocal(returnUrl);
                //}
                //AddErrors(result);
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

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
            HttpContext.Session.SetInt32("TipoUsuario", 0);

            HttpContext.Session.SetInt32("FlUsuarioI", 0);
            HttpContext.Session.SetInt32("FlUsuarioC", 0);
            HttpContext.Session.SetInt32("FlUsuarioA", 0);
            HttpContext.Session.SetInt32("FlUsuarioE", 0);

            HttpContext.Session.SetInt32("FlPacienteI", 0);
            HttpContext.Session.SetInt32("FlPacienteC", 0);
            HttpContext.Session.SetInt32("FlPacienteA", 0);
            HttpContext.Session.SetInt32("FlPacienteE", 0);

            HttpContext.Session.SetInt32("FlMedicamentoI", 0);
            HttpContext.Session.SetInt32("FlMedicamentoC", 0);
            HttpContext.Session.SetInt32("FlMedicamentoA", 0);
            HttpContext.Session.SetInt32("FlMedicamentoE", 0);

            HttpContext.Session.SetInt32("FlExamesI", 0);
            HttpContext.Session.SetInt32("FlExamesC", 0);
            HttpContext.Session.SetInt32("FlExamesA", 0);
            HttpContext.Session.SetInt32("FlExamesE", 0);
        }
    }
}
