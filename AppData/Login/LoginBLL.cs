using System;
using System.Collections.Generic;
using System.Web;
using SGCM.Models.Account;
using SGCM.AppData.Login;

namespace SGCM.AppData.Login { 
    public class LoginBLL {

        public LoginTO EfetuarLogin(LoginViewModel Usuario) {
            if (Usuario.Equals(null)) {
                return null;
            } else if (Usuario.Username.Equals("")) {
                return null;
            } else if (Usuario.Password.Equals("")) {
                return null;
            } else {
                LoginDAL loginDAl = new LoginDAL();
                return loginDAl.EfetuarLogin(Usuario);
            }
        }
    }
}