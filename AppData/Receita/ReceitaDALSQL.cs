using SGCM.Models.Consulta.CadastroConsultaModel;
using SGCM.Models.Consulta.EditarConsultaModel;
using System;
using System.Text;

namespace SGCM.AppData.Receita {

    public class ReceitaDALSQL
    {
        public string ConsultarMedicamento(int sortMedicamento)
        {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select con.idConsulta,");
            command.AppendLine("	   con.idPacienteConsulta,");
            command.AppendLine("       con.dataConsulta,");
            command.AppendLine("       conMed.idConsulta_Medicamento,");
            command.AppendLine("       med.idMedicamento,");
            command.AppendLine("       med.nomeGenerico,");
            command.AppendLine("       med.nomeFabrica,");
            command.AppendLine("       med.fabricante");
            command.AppendLine("From consulta con INNER JOIN consulta_medicamento conMed ON con.idConsulta = conMed.idConsultaConsulta_Medicamento");
            command.AppendLine("	 INNER JOIN medicamento med ON med.idMedicamento = conMed.idMedicamentoConsulta_Medicamento");
            command.AppendLine("Where con.idConsulta = @IDCONSULTA");

            switch (sortMedicamento) {
                case 1:
                    command.AppendLine("Order By nomeGenerico ASC");
                    break;
                case 2:
                    command.AppendLine("Order By nomeGenerico DESC");
                    break;
                case 3:
                    command.AppendLine("Order By nomeFabrica ASC");
                    break;
                case 4:
                    command.AppendLine("Order By nomeFabrica DESC");
                    break;
            }

            return command.ToString();
        }

        public string ConsultarExame(int sortExame)
        {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select con.idConsulta,");
            command.AppendLine("       con.idPacienteConsulta,");
            command.AppendLine("       con.dataConsulta,");
            command.AppendLine("       exmPed.idBaseNomeExameExamePedido,");
            command.AppendLine("       base.baseNomeExame");
            command.AppendLine("From consulta con INNER JOIN examepedido exmPed ON con.idConsulta = exmPed.idConsultaExamePedido");
            command.AppendLine("     INNER JOIN basenomeexame base ON base.idBaseNomeExame = exmPed.idBaseNomeExameExamePedido");
            command.AppendLine("Where con.idConsulta = @IDCONSULTA");

            switch (sortExame) {
                case 1:
                    command.AppendLine("Order By base.baseNomeExame ASC");
                    break;
                case 2:
                    command.AppendLine("Order By base.baseNomeExame DESC");
                    break;
            }

            return command.ToString();
        }

        public string ConsultaPaciente()
        {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select pes.nome");
            command.AppendLine("From paciente pac INNER JOIN pessoa pes ON pac.idPessoaPaciente = pes.idPessoa");
            command.AppendLine("Where pac.idPaciente = @IDPACIENTE");

            return command.ToString();
        }
    }       
}