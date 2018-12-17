using System.Text.RegularExpressions;
using SGCM.Models.Usuario.CadastroUsuarioModel;

namespace SGCM.AppData.Infraestrutura.UtilMetodo
{
    public class UtilMetodo
    {
        public static string RemovendoCaracteresEspeciais(string cpf)
        {
            Regex rgx = new Regex(@"[^\d]");
            return rgx.Replace(cpf, "").ToString();
        }

        public static CadastroUsuarioModel ConversaoPermissoesStringParaInt(CadastroUsuarioModel usuario)
        {
            int valorTrue = 1;
            int valorFalse = 0;

            if ((usuario.permissoes.FlUsuarioI == "true") || (usuario.permissoes.FlUsuarioI == "True")) {
                usuario.permissoes.FlUsuarioI = valorTrue.ToString();
            } else {
                usuario.permissoes.FlUsuarioI = valorFalse.ToString();
            }

            if ((usuario.permissoes.FlUsuarioC == "true") || (usuario.permissoes.FlUsuarioC == "True")) {
                usuario.permissoes.FlUsuarioC = valorTrue.ToString();
            } else {
                usuario.permissoes.FlUsuarioC = valorFalse.ToString();
            }

            if ((usuario.permissoes.FlUsuarioA == "true") || (usuario.permissoes.FlUsuarioA == "True")) {
                usuario.permissoes.FlUsuarioA = valorTrue.ToString();
            } else {
                usuario.permissoes.FlUsuarioA = valorFalse.ToString();
            }

            if ((usuario.permissoes.FlUsuarioE == "true") || (usuario.permissoes.FlUsuarioE == "True")) {
                usuario.permissoes.FlUsuarioE = valorTrue.ToString();
            } else {
                usuario.permissoes.FlUsuarioE = valorFalse.ToString();
            }

            if ((usuario.permissoes.FlPacienteI == "true") || (usuario.permissoes.FlPacienteI == "True")) {
                usuario.permissoes.FlPacienteI = valorTrue.ToString();
            } else {
                usuario.permissoes.FlPacienteI = valorFalse.ToString();
            }

            if ((usuario.permissoes.FlPacienteC == "true") || (usuario.permissoes.FlPacienteC == "True")) {
                usuario.permissoes.FlPacienteC = valorTrue.ToString();
            } else {
                usuario.permissoes.FlPacienteC = valorFalse.ToString();
            }

            if ((usuario.permissoes.FlPacienteA == "true") || (usuario.permissoes.FlPacienteA == "True")) {
                usuario.permissoes.FlPacienteA = valorTrue.ToString();
            } else {
                usuario.permissoes.FlPacienteA = valorFalse.ToString();
            }

            if ((usuario.permissoes.FlPacienteE == "true") || (usuario.permissoes.FlPacienteE == "True")) {
                usuario.permissoes.FlPacienteE = valorTrue.ToString();
            } else {
                usuario.permissoes.FlPacienteE = valorFalse.ToString();
            }

            if ((usuario.permissoes.FlConsultaI == "true") || (usuario.permissoes.FlConsultaI == "True")) {
                usuario.permissoes.FlConsultaI = valorTrue.ToString();
            } else {
                usuario.permissoes.FlConsultaI = valorFalse.ToString();
            }

            if ((usuario.permissoes.FlConsultaC == "true") || (usuario.permissoes.FlConsultaC == "True")) {
                usuario.permissoes.FlConsultaC = valorTrue.ToString();
            } else {
                usuario.permissoes.FlConsultaC = valorFalse.ToString();
            }

            if ((usuario.permissoes.FlConsultaA == "true") || (usuario.permissoes.FlConsultaA == "True")) {
                usuario.permissoes.FlConsultaA = valorTrue.ToString();
            } else {
                usuario.permissoes.FlConsultaA = valorFalse.ToString();
            }

            if ((usuario.permissoes.FlConsultaE == "true") || (usuario.permissoes.FlConsultaE == "True")) {
                usuario.permissoes.FlConsultaE = valorTrue.ToString();
            } else {
                usuario.permissoes.FlConsultaE = valorFalse.ToString();
            }

            if ((usuario.permissoes.FlMedicamentoI == "true") || (usuario.permissoes.FlMedicamentoI == "True")) {
                usuario.permissoes.FlMedicamentoI = valorTrue.ToString();
            } else {
                usuario.permissoes.FlMedicamentoI = valorFalse.ToString();
            }

            if ((usuario.permissoes.FlMedicamentoC == "true") || (usuario.permissoes.FlMedicamentoC == "True")) {
                usuario.permissoes.FlMedicamentoC = valorTrue.ToString();
            } else {
                usuario.permissoes.FlMedicamentoC = valorFalse.ToString();
            }

            if ((usuario.permissoes.FlMedicamentoA == "true") || (usuario.permissoes.FlMedicamentoA == "True")) {
                usuario.permissoes.FlMedicamentoA = valorTrue.ToString();
            } else {
                usuario.permissoes.FlMedicamentoA = valorFalse.ToString();
            }

            if ((usuario.permissoes.FlMedicamentoE == "true") || (usuario.permissoes.FlMedicamentoE == "True")) {
                usuario.permissoes.FlMedicamentoE = valorTrue.ToString();
            } else {
                usuario.permissoes.FlMedicamentoE = valorFalse.ToString();
            }

            if ((usuario.permissoes.FlExamesI == "true") || (usuario.permissoes.FlExamesI == "True")) {
                usuario.permissoes.FlExamesI = valorTrue.ToString();
            } else {
                usuario.permissoes.FlExamesI = valorFalse.ToString();
            }

            if ((usuario.permissoes.FlExamesC == "true") || (usuario.permissoes.FlExamesC == "True")) {
                usuario.permissoes.FlExamesC = valorTrue.ToString();
            } else {
                usuario.permissoes.FlExamesC = valorFalse.ToString();
            }

            if ((usuario.permissoes.FlExamesA == "true") || (usuario.permissoes.FlExamesA == "True")) {
                usuario.permissoes.FlExamesA = valorTrue.ToString();
            } else {
                usuario.permissoes.FlExamesA = valorFalse.ToString();
            }

            if ((usuario.permissoes.FlExamesE == "true") || (usuario.permissoes.FlExamesE == "True")) {
                usuario.permissoes.FlExamesE = valorTrue.ToString();
            } else {
                usuario.permissoes.FlExamesE = valorFalse.ToString();
            }

            return usuario;
        }

        public static string ArrumarDateFormatoBanco(string data)
        {
            var dataArray = data.Split('/');
            var dataReturn = dataArray[2] + "-" + dataArray[1] + "-" + dataArray[0];

            return dataReturn;
        }
    }
}
