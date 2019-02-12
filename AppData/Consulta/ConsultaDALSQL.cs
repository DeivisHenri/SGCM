using SGCM.Models.Consulta.CadastroConsultaModel;
using SGCM.Models.Consulta.EditarConsultaModel;
using System;
using System.Text;

namespace SGCM.AppData.Consulta {
    public class ConsultaDALSQL {
        public string ConsultarPacienteNome(string nome, string cpf, int? idPaciente) {
            Boolean flag = false;
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select Pac.idPaciente, Pes.nome, Pes.cpf");
            command.AppendLine("From Pessoa Pes INNER JOIN Paciente Pac ON Pes.idPessoa = Pac.idPessoaPaciente");

            if (nome != null) {
                command.AppendLine("Where UPPER(Pes.nome) like UPPER(@NOME)");
                flag = true;
            }

            if (cpf != null && flag == false) {
                command.AppendLine("Where Pes.cpf = @CPF ");
            } else if (cpf != null && flag == true) {
                command.AppendLine("AND Pes.cpf = @CPF ");
            }

            if (idPaciente != null && flag == false) {
                command.AppendLine("Where Pac.idPaciente = @IDPACIENTE ");
            } else if (idPaciente != null && flag == true) {
                command.AppendLine("AND Pac.idPaciente = @IDPACIENTE ");
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

        public string ConsultarConsultas()
        {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select Pac.idPaciente, Pes.nome, Con.idConsulta, Con.idPacienteConsulta, Con.dataConsulta");
            command.AppendLine("From pessoa Pes INNER JOIN paciente Pac ON Pes.idPessoa = Pac.idPessoaPaciente ");
            command.AppendLine("     INNER JOIN consulta Con ON Pac.idPaciente = Con.idPacienteConsulta");
            command.AppendLine("Where (dataConsulta BETWEEN @DATAINICIAL AND @DATAFINAL)");

            return command.ToString();
        }

        public string ConsultarConsulta() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select Pes.nome, Pac.idPaciente, Pes.cpf, Con.dataConsulta, Con.idConsulta");
            command.AppendLine("From pessoa as Pes INNER JOIN paciente Pac ON Pes.idPessoa = Pac.idPessoaPaciente ");
            command.AppendLine("     INNER JOIN consulta Con ON Pac.idPaciente = Con.idPacienteConsulta");
            command.AppendLine("Where Con.idConsulta = @IDCONSULTA");

            return command.ToString();
        }

        public string EditarConsulta(EditarConsultaModel consulta) {
            StringBuilder command = new StringBuilder();
            Boolean flag = false;

            command.AppendLine("Update consulta");
            if (consulta.paciente.idPaciente != 0) {
                command.AppendLine("Set idPacienteConsulta = @IDPACIENTECONSULTA,");
                flag = true;
            }

            if (consulta.consulta.DataConsulta != default(DateTime) && flag == true) {
                command.AppendLine("	dataConsulta = STR_TO_DATE(@DATACONSULTA, '%d/%m/%Y %h:%i:%s')");
            } else if (consulta.consulta.DataConsulta != null && flag == false) {
                command.AppendLine("Set dataConsulta = @DATACONSULTA");
            }

            command.AppendLine("Where idConsulta = @IDCONSULTA");

            return command.ToString();
        }
    }
}
