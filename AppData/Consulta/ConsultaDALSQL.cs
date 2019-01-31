using SGCM.Models.Consulta.CadastroConsultaModel;
using SGCM.Models.Paciente.EditarPacienteModel;
using System;
using System.Text;

namespace SGCM.AppData.Consulta {
    public class ConsultaDALSQL {
        public string ConsultarPacienteNome(string nome, string cpf) {
            Boolean flag = false;
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select Pac.idPaciente, Pes.nome, Pes.cpf");
            command.AppendLine("From Pessoa Pes INNER JOIN Paciente Pac ON Pes.idPessoa = Pac.idPessoaPaciente");

            if (nome != null) {
                //command.AppendLine("Where UPPER(Pes.nome) like UPPER('%" + nome + "%')");
                command.AppendLine("Where UPPER(Pes.nome) like UPPER(@NOME)");
                flag = true;
            }

            if (cpf != null && flag == false) {
                command.AppendLine("Where Pes.cpf = @CPF ");
            } else if (cpf != null && flag == true) {
                command.AppendLine("AND Pes.cpf = @CPF ");
            }

            return command.ToString();
        }

        public string CadastrarConsulta(CadastroConsultaModel model) {
            StringBuilder command = new StringBuilder();

            command.AppendLine("INSERT INTO consulta(idPacienteConsulta, dataConsulta)");

            if (model.consulta.flagPM) command.AppendLine("VALUES(@IDPACIENTECONSULTA, STR_TO_DATE(@DATACONSULTA @FLAGPM, '%d/%m/%Y %h:%i:%s %p'))");
            else command.AppendLine("VALUES(@IDPACIENTECONSULTA, STR_TO_DATE(@DATACONSULTA, '%d/%m/%Y %h:%i:%s'))");

            return command.ToString();
        }

        public string verificaConsultaCadastrada(CadastroConsultaModel model)
        {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select *");
            command.AppendLine("From consulta");
            if (model.consulta.flagPM) command.AppendLine("Where dataConsulta = STR_TO_DATE(@DATACONSULTA @FLAGPM, '%d/%m/%Y %h:%i:%s %p')");
            else command.AppendLine("Where dataConsulta = STR_TO_DATE(@DATACONSULTA, '%Y-%m-%d %h:%i:%s')");

            return command.ToString();
        }
    }
}
