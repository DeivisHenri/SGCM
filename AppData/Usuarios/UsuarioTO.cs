using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCM.AppData.Usuario
{
    public class UsuarioCompletoTO {

        public UsuarioTO usuarioTO { get; set; }

        public PessoaTO pessoaTO { get; set; }

        public PermissoesTO permissoesTO { get; set; }

        public int IdRetorno { get; set; }
    }

    public class UsuarioTO {

        public int idUsuario { get; set; }

        public int idPessoa { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public string statusDesativado { get; set; }
    }

    public class PessoaTO
    {
        public int idPessoa { get; set; }
        public int idMedico { get; set; }
        public int tipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string DataNascimento { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Telefone_Celular { get; set; }
        public string Email { get; set; }
    }

    public class PermissoesTO {
        public int idPermissoes { get; set; }
        public int IdUsuario { get; set; }
        public int flUsuarioI { get; set; }
        public int flUsuarioC { get; set; }
        public int flUsuarioA { get; set; }
        public int flUsuarioE { get; set; }
        public int flPacienteI { get; set; }
        public int flPacienteC { get; set; }
        public int flPacienteA { get; set; }
        public int flPacienteE { get; set; }
        public int flConsultaI { get; set; }
        public int flConsultaC { get; set; }
        public int flConsultaA { get; set; }
        public int flConsultaE { get; set; }
        public int flAusenciaI { get; set; }
        public int flAusenciaC { get; set; }
        public int flAusenciaA { get; set; }
        public int flAusenciaE { get; set; }
        public int flMedicamentoI { get; set; }
        public int flMedicamentoC { get; set; }
        public int flMedicamentoA { get; set; }
        public int flMedicamentoE { get; set; }
        public int flExamesI { get; set; }
        public int flExamesC { get; set; }
        public int flExamesA { get; set; }
        public int flExamesE { get; set; }
        public int flReceitaI { get; set; }
        public int flReceitaC { get; set; }
        public int flReceitaA { get; set; }
        public int flReceitaE { get; set; }
        public int flHistoriaMolestiaAtualI { get; set; }
        public int flHistoriaMolestiaAtualC { get; set; }
        public int flHistoriaMolestiaAtualA { get; set; }
        public int flHistoriaMolestiaAtualE { get; set; }
        public int flHistoriaPatologicaPregressaI { get; set; }
        public int flHistoriaPatologicaPregressaC { get; set; }
        public int flHistoriaPatologicaPregressaA { get; set; }
        public int flHistoriaPatologicaPregressaE { get; set; }
        public int flHipoteseDiagnosticaI { get; set; }
        public int flHipoteseDiagnosticaC { get; set; }
        public int flHipoteseDiagnosticaA { get; set; }
        public int flHipoteseDiagnosticaE { get; set; }
        public int flCondutaI { get; set; }
        public int flCondutaC { get; set; }
        public int flCondutaA { get; set; }
        public int flCondutaE { get; set; }
        public int flIniciarAtendimento { get; set; }
    }
}
