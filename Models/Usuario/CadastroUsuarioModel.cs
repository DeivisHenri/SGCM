using System;
using System.ComponentModel.DataAnnotations;
using static SGCM.AppData.Infraestrutura.CustomMetadataProvider;

namespace SGCM.Models.Usuario.CadastroUsuarioModel
{
    public class CadastroUsuarioModel
    {
        public DadosPessoais pessoa { get; set; }
        public DadosLogin usuario { get; set; }
        public DadosPermissoes permissoes { get; set; }
    }

    public class DadosPessoais
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo Nome deve ter no máximo 50 caracteres.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }      

        [Required(ErrorMessage = "O campo Sexo é obrigatório.")]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [StringLength(14, ErrorMessage = "O campo CPF deve conter os 11 caracteres.", MinimumLength = 14)]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo RG é obrigatório.")]
        [StringLength(14, ErrorMessage = "O campo CPF deve conter os 8 caracteres.", MinimumLength = 10)]
        [Display(Name = "RG")]
        public string RG { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        [Display(Name = "Data Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo Logradouro é obrigatório.")]
        [StringLength(35, ErrorMessage = "O campo Logradouro deve conter no máximo 35 caracteres.")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo Número é obrigatório.")]
        [StringLength(6, ErrorMessage = "O campo Número deve conter no máximo 6 caracteres.")]
        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório.")]
        [StringLength(40, ErrorMessage = "O campo Bairro deve conter no máximo 40 caracteres.")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        [StringLength(30, ErrorMessage = "O campo Estado deve conter no máximo 30 caracteres.")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo UF é obrigatório.")]
        [StringLength(2, ErrorMessage = "O campo UF deve conter no máximo 2 caracteres.")]
        [Display(Name = "UF")]
        public string UF { get; set; }

        [Required(ErrorMessage = "O campo Celular é obrigatório.")]
        [StringLength(15, ErrorMessage = "O campo Celular deve conter os 11 digitos com DDD.", MinimumLength = 15)]
        [Display(Name = "Celular")]
        [HTMLMaskAttribute("mask", "(99) 99999-9999")] //phone format 
        public string Telefone_Celular { get; set; }

        [StringLength(40, ErrorMessage = "O campo E-mail deve conter no máximo 40 caracteres.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public int IdPessoa { get; set; }

        public int IdMedico { get; set; }
    }

    public class DadosLogin
    {
        [Required(ErrorMessage = "O campo Usuário é obrigatório.")]
        [Display(Name = "Usuário")]
        [StringLength(20, ErrorMessage = "O campo Usuário deve ter no mínimo 5 caracteres e no máximo 20.", MinimumLength = 5)]
        public string Username { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "O campo Senha deve ter no mínimo 6 caracteres e no máximo 20.", MinimumLength = 6)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo Confirmar Senha é obrigatório.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [StringLength(20, ErrorMessage = "O campo Senha deve ter no mínimo 6 caracteres e no máximo 20.", MinimumLength = 6)]
        [Compare("Password", ErrorMessage = "A campo Senha não é igual ao campo Confirmar Senha.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "O campo Tipo Usuário é obrigatório.")]
        [Display(Name = "Tipo Usuário")]
        public string TipoUsuario { get; set; }

        public int IdUsuario { get; set; }
    }

    public class DadosPermissoes
    {
        public string flUsuarioI { get; set; }
        public string flUsuarioC { get; set; }
        public string flUsuarioA { get; set; }
        public string flUsuarioE { get; set; }

        public string flPacienteI { get; set; }
        public string flPacienteC { get; set; }
        public string flPacienteA { get; set; }
        public string flPacienteE { get; set; }

        public string flConsultaI { get; set; }
        public string flConsultaC { get; set; }
        public string flConsultaA { get; set; }
        public string flConsultaE { get; set; }

        public string flAusenciaI { get; set; }
        public string flAusenciaC { get; set; }
        public string flAusenciaA { get; set; }
        public string flAusenciaE { get; set; }

        public string flMedicamentoI { get; set; }
        public string flMedicamentoC { get; set; }
        public string flMedicamentoA { get; set; }
        public string flMedicamentoE { get; set; }

        public string flExamesI { get; set; }
        public string flExamesC { get; set; }
        public string flExamesA { get; set; }
        public string flExamesE { get; set; }
                      
        public string flHistoriaMolestiaAtualI { get; set; }
        public string flHistoriaMolestiaAtualC { get; set; }
        public string flHistoriaMolestiaAtualA { get; set; }
        public string flHistoriaMolestiaAtualE { get; set; }

        public string flHistoriaPatologicaPregressaI { get; set; }
        public string flHistoriaPatologicaPregressaC { get; set; }
        public string flHistoriaPatologicaPregressaA { get; set; }
        public string flHistoriaPatologicaPregressaE { get; set; }

        public string flHipoteseDiagnosticaI { get; set; }
        public string flHipoteseDiagnosticaC { get; set; }
        public string flHipoteseDiagnosticaA { get; set; }
        public string flHipoteseDiagnosticaE { get; set; }

        public string flCondutaI { get; set; }
        public string flCondutaC { get; set; }
        public string flCondutaA { get; set; }
        public string flCondutaE { get; set; }  
        
        public string flIniciarAtendimento { get; set; }

        public int IdPermissoes { get; set; }

    }
}
