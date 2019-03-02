using System.Text.RegularExpressions;
using System;
using SGCM.Models.Consulta.ConsultarConsultaModel;
using SGCM.Models.Ausencia.CadastrarAusenciaModel;
using SGCM.Models.Ausencia.EditarAusenciaModel;

namespace SGCM.AppData.Infraestrutura.UtilMetodo {
    public class UtilMetodo {
        public static string RemovendoCaracteresEspeciais(string cpf) {
            Regex rgx = new Regex(@"[^\d]");
            return rgx.Replace(cpf, "").ToString();
        }

        public static Models.Usuario.CadastroUsuarioModel.DadosPermissoes ConversaoPermissoesStringParaIntCadastro(Models.Usuario.CadastroUsuarioModel.DadosPermissoes dadosPermissoes)
        {
            int valorTrue = 1;
            int valorFalse = 0;

            /* USUARIO */
            if ((dadosPermissoes.flUsuarioI == "true") || (dadosPermissoes.flUsuarioI == "True")) {
                dadosPermissoes.flUsuarioI = valorTrue.ToString();
            } else {
                dadosPermissoes.flUsuarioI = valorFalse.ToString();
            }

            if ((dadosPermissoes.flUsuarioC == "true") || (dadosPermissoes.flUsuarioC == "True")) {
                dadosPermissoes.flUsuarioC = valorTrue.ToString();
            } else {
                dadosPermissoes.flUsuarioC = valorFalse.ToString();
            }

            if ((dadosPermissoes.flUsuarioA == "true") || (dadosPermissoes.flUsuarioA == "True")) {
                dadosPermissoes.flUsuarioA = valorTrue.ToString();
            } else {
                dadosPermissoes.flUsuarioA = valorFalse.ToString();
            }

            if ((dadosPermissoes.flUsuarioE == "true") || (dadosPermissoes.flUsuarioE == "True")) {
                dadosPermissoes.flUsuarioE = valorTrue.ToString();
            } else {
                dadosPermissoes.flUsuarioE = valorFalse.ToString();
            }

            /* PACIENTE */
            if ((dadosPermissoes.flPacienteI == "true") || (dadosPermissoes.flPacienteI == "True")) {
                dadosPermissoes.flPacienteI = valorTrue.ToString();
            } else {
                dadosPermissoes.flPacienteI = valorFalse.ToString();
            }

            if ((dadosPermissoes.flPacienteC == "true") || (dadosPermissoes.flPacienteC == "True")) {
                dadosPermissoes.flPacienteC = valorTrue.ToString();
            } else {
                dadosPermissoes.flPacienteC = valorFalse.ToString();
            }

            if ((dadosPermissoes.flPacienteA == "true") || (dadosPermissoes.flPacienteA == "True")) {
                dadosPermissoes.flPacienteA = valorTrue.ToString();
            } else {
                dadosPermissoes.flPacienteA = valorFalse.ToString();
            }

            if ((dadosPermissoes.flPacienteE == "true") || (dadosPermissoes.flPacienteE == "True")) {
                dadosPermissoes.flPacienteE = valorTrue.ToString();
            } else {
                dadosPermissoes.flPacienteE = valorFalse.ToString();
            }

            /* CONSULTA */
            if ((dadosPermissoes.flConsultaI == "true") || (dadosPermissoes.flConsultaI == "True")) {
                dadosPermissoes.flConsultaI = valorTrue.ToString();
            } else {
                dadosPermissoes.flConsultaI = valorFalse.ToString();
            }

            if ((dadosPermissoes.flConsultaC == "true") || (dadosPermissoes.flConsultaC == "True")) {
                dadosPermissoes.flConsultaC = valorTrue.ToString();
            } else {
                dadosPermissoes.flConsultaC = valorFalse.ToString();
            }

            if ((dadosPermissoes.flConsultaA == "true") || (dadosPermissoes.flConsultaA == "True")) {
                dadosPermissoes.flConsultaA = valorTrue.ToString();
            } else {
                dadosPermissoes.flConsultaA = valorFalse.ToString();
            }

            if ((dadosPermissoes.flConsultaE == "true") || (dadosPermissoes.flConsultaE == "True")) {
                dadosPermissoes.flConsultaE = valorTrue.ToString();
            } else {
                dadosPermissoes.flConsultaE = valorFalse.ToString();
            }

            /* AUSENCIA */
            if ((dadosPermissoes.flAusenciaI == "true") || (dadosPermissoes.flAusenciaI == "True")) {
                dadosPermissoes.flAusenciaI = valorTrue.ToString();
            } else {
                dadosPermissoes.flAusenciaI = valorFalse.ToString();
            }

            if ((dadosPermissoes.flAusenciaC == "true") || (dadosPermissoes.flAusenciaC == "True")) {
                dadosPermissoes.flAusenciaC = valorTrue.ToString();
            } else {
                dadosPermissoes.flAusenciaC = valorFalse.ToString();
            }

            if ((dadosPermissoes.flAusenciaA == "true") || (dadosPermissoes.flAusenciaA == "True")) {
                dadosPermissoes.flAusenciaA = valorTrue.ToString();
            } else {
                dadosPermissoes.flAusenciaA = valorFalse.ToString();
            }

            if ((dadosPermissoes.flAusenciaE == "true") || (dadosPermissoes.flAusenciaE == "True")) {
                dadosPermissoes.flAusenciaE = valorTrue.ToString();
            } else {
                dadosPermissoes.flAusenciaE = valorFalse.ToString();
            }

            /* MEDICAMENTO */
            if ((dadosPermissoes.flMedicamentoI == "true") || (dadosPermissoes.flMedicamentoI == "True")) {
                dadosPermissoes.flMedicamentoI = valorTrue.ToString();
            } else {
                dadosPermissoes.flMedicamentoI = valorFalse.ToString();
            }

            if ((dadosPermissoes.flMedicamentoC == "true") || (dadosPermissoes.flMedicamentoC == "True")) {
                dadosPermissoes.flMedicamentoC = valorTrue.ToString();
            } else {
                dadosPermissoes.flMedicamentoC = valorFalse.ToString();
            }

            if ((dadosPermissoes.flMedicamentoA == "true") || (dadosPermissoes.flMedicamentoA == "True")) {
                dadosPermissoes.flMedicamentoA = valorTrue.ToString();
            } else {
                dadosPermissoes.flMedicamentoA = valorFalse.ToString();
            }

            if ((dadosPermissoes.flMedicamentoE == "true") || (dadosPermissoes.flMedicamentoE == "True")) {
                dadosPermissoes.flMedicamentoE = valorTrue.ToString();
            } else {
                dadosPermissoes.flMedicamentoE = valorFalse.ToString();
            }

            /* EXAME */
            if ((dadosPermissoes.flExamesI == "true") || (dadosPermissoes.flExamesI == "True")) {
                dadosPermissoes.flExamesI = valorTrue.ToString();
            } else {
                dadosPermissoes.flExamesI = valorFalse.ToString();
            }

            if ((dadosPermissoes.flExamesC == "true") || (dadosPermissoes.flExamesC == "True")) {
                dadosPermissoes.flExamesC = valorTrue.ToString();
            } else {
                dadosPermissoes.flExamesC = valorFalse.ToString();
            }

            if ((dadosPermissoes.flExamesA == "true") || (dadosPermissoes.flExamesA == "True")) {
                dadosPermissoes.flExamesA = valorTrue.ToString();
            } else {
                dadosPermissoes.flExamesA = valorFalse.ToString();
            }

            if ((dadosPermissoes.flExamesE == "true") || (dadosPermissoes.flExamesE == "True")) {
                dadosPermissoes.flExamesE = valorTrue.ToString();
            } else {
                dadosPermissoes.flExamesE = valorFalse.ToString();
            }

            /* MOLESTIA ATUAL */
            if ((dadosPermissoes.flHistoriaMolestiaAtualI == "true") || (dadosPermissoes.flHistoriaMolestiaAtualI == "True")) {
                dadosPermissoes.flHistoriaMolestiaAtualI = valorTrue.ToString();
            } else {
                dadosPermissoes.flHistoriaMolestiaAtualI = valorFalse.ToString();
            }

            if ((dadosPermissoes.flHistoriaMolestiaAtualC == "true") || (dadosPermissoes.flHistoriaMolestiaAtualC == "True")) {
                dadosPermissoes.flHistoriaMolestiaAtualC = valorTrue.ToString();
            } else {
                dadosPermissoes.flHistoriaMolestiaAtualC = valorFalse.ToString();
            }

            if ((dadosPermissoes.flHistoriaMolestiaAtualA == "true") || (dadosPermissoes.flHistoriaMolestiaAtualA == "True")) {
                dadosPermissoes.flHistoriaMolestiaAtualA = valorTrue.ToString();
            } else {
                dadosPermissoes.flHistoriaMolestiaAtualA = valorFalse.ToString();
            }

            if ((dadosPermissoes.flHistoriaMolestiaAtualE == "true") || (dadosPermissoes.flHistoriaMolestiaAtualE == "True")) {
                dadosPermissoes.flHistoriaMolestiaAtualE = valorTrue.ToString();
            } else {
                dadosPermissoes.flHistoriaMolestiaAtualE = valorFalse.ToString();
            }

            /* PATOLOGICA PREGRESSA */
            if ((dadosPermissoes.flHistoriaPatologicaPregressaI == "true") || (dadosPermissoes.flHistoriaPatologicaPregressaI == "True")) {
                dadosPermissoes.flHistoriaPatologicaPregressaI = valorTrue.ToString();
            } else {
                dadosPermissoes.flHistoriaPatologicaPregressaI = valorFalse.ToString();
            }

            if ((dadosPermissoes.flHistoriaPatologicaPregressaC == "true") || (dadosPermissoes.flHistoriaPatologicaPregressaC == "True")) {
                dadosPermissoes.flHistoriaPatologicaPregressaC = valorTrue.ToString();
            } else             {
                dadosPermissoes.flHistoriaPatologicaPregressaC = valorFalse.ToString();
            }

            if ((dadosPermissoes.flHistoriaPatologicaPregressaA == "true") || (dadosPermissoes.flHistoriaPatologicaPregressaA == "True")) {
                dadosPermissoes.flHistoriaPatologicaPregressaA = valorTrue.ToString();
            } else             {
                dadosPermissoes.flHistoriaPatologicaPregressaA = valorFalse.ToString();
            }

            if ((dadosPermissoes.flHistoriaPatologicaPregressaE == "true") || (dadosPermissoes.flHistoriaPatologicaPregressaE == "True")) {
                dadosPermissoes.flHistoriaPatologicaPregressaE = valorTrue.ToString();
            } else {
                dadosPermissoes.flHistoriaPatologicaPregressaE = valorFalse.ToString();
            }

            /* HIPOTESE DIAGNOSTICA */
            if ((dadosPermissoes.flHipoteseDiagnosticaI == "true") || (dadosPermissoes.flHipoteseDiagnosticaI == "True")) {
                dadosPermissoes.flHipoteseDiagnosticaI = valorTrue.ToString();
            } else {
                dadosPermissoes.flHipoteseDiagnosticaI = valorFalse.ToString();
            }

            if ((dadosPermissoes.flHipoteseDiagnosticaC == "true") || (dadosPermissoes.flHipoteseDiagnosticaC == "True")) {
                dadosPermissoes.flHipoteseDiagnosticaC = valorTrue.ToString();
            } else {
                dadosPermissoes.flHipoteseDiagnosticaC = valorFalse.ToString();
            }

            if ((dadosPermissoes.flHipoteseDiagnosticaA == "true") || (dadosPermissoes.flHipoteseDiagnosticaA == "True")) {
                dadosPermissoes.flHipoteseDiagnosticaA = valorTrue.ToString();
            } else {
                dadosPermissoes.flHipoteseDiagnosticaA = valorFalse.ToString();
            }

            if ((dadosPermissoes.flHipoteseDiagnosticaE == "true") || (dadosPermissoes.flHipoteseDiagnosticaE == "True")) {
                dadosPermissoes.flHipoteseDiagnosticaE = valorTrue.ToString();
            } else {
                dadosPermissoes.flHipoteseDiagnosticaE = valorFalse.ToString();
            }

            /* CONDUTA */
            if ((dadosPermissoes.flCondutaI == "true") || (dadosPermissoes.flCondutaI == "True")) {
                dadosPermissoes.flCondutaI = valorTrue.ToString();
            } else {
                dadosPermissoes.flCondutaI = valorFalse.ToString();
            }

            if ((dadosPermissoes.flCondutaC == "true") || (dadosPermissoes.flCondutaC == "True")) {
                dadosPermissoes.flCondutaC = valorTrue.ToString();
            } else {
                dadosPermissoes.flCondutaC = valorFalse.ToString();
            }

            if ((dadosPermissoes.flCondutaA == "true") || (dadosPermissoes.flCondutaA == "True")) {
                dadosPermissoes.flCondutaA = valorTrue.ToString();
            } else {
                dadosPermissoes.flCondutaA = valorFalse.ToString();
            }

            if ((dadosPermissoes.flCondutaE == "true") || (dadosPermissoes.flCondutaE == "True")) {
                dadosPermissoes.flCondutaE = valorTrue.ToString();
            } else {
                dadosPermissoes.flCondutaE = valorFalse.ToString();
            }

            /* INICIAR ATENDIMENTO */

            return dadosPermissoes;
        }

        public static Models.Usuario.EditarUsuarioModel.DadosPermissoes ConversaoPermissoesStringParaIntEditar(Models.Usuario.EditarUsuarioModel.DadosPermissoes dadosPermissoes) {
            int valorTrue = 1;
            int valorFalse = 0;

            /* USUARIO */
            if ((dadosPermissoes.flUsuarioI == "true") || (dadosPermissoes.flUsuarioI == "True")) {
                dadosPermissoes.flUsuarioI = valorTrue.ToString();
            } else {
                dadosPermissoes.flUsuarioI = valorFalse.ToString();
            }

            if ((dadosPermissoes.flUsuarioC == "true") || (dadosPermissoes.flUsuarioC == "True"))
            {
                dadosPermissoes.flUsuarioC = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flUsuarioC = valorFalse.ToString();
            }

            if ((dadosPermissoes.flUsuarioA == "true") || (dadosPermissoes.flUsuarioA == "True"))
            {
                dadosPermissoes.flUsuarioA = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flUsuarioA = valorFalse.ToString();
            }

            if ((dadosPermissoes.flUsuarioE == "true") || (dadosPermissoes.flUsuarioE == "True"))
            {
                dadosPermissoes.flUsuarioE = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flUsuarioE = valorFalse.ToString();
            }

            /* PACIENTE */
            if ((dadosPermissoes.flPacienteI == "true") || (dadosPermissoes.flPacienteI == "True"))
            {
                dadosPermissoes.flPacienteI = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flPacienteI = valorFalse.ToString();
            }

            if ((dadosPermissoes.flPacienteC == "true") || (dadosPermissoes.flPacienteC == "True"))
            {
                dadosPermissoes.flPacienteC = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flPacienteC = valorFalse.ToString();
            }

            if ((dadosPermissoes.flPacienteA == "true") || (dadosPermissoes.flPacienteA == "True"))
            {
                dadosPermissoes.flPacienteA = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flPacienteA = valorFalse.ToString();
            }

            if ((dadosPermissoes.flPacienteE == "true") || (dadosPermissoes.flPacienteE == "True"))
            {
                dadosPermissoes.flPacienteE = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flPacienteE = valorFalse.ToString();
            }

            /* CONSULTA */
            if ((dadosPermissoes.flConsultaI == "true") || (dadosPermissoes.flConsultaI == "True"))
            {
                dadosPermissoes.flConsultaI = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flConsultaI = valorFalse.ToString();
            }

            if ((dadosPermissoes.flConsultaC == "true") || (dadosPermissoes.flConsultaC == "True"))
            {
                dadosPermissoes.flConsultaC = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flConsultaC = valorFalse.ToString();
            }

            if ((dadosPermissoes.flConsultaA == "true") || (dadosPermissoes.flConsultaA == "True"))
            {
                dadosPermissoes.flConsultaA = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flConsultaA = valorFalse.ToString();
            }

            if ((dadosPermissoes.flConsultaE == "true") || (dadosPermissoes.flConsultaE == "True"))
            {
                dadosPermissoes.flConsultaE = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flConsultaE = valorFalse.ToString();
            }

            /* AUSENCIA */
            if ((dadosPermissoes.flAusenciaI == "true") || (dadosPermissoes.flAusenciaI == "True"))
            {
                dadosPermissoes.flAusenciaI = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flAusenciaI = valorFalse.ToString();
            }

            if ((dadosPermissoes.flAusenciaC == "true") || (dadosPermissoes.flAusenciaC == "True"))
            {
                dadosPermissoes.flAusenciaC = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flAusenciaC = valorFalse.ToString();
            }

            if ((dadosPermissoes.flAusenciaA == "true") || (dadosPermissoes.flAusenciaA == "True"))
            {
                dadosPermissoes.flAusenciaA = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flAusenciaA = valorFalse.ToString();
            }

            if ((dadosPermissoes.flAusenciaE == "true") || (dadosPermissoes.flAusenciaE == "True"))
            {
                dadosPermissoes.flAusenciaE = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flAusenciaE = valorFalse.ToString();
            }

            /* MEDICAMENTO */
            if ((dadosPermissoes.flMedicamentoI == "true") || (dadosPermissoes.flMedicamentoI == "True"))
            {
                dadosPermissoes.flMedicamentoI = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flMedicamentoI = valorFalse.ToString();
            }

            if ((dadosPermissoes.flMedicamentoC == "true") || (dadosPermissoes.flMedicamentoC == "True"))
            {
                dadosPermissoes.flMedicamentoC = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flMedicamentoC = valorFalse.ToString();
            }

            if ((dadosPermissoes.flMedicamentoA == "true") || (dadosPermissoes.flMedicamentoA == "True"))
            {
                dadosPermissoes.flMedicamentoA = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flMedicamentoA = valorFalse.ToString();
            }

            if ((dadosPermissoes.flMedicamentoE == "true") || (dadosPermissoes.flMedicamentoE == "True"))
            {
                dadosPermissoes.flMedicamentoE = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flMedicamentoE = valorFalse.ToString();
            }

            /* EXAME */
            if ((dadosPermissoes.flExamesI == "true") || (dadosPermissoes.flExamesI == "True"))
            {
                dadosPermissoes.flExamesI = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flExamesI = valorFalse.ToString();
            }

            if ((dadosPermissoes.flExamesC == "true") || (dadosPermissoes.flExamesC == "True"))
            {
                dadosPermissoes.flExamesC = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flExamesC = valorFalse.ToString();
            }

            if ((dadosPermissoes.flExamesA == "true") || (dadosPermissoes.flExamesA == "True"))
            {
                dadosPermissoes.flExamesA = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flExamesA = valorFalse.ToString();
            }

            if ((dadosPermissoes.flExamesE == "true") || (dadosPermissoes.flExamesE == "True"))
            {
                dadosPermissoes.flExamesE = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flExamesE = valorFalse.ToString();
            }

            /* MOLESTIA ATUAL */
            if ((dadosPermissoes.flHistoriaMolestiaAtualI == "true") || (dadosPermissoes.flHistoriaMolestiaAtualI == "True"))
            {
                dadosPermissoes.flHistoriaMolestiaAtualI = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flHistoriaMolestiaAtualI = valorFalse.ToString();
            }

            if ((dadosPermissoes.flHistoriaMolestiaAtualC == "true") || (dadosPermissoes.flHistoriaMolestiaAtualC == "True"))
            {
                dadosPermissoes.flHistoriaMolestiaAtualC = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flHistoriaMolestiaAtualC = valorFalse.ToString();
            }

            if ((dadosPermissoes.flHistoriaMolestiaAtualA == "true") || (dadosPermissoes.flHistoriaMolestiaAtualA == "True"))
            {
                dadosPermissoes.flHistoriaMolestiaAtualA = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flHistoriaMolestiaAtualA = valorFalse.ToString();
            }

            if ((dadosPermissoes.flHistoriaMolestiaAtualE == "true") || (dadosPermissoes.flHistoriaMolestiaAtualE == "True"))
            {
                dadosPermissoes.flHistoriaMolestiaAtualE = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flHistoriaMolestiaAtualE = valorFalse.ToString();
            }

            /* PATOLOGICA PREGRESSA */
            if ((dadosPermissoes.flHistoriaPatologicaPregressaI == "true") || (dadosPermissoes.flHistoriaPatologicaPregressaI == "True"))
            {
                dadosPermissoes.flHistoriaPatologicaPregressaI = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flHistoriaPatologicaPregressaI = valorFalse.ToString();
            }

            if ((dadosPermissoes.flHistoriaPatologicaPregressaC == "true") || (dadosPermissoes.flHistoriaPatologicaPregressaC == "True"))
            {
                dadosPermissoes.flHistoriaPatologicaPregressaC = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flHistoriaPatologicaPregressaC = valorFalse.ToString();
            }

            if ((dadosPermissoes.flHistoriaPatologicaPregressaA == "true") || (dadosPermissoes.flHistoriaPatologicaPregressaA == "True"))
            {
                dadosPermissoes.flHistoriaPatologicaPregressaA = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flHistoriaPatologicaPregressaA = valorFalse.ToString();
            }

            if ((dadosPermissoes.flHistoriaPatologicaPregressaE == "true") || (dadosPermissoes.flHistoriaPatologicaPregressaE == "True"))
            {
                dadosPermissoes.flHistoriaPatologicaPregressaE = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flHistoriaPatologicaPregressaE = valorFalse.ToString();
            }

            /* HIPOTESE DIAGNOSTICA */
            if ((dadosPermissoes.flHipoteseDiagnosticaI == "true") || (dadosPermissoes.flHipoteseDiagnosticaI == "True"))
            {
                dadosPermissoes.flHipoteseDiagnosticaI = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flHipoteseDiagnosticaI = valorFalse.ToString();
            }

            if ((dadosPermissoes.flHipoteseDiagnosticaC == "true") || (dadosPermissoes.flHipoteseDiagnosticaC == "True"))
            {
                dadosPermissoes.flHipoteseDiagnosticaC = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flHipoteseDiagnosticaC = valorFalse.ToString();
            }

            if ((dadosPermissoes.flHipoteseDiagnosticaA == "true") || (dadosPermissoes.flHipoteseDiagnosticaA == "True"))
            {
                dadosPermissoes.flHipoteseDiagnosticaA = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flHipoteseDiagnosticaA = valorFalse.ToString();
            }

            if ((dadosPermissoes.flHipoteseDiagnosticaE == "true") || (dadosPermissoes.flHipoteseDiagnosticaE == "True"))
            {
                dadosPermissoes.flHipoteseDiagnosticaE = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flHipoteseDiagnosticaE = valorFalse.ToString();
            }

            /* CONDUTA */
            if ((dadosPermissoes.flCondutaI == "true") || (dadosPermissoes.flCondutaI == "True"))
            {
                dadosPermissoes.flCondutaI = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flCondutaI = valorFalse.ToString();
            }

            if ((dadosPermissoes.flCondutaC == "true") || (dadosPermissoes.flCondutaC == "True"))
            {
                dadosPermissoes.flCondutaC = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flCondutaC = valorFalse.ToString();
            }

            if ((dadosPermissoes.flCondutaA == "true") || (dadosPermissoes.flCondutaA == "True"))
            {
                dadosPermissoes.flCondutaA = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flCondutaA = valorFalse.ToString();
            }

            if ((dadosPermissoes.flCondutaE == "true") || (dadosPermissoes.flCondutaE == "True"))
            {
                dadosPermissoes.flCondutaE = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.flCondutaE = valorFalse.ToString();
            }

            /* INICIAR ATENDIMENTO */

            return dadosPermissoes;
        }

        public static string ArrumarDateFormatoBanco(string data)
        {
            var dataArray = data.Split('/');
            var dataReturn = dataArray[2] + "-" + dataArray[1] + "-" + dataArray[0];

            return dataReturn;
        }

        public static string ConsultarUltimoIdInseridoNoBanco()
        {
            return "SELECT LAST_INSERT_ID();";

        }

        public static string VerificaDiaDaSemana(int dia, int mes, int ano) {
            if (mes == 1) {
                mes = 13;
                ano--;
            }

            if (mes == 2) {
                mes = 14;
                ano--;
            }

            int q = dia;
            int m = mes;
            int k = ano % 100;
            int j = ano / 100;
            int h = q + 13 * (m + 1) / 5 + k + k / 4 + j / 4 + 5 * j;
            h = h % 7;

            switch (h) {
                case 0:
                    return "sabado";
                case 1:
                    return "domingo";
                case 2:
                    return "segunda";
                case 3:
                    return "terça";
                case 4:
                    return "quarta";
                case 5:
                    return "quinta";
                case 6:
                    return "sexta";
            }
            return "";
        }

        public static void AdicinarDadosBandoNaModelSegunda(string hora, string minuto,
                                                    ref ConsultarConsultasModel model, ConsultasQuery consultaDia)
        {
            switch (hora)
            {
                case "06":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSegundaSeis.seis = consultaDia.nome;
                        model.quadroSegundaSeis.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaSeis.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaSeis.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaSeis.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSegundaSeisMeia.seisMeia = consultaDia.nome;
                        model.quadroSegundaSeisMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaSeisMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaSeisMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaSeisMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "07":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSegundaSete.sete = consultaDia.nome;
                        model.quadroSegundaSete.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaSete.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaSete.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaSete.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSegundaSeteMeia.seteMeia = consultaDia.nome;
                        model.quadroSegundaSeteMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaSeteMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaSeteMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaSeteMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "08":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSegundaOito.oito = consultaDia.nome;
                        model.quadroSegundaOito.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaOito.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaOito.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaOito.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSegundaOitoMeia.oitoMeia = consultaDia.nome;
                        model.quadroSegundaOitoMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaOitoMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaOitoMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaOitoMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "09":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSegundaNove.nove = consultaDia.nome;
                        model.quadroSegundaNove.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaNove.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaNove.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaNove.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSegundaNoveMeia.noveMeia = consultaDia.nome;
                        model.quadroSegundaNoveMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaNoveMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaNoveMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaNoveMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "10":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSegundaDez.dez = consultaDia.nome;
                        model.quadroSegundaDez.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaDez.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaDez.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaDez.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSegundaDezMeia.dezMeia = consultaDia.nome;
                        model.quadroSegundaDezMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaDezMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaDezMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaDezMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "11":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSegundaOnze.onze = consultaDia.nome;
                        model.quadroSegundaOnze.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaOnze.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaOnze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaOnze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSegundaOnzeMeia.onzeMeia = consultaDia.nome;
                        model.quadroSegundaOnzeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaOnzeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaOnzeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaOnzeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "12":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSegundaDoze.doze = consultaDia.nome;
                        model.quadroSegundaDoze.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaDoze.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaDoze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaDoze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSegundaDozeMeia.dozeMeia = consultaDia.nome;
                        model.quadroSegundaDozeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaDozeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaDozeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaDozeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "13":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSegundaTreze.treze = consultaDia.nome;
                        model.quadroSegundaTreze.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaTreze.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaTreze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaTreze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSegundaTrezeMeia.trezeMeia = consultaDia.nome;
                        model.quadroSegundaTrezeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaTrezeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaTrezeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaTrezeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "14":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSegundaQuatorze.quatorze = consultaDia.nome;
                        model.quadroSegundaQuatorze.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaQuatorze.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaQuatorze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaQuatorze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSegundaQuatorzeMeia.quatorzeMeia = consultaDia.nome;
                        model.quadroSegundaQuatorzeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaQuatorzeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaQuatorzeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaQuatorzeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "15":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSegundaQuinze.quinze = consultaDia.nome;
                        model.quadroSegundaQuinze.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaQuinze.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaQuinze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaQuinze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSegundaQuinzeMeia.quinzeMeia = consultaDia.nome;
                        model.quadroSegundaQuinzeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaQuinzeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaQuinzeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaQuinzeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "16":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSegundaDezesseis.dezesseis = consultaDia.nome;
                        model.quadroSegundaDezesseis.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaDezesseis.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaDezesseis.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaDezesseis.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSegundaDezesseisMeia.dezesseisMeia = consultaDia.nome;
                        model.quadroSegundaDezesseisMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaDezesseisMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaDezesseisMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaDezesseisMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "17":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSegundaDezessete.dezessete = consultaDia.nome;
                        model.quadroSegundaDezessete.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaDezessete.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaDezessete.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaDezessete.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSegundaDezesseteMeia.dezesseteMeia = consultaDia.nome;
                        model.quadroSegundaDezesseteMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaDezesseteMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaDezesseteMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaDezesseteMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "18":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSegundaDezoito.dezoito = consultaDia.nome;
                        model.quadroSegundaDezoito.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaDezoito.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaDezoito.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaDezoito.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSegundaDezoitoMeia.dezoitoMeia = consultaDia.nome;
                        model.quadroSegundaDezoitoMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSegundaDezoitoMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSegundaDezoitoMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSegundaDezoitoMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
            }
        }

        public static void AdicinarDadosBandoNaModelTerca(string hora, string minuto,
                                                    ref ConsultarConsultasModel model, ConsultasQuery consultaDia)
        {
            switch (hora)
            {
                case "06":
                    if (minuto.Equals("00"))
                    {
                        model.quadroTercaSeis.seis = consultaDia.nome;
                        model.quadroTercaSeis.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaSeis.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaSeis.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaSeis.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroTercaSeisMeia.seisMeia = consultaDia.nome;
                        model.quadroTercaSeisMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaSeisMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaSeisMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaSeisMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "07":
                    if (minuto.Equals("00"))
                    {
                        model.quadroTercaSete.sete = consultaDia.nome;
                        model.quadroTercaSete.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaSete.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaSete.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaSete.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroTercaSeteMeia.seteMeia = consultaDia.nome;
                        model.quadroTercaSeteMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaSeteMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaSeteMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaSeteMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "08":
                    if (minuto.Equals("00"))
                    {
                        model.quadroTercaOito.oito = consultaDia.nome;
                        model.quadroTercaOito.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaOito.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaOito.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaOito.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroTercaOitoMeia.oitoMeia = consultaDia.nome;
                        model.quadroTercaOitoMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaOitoMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaOitoMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaOitoMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "09":
                    if (minuto.Equals("00"))
                    {
                        model.quadroTercaNove.nove = consultaDia.nome;
                        model.quadroTercaNove.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaNove.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaNove.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaNove.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroTercaNoveMeia.noveMeia = consultaDia.nome;
                        model.quadroTercaNoveMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaNoveMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaNoveMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaNoveMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "10":
                    if (minuto.Equals("00"))
                    {
                        model.quadroTercaDez.dez = consultaDia.nome;
                        model.quadroTercaDez.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaDez.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaDez.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaDez.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroTercaDezMeia.dezMeia = consultaDia.nome;
                        model.quadroTercaDezMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaDezMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaDezMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaDezMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "11":
                    if (minuto.Equals("00"))
                    {
                        model.quadroTercaOnze.onze = consultaDia.nome;
                        model.quadroTercaOnze.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaOnze.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaOnze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaOnze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroTercaOnzeMeia.onzeMeia = consultaDia.nome;
                        model.quadroTercaOnzeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaOnzeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaOnzeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaOnzeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "12":
                    if (minuto.Equals("00"))
                    {
                        model.quadroTercaDoze.doze = consultaDia.nome;
                        model.quadroTercaDoze.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaDoze.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaDoze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaDoze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroTercaDozeMeia.dozeMeia = consultaDia.nome;
                        model.quadroTercaDozeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaDozeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaDozeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaDozeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "13":
                    if (minuto.Equals("00"))
                    {
                        model.quadroTercaTreze.treze = consultaDia.nome;
                        model.quadroTercaTreze.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaTreze.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaTreze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaTreze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroTercaTrezeMeia.trezeMeia = consultaDia.nome;
                        model.quadroTercaTrezeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaTrezeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaTrezeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaTrezeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "14":
                    if (minuto.Equals("00"))
                    {
                        model.quadroTercaQuatorze.quatorze = consultaDia.nome;
                        model.quadroTercaQuatorze.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaQuatorze.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaQuatorze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaQuatorze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroTercaQuatorzeMeia.quatorzeMeia = consultaDia.nome;
                        model.quadroTercaQuatorzeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaQuatorzeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaQuatorzeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                    }
                    break;
                case "15":
                    if (minuto.Equals("00"))
                    {
                        model.quadroTercaQuinze.quinze = consultaDia.nome;
                        model.quadroTercaQuinze.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaQuinze.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaQuinze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaQuinze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroTercaQuinzeMeia.quinzeMeia = consultaDia.nome;
                        model.quadroTercaQuinzeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaQuinzeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaQuinzeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaQuinzeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "16":
                    if (minuto.Equals("00"))
                    {
                        model.quadroTercaDezesseis.dezesseis = consultaDia.nome;
                        model.quadroTercaDezesseis.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaDezesseis.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaDezesseis.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaDezesseis.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroTercaDezesseisMeia.dezesseisMeia = consultaDia.nome;
                        model.quadroTercaDezesseisMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaDezesseisMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaDezesseisMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaDezesseisMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "17":
                    if (minuto.Equals("00"))
                    {
                        model.quadroTercaDezessete.dezessete = consultaDia.nome;
                        model.quadroTercaDezessete.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaDezessete.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaDezessete.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaDezessete.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroTercaDezesseteMeia.dezesseteMeia = consultaDia.nome;
                        model.quadroTercaDezesseteMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaDezesseteMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaDezesseteMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaDezesseteMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "18":
                    if (minuto.Equals("00"))
                    {
                        model.quadroTercaDezoito.dezoito = consultaDia.nome;
                        model.quadroTercaDezoito.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaDezoito.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaDezoito.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaDezoito.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroTercaDezoitoMeia.dezoitoMeia = consultaDia.nome;
                        model.quadroTercaDezoitoMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroTercaDezoitoMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroTercaDezoitoMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroTercaDezoitoMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
            }
        }

        public static void AdicinarDadosBandoNaModelQuarta(string hora, string minuto,
                                                    ref ConsultarConsultasModel model, ConsultasQuery consultaDia)
        {
            switch (hora)
            {
                case "06":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuartaSeis.seis = consultaDia.nome;
                        model.quadroQuartaSeis.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaSeis.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaSeis.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaSeis.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuartaSeisMeia.seisMeia = consultaDia.nome;
                        model.quadroQuartaSeisMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaSeisMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaSeisMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaSeisMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "07":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuartaSete.sete = consultaDia.nome;
                        model.quadroQuartaSete.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaSete.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaSete.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaSete.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuartaSeteMeia.seteMeia = consultaDia.nome;
                        model.quadroQuartaSeteMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaSeteMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaSeteMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaSeteMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "08":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuartaOito.oito = consultaDia.nome;
                        model.quadroQuartaOito.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaOito.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaOito.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaOito.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuartaOitoMeia.oitoMeia = consultaDia.nome;
                        model.quadroQuartaOitoMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaOitoMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaOitoMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaOitoMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "09":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuartaNove.nove = consultaDia.nome;
                        model.quadroQuartaNove.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaNove.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaNove.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaNove.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuartaNoveMeia.noveMeia = consultaDia.nome;
                        model.quadroQuartaNoveMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaNoveMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaNoveMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaNoveMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "10":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuartaDez.dez = consultaDia.nome;
                        model.quadroQuartaDez.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaDez.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaDez.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaDez.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuartaDezMeia.dezMeia = consultaDia.nome;
                        model.quadroQuartaDezMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaDezMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaDezMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaDezMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "11":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuartaOnze.onze = consultaDia.nome;
                        model.quadroQuartaOnze.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaOnze.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaOnze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaOnze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuartaOnzeMeia.onzeMeia = consultaDia.nome;
                        model.quadroQuartaOnzeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaOnzeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaOnzeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaOnzeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "12":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuartaDoze.doze = consultaDia.nome;
                        model.quadroQuartaDoze.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaDoze.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaDoze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaDoze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuartaDozeMeia.dozeMeia = consultaDia.nome;
                        model.quadroQuartaDozeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaDozeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaDozeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaDozeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "13":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuartaTreze.treze = consultaDia.nome;
                        model.quadroQuartaTreze.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaTreze.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaTreze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaTreze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuartaTrezeMeia.trezeMeia = consultaDia.nome;
                        model.quadroQuartaTrezeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaTrezeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaTrezeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaTrezeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "14":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuartaQuatorze.quatorze = consultaDia.nome;
                        model.quadroQuartaQuatorze.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaQuatorze.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaQuatorze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaQuatorze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuartaQuatorzeMeia.quatorzeMeia = consultaDia.nome;
                        model.quadroQuartaQuatorzeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaQuatorzeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaQuatorzeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaQuatorzeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "15":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuartaQuinze.quinze = consultaDia.nome;
                        model.quadroQuartaQuinze.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaQuinze.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaQuinze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaQuinze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuartaQuinzeMeia.quinzeMeia = consultaDia.nome;
                        model.quadroQuartaQuinzeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaQuinzeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaQuinzeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaQuinzeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "16":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuartaDezesseis.dezesseis = consultaDia.nome;
                        model.quadroQuartaDezesseis.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaDezesseis.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaDezesseis.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaDezesseis.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuartaDezesseisMeia.dezesseisMeia = consultaDia.nome;
                        model.quadroQuartaDezesseisMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaDezesseisMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaDezesseisMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaDezesseisMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "17":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuartaDezessete.dezessete = consultaDia.nome;
                        model.quadroQuartaDezessete.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaDezessete.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaDezessete.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaDezessete.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuartaDezesseteMeia.dezesseteMeia = consultaDia.nome;
                        model.quadroQuartaDezesseteMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaDezesseteMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaDezesseteMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaDezesseteMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "18":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuartaDezoito.dezoito = consultaDia.nome;
                        model.quadroQuartaDezoito.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaDezoito.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaDezoito.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaDezoito.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuartaDezoitoMeia.dezoitoMeia = consultaDia.nome;
                        model.quadroQuartaDezoitoMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuartaDezoitoMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuartaDezoitoMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuartaDezoitoMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
            }
        }

        public static void AdicinarDadosBandoNaModelQuinta(string hora, string minuto,
                                                    ref ConsultarConsultasModel model, ConsultasQuery consultaDia)
        {
            switch (hora)
            {
                case "06":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuintaSeis.seis = consultaDia.nome;
                        model.quadroQuintaSeis.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaSeis.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaSeis.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaSeis.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuintaSeisMeia.seisMeia = consultaDia.nome;
                        model.quadroQuintaSeisMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaSeisMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaSeisMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaSeisMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "07":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuintaSete.sete = consultaDia.nome;
                        model.quadroQuintaSete.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaSete.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaSete.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaSete.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuintaSeteMeia.seteMeia = consultaDia.nome;
                        model.quadroQuintaSeteMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaSeteMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaSeteMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaSeteMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "08":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuintaOito.oito = consultaDia.nome;
                        model.quadroQuintaOito.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaOito.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaOito.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaOito.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuintaOitoMeia.oitoMeia = consultaDia.nome;
                        model.quadroQuintaOitoMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaOitoMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaOitoMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaOitoMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "09":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuintaNove.nove = consultaDia.nome;
                        model.quadroQuintaNove.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaNove.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaNove.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaNove.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuintaNoveMeia.noveMeia = consultaDia.nome;
                        model.quadroQuintaNoveMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaNoveMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaNoveMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaNoveMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "10":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuintaDez.dez = consultaDia.nome;
                        model.quadroQuintaDez.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaDez.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaDez.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaDez.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuintaDezMeia.dezMeia = consultaDia.nome;
                        model.quadroQuintaDezMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaDezMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaDezMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaDezMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "11":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuintaOnze.onze = consultaDia.nome;
                        model.quadroQuintaOnze.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaOnze.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaOnze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaOnze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuintaOnzeMeia.onzeMeia = consultaDia.nome;
                        model.quadroQuintaOnzeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaOnzeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaOnzeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaOnzeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "12":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuintaDoze.doze = consultaDia.nome;
                        model.quadroQuintaDoze.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaDoze.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaDoze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaDoze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuintaDozeMeia.dozeMeia = consultaDia.nome;
                        model.quadroQuintaDozeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaDozeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaDozeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaDozeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "13":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuintaTreze.treze = consultaDia.nome;
                        model.quadroQuintaTreze.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaTreze.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaTreze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaTreze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuintaTrezeMeia.trezeMeia = consultaDia.nome;
                        model.quadroQuintaTrezeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaTrezeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaTrezeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaTrezeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "14":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuintaQuatorze.quatorze = consultaDia.nome;
                        model.quadroQuintaQuatorze.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaQuatorze.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaQuatorze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaQuatorze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuintaQuatorzeMeia.quatorzeMeia = consultaDia.nome;
                        model.quadroQuintaQuatorzeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaQuatorzeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaQuatorzeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaQuatorzeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "15":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuintaQuinze.quinze = consultaDia.nome;
                        model.quadroQuintaQuinze.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaQuinze.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaQuinze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaQuinze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuintaQuinzeMeia.quinzeMeia = consultaDia.nome;
                        model.quadroQuintaQuinzeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaQuinzeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaQuinzeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaQuinzeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "16":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuintaDezesseis.dezesseis = consultaDia.nome;
                        model.quadroQuintaDezesseis.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaDezesseis.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaDezesseis.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaDezesseis.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuintaDezesseisMeia.dezesseisMeia = consultaDia.nome;
                        model.quadroQuintaDezesseisMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaDezesseisMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaDezesseisMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaDezesseisMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "17":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuintaDezessete.dezessete = consultaDia.nome;
                        model.quadroQuintaDezessete.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaDezessete.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaDezessete.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaDezessete.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuintaDezesseteMeia.dezesseteMeia = consultaDia.nome;
                        model.quadroQuintaDezesseteMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaDezesseteMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaDezesseteMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaDezesseteMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "18":
                    if (minuto.Equals("00"))
                    {
                        model.quadroQuintaDezoito.dezoito = consultaDia.nome;
                        model.quadroQuintaDezoito.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaDezoito.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaDezoito.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaDezoito.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroQuintaDezoitoMeia.dezoitoMeia = consultaDia.nome;
                        model.quadroQuintaDezoitoMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroQuintaDezoitoMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroQuintaDezoitoMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroQuintaDezoitoMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
            }
        }
        public static void AdicinarDadosBandoNaModelSexta(string hora, string minuto,
                                                    ref ConsultarConsultasModel model, ConsultasQuery consultaDia)
        {
            switch (hora)
            {
                case "06":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSextaSeis.seis = consultaDia.nome;
                        model.quadroSextaSeis.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaSeis.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaSeis.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaSeis.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSextaSeisMeia.seisMeia = consultaDia.nome;
                        model.quadroSextaSeisMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaSeisMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaSeisMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaSeisMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "07":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSextaSete.sete = consultaDia.nome;
                        model.quadroSextaSete.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaSete.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaSete.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaSete.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSextaSeteMeia.seteMeia = consultaDia.nome;
                        model.quadroSextaSeteMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaSeteMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaSeteMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaSeteMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "08":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSextaOito.oito = consultaDia.nome;
                        model.quadroSextaOito.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaOito.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaOito.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaOito.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSextaOitoMeia.oitoMeia = consultaDia.nome;
                        model.quadroSextaOitoMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaOitoMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaOitoMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaOitoMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "09":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSextaNove.nove = consultaDia.nome;
                        model.quadroSextaNove.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaNove.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaNove.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaNove.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSextaNoveMeia.noveMeia = consultaDia.nome;
                        model.quadroSextaNoveMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaNoveMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaNoveMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaNoveMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "10":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSextaDez.dez = consultaDia.nome;
                        model.quadroSextaDez.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaDez.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaDez.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaDez.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSextaDezMeia.dezMeia = consultaDia.nome;
                        model.quadroSextaDezMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaDezMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaDezMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaDezMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "11":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSextaOnze.onze = consultaDia.nome;
                        model.quadroSextaOnze.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaOnze.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaOnze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaOnze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSextaOnzeMeia.onzeMeia = consultaDia.nome;
                        model.quadroSextaOnzeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaOnzeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaOnzeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaOnzeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "12":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSextaDoze.doze = consultaDia.nome;
                        model.quadroSextaDoze.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaDoze.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaDoze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaDoze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSextaDozeMeia.dozeMeia = consultaDia.nome;
                        model.quadroSextaDozeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaDozeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaDozeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaDozeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "13":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSextaTreze.treze = consultaDia.nome;
                        model.quadroSextaTreze.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaTreze.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaTreze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaTreze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSextaTrezeMeia.trezeMeia = consultaDia.nome;
                        model.quadroSextaTrezeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaTrezeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaTrezeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaTrezeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "14":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSextaQuatorze.quatorze = consultaDia.nome;
                        model.quadroSextaQuatorze.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaQuatorze.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaQuatorze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaQuatorze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSextaQuatorzeMeia.quatorzeMeia = consultaDia.nome;
                        model.quadroSextaQuatorzeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaQuatorzeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaQuatorzeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaQuatorzeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "15":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSextaQuinze.quinze = consultaDia.nome;
                        model.quadroSextaQuinze.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaQuinze.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaQuinze.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaQuinze.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSextaQuinzeMeia.quinzeMeia = consultaDia.nome;
                        model.quadroSextaQuinzeMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaQuinzeMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaQuinzeMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaQuinzeMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "16":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSextaDezesseis.dezesseis = consultaDia.nome;
                        model.quadroSextaDezesseis.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaDezesseis.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaDezesseis.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaDezesseis.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSextaDezesseisMeia.dezesseisMeia = consultaDia.nome;
                        model.quadroSextaDezesseisMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaDezesseisMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaDezesseisMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaDezesseisMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "17":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSextaDezessete.dezessete = consultaDia.nome;
                        model.quadroSextaDezessete.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaDezessete.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaDezessete.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaDezessete.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSextaDezesseteMeia.dezesseteMeia = consultaDia.nome;
                        model.quadroSextaDezesseteMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaDezesseteMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaDezesseteMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaDezesseteMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
                case "18":
                    if (minuto.Equals("00"))
                    {
                        model.quadroSextaDezoito.dezoito = consultaDia.nome;
                        model.quadroSextaDezoito.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaDezoito.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaDezoito.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaDezoito.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    else if (minuto.Equals("30"))
                    {
                        model.quadroSextaDezoitoMeia.dezoitoMeia = consultaDia.nome;
                        model.quadroSextaDezoitoMeia.idConsulta = consultaDia.idConsulta;
                        model.quadroSextaDezoitoMeia.idPaciente = consultaDia.idPaciente;
                        model.quadroSextaDezoitoMeia.idPacienteConsulta = consultaDia.idPacienteConsulta;
                        model.quadroSextaDezoitoMeia.consultaFinalizada = consultaDia.consultaFinalizada;
                    }
                    break;
            }
        }

        public static int[] DescobrirHora(int indice) {
            int[] hora = new int[2];
            switch (indice) {
                case 1:
                    hora[0] = 6;
                    hora[1] = 00;
                    break;
                case 2:
                    hora[0] = 6;
                    hora[1] = 30;
                    break;
                case 3:
                    hora[0] = 7;
                    hora[1] = 00;
                    break;
                case 4:
                    hora[0] = 7;
                    hora[1] = 30;
                    break;
                case 5:
                    hora[0] = 8;
                    hora[1] = 00;
                    break;
                case 6:
                    hora[0] = 8;
                    hora[1] = 30;
                    break;
                case 7:
                    hora[0] = 9;
                    hora[1] = 00;
                    break;
                case 8:
                    hora[0] = 9;
                    hora[1] = 30;
                    break;
                case 9:
                    hora[0] = 10;
                    hora[1] = 00;
                    break;
                case 10:
                    hora[0] = 10;
                    hora[1] = 30;
                    break;
                case 11:
                    hora[0] = 11;
                    hora[1] = 00;
                    break;
                case 12:
                    hora[0] = 11;
                    hora[1] = 30;
                    break;
                case 13:
                    hora[0] = 12;
                    hora[1] = 00;
                    break;
                case 14:
                    hora[0] = 12;
                    hora[1] = 30;
                    break;
                case 15:
                    hora[0] = 13;
                    hora[1] = 00;
                    break;
                case 16:
                    hora[0] = 13;
                    hora[1] = 30;
                    break;
                case 17:
                    hora[0] = 14;
                    hora[1] = 00;
                    break;
                case 18:
                    hora[0] = 14;
                    hora[1] = 30;
                    break;
                case 19:
                    hora[0] = 15;
                    hora[1] = 00;
                    break;
                case 20:
                    hora[0] = 15;
                    hora[1] = 30;
                    break;
                case 21:
                    hora[0] = 16;
                    hora[1] = 00;
                    break;
                case 22:
                    hora[0] = 16;
                    hora[1] = 30;
                    break;
                case 23:
                    hora[0] = 17;
                    hora[1] = 00;
                    break;
                case 24:
                    hora[0] = 17;
                    hora[1] = 30;
                    break;
                case 25:
                    hora[0] = 18;
                    hora[1] = 00;
                    break;
                case 26:
                    hora[0] = 18;
                    hora[1] = 30;
                    break;
            }

            return hora;
        }

        public static CadastrarAusenciaBancoModel MarcarAusenciaCadastrarNoBancoModel(CadastrarAusenciaBancoModel ausenciaBancoModel, int[] listAusencia) {

            ausenciaBancoModel.Seis = listAusencia[0];
            ausenciaBancoModel.SeisMeia = listAusencia[1];
            ausenciaBancoModel.Sete = listAusencia[2];
            ausenciaBancoModel.SeteMeia = listAusencia[3];
            ausenciaBancoModel.Oito = listAusencia[4];
            ausenciaBancoModel.OitoMeia = listAusencia[5];
            ausenciaBancoModel.Nove = listAusencia[5];
            ausenciaBancoModel.NoveMeia = listAusencia[7];
            ausenciaBancoModel.Dez = listAusencia[8];
            ausenciaBancoModel.DezMeia = listAusencia[9];
            ausenciaBancoModel.Onze = listAusencia[10];
            ausenciaBancoModel.OnzeMeia = listAusencia[11];
            ausenciaBancoModel.Doze = listAusencia[12];
            ausenciaBancoModel.DozeMeia = listAusencia[13];
            ausenciaBancoModel.Treze = listAusencia[14];
            ausenciaBancoModel.TrezeMeia = listAusencia[15];
            ausenciaBancoModel.Quatorze = listAusencia[16];
            ausenciaBancoModel.QuatorzeMeia = listAusencia[17];
            ausenciaBancoModel.Quinze = listAusencia[18];
            ausenciaBancoModel.QuinzeMeia = listAusencia[19];
            ausenciaBancoModel.Dezesseis = listAusencia[20];
            ausenciaBancoModel.DezesseisMeia = listAusencia[21];
            ausenciaBancoModel.Dezessete = listAusencia[22];
            ausenciaBancoModel.DezesseteMeia = listAusencia[23];
            ausenciaBancoModel.Dezoito = listAusencia[24];
            ausenciaBancoModel.DezoitoMeia = listAusencia[25];
            return ausenciaBancoModel;
        }

        public static EditarAusenciaBancoModel MarcarAusenciaEditarNoBancoModel(EditarAusenciaBancoModel editarAusenciaBanco, int[] listAusencia) {

            editarAusenciaBanco.Seis = listAusencia[0];
            editarAusenciaBanco.SeisMeia = listAusencia[1];
            editarAusenciaBanco.Sete = listAusencia[2];
            editarAusenciaBanco.SeteMeia = listAusencia[3];
            editarAusenciaBanco.Oito = listAusencia[4];
            editarAusenciaBanco.OitoMeia = listAusencia[5];
            editarAusenciaBanco.Nove = listAusencia[5];
            editarAusenciaBanco.NoveMeia = listAusencia[7];
            editarAusenciaBanco.Dez = listAusencia[8];
            editarAusenciaBanco.DezMeia = listAusencia[9];
            editarAusenciaBanco.Onze = listAusencia[10];
            editarAusenciaBanco.OnzeMeia = listAusencia[11];
            editarAusenciaBanco.Doze = listAusencia[12];
            editarAusenciaBanco.DozeMeia = listAusencia[13];
            editarAusenciaBanco.Treze = listAusencia[14];
            editarAusenciaBanco.TrezeMeia = listAusencia[15];
            editarAusenciaBanco.Quatorze = listAusencia[16];
            editarAusenciaBanco.QuatorzeMeia = listAusencia[17];
            editarAusenciaBanco.Quinze = listAusencia[18];
            editarAusenciaBanco.QuinzeMeia = listAusencia[19];
            editarAusenciaBanco.Dezesseis = listAusencia[20];
            editarAusenciaBanco.DezesseisMeia = listAusencia[21];
            editarAusenciaBanco.Dezessete = listAusencia[22];
            editarAusenciaBanco.DezesseteMeia = listAusencia[23];
            editarAusenciaBanco.Dezoito = listAusencia[24];
            editarAusenciaBanco.DezoitoMeia = listAusencia[25];
            return editarAusenciaBanco;
        }

        public static CadastrarAusenciaBancoModel ConvertandoHoraViewParaObjeto(DateTime dataView) {
            int hora = Convert.ToInt32(dataView.ToShortTimeString().Split(':')[0]);
            int minuto = Convert.ToInt32(dataView.ToShortTimeString().Split(':')[1]);

            CadastrarAusenciaBancoModel ausenciaBancoModel = new CadastrarAusenciaBancoModel();

            switch (hora) {
                case 6:
                    if (minuto == 30) {
                        ausenciaBancoModel.SeisMeia = 1;
                        ausenciaBancoModel.retorno = 2;
                    } else {
                        ausenciaBancoModel.Seis = 1;
                        ausenciaBancoModel.retorno = 1;
                    }
                    break;
                case 7:
                    if (minuto == 30) {
                        ausenciaBancoModel.SeteMeia = 1;
                        ausenciaBancoModel.retorno = 4;
                    } else {
                        ausenciaBancoModel.Sete = 1;
                        ausenciaBancoModel.retorno = 3;
                    }
                    break;
                case 8:
                    if (minuto == 30) {
                        ausenciaBancoModel.OitoMeia = 1;
                        ausenciaBancoModel.retorno = 6;
                    } else {
                        ausenciaBancoModel.Oito = 1;
                        ausenciaBancoModel.retorno = 5;
                    }
                    break;
                case 9:
                    if (minuto == 30) {
                        ausenciaBancoModel.NoveMeia = 1;
                        ausenciaBancoModel.retorno = 8;
                    } else {
                        ausenciaBancoModel.Nove = 1;
                        ausenciaBancoModel.retorno = 7;
                    }
                    break;
                case 10:
                    if (minuto == 30) {
                        ausenciaBancoModel.DezMeia = 1;
                        ausenciaBancoModel.retorno = 10;
                    } else {
                        ausenciaBancoModel.Dez = 1;
                        ausenciaBancoModel.retorno = 9;
                    }
                    break;
                case 11:
                    if (minuto == 30) {
                        ausenciaBancoModel.OnzeMeia = 1;
                        ausenciaBancoModel.retorno = 12;
                    } else {
                        ausenciaBancoModel.Onze = 1;
                        ausenciaBancoModel.retorno = 11;
                    }
                    break;
                case 12:
                    if (minuto == 30) {
                        ausenciaBancoModel.DozeMeia = 1;
                        ausenciaBancoModel.retorno = 14;
                    } else {
                        ausenciaBancoModel.Doze = 1;
                        ausenciaBancoModel.retorno = 13;
                    }
                    break;
                case 13:
                    if (minuto == 30) {
                        ausenciaBancoModel.TrezeMeia = 1;
                        ausenciaBancoModel.retorno = 16;
                    } else {
                        ausenciaBancoModel.Treze = 1;
                        ausenciaBancoModel.retorno = 15;
                    }
                    break;
                case 14:
                    if (minuto == 30) {
                        ausenciaBancoModel.QuatorzeMeia = 1;
                        ausenciaBancoModel.retorno = 18;
                    } else {
                        ausenciaBancoModel.Quatorze = 1;
                        ausenciaBancoModel.retorno = 17;
                    }
                    break;
                case 15:
                    if (minuto == 30) {
                        ausenciaBancoModel.QuinzeMeia = 1;
                        ausenciaBancoModel.retorno = 20;
                    } else {
                        ausenciaBancoModel.Quinze = 1;
                        ausenciaBancoModel.retorno = 19;
                    }
                    break;
                case 16:
                    if (minuto == 30) {
                        ausenciaBancoModel.DezesseisMeia = 1;
                        ausenciaBancoModel.retorno = 22;
                    } else {
                        ausenciaBancoModel.Dezesseis = 1;
                        ausenciaBancoModel.retorno = 21;
                    }
                    break;
                case 17:
                    if (minuto == 30) {
                        ausenciaBancoModel.DezesseteMeia = 1;
                        ausenciaBancoModel.retorno = 24;
                    } else {
                        ausenciaBancoModel.Dezessete = 1;
                        ausenciaBancoModel.retorno = 23;
                    }
                    break;
                case 18:
                    if (minuto == 30) {
                        ausenciaBancoModel.DezoitoMeia = 1;
                        ausenciaBancoModel.retorno = 26;
                    } else {
                        ausenciaBancoModel.Dezoito = 1;
                        ausenciaBancoModel.retorno = 25;
                    }
                    break;
            }
            return ausenciaBancoModel;
        }
    }
}
 