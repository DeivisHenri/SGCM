using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SGCM.Models.Account;

namespace SGCM.AppData.Login {

    public class LoginDALSQL {

        public string EfetuarLogin(LoginViewModel usuario) {
            StringBuilder command = new StringBuilder();
            command.AppendLine("Select id, username, password, tipoUsuario,");
            command.AppendLine("       fl_Usuario_I,     fl_Usuario_C,     fl_Usuario_A,     fl_Usuario_E,");
            command.AppendLine("       fl_Paciente_I,    fl_Paciente_C,    fl_Paciente_A,    fl_Paciente_E,");
            command.AppendLine("       fl_Medicamento_I, fl_Medicamento_C, fl_Medicamento_A, fl_Medicamento_E,");
            command.AppendLine("       fl_Exames_I,      fl_Exames_C,      fl_Exames_A,      fl_Exames_E");
            command.AppendLine("From [dbo].[Usuario]");
            command.AppendLine("Where username = '" + usuario.Username + "' AND password = '" + usuario.Password + "'");

            return command.ToString();
        }

    }
}