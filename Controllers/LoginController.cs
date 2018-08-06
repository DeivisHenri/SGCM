﻿using SGCM.Models.Account;
using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using SGCM.AppData.Login;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SGCM.Controllers {

    public class LoginController : Controller {

        //GET: /Login/Signin
        [HttpGet]
        public ActionResult Signin()
        {
            ViewBag.Title = "Login";

            return View();
        }

        // POST: /Login/Signin
        [HttpPost]
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

                if (!(retorno.ID != 0)) {
                    ModelState.AddModelError(string.Empty, "Usuário não encontrado!");
                    return View(model);
                } else {
                    CarregarDadosUsuarioParaSession(retorno);
                    
                    return Redirect("/Home/Index");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }

        private void CarregarDadosUsuarioParaSession(LoginTO loginTO)
        {
            HttpContext.Session.SetInt32("ID", loginTO.ID);
            HttpContext.Session.SetString("Username", loginTO.username);
            HttpContext.Session.SetString("Password", loginTO.password);
            HttpContext.Session.SetInt32("TipoUsuario", loginTO.tipoUsuario);

            HttpContext.Session.SetInt32("FlUsuarioI", loginTO.FlUsuarioI);
            HttpContext.Session.SetInt32("FlUsuarioC", loginTO.FlUsuarioC);
            HttpContext.Session.SetInt32("FlUsuarioA", loginTO.FlUsuarioA);
            HttpContext.Session.SetInt32("FlUsuarioE", loginTO.FlUsuarioE);

            HttpContext.Session.SetInt32("FlPacienteI", loginTO.FlPacienteI);
            HttpContext.Session.SetInt32("FlPacienteC", loginTO.FlPacienteC);
            HttpContext.Session.SetInt32("FlPacienteA", loginTO.FlPacienteA);
            HttpContext.Session.SetInt32("FlPacienteE", loginTO.FlPacienteE);

            HttpContext.Session.SetInt32("FlMedicamentoI", loginTO.FlMedicamentoI);
            HttpContext.Session.SetInt32("FlMedicamentoC", loginTO.FlMedicamentoC);
            HttpContext.Session.SetInt32("FlMedicamentoA", loginTO.FlMedicamentoA);
            HttpContext.Session.SetInt32("FlMedicamentoE", loginTO.FlMedicamentoE);

            HttpContext.Session.SetInt32("FlExamesI", loginTO.FlExamesI);
            HttpContext.Session.SetInt32("FlExamesC", loginTO.FlExamesC);
            HttpContext.Session.SetInt32("FlExamesA", loginTO.FlExamesA);
            HttpContext.Session.SetInt32("FlExamesE", loginTO.FlExamesE);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Post([FromBody] LoginViewModel Usuario){
        //    try {
        //        if (ModelState.IsValid) {
        //            var objLoginBLL = new LoginBLL();
        //            var retorno = objLoginBLL.EfetuarLogin(Usuario);

        //            if (retorno == null) {
        //                //return RedirectPermanent("/Home/Index");
        //                return BadRequest(retorno);
        //            } else {
        //                return Ok(retorno);
        //            }
        //        } else {
        //            //return View(model);
        //            return Json(ModelState);
        //        }

        //    }
        //    catch (Exception ex) {
        //        return BadRequest(ex.Message);
        //    }
        //}


        // GET api/Login
        //[HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        //[Route("UserInfo")]
        //public UserInfoViewModel GetUserInfo()
        //{
        //    ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

        //    return new UserInfoViewModel
        //    {
        //        Email = User.Identity.GetUserName(),
        //        HasRegistered = externalLogin == null,
        //        LoginProvider = externalLogin != null ? externalLogin.LoginProvider : null
        //    };
        //}

    }
}



//namespace SGCM.Controllers
//{

//    public class AccountController : ApiController
//    {
//        private const string LocalLoginProvider = "Local";
//        private ApplicationUserManager _userManager;

//        public AccountController()
//        {
//        }

//        public AccountController(ApplicationUserManager userManager,
//            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
//        {
//            UserManager = userManager;
//            AccessTokenFormat = accessTokenFormat;
//        }

//        public ApplicationUserManager UserManager
//        {
//            get
//            {
//                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
//            }
//            private set
//            {
//                _userManager = value;
//            }
//        }

//        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

//        // GET api/Account/UserInfo
//        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
//        [Route("UserInfo")]
//        public UserInfoViewModel GetUserInfo()
//        {
//            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

//            return new UserInfoViewModel
//            {
//                Email = User.Identity.GetUserName(),
//                HasRegistered = externalLogin == null,
//                LoginProvider = externalLogin != null ? externalLogin.LoginProvider : null
//            };
//        }

//        // POST api/Account/Logout
//        [Route("Logout")]
//        public IHttpActionResult Logout()
//        {
//            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
//            return Ok();
//        }

//        // GET api/Account/ManageInfo?returnUrl=%2F&generateState=true
//        [Route("ManageInfo")]
//        public async Task<ManageInfoViewModel> GetManageInfo(string returnUrl, bool generateState = false)
//        {
//            IdentityUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

//            if (user == null)
//            {
//                return null;
//            }

//            List<UserLoginInfoViewModel> logins = new List<UserLoginInfoViewModel>();

//            foreach (IdentityUserLogin linkedAccount in user.Logins)
//            {
//                logins.Add(new UserLoginInfoViewModel
//                {
//                    LoginProvider = linkedAccount.LoginProvider,
//                    ProviderKey = linkedAccount.ProviderKey
//                });
//            }

//            if (user.PasswordHash != null)
//            {
//                logins.Add(new UserLoginInfoViewModel
//                {
//                    LoginProvider = LocalLoginProvider,
//                    ProviderKey = user.UserName,
//                });
//            }

//            return new ManageInfoViewModel
//            {
//                LocalLoginProvider = LocalLoginProvider,
//                Email = user.UserName,
//                Logins = logins,
//                ExternalLoginProviders = GetExternalLogins(returnUrl, generateState)
//            };
//        }

//        // POST api/Account/ChangePassword
//        [Route("ChangePassword")]
//        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword,
//                model.NewPassword);

//            if (!result.Succeeded)
//            {
//                return GetErrorResult(result);
//            }

//            return Ok();
//        }

//        // POST api/Account/SetPassword
//        [Route("SetPassword")]
//        public async Task<IHttpActionResult> SetPassword(SetPasswordBindingModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);

//            if (!result.Succeeded)
//            {
//                return GetErrorResult(result);
//            }

//            return Ok();
//        }

//        // POST api/Account/AddExternalLogin
//        [Route("AddExternalLogin")]
//        public async Task<IHttpActionResult> AddExternalLogin(AddExternalLoginBindingModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

//            AuthenticationTicket ticket = AccessTokenFormat.Unprotect(model.ExternalAccessToken);

//            if (ticket == null || ticket.Identity == null || (ticket.Properties != null
//                && ticket.Properties.ExpiresUtc.HasValue
//                && ticket.Properties.ExpiresUtc.Value < DateTimeOffset.UtcNow))
//            {
//                return BadRequest("Falha no login externo.");
//            }

//            ExternalLoginData externalData = ExternalLoginData.FromIdentity(ticket.Identity);

//            if (externalData == null)
//            {
//                return BadRequest("O login externo já está associado a uma conta.");
//            }

//            IdentityResult result = await UserManager.AddLoginAsync(User.Identity.GetUserId(),
//                new UserLoginInfo(externalData.LoginProvider, externalData.ProviderKey));

//            if (!result.Succeeded)
//            {
//                return GetErrorResult(result);
//            }

//            return Ok();
//        }

//        // POST api/Account/RemoveLogin
//        [Route("RemoveLogin")]
//        public async Task<IHttpActionResult> RemoveLogin(RemoveLoginBindingModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            IdentityResult result;

//            if (model.LoginProvider == LocalLoginProvider)
//            {
//                result = await UserManager.RemovePasswordAsync(User.Identity.GetUserId());
//            }
//            else
//            {
//                result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(),
//                    new UserLoginInfo(model.LoginProvider, model.ProviderKey));
//            }

//            if (!result.Succeeded)
//            {
//                return GetErrorResult(result);
//            }

//            return Ok();
//        }

//        // GET api/Account/ExternalLogin
//        [OverrideAuthentication]
//        [HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
//        [AllowAnonymous]
//        [Route("ExternalLogin", Name = "ExternalLogin")]
//        public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
//        {
//            if (error != null)
//            {
//                return Redirect(Url.Content("~/") + "#error=" + Uri.EscapeDataString(error));
//            }

//            if (!User.Identity.IsAuthenticated)
//            {
//                return new ChallengeResult(provider, this);
//            }

//            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

//            if (externalLogin == null)
//            {
//                return InternalServerError();
//            }

//            if (externalLogin.LoginProvider != provider)
//            {
//                Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
//                return new ChallengeResult(provider, this);
//            }

//            ApplicationUser user = await UserManager.FindAsync(new UserLoginInfo(externalLogin.LoginProvider,
//                externalLogin.ProviderKey));

//            bool hasRegistered = user != null;

//            if (hasRegistered)
//            {
//                Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

//                ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(UserManager,
//                   OAuthDefaults.AuthenticationType);
//                ClaimsIdentity cookieIdentity = await user.GenerateUserIdentityAsync(UserManager,
//                    CookieAuthenticationDefaults.AuthenticationType);

//                AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user.UserName);
//                Authentication.SignIn(properties, oAuthIdentity, cookieIdentity);
//            }
//            else
//            {
//                IEnumerable<Claim> claims = externalLogin.GetClaims();
//                ClaimsIdentity identity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
//                Authentication.SignIn(identity);
//            }

//            return Ok();
//        }

//        // GET api/Account/ExternalLogins?returnUrl=%2F&generateState=true
//        [AllowAnonymous]
//        [Route("ExternalLogins")]
//        public IEnumerable<ExternalLoginViewModel> GetExternalLogins(string returnUrl, bool generateState = false)
//        {
//            IEnumerable<AuthenticationDescription> descriptions = Authentication.GetExternalAuthenticationTypes();
//            List<ExternalLoginViewModel> logins = new List<ExternalLoginViewModel>();

//            string state;

//            if (generateState)
//            {
//                const int strengthInBits = 256;
//                state = RandomOAuthStateGenerator.Generate(strengthInBits);
//            }
//            else
//            {
//                state = null;
//            }

//            foreach (AuthenticationDescription description in descriptions)
//            {
//                ExternalLoginViewModel login = new ExternalLoginViewModel
//                {
//                    Name = description.Caption,
//                    Url = Url.Route("ExternalLogin", new
//                    {
//                        provider = description.AuthenticationType,
//                        response_type = "token",
//                        client_id = Startup.PublicClientId,
//                        redirect_uri = new Uri(Request.RequestUri, returnUrl).AbsoluteUri,
//                        state = state
//                    }),
//                    State = state
//                };
//                logins.Add(login);
//            }

//            return logins;
//        }

//        // POST api/Account/Register
//        [AllowAnonymous]
//        [Route("Register")]
//        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };

//            IdentityResult result = await UserManager.CreateAsync(user, model.Password);

//            if (!result.Succeeded)
//            {
//                return GetErrorResult(result);
//            }

//            return Ok();
//        }

//        // POST api/Account/RegisterExternal
//        [OverrideAuthentication]
//        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
//        [Route("RegisterExternal")]
//        public async Task<IHttpActionResult> RegisterExternal(RegisterExternalBindingModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var info = await Authentication.GetExternalLoginInfoAsync();
//            if (info == null)
//            {
//                return InternalServerError();
//            }

//            var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };

//            IdentityResult result = await UserManager.CreateAsync(user);
//            if (!result.Succeeded)
//            {
//                return GetErrorResult(result);
//            }

//            result = await UserManager.AddLoginAsync(user.Id, info.Login);
//            if (!result.Succeeded)
//            {
//                return GetErrorResult(result);
//            }
//            return Ok();
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && _userManager != null)
//            {
//                _userManager.Dispose();
//                _userManager = null;
//            }

//            base.Dispose(disposing);
//        }

//        #region Auxiliares

//        private IAuthenticationManager Authentication
//        {
//            get { return Request.GetOwinContext().Authentication; }
//        }

//        private IHttpActionResult GetErrorResult(IdentityResult result)
//        {
//            if (result == null)
//            {
//                return InternalServerError();
//            }

//            if (!result.Succeeded)
//            {
//                if (result.Errors != null)
//                {
//                    foreach (string error in result.Errors)
//                    {
//                        ModelState.AddModelError("", error);
//                    }
//                }

//                if (ModelState.IsValid)
//                {
//                    // Nenhum erro ModelState disponível para envio; retorne um BadRequest vazio.
//                    return BadRequest();
//                }

//                return BadRequest(ModelState);
//            }

//            return null;
//        }

//        private class ExternalLoginData
//        {
//            public string LoginProvider { get; set; }
//            public string ProviderKey { get; set; }
//            public string UserName { get; set; }

//            public IList<Claim> GetClaims()
//            {
//                IList<Claim> claims = new List<Claim>();
//                claims.Add(new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider));

//                if (UserName != null)
//                {
//                    claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));
//                }

//                return claims;
//            }

//            public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
//            {
//                if (identity == null)
//                {
//                    return null;
//                }

//                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

//                if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer)
//                    || String.IsNullOrEmpty(providerKeyClaim.Value))
//                {
//                    return null;
//                }

//                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
//                {
//                    return null;
//                }

//                return new ExternalLoginData
//                {
//                    LoginProvider = providerKeyClaim.Issuer,
//                    ProviderKey = providerKeyClaim.Value,
//                    UserName = identity.FindFirstValue(ClaimTypes.Name)
//                };
//            }
//        }

//        private static class RandomOAuthStateGenerator
//        {
//            private static RandomNumberGenerator _random = new RNGCryptoServiceProvider();

//            public static string Generate(int strengthInBits)
//            {
//                const int bitsPerByte = 8;

//                if (strengthInBits % bitsPerByte != 0)
//                {
//                    throw new ArgumentException("strengthInBits deve ser divisível por 8.", "strengthInBits");
//                }

//                int strengthInBytes = strengthInBits / bitsPerByte;

//                byte[] data = new byte[strengthInBytes];
//                _random.GetBytes(data);
//                return HttpServerUtility.UrlTokenEncode(data);
//            }
//        }

//        #endregion
//    }
//}
