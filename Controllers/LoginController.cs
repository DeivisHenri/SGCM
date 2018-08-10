using SGCM.Models;
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
using System.Data.SqlClient;
using static SGCM.AppData.Infraestrutura.UtilObjetos.UtilObjetos;
using SGCM.Models.Account;

namespace SGCM.Controllers {

    public class LoginController : Controller {

        //GET: /Login/Signin
        [HttpGet]
        public ActionResult Signin(string returnUrl = null)
        {
            CarregarDadosUsuarioParaTela();
            if ((ViewBag.ID == null) || (ViewBag.ID == 0))
            {
                ViewBag.Title = "Login";
                return View();
            } else {
                HttpContext.Session.SetString("MensagemErro", "Você já está logado no sistema! Para entrar com outra conta, saia primeiro dessa!");
                HttpContext.Session.SetInt32("FlMensagemErro", 1);
                return RedirectToAction("Index", "Home");
            }
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

                if (!(retorno.usuarioTO.ID_Usuario != 0)) {
                    ModelState.AddModelError(string.Empty, "Usuário não encontrado!");
                    return View(model);
                } else {
                    CarregarDadosUsuarioParaSession(retorno);
                    
                    return Redirect("/Home/Index");
                }
            } catch (SqlException exSQL) {
                ModelState.AddModelError(string.Empty, "Não foi possivel estabelecer uma conexão com o banco de dados!");
                return View(model);
            }
            catch (Exception ex) {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
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
