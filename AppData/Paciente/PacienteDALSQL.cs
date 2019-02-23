using SGCM.Models.Paciente.EditarPacienteModel;
using System;
using System.Text;

namespace SGCM.AppData.Paciente
{
    public class PacienteDALSQL {

        public string InserirPessoa() {
            StringBuilder command = new StringBuilder();
            command.AppendLine("INSERT INTO Pessoa(idMedico,");
            command.AppendLine("                   nome,");
            command.AppendLine("                   sexo,");
            command.AppendLine("                   cpf,");
            command.AppendLine("                   rg,");
            command.AppendLine("                   dataNascimento,");
            command.AppendLine("                   logradouro,");
            command.AppendLine("                   numero,");
            command.AppendLine("                   bairro,");
            command.AppendLine("                   cidade,");
            command.AppendLine("                   uf,");
            command.AppendLine("                   telefoneCelular,");
            command.AppendLine("                   email)");
            command.AppendLine("       VALUES(@IDMEDICO,");
            command.AppendLine("              @NOME,");
            command.AppendLine("              @SEXO,");
            command.AppendLine("              @CPF,");
            command.AppendLine("              @RG,");
            command.AppendLine("              STR_TO_DATE(@DATANASCIMENTO, '%d/%m/%Y'),");
            command.AppendLine("              @LOGRADOURO,");
            command.AppendLine("              @NUMERO,");
            command.AppendLine("              @BAIRRO,");
            command.AppendLine("              @CIDADE,");
            command.AppendLine("              @UF,");
            command.AppendLine("              @TELEFONECELULAR,");
            command.AppendLine("              @EMAIL); ");

            return command.ToString();
        }

        public string InserirPaciente() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("INSERT INTO Paciente(idPessoaPaciente, idMedicoPaciente, idConsulta, idExame, idMedicamento, idReceita) ");
            command.AppendLine("              VALUES(@IDPESSOA, @IDMEDICO, @IDCONSULTA, @IDEXAME, @IDMEDICAMENTO, @IDRECEITA) ");

            return command.ToString();
        }

        public string ConsultaIdConsulta() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select MAX(idConsulta) As idConsulta");
            command.AppendLine("From paciente;");

            return command.ToString();
        }

        public string ConsultaIdExame() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select MAX(idExame) As idExame");
            command.AppendLine("From paciente;");

            return command.ToString();
        }

        public string ConsultaIdMedicamento() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select MAX(idMedicamento) As idMedicamento");
            command.AppendLine("From paciente;");

            return command.ToString();
        }

        public string ConsultaIdReceita() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select MAX(idReceita) As idReceita");
            command.AppendLine("From paciente;");

            return command.ToString();
        }

        public string ConsultarPaciente() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select Pes.idPessoa, Pes.nome, Pes.cpf, Pes.telefoneCelular, Pac.idPaciente");
            command.AppendLine("From Pessoa Pes RIGHT JOIN Paciente Pac ON Pes.idPessoa = Pac.idPessoaPaciente ");
            command.AppendLine("Where Pes.idMedico = @IDMEDICO");

            return command.ToString();
        }

        public string ConsultarPacienteID() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select Pes.idPessoa,");
            command.AppendLine("       Pes.nome,");
            command.AppendLine("       Pes.cpf,");
            command.AppendLine("       Pes.rg,");
            command.AppendLine("       Pes.sexo,");
            command.AppendLine("       Pes.dataNascimento,");
            command.AppendLine("       Pes.logradouro,");
            command.AppendLine("       Pes.numero,");
            command.AppendLine("       Pes.bairro,");
            command.AppendLine("       Pes.cidade,");
            command.AppendLine("       Pes.uf,");
            command.AppendLine("       Pes.telefoneCelular,");
            command.AppendLine("       Pes.email");
            command.AppendLine("From Pessoa Pes INNER JOIN Paciente Pac ON Pes.idPessoa = Pac.idPessoaPaciente");
            command.AppendLine("Where Pac.idPaciente = @IDPACIENTE");

            return command.ToString();
        }

        public string EditarPessoa(EditarPacienteModel paciente) {
            Boolean flagSet = false;
            StringBuilder command = new StringBuilder();

            command.AppendLine("Update Pessoa");

            if (paciente.pessoa.Sexo != null) {
                command.AppendLine("Set    sexo = @SEXO,");
                flagSet = true;
            }

            if (paciente.pessoa.Nome != null) {
                if (flagSet) {
                    command.AppendLine("       nome = @NOME,");
                } else {
                    command.AppendLine("Set    nome = @NOME,");
                    flagSet = true;
                }
            }

            if (paciente.pessoa.CPF != null) {
                if (flagSet)
                    command.AppendLine("       cpf = @CPF,");
                else {
                    command.AppendLine("Set    cpf = @CPF,");
                    flagSet = true;
                }
            }

            if (paciente.pessoa.RG != null) {
                if (flagSet)
                    command.AppendLine("       rg = @RG,");
                else {
                    command.AppendLine("Set    rg = @RG,");
                    flagSet = true;
                }
            }

            if (paciente.pessoa.DataNascimento != null && paciente.pessoa.DataNascimento != default(DateTime)) {
                if (flagSet)
                    command.AppendLine("       dataNascimento = STR_TO_DATE(@DATANASCIMENTO, '%d/%m/%Y'),");
                else {
                    command.AppendLine("Set    dataNascimento = STR_TO_DATE(@DATANASCIMENTO, '%d/%m/%Y'),");
                    flagSet = true;
                }
            }

            if (paciente.pessoa.Logradouro != null) {
                if (flagSet)
                    command.AppendLine("       logradouro = @LOGRADOURO,");
                else {
                    command.AppendLine("Set    logradouro = @LOGRADOURO,");
                    flagSet = true;
                }
            }

            if (paciente.pessoa.Numero != 0) {
                if (flagSet)
                    command.AppendLine("       numero = @NUMERO,");
                else {
                    command.AppendLine("Set    numero = @NUMERO,");
                    flagSet = true;
                }
            }

            if (paciente.pessoa.Bairro != null) {
                if (flagSet)
                    command.AppendLine("       bairro = @BAIRRO,");
                else {
                    command.AppendLine("Set    bairro = @BAIRRO,");
                    flagSet = true;
                }
            }

            if (paciente.pessoa.Cidade != null) {
                if (flagSet)
                    command.AppendLine("       cidade = @CIDADE,");
                else {
                    command.AppendLine("Set    cidade = @CIDADE,");
                    flagSet = true;
                }
            }

            if (paciente.pessoa.Uf != null) {
                if (flagSet)
                    command.AppendLine("       uf = @UF,");
                else {
                    command.AppendLine("Set    uf = @UF,");
                    flagSet = true;
                }
            }

            if (paciente.pessoa.TelefoneCelular != null) {
                if (flagSet)
                    command.AppendLine("       telefoneCelular = @TELEFONECELULAR,");
                else {
                    command.AppendLine("Set    telefoneCelular = @TELEFONECELULAR,");
                    flagSet = true;
                }
            }

            if (paciente.pessoa.Email != null) {
                if (flagSet)
                    command.AppendLine("       email = @EMAIL,");
                else {
                    command.AppendLine("Set    email = @EMAIL,");
                    flagSet = true;
                }
            }
            command = new StringBuilder(command.ToString().Remove(command.Length - 3, 3));
            command.AppendLine(" Where idPessoa = @IDPESSOA");
            return command.ToString();
        }
    }
}
