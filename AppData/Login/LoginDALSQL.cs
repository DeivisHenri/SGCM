using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SGCM.Models.Account;

namespace SGCM.AppData.Login {

    public class LoginDALSQL {

        public string EfetuarLogin() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select Usr.idUsuario,");
            command.AppendLine("       Usr.usuario,");
            
            command.AppendLine("       Pes.idPessoa,");
            command.AppendLine("       Pes.idMedico,");
            command.AppendLine("       Usr.tipoUsuario,");
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

            command.AppendLine("       Per.flUsuarioI,");
            command.AppendLine("       Per.flUsuarioC,");
            command.AppendLine("       Per.flUsuarioA,");
            command.AppendLine("       Per.flUsuarioE,");

            command.AppendLine("       Per.flPacienteI,");
            command.AppendLine("       Per.flPacienteC,");
            command.AppendLine("       Per.flPacienteA,");
            command.AppendLine("       Per.flPacienteE,");
                                           
            command.AppendLine("       Per.flConsultaI,");
            command.AppendLine("       Per.flConsultaC,");
            command.AppendLine("       Per.flConsultaA,");
            command.AppendLine("       Per.flConsultaE,");
                                           
            command.AppendLine("       Per.flAusenciaI,");
            command.AppendLine("       Per.flAusenciaC,");
            command.AppendLine("       Per.flAusenciaA,");
            command.AppendLine("       Per.flAusenciaE,");
                                           
            command.AppendLine("       Per.flMedicamentoI,");
            command.AppendLine("       Per.flMedicamentoC,");
            command.AppendLine("       Per.flMedicamentoA,");
            command.AppendLine("       Per.flMedicamentoE,");
                                           
            command.AppendLine("       Per.flExamesI,");
            command.AppendLine("       Per.flExamesC,");
            command.AppendLine("       Per.flExamesA,");
            command.AppendLine("       Per.flExamesE,");

            command.AppendLine("       Per.flHistoriaMolestiaAtualI,");
            command.AppendLine("       Per.flHistoriaMolestiaAtualC,");
            command.AppendLine("       Per.flHistoriaMolestiaAtualA,");
            command.AppendLine("       Per.flHistoriaMolestiaAtualE,");

            command.AppendLine("       Per.flHistoriaPatologicaPregressaI,");
            command.AppendLine("       Per.flHistoriaPatologicaPregressaC,");
            command.AppendLine("       Per.flHistoriaPatologicaPregressaA,");
            command.AppendLine("       Per.flHistoriaPatologicaPregressaE,");

            command.AppendLine("       Per.flHipoteseDiagnosticaI,");
            command.AppendLine("       Per.flHipoteseDiagnosticaC,");
            command.AppendLine("       Per.flHipoteseDiagnosticaA,");
            command.AppendLine("       Per.flHipoteseDiagnosticaE,");

            command.AppendLine("       Per.flCondutaI,");
            command.AppendLine("       Per.flCondutaC,");
            command.AppendLine("       Per.flCondutaA,");
            command.AppendLine("       Per.flCondutaE,");
            command.AppendLine("       Per.flIniciarAtendimento,");
            command.AppendLine("       Usr.statusDesativacao");
                 
            command.AppendLine("From Usuario Usr INNER JOIN Pessoa Pes ON Usr.idPessoaUsuario = Pes.idPessoa");
            command.AppendLine("     INNER JOIN Permissoes Per ON Usr.idUsuario = Per.idUsuarioPermissoes");
            command.AppendLine("Where Usr.usuario = @USUARIO AND Usr.senha = @SENHA");
            return command.ToString();
        }

        public string BuscarDadosUsuario()
        {
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
            command.AppendLine("       Usu.statusDesativacao");

            command.AppendLine("From Usuario Usu INNER JOIN Pessoa Pes ON Usu.idPessoa = Pes.idPessoa");
            command.AppendLine("     INNER JOIN Permissoes Per ON Usu.idUsuario = Per.idUsuario");
            command.AppendLine("Where Usu.usuario = @USUARIO AND Usu.statusDesativacao != 2");
            return command.ToString();
        }

    }
}