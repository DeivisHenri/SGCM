using System.Text.RegularExpressions;
using SGCM.Models.Usuario.CadastroUsuarioModel;
using SGCM.Models.Usuario.EditarUsuarioModel;

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

            if ((dadosPermissoes.FlUsuarioI == "true") || (dadosPermissoes.FlUsuarioI == "True")) {
                dadosPermissoes.FlUsuarioI = valorTrue.ToString();
            } else {
                dadosPermissoes.FlUsuarioI = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlUsuarioC == "true") || (dadosPermissoes.FlUsuarioC == "True")) {
                dadosPermissoes.FlUsuarioC = valorTrue.ToString();
            } else {
                dadosPermissoes.FlUsuarioC = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlUsuarioA == "true") || (dadosPermissoes.FlUsuarioA == "True")) {
                dadosPermissoes.FlUsuarioA = valorTrue.ToString();
            } else {
                dadosPermissoes.FlUsuarioA = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlUsuarioE == "true") || (dadosPermissoes.FlUsuarioE == "True")) {
                dadosPermissoes.FlUsuarioE = valorTrue.ToString();
            } else {
                dadosPermissoes.FlUsuarioE = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlPacienteI == "true") || (dadosPermissoes.FlPacienteI == "True")) {
                dadosPermissoes.FlPacienteI = valorTrue.ToString();
            } else {
                dadosPermissoes.FlPacienteI = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlPacienteC == "true") || (dadosPermissoes.FlPacienteC == "True")) {
                dadosPermissoes.FlPacienteC = valorTrue.ToString();
            } else {
                dadosPermissoes.FlPacienteC = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlPacienteA == "true") || (dadosPermissoes.FlPacienteA == "True")) {
                dadosPermissoes.FlPacienteA = valorTrue.ToString();
            } else {
                dadosPermissoes.FlPacienteA = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlPacienteE == "true") || (dadosPermissoes.FlPacienteE == "True")) {
                dadosPermissoes.FlPacienteE = valorTrue.ToString();
            } else {
                dadosPermissoes.FlPacienteE = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlConsultaI == "true") || (dadosPermissoes.FlConsultaI == "True")) {
                dadosPermissoes.FlConsultaI = valorTrue.ToString();
            } else {
                dadosPermissoes.FlConsultaI = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlConsultaC == "true") || (dadosPermissoes.FlConsultaC == "True")) {
                dadosPermissoes.FlConsultaC = valorTrue.ToString();
            } else {
                dadosPermissoes.FlConsultaC = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlConsultaA == "true") || (dadosPermissoes.FlConsultaA == "True")) {
                dadosPermissoes.FlConsultaA = valorTrue.ToString();
            } else {
                dadosPermissoes.FlConsultaA = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlConsultaE == "true") || (dadosPermissoes.FlConsultaE == "True")) {
                dadosPermissoes.FlConsultaE = valorTrue.ToString();
            } else {
                dadosPermissoes.FlConsultaE = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlMedicamentoI == "true") || (dadosPermissoes.FlMedicamentoI == "True")) {
                dadosPermissoes.FlMedicamentoI = valorTrue.ToString();
            } else {
                dadosPermissoes.FlMedicamentoI = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlMedicamentoC == "true") || (dadosPermissoes.FlMedicamentoC == "True")) {
                dadosPermissoes.FlMedicamentoC = valorTrue.ToString();
            } else {
                dadosPermissoes.FlMedicamentoC = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlMedicamentoA == "true") || (dadosPermissoes.FlMedicamentoA == "True")) {
                dadosPermissoes.FlMedicamentoA = valorTrue.ToString();
            } else {
                dadosPermissoes.FlMedicamentoA = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlMedicamentoE == "true") || (dadosPermissoes.FlMedicamentoE == "True")) {
                dadosPermissoes.FlMedicamentoE = valorTrue.ToString();
            } else {
                dadosPermissoes.FlMedicamentoE = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlExamesI == "true") || (dadosPermissoes.FlExamesI == "True")) {
                dadosPermissoes.FlExamesI = valorTrue.ToString();
            } else {
                dadosPermissoes.FlExamesI = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlExamesC == "true") || (dadosPermissoes.FlExamesC == "True")) {
                dadosPermissoes.FlExamesC = valorTrue.ToString();
            } else {
                dadosPermissoes.FlExamesC = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlExamesA == "true") || (dadosPermissoes.FlExamesA == "True")) {
                dadosPermissoes.FlExamesA = valorTrue.ToString();
            } else {
                dadosPermissoes.FlExamesA = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlExamesE == "true") || (dadosPermissoes.FlExamesE == "True")) {
                dadosPermissoes.FlExamesE = valorTrue.ToString();
            } else {
                dadosPermissoes.FlExamesE = valorFalse.ToString();
            }

            return dadosPermissoes;
        }

        public static Models.Usuario.EditarUsuarioModel.DadosPermissoes ConversaoPermissoesStringParaIntEditar(Models.Usuario.EditarUsuarioModel.DadosPermissoes dadosPermissoes) {
            int valorTrue = 1;
            int valorFalse = 0;

            if ((dadosPermissoes.FlUsuarioI == "true") || (dadosPermissoes.FlUsuarioI == "True"))
            {
                dadosPermissoes.FlUsuarioI = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.FlUsuarioI = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlUsuarioC == "true") || (dadosPermissoes.FlUsuarioC == "True"))
            {
                dadosPermissoes.FlUsuarioC = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.FlUsuarioC = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlUsuarioA == "true") || (dadosPermissoes.FlUsuarioA == "True"))
            {
                dadosPermissoes.FlUsuarioA = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.FlUsuarioA = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlUsuarioE == "true") || (dadosPermissoes.FlUsuarioE == "True"))
            {
                dadosPermissoes.FlUsuarioE = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.FlUsuarioE = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlPacienteI == "true") || (dadosPermissoes.FlPacienteI == "True"))
            {
                dadosPermissoes.FlPacienteI = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.FlPacienteI = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlPacienteC == "true") || (dadosPermissoes.FlPacienteC == "True"))
            {
                dadosPermissoes.FlPacienteC = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.FlPacienteC = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlPacienteA == "true") || (dadosPermissoes.FlPacienteA == "True"))
            {
                dadosPermissoes.FlPacienteA = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.FlPacienteA = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlPacienteE == "true") || (dadosPermissoes.FlPacienteE == "True"))
            {
                dadosPermissoes.FlPacienteE = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.FlPacienteE = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlConsultaI == "true") || (dadosPermissoes.FlConsultaI == "True"))
            {
                dadosPermissoes.FlConsultaI = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.FlConsultaI = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlConsultaC == "true") || (dadosPermissoes.FlConsultaC == "True"))
            {
                dadosPermissoes.FlConsultaC = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.FlConsultaC = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlConsultaA == "true") || (dadosPermissoes.FlConsultaA == "True"))
            {
                dadosPermissoes.FlConsultaA = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.FlConsultaA = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlConsultaE == "true") || (dadosPermissoes.FlConsultaE == "True"))
            {
                dadosPermissoes.FlConsultaE = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.FlConsultaE = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlMedicamentoI == "true") || (dadosPermissoes.FlMedicamentoI == "True"))
            {
                dadosPermissoes.FlMedicamentoI = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.FlMedicamentoI = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlMedicamentoC == "true") || (dadosPermissoes.FlMedicamentoC == "True"))
            {
                dadosPermissoes.FlMedicamentoC = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.FlMedicamentoC = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlMedicamentoA == "true") || (dadosPermissoes.FlMedicamentoA == "True"))
            {
                dadosPermissoes.FlMedicamentoA = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.FlMedicamentoA = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlMedicamentoE == "true") || (dadosPermissoes.FlMedicamentoE == "True"))
            {
                dadosPermissoes.FlMedicamentoE = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.FlMedicamentoE = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlExamesI == "true") || (dadosPermissoes.FlExamesI == "True"))
            {
                dadosPermissoes.FlExamesI = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.FlExamesI = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlExamesC == "true") || (dadosPermissoes.FlExamesC == "True"))
            {
                dadosPermissoes.FlExamesC = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.FlExamesC = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlExamesA == "true") || (dadosPermissoes.FlExamesA == "True"))
            {
                dadosPermissoes.FlExamesA = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.FlExamesA = valorFalse.ToString();
            }

            if ((dadosPermissoes.FlExamesE == "true") || (dadosPermissoes.FlExamesE == "True"))
            {
                dadosPermissoes.FlExamesE = valorTrue.ToString();
            }
            else
            {
                dadosPermissoes.FlExamesE = valorFalse.ToString();
            }

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
                    return "sábado";
                case 1:
                    return "domingo";
                case 2:
                    return "segunda-feira";
                case 3:
                    return "terça-feira";
                case 4:
                    return "quarta-feira";
                case 5:
                    return "quinta-feira";
                case 6:
                    return "sexta-feira";
            }
            return "";
        }
    }
}