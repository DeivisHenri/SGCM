using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCM.AppData.PDF {
    public class PDFDALSQL {

        public string ConsultarDadosExamePreencherPDF() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select pes.nome,");
            command.AppendLine("       pes.rg,");
            command.AppendLine("       pes.dataNascimento,");
            command.AppendLine("       con.dataConsulta,");
            command.AppendLine("       basNomExa.baseNomeExame");
            command.AppendLine("From pessoa pes INNER JOIN paciente pac ON pes.idPessoa = pac.idPessoaPaciente");
            command.AppendLine("     INNER JOIN consulta con ON con.idPacienteConsulta = pac.idConsulta");
            command.AppendLine("     INNER JOIN examepedido exaPed ON exaPed.idConsultaExamePedido = con.idConsulta");
            command.AppendLine("     INNER JOIN basenomeexame basNomExa ON basNomExa.idBaseNomeExame = exaPed.idBaseNomeExameExamePedido");
            command.AppendLine("Where con.idConsulta = @IDCONSULTA AND basNomExa.idBaseNomeExame = @IDBASENOMEEXAME");

            return command.ToString();
        }

        public string ConsultarDadosMedicamentoPreencherPDF() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select pes.nome,");
            command.AppendLine("       pes.rg,");
            command.AppendLine("       pes.dataNascimento,");
            command.AppendLine("       con.dataConsulta,");
            command.AppendLine("       med.nomeGenerico,");
            command.AppendLine("       med.nomeFabrica");
            command.AppendLine("From pessoa pes INNER JOIN paciente pac ON pes.idPessoa = pac.idPessoaPaciente");
            command.AppendLine("     INNER JOIN consulta con ON con.idPacienteConsulta = pac.idConsulta");
            command.AppendLine("     INNER JOIN consulta_medicamento conMed ON conMed.idConsultaConsulta_Medicamento = con.idConsulta");
            command.AppendLine("     INNER JOIN medicamento med ON med.idMedicamento = conMed.idMedicamentoConsulta_Medicamento");
            command.AppendLine("Where con.idConsulta = @IDCONSULTA AND conMed.idMedicamentoConsulta_Medicamento = @IDMEDICAMENTOCONSULTA_MEDICAMENTO");

            return command.ToString();
        }

        public string ConsultarDadosPacientePreencherPDF() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select pes.nome,");
            command.AppendLine("       pes.rg,");
            command.AppendLine("       pes.dataNascimento,");
            command.AppendLine("       con.dataConsulta,");
            command.AppendLine("       con.consultaFinalizada");
            command.AppendLine("From pessoa pes INNER JOIN paciente pac ON pes.idPessoa = pac.idPessoaPaciente");
            command.AppendLine("     INNER JOIN consulta con ON con.idPacienteConsulta = pac.idPaciente");
            command.AppendLine("Where pac.idPaciente = @IDPACIENTE");

            return command.ToString();
        }
    }
}