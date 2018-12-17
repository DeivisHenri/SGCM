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

            command.AppendLine("Select Usu.idUsuario,");
            command.AppendLine("       Usu.usuario,");

            command.AppendLine("       Pes.idPessoa,");
            command.AppendLine("       Pes.idMedico,");
            command.AppendLine("       Pes.tipoUsuario,");
            command.AppendLine("       Pes.nome,");
            command.AppendLine("       Pes.cpf,");
            command.AppendLine("       Pes.rg,");
            command.AppendLine("       Pes.dataNascimento,");
            command.AppendLine("       Pes.logradouro,");
            command.AppendLine("       Pes.numero,");
            command.AppendLine("       Pes.bairro,");
            command.AppendLine("       Pes.cidade,");
            command.AppendLine("       Pes.uf,");
            command.AppendLine("       Pes.telefoneCelular,");
            command.AppendLine("       Pes.email,");

            command.AppendLine("       Per.IdPermissoes,");
            command.AppendLine("       Per.FlUsuarioI,");
            command.AppendLine("       Per.FlUsuarioC,");
            command.AppendLine("       Per.FlUsuarioA,");
            command.AppendLine("       Per.FlUsuarioE,");
            command.AppendLine("       Per.FlPacienteI,");
            command.AppendLine("       Per.FlPacienteC,");
            command.AppendLine("       Per.FlPacienteA,");
            command.AppendLine("       Per.FlPacienteE,");
            command.AppendLine("       Per.FlConsultaI,");
            command.AppendLine("       Per.FlConsultaC,");
            command.AppendLine("       Per.FlConsultaA,");
            command.AppendLine("       Per.FlConsultaE,");
            command.AppendLine("       Per.FlMedicamentoI,");
            command.AppendLine("       Per.FlMedicamentoC,");
            command.AppendLine("       Per.FlMedicamentoA,");
            command.AppendLine("       Per.FlMedicamentoE,");
            command.AppendLine("       Per.FlExamesI,");
            command.AppendLine("       Per.FlExamesC,");
            command.AppendLine("       Per.FlExamesA,");
            command.AppendLine("       Per.flExamesE,");
            command.AppendLine("       Usu.dataDesativacao");

            command.AppendLine("From Usuario Usu INNER JOIN Pessoa Pes ON Usu.idPessoa = Pes.idPessoa");
            command.AppendLine("     INNER JOIN Permissoes Per ON Usu.idUsuario = Per.idUsuario");
            command.AppendLine("Where Usu.usuario = 'deivis' AND Usu.senha = 'deivis' AND Usu.dataDesativacao is null");
            return command.ToString();
        }

    }
}