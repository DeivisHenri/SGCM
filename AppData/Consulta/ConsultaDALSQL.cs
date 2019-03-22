using SGCM.Models.Consulta.CadastroConsultaModel;
using SGCM.Models.Consulta.EditarConsultaModel;
using System;
using System.Text;

namespace SGCM.AppData.Consulta {
    public class ConsultaDALSQL {
        public string ConsultarPacienteNome(string nome, string cpf, int? idPaciente) {
            Boolean flag = false;
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select Pac.idPaciente, Pes.nome, Pes.cpf, Pac.statusDesativado");
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

            command.AppendLine("INSERT INTO consulta(idPacienteConsulta, dataConsulta, consultaFinalizada)");

            if (model.consulta.flagPM) command.AppendLine("VALUES(@IDPACIENTECONSULTA, STR_TO_DATE(@DATACONSULTA @FLAGPM, '%d/%m/%Y %h:%i:%s %p'), 0)");
            else command.AppendLine("VALUES(@IDPACIENTECONSULTA, STR_TO_DATE(@DATACONSULTA, '%d/%m/%Y %h:%i:%s'), 0)");

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

            command.AppendLine("Select Pac.idPaciente, Pes.nome, Con.idConsulta, Con.idPacienteConsulta, Con.dataConsulta, Con.consultaFinalizada");
            command.AppendLine("From pessoa Pes INNER JOIN paciente Pac ON Pes.idPessoa = Pac.idPessoaPaciente ");
            command.AppendLine("     INNER JOIN consulta Con ON Pac.idPaciente = Con.idPacienteConsulta");
            command.AppendLine("Where (dataConsulta BETWEEN @DATAINICIAL AND @DATAFINAL)");

            return command.ToString();
        }

        public string ConsultarConsulta() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select Pes.nome, Pac.idPaciente, Pes.cpf, Con.dataConsulta, Con.idConsulta, Con.consultaFinalizada");
            command.AppendLine("From pessoa as Pes INNER JOIN paciente Pac ON Pes.idPessoa = Pac.idPessoaPaciente ");
            command.AppendLine("     INNER JOIN consulta Con ON Pac.idPaciente = Con.idPacienteConsulta");
            command.AppendLine("Where Con.idConsulta = @IDCONSULTA");

            return command.ToString();
        }

        public string EditarConsulta(EditarConsultaModel consulta) {
            StringBuilder command = new StringBuilder();
            Boolean flag = false;

            command.AppendLine("Update consulta");
            if (consulta.Paciente.idPaciente != 0) {
                command.AppendLine("Set idPacienteConsulta = @IDPACIENTECONSULTA,");
                flag = true;
            }

            if (consulta.Consulta.DataConsulta != default(DateTime) && flag == true && consulta.Consulta.flagPM == true) {
                command.AppendLine("dataConsulta = STR_TO_DATE(@DATACONSULTA @FLAGPM, '%d/%m/%Y %h:%i:%s %p')");
            } else if (consulta.Consulta.DataConsulta != null && flag == false && consulta.Consulta.flagPM == false) {
                command.AppendLine("Set dataConsulta STR_TO_DATE(@DATACONSULTA, '%d/%m/%Y %h:%i:%s'");
            }

            command.AppendLine("Where idConsulta = @IDCONSULTA");

            return command.ToString();
        }

        public string EditarMolestiaAtual(DadosMolestiaAtual molestiaAtual) {
            StringBuilder command = new StringBuilder();
            Boolean flag = false;

            command.AppendLine("Update molestiaatual");

            if (molestiaAtual.idPacienteMolestiaAtual != 0) {
                command.AppendLine("Set idPacienteMolestiaAtual = @IDPACIENTEMOLESTIAATUAL,");
                flag = true;
            }

            if (molestiaAtual.molestiaAtual != null && flag == true) {
                command.AppendLine("	molestiaAtual = @MOLESTIAATUAL");
            } else if (molestiaAtual.molestiaAtual != null && flag == false) {
                command.AppendLine("Set molestiaAtual = @MOLESTIAATUAL");
            }

            command.AppendLine("Where idMolestiaAtual = @IDMOLESTIAATUAL");

            return command.ToString();
        }

        public string EditarPatologicaPregressa(DadosPatologicaPregressa patologicaPregressa) {
            StringBuilder command = new StringBuilder();
            Boolean flag = false;

            command.AppendLine("Update patologicapregressa");

            if (patologicaPregressa.idPacientePatologicaPregressa != 0) {
                command.AppendLine("Set idPacientePatologicaPregressa = @IDPACIENTEPATOLOGICAPREGRESSA ");
                flag = true;
            }

            if (patologicaPregressa.patologicaPregressa != null && flag == true) {
                command.AppendLine(", patologicaPregressa = @PATOLOGICAPREGRESSA");
            } else if (patologicaPregressa.patologicaPregressa != null && flag == false) {
                command.AppendLine("Set patologicaPregressa = @PATOLOGICAPREGRESSA");
            }

            command.AppendLine("Where idPatologicaPregressa = @IDPATOLOGICAPREGRESSA");

            return command.ToString();
        }

        public string EditarExameFisico(DadosExameFisico exameFisico) {
            StringBuilder command = new StringBuilder();
            Boolean flag = false;

            command.AppendLine("Update examefisico");

            if (exameFisico.idPacienteExameFisico != 0) {
                command.AppendLine("Set idPacienteExameFisico = @IDPACIENTEEXAMEFISICO,");
                flag = true;
            }

            if (exameFisico.exameFisico != null && flag == true) {
                command.AppendLine("	exameFisico = @EXAMEFISICO");
            } else if (exameFisico.exameFisico != null && flag == false) {
                command.AppendLine("Set exameFisico = @EXAMEFISICO");
            }

            command.AppendLine("Where idExameFisico = @IDEXAMEFISICO");

            return command.ToString();
        }

        public string EditarHipoteseDiagnostica(DadosHipoteseDiagnostica hipoteseDiagnostica) {
            StringBuilder command = new StringBuilder();
            Boolean flag = false;

            command.AppendLine("Update hipotesediagnostica");

            if (hipoteseDiagnostica.idPacienteHipoteseDiagnostica != 0) {
                command.AppendLine("Set idPacienteHipoteseDiagnostica = @IDPACIENTEHIPOTESEDIAGNOSTICA ");
                flag = true;
            }

            if (hipoteseDiagnostica.hipoteseDiagnostica != null && flag == true) {
                command.AppendLine("    , hipoteseDiagnostica = @HIPOTESEDIAGNOSTICA");
            } else if (hipoteseDiagnostica.hipoteseDiagnostica != null && flag == false) {
                command.AppendLine("Set hipoteseDiagnostica = @HIPOTESEDIAGNOSTICA");
            }

            command.AppendLine("Where idHipoteseDiagnostica = @IDHIPOTESEDIAGNOSTICA");

            return command.ToString();
        }

        public string EditarConduta(DadosConduta conduta) {
            StringBuilder command = new StringBuilder();
            Boolean flag = false;

            command.AppendLine("Update conduta");

            if (conduta.idPacienteConduta != 0) {
                command.AppendLine("Set idPacienteConduta = @IDPACIENTECONDUTA,");
                flag = true;
            }

            if (conduta.conduta != null && flag == true) {
                command.AppendLine("	conduta = @CONDUTA");
            } else if (conduta.conduta != null && flag == false) {
                command.AppendLine("Set conduta = @CONDUTA");
            }

            command.AppendLine("Where idConduta = @IDCONDUTA");

            return command.ToString();
        }

        public string ConsultarAusencia() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select idAusencia,");
            command.AppendLine("       dataInicial,");
            command.AppendLine("       dataFinal,");
            command.AppendLine("       seis,");
            command.AppendLine("       seisMeia,");
            command.AppendLine("       sete,");
            command.AppendLine("       seteMeia,");
            command.AppendLine("       oito,");
            command.AppendLine("       oitoMeia,");
            command.AppendLine("       nove,");
            command.AppendLine("       noveMeia,");
            command.AppendLine("       dez,");
            command.AppendLine("       dezMeia,");
            command.AppendLine("       onze,");
            command.AppendLine("       onzeMeia,");
            command.AppendLine("       doze,");
            command.AppendLine("       dozeMeia,");
            command.AppendLine("       treze,");
            command.AppendLine("       trezeMeia,");
            command.AppendLine("       quatorze,");
            command.AppendLine("       quatorzeMeia,");
            command.AppendLine("       quinze,");
            command.AppendLine("       quinzeMeia,");
            command.AppendLine("       dezesseis,");
            command.AppendLine("       dezesseisMeia,");
            command.AppendLine("       dezessete,");
            command.AppendLine("       dezesseteMeia,");
            command.AppendLine("       dezoito,");
            command.AppendLine("       dezoitoMeia");
            command.AppendLine("From ausencia");
            command.AppendLine("Where dataInicial = STR_TO_DATE(@DATAINICIAL, '%d/%m/%Y')");

            return command.ToString();
        }

        public string DadosPessoaisPaciente() {
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
            command.AppendLine("       Pes.email,");

            command.AppendLine("       Pac.idPaciente,");

            command.AppendLine("       Con.idConsulta,");
            command.AppendLine("       Con.idPacienteConsulta,");
            command.AppendLine("       Con.dataConsulta,");
            command.AppendLine("       Con.consultaFinalizada");
            command.AppendLine("From pessoa Pes INNER JOIN paciente Pac ON Pes.idPessoa = Pac.idPessoaPaciente");
            command.AppendLine("     INNER JOIN consulta Con ON Pac.idPaciente = Con.idPacienteConsulta");
            command.AppendLine("Where Con.idConsulta = @IDCONSULTA");

            return command.ToString();
        }

        public string ConsultaLista() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select idConsulta,");
            command.AppendLine("       idPacienteConsulta,");
            command.AppendLine("       dataConsulta,");
            command.AppendLine("       consultaFinalizada");
            command.AppendLine("From consulta");
            command.AppendLine("Where idPacienteConsulta = @IDPACIENTECONSULTA");
            command.AppendLine("Order By dataConsulta DESC");

            return command.ToString();
        }

        public string ConsultaExameLaboratorial() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select idExameLaboratorial,");
            command.AppendLine("       idPacienteExameLaboratorial,");
            command.AppendLine("       idConsultaExameLaboratorial,");
            command.AppendLine("       exameLaboratorial,");
            command.AppendLine("       tamanhoArquivo");
            command.AppendLine("From examelaboratorial");
            command.AppendLine("Where idPacienteExameLaboratorial = @IDPACIENTEEXAMELABORATORIAL");

            return command.ToString();
        }
        
        public string InsertHistoriaMolestiaAtual() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Insert Into molestiaatual(idPacienteMolestiaAtual,");
            command.AppendLine("                          idConsultaMolestiaAtual,");
            command.AppendLine("                          molestiaAtual)");
            command.AppendLine("VALUES(@IDPACIENTEMOLESTIAATUAL, @IDCONSULTAMOLESTIAATUAL, @MOLESTIAATUAL)");

            return command.ToString();
        }

        public string InsertPatologicaPregressa() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Insert Into patologicapregressa(idPacientePatologicaPregressa,");
            command.AppendLine("                                idConsultaPatologicaPregressa,");
            command.AppendLine("                                patologicaPregressa)");
            command.AppendLine("VALUES(@IDPACIENTEPATOLOGICAPREGRESSA, @IDCONSULTAPATOLOGICAPREGRESSA, @PATOLOGICAPREGRESSA)");

            return command.ToString();
        }

        public string InsertExameFisico() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Insert Into examefisico(idPacienteExameFisico,");
            command.AppendLine("                        idConsultaExameFisico,");
            command.AppendLine("                        exameFisico)");
            command.AppendLine("VALUES(@IDPACIENTEEXAMEFISICO, @IDCONSULTAEXAMEFISICO, @EXAMEFISICO)");

            return command.ToString();
        }

        public string InsertHipoteseDiagnostica() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Insert Into hipotesediagnostica(idPacienteHipoteseDiagnostica,");
            command.AppendLine("                                idConsultaHipoteseDiagnostica,");
            command.AppendLine("                                hipoteseDiagnostica)");
            command.AppendLine("VALUES(@IDPACIENTEHIPOTESEDIAGNOSTICA, @IDCONSULTAHIPOTESEDIAGNOSTICA, @HIPOTESEDIAGNOSTICA)");

            return command.ToString();
        }

        public string InsertConduta() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Insert Into conduta(idPacienteConduta,");
            command.AppendLine("                    idConsultaConduta,");
            command.AppendLine("                    conduta)");
            command.AppendLine("VALUES(@IDPACIENTECONDUTA, @IDCONSULTACONDUTA, @CONDUTA)");

            return command.ToString();
        }


        public string GetBaseNomeExame() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("SELECT idBaseNomeExame, baseNomeExame");
            command.AppendLine("FROM basenomeexame");

            return command.ToString();
        }

        public string GetMedicamento() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select idMedicamento, nomeGenerico, nomeFabrica, fabricante");
            command.AppendLine("From medicamento");

            return command.ToString();
        }

        public string InsertExamePedido() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Insert Into examepedido(idBaseNomeExameExamePedido,");
            command.AppendLine("                        idPacienteExamePedido,");
            command.AppendLine("                        idConsultaExamePedido)");
            command.AppendLine("VALUES(@IDBASENOMEEXAMEEXAMEPEDIDO,");
            command.AppendLine("       @IDPACIENTEEXAMEPEDIDO,");
            command.AppendLine("       @IDCONSULTAEXAMEPEDIDO)");

            return command.ToString();
        }

        public string InsertMedicamentoConsulta()
        {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Insert Into consulta_medicamento(idConsultaConsulta_Medicamento,");
            command.AppendLine("                                 idMedicamentoConsulta_Medicamento)");
            command.AppendLine("VALUES(@IDCONSULTACONSULTA_MEDICAMENTO,");
            command.AppendLine("       @IDMEDICAMENTOCONSULTA_MEDICAMENTO)");

            return command.ToString();
        }

        public string DeleteExamePedido() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Delete From examepedido");
            command.AppendLine("Where idBaseNomeExameExamePedido = @IDBASENOMEEXAMEEXAMEPEDIDO");

            return command.ToString();
        }

        public string DeleteMedicamentoConsulta() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Delete From consulta_medicamento");
            command.AppendLine("Where idConsultaConsulta_Medicamento = @IDCONSULTACONSULTA_MEDICAMENTO ");
            command.AppendLine("      AND idMedicamentoConsulta_Medicamento = @IDMEDICAMENTOCONSULTA_MEDICAMENTO");

            return command.ToString();
        }

        public string UpdateConsultaStatus() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Update consulta");
            command.AppendLine("Set consultaFinalizada = @CONSULTAFINALIZADA");
            command.AppendLine("Where idConsulta = @IDCONSULTA");

            return command.ToString();
        }

        public string ConsultaMolestiaAtual() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select idMolestiaAtual,");
            command.AppendLine("      idPacienteMolestiaAtual,");
            command.AppendLine("      idConsultaMolestiaAtual,");
            command.AppendLine("      molestiaAtual");
            command.AppendLine("From sgcm.molestiaatual");
            command.AppendLine("Where idConsultaMolestiaAtual = @IDCONSULTAMOLESTIAATUAL");

            return command.ToString();
        }

        public string ConsultaPatologicaPregressa() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select idPatologicaPregressa,");
            command.AppendLine("       idPacientePatologicaPregressa,");
            command.AppendLine("       idConsultaPatologicaPregressa,");
            command.AppendLine("       patologicaPregressa");
            command.AppendLine("From patologicapregressa");
            command.AppendLine("Where idConsultaPatologicaPregressa = @IDCONSULTAPATOLOGICAPREGRESSA");

            return command.ToString();
        }

        public string ConsultaExameFisico() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select idExameFisico,");
            command.AppendLine("       idPacienteExameFisico,");
            command.AppendLine("       idConsultaExameFisico,");
            command.AppendLine("       exameFisico");
            command.AppendLine("From examefisico");
            command.AppendLine("Where idConsultaExameFisico = @IDCONSULTAEXAMEFISICO");

            return command.ToString();
        }

        public string ConsultaExameLaboratorialIdConsulta() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select idExameLaboratorial,");
            command.AppendLine("       idPacienteExameLaboratorial,");
            command.AppendLine("       idConsultaExameLaboratorial,");
            command.AppendLine("       exameLaboratorial,");
            command.AppendLine("       tamanhoArquivo");
            command.AppendLine("From examelaboratorial");
            command.AppendLine("Where idConsultaExameLaboratorial = @IDCONSULTAEXAMELABORATORIAL");

            return command.ToString();
        }

        public string ConsultaHipoteseDiagnostica() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select idHipoteseDiagnostica,");
            command.AppendLine("       idPacienteHipoteseDiagnostica,");
            command.AppendLine("       idConsultaHipoteseDiagnostica,");
            command.AppendLine("       hipoteseDiagnostica");
            command.AppendLine("From hipotesediagnostica");
            command.AppendLine("Where idConsultaHipoteseDiagnostica = @IDCONSULTAHIPOTESEDIAGNOSTICA");

            return command.ToString();
        }

        public string ConsultaConduta() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select idConduta,");
            command.AppendLine("       idPacienteConduta,");
            command.AppendLine("       idConsultaConduta,");
            command.AppendLine("       conduta");
            command.AppendLine("From conduta");
            command.AppendLine("Where idConsultaConduta = @IDCONSULTACONDUTA");

            return command.ToString();
        }

        public string ConsultaExamePedido() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("SELECT idExamePedido, idBaseNomeExameExamePedido, idPacienteExamePedido, idConsultaExamePedido");
            command.AppendLine("FROM examepedido");
            command.AppendLine("Where idConsultaExamePedido = @IDCONSULTAEXAMEPEDIDO");

            return command.ToString();
        }

        public string ConsultaMedicamentoPrescrito()
        {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select idConsulta_Medicamento, idConsultaConsulta_Medicamento, idMedicamentoConsulta_Medicamento");
            command.AppendLine("From consulta_medicamento");
            command.AppendLine("Where idConsultaConsulta_Medicamento = @IDCONSULTA");

            return command.ToString();
        }

        public string CancelarConsulta() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Delete From consulta");
            command.AppendLine("Where idConsulta = @IDCONSULTA");

            return command.ToString();
        }
    }
}