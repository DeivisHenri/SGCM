using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using SGCM.AppData.Usuarios;
using SGCM.Models.Usuarios;

namespace SGCM.AppData.Infraestrutura.UtilMetodo
{
    public class UtilMetodo
    {
        public static string RemovendoCaracteresEspeciais(string cpf)
        {
            Regex rgx = new Regex(@"[^\d]");
            return rgx.Replace(cpf, "").ToString();
        }

        public static PermissoesTO ConversaoPermissoesStringParaInt(PermissoesTO permissoesTO, UsuariosModel usuario)
        {
            if ((usuario.permissoes.FlUsuarioI == "true") || (usuario.permissoes.FlUsuarioI == "True")) {
                permissoesTO.Fl_Usuario_I = 1;
            } else {
                permissoesTO.Fl_Usuario_I = 0;
            }

            if ((usuario.permissoes.FlUsuarioC == "true") || (usuario.permissoes.FlUsuarioC == "True")) {
                permissoesTO.Fl_Usuario_C = 1;
            } else {
                permissoesTO.Fl_Usuario_C = 0;
            }

            if ((usuario.permissoes.FlUsuarioA == "true") || (usuario.permissoes.FlUsuarioA == "True")) {
                permissoesTO.Fl_Usuario_A = 1;
            } else {
                permissoesTO.Fl_Usuario_A = 0;
            }

            if ((usuario.permissoes.FlUsuarioE == "true") || (usuario.permissoes.FlUsuarioE == "True")) {
                permissoesTO.Fl_Usuario_E = 1;
            } else {
                permissoesTO.Fl_Usuario_E = 0;
            }

            if ((usuario.permissoes.FlPacienteI == "true") || (usuario.permissoes.FlPacienteI == "True")) {
                permissoesTO.Fl_Paciente_I = 1;
            } else {
                permissoesTO.Fl_Paciente_I = 0;
            }

            if ((usuario.permissoes.FlPacienteC == "true") || (usuario.permissoes.FlPacienteC == "True")) {
                permissoesTO.Fl_Paciente_C = 1;
            } else {
                permissoesTO.Fl_Paciente_C = 0;
            }

            if ((usuario.permissoes.FlPacienteA == "true") || (usuario.permissoes.FlPacienteA == "True")) {
                permissoesTO.Fl_Paciente_A = 1;
            } else {
                permissoesTO.Fl_Paciente_A = 0;
            }

            if ((usuario.permissoes.FlPacienteE == "true") || (usuario.permissoes.FlPacienteE == "True")) {
                permissoesTO.Fl_Paciente_E = 1;
            } else {
                permissoesTO.Fl_Paciente_E = 0;
            }

            if ((usuario.permissoes.FlConsultaI == "true") || (usuario.permissoes.FlConsultaI == "True")) {
                permissoesTO.Fl_Consulta_I = 1;
            } else {
                permissoesTO.Fl_Consulta_I = 0;
            }

            if ((usuario.permissoes.FlConsultaC == "true") || (usuario.permissoes.FlConsultaC == "True")) {
                permissoesTO.Fl_Consulta_C = 1;
            } else {
                permissoesTO.Fl_Consulta_C = 0;
            }

            if ((usuario.permissoes.FlConsultaA == "true") || (usuario.permissoes.FlConsultaA == "True")) {
                permissoesTO.Fl_Consulta_A = 1;
            } else {
                permissoesTO.Fl_Consulta_A = 0;
            }

            if ((usuario.permissoes.FlConsultaE == "true") || (usuario.permissoes.FlConsultaE == "True")) {
                permissoesTO.Fl_Consulta_E = 1;
            } else {
                permissoesTO.Fl_Consulta_E = 0;
            }

            if ((usuario.permissoes.FlMedicamentoI == "true") || (usuario.permissoes.FlMedicamentoI == "True")) {
                permissoesTO.Fl_Medicamento_I = 1;
            } else {
                permissoesTO.Fl_Medicamento_I = 0;
            }

            if ((usuario.permissoes.FlMedicamentoC == "true") || (usuario.permissoes.FlMedicamentoC == "True")) {
                permissoesTO.Fl_Medicamento_C = 1;
            } else {
                permissoesTO.Fl_Medicamento_C = 0;
            }

            if ((usuario.permissoes.FlMedicamentoA == "true") || (usuario.permissoes.FlMedicamentoA == "True")) {
                permissoesTO.Fl_Medicamento_A = 1;
            } else {
                permissoesTO.Fl_Medicamento_A = 0;
            }

            if ((usuario.permissoes.FlMedicamentoE == "true") || (usuario.permissoes.FlMedicamentoE == "True")) {
                permissoesTO.Fl_Medicamento_E = 1;
            } else {
                permissoesTO.Fl_Medicamento_E = 0;
            }

            if ((usuario.permissoes.FlExamesI == "true") || (usuario.permissoes.FlExamesI == "True")) {
                permissoesTO.Fl_Exames_I = 1;
            } else {
                permissoesTO.Fl_Exames_I = 0;
            }

            if ((usuario.permissoes.FlExamesC == "true") || (usuario.permissoes.FlExamesC == "True")) {
                permissoesTO.Fl_Exames_C = 1;
            } else {
                permissoesTO.Fl_Exames_C = 0;
            }

            if ((usuario.permissoes.FlExamesA == "true") || (usuario.permissoes.FlExamesA == "True")) {
                permissoesTO.Fl_Exames_A = 1;
            } else {
                permissoesTO.Fl_Exames_A = 0;
            }

            if ((usuario.permissoes.FlExamesE == "true") || (usuario.permissoes.FlExamesE == "True")) {
                permissoesTO.Fl_Exames_E = 1;
            } else {
                permissoesTO.Fl_Exames_E = 0;
            }

            return permissoesTO;
        }
    }
}
