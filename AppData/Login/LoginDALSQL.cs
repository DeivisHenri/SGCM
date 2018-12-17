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
            command.AppendLine("Select Usu.Id_Usuario,");
            command.AppendLine("       Usu.Username,");
            command.AppendLine("       Usu.Password,");

            command.AppendLine("       Pes.Id_Pessoa,");
            command.AppendLine("       Pes.Id_Medico,");
            command.AppendLine("       Pes.Nome,");
            command.AppendLine("       Pes.Cpf,");
            command.AppendLine("       Pes.Estado,");
            command.AppendLine("       Pes.Cidade,");
            command.AppendLine("       Pes.Bairro,");
            command.AppendLine("       Pes.Endereco,");
            command.AppendLine("       Pes.Numero,");
            command.AppendLine("       Pes.Telefone_Celular,");
            command.AppendLine("       Pes.Email,");
            command.AppendLine("       Pes.Tipo_Usuario,");

            command.AppendLine("       Per.Id_Permissoes,");
            command.AppendLine("       Per.Id_Usuario,");
            command.AppendLine("       Per.Fl_Usuario_I,");
            command.AppendLine("       Per.Fl_Usuario_C,");
            command.AppendLine("       Per.Fl_Usuario_A,");
            command.AppendLine("       Per.Fl_Usuario_E,");
            command.AppendLine("       Per.Fl_Paciente_I,");
            command.AppendLine("       Per.Fl_Paciente_C,");
            command.AppendLine("       Per.Fl_Paciente_A,");
            command.AppendLine("       Per.Fl_Paciente_E,");
            command.AppendLine("       Per.Fl_Consulta_I,");
            command.AppendLine("       Per.Fl_Consulta_C,");
            command.AppendLine("       Per.Fl_Consulta_A,");
            command.AppendLine("       Per.Fl_Consulta_E,");
            command.AppendLine("       Per.Fl_Medicamento_I,");
            command.AppendLine("       Per.Fl_Medicamento_C,");
            command.AppendLine("       Per.Fl_Medicamento_A,");
            command.AppendLine("       Per.Fl_Medicamento_E,");
            command.AppendLine("       Per.Fl_Exames_I,");
            command.AppendLine("       Per.Fl_Exames_C,");
            command.AppendLine("       Per.Fl_Exames_A,");
            command.AppendLine("       Per.Fl_Exames_E,");
            command.AppendLine("       Usu.DatDst");

            command.AppendLine("From[dbo].[Usuario] Usu INNER JOIN [dbo].[Pessoa] Pes ON Usu.Id_Pessoa = Pes.Id_Pessoa INNER JOIN[dbo].[Permissoes] Per ON Usu.Id_Usuario = Per.Id_Usuario");
            command.AppendLine("Where username = @USERNAME AND password = @PASSWORD");
            return command.ToString();
        }

    }
}