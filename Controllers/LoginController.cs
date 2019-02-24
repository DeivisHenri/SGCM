using System;
using Microsoft.AspNetCore.Mvc;
using SGCM.AppData.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using SGCM.AppData.Usuario;
using SGCM.Models.Account;
using SGCM.Models.UserMessage;
using MySql.Data.MySqlClient;

namespace SGCM.Controllers {

    public class LoginController : Controller {

        //GET: /Login/Signin
        [HttpGet]
        public ActionResult Signin(string returnUrl = null) {
            try {
                if (returnUrl != null) ViewData.Add("ReturnUrl", returnUrl);
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] == null) || ((int)ViewData["idUsuario"] == 0)) {
                    var usuarioCookie = getCookie("usuario");
                    if (usuarioCookie != null) {
                        var objLoginBLL = new LoginBLL();
                        var retorno = objLoginBLL.BuscarDadosUsuario(usuarioCookie);
                        CarregarDadosUsuarioParaSession(retorno);
                        CarregarDadosUsuarioParaTela();

                        if ((ViewData["ReturnUrl"] != null) && (ViewData["ReturnUrl"].ToString() != "")) {
                            return Redirect("/" + returnUrl);
                        } else {
                            return Redirect("/Home/Index");
                        }
                    } else {
                        if ((HttpContext.Session.GetString("UserMessage") != null) && (HttpContext.Session.GetString("UserMessage") != "")) {
                            ViewData["UserMessage"] = new UserMessage { title = "Erro", userMessage = HttpContext.Session.GetString("UserMessage"), cssClassName = "alert-error" };
                            HttpContext.Session.SetString("UserMessage", "");
                        }
                        ViewData["Title"] = "Login";
                        return View();
                    }
                } else {
                    if ((ViewData["ReturnUrl"] != null) && (ViewData["ReturnUrl"].ToString() != "")){
                        return Redirect("/" + returnUrl);
                    } else {
                        return Redirect("/Home/Index");
                    }
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: LoginController";
                ViewBag.MensagemBodyAction = "Action: Signin - GET";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
            
        }

        // POST: /Login/Signin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signin(LoginViewModel model, string returnUrl = null) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                if (!ModelState.IsValid) return View(model);

                var objLoginBLL = new LoginBLL();
                var retorno = objLoginBLL.EfetuarLogin(model);

                if (model.RememberMe) setCookie(model);

                if (retorno.IdRetorno == 1) {
                    ViewBag.MensagemTitle = "Erro";
                    ViewBag.MensagemBody = "Usuário " + model.Username + " está desativado!";
                    return View(model);
                } else if (retorno.IdRetorno == 2) {
                    ViewBag.MensagemTitle = "Erro";
                    ViewBag.MensagemBody = "Usuário ou senha inválido!";
                    return View();
                } else {
                    ViewBag.MensagemTitle = "Sucesso";
                    ViewBag.MensagemBody = "Login realizado com sucesso, redirecionando a página...";
                    CarregarDadosUsuarioParaSession(retorno);
                    if (returnUrl != null) {
                        return Redirect("/" + returnUrl);
                    } else {
                        return Redirect("/Home/Index");
                    }
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: LoginController";
                ViewBag.MensagemBodyAction = "Action: Signin/{LOGIN} - POST";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
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

            HttpContext.Session.SetInt32("flAusenciaI", usuarioCompletoTO.permissoesTO.flAusenciaI);
            HttpContext.Session.SetInt32("flAusenciaC", usuarioCompletoTO.permissoesTO.flAusenciaC);
            HttpContext.Session.SetInt32("flAusenciaA", usuarioCompletoTO.permissoesTO.flAusenciaA);
            HttpContext.Session.SetInt32("flAusenciaE", usuarioCompletoTO.permissoesTO.flAusenciaE);

            HttpContext.Session.SetInt32("flMedicamentoI", usuarioCompletoTO.permissoesTO.flMedicamentoI);
            HttpContext.Session.SetInt32("flMedicamentoC", usuarioCompletoTO.permissoesTO.flMedicamentoC);
            HttpContext.Session.SetInt32("flMedicamentoA", usuarioCompletoTO.permissoesTO.flMedicamentoA);
            HttpContext.Session.SetInt32("flMedicamentoE", usuarioCompletoTO.permissoesTO.flMedicamentoE);

            HttpContext.Session.SetInt32("flExamesI", usuarioCompletoTO.permissoesTO.flExamesI);
            HttpContext.Session.SetInt32("flExamesC", usuarioCompletoTO.permissoesTO.flExamesC);
            HttpContext.Session.SetInt32("flExamesA", usuarioCompletoTO.permissoesTO.flExamesA);
            HttpContext.Session.SetInt32("flExamesE", usuarioCompletoTO.permissoesTO.flExamesE);

            HttpContext.Session.SetInt32("flHistoriaMolestiaAtualI", usuarioCompletoTO.permissoesTO.flHistoriaMolestiaAtualI);
            HttpContext.Session.SetInt32("flHistoriaMolestiaAtualC", usuarioCompletoTO.permissoesTO.flHistoriaMolestiaAtualC);
            HttpContext.Session.SetInt32("flHistoriaMolestiaAtualA", usuarioCompletoTO.permissoesTO.flHistoriaMolestiaAtualA);
            HttpContext.Session.SetInt32("flHistoriaMolestiaAtualE", usuarioCompletoTO.permissoesTO.flHistoriaMolestiaAtualE);

            HttpContext.Session.SetInt32("flHistoriaPatologicaPregressaI", usuarioCompletoTO.permissoesTO.flHistoriaPatologicaPregressaI);
            HttpContext.Session.SetInt32("flHistoriaPatologicaPregressaC", usuarioCompletoTO.permissoesTO.flHistoriaPatologicaPregressaC);
            HttpContext.Session.SetInt32("flHistoriaPatologicaPregressaA", usuarioCompletoTO.permissoesTO.flHistoriaPatologicaPregressaA);
            HttpContext.Session.SetInt32("flHistoriaPatologicaPregressaE", usuarioCompletoTO.permissoesTO.flHistoriaPatologicaPregressaE);

            HttpContext.Session.SetInt32("flHipoteseDiagnosticaI", usuarioCompletoTO.permissoesTO.flHipoteseDiagnosticaI);
            HttpContext.Session.SetInt32("flHipoteseDiagnosticaC", usuarioCompletoTO.permissoesTO.flHipoteseDiagnosticaC);
            HttpContext.Session.SetInt32("flHipoteseDiagnosticaA", usuarioCompletoTO.permissoesTO.flHipoteseDiagnosticaA);
            HttpContext.Session.SetInt32("flHipoteseDiagnosticaE", usuarioCompletoTO.permissoesTO.flHipoteseDiagnosticaE);

            HttpContext.Session.SetInt32("flCondutaI", usuarioCompletoTO.permissoesTO.flCondutaI);
            HttpContext.Session.SetInt32("flCondutaC", usuarioCompletoTO.permissoesTO.flCondutaC);
            HttpContext.Session.SetInt32("flCondutaA", usuarioCompletoTO.permissoesTO.flCondutaA);
            HttpContext.Session.SetInt32("flCondutaE", usuarioCompletoTO.permissoesTO.flCondutaE);
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

        public void setCookie(LoginViewModel model)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(1440);
            Response.Cookies.Append("usuario", model.Username, option);
            Response.Cookies.Append("senha", model.Password, option);
        }

        public string getCookie(string key)
        {
            return Request.Cookies[key];
        }

        public void removeCookie(string key)
        {
            Response.Cookies.Delete(key);
        }

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
