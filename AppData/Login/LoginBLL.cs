using SGCM.Models;
using System;
using System.Collections.Generic;
using System.Web;
using SGCM.AppData.Login;

namespace SGCM.AppData.Login { 
    public class LoginBLL {

        public LoginTO EfetuarLogin(EfetuarLoginModel Usuario) {
            if (Usuario.Equals(null)) {
                return null;
            } else if (Usuario.username.Equals("")) {
                return null;
            } else if (Usuario.password.Equals("")) {
                return null;
            } else {
                LoginDAL loginDAl = new LoginDAL();
                return loginDAl.EfetuarLogin(Usuario);
            }
        }
    }
}