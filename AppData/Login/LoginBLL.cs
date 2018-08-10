using System;
using System.Collections.Generic;
using System.Web;
using SGCM.Models.Account;
using SGCM.AppData.Login;

namespace SGCM.AppData.Login { 
    public class LoginBLL {

        public Infraestrutura.UtilObjetos.UtilObjetos.UsuarioCompletoTO EfetuarLogin(LoginViewModel Usuario) {
            LoginDAL loginDAl = new LoginDAL();
            return loginDAl.EfetuarLogin(Usuario);
        }
    }
}