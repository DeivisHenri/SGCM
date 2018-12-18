using System;
using System.Collections.Generic;
using System.Web;
using SGCM.Models.Account;
using SGCM.AppData.Login;
using SGCM.AppData.Usuario;

namespace SGCM.AppData.Login { 
    public class LoginBLL {
        public UsuarioCompletoTO EfetuarLogin(LoginViewModel Usuario) {
            LoginDAL loginDAl = new LoginDAL();
            return loginDAl.EfetuarLogin(Usuario);
        }

        public UsuarioCompletoTO BuscarDadosUsuario(string usuarioCookie)
        {
            LoginDAL loginDAl = new LoginDAL();
            return loginDAl.BuscarDadosUsuario(usuarioCookie);
        }
    }
}