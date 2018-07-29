using SGCM.Models;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGCM.AppData.Login {

    public class LoginDALSQL {

        public string EfetuarLogin(EfetuarLoginModel usuario) {
            StringBuilder command = new StringBuilder();
            command.AppendLine("Select ID, username, password");
            command.AppendLine("From [dbo].[Usuario]");
            command.AppendLine("Where username = '" + usuario.username + "' AND password = '" + usuario.password + "'");

            return command.ToString();
        }

    }
}