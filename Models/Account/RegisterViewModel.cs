using System;
using System.ComponentModel.DataAnnotations;

namespace SGCM.Models.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O campo Usuário é obrigatório.")]
        [Display(Name = "Usuário")]
        [StringLength(20, ErrorMessage = "O campo Usuário deve ter no mínimo 6 caracteres e no máximo 20.", MinimumLength = 5)]
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
        
        public string TipoUsuario { get; set; }
        public string FlUsuarioI { get; set; }
        public string FlUsuarioC { get; set; }
        public string FlUsuarioA { get; set; }
        public string FlUsuarioE { get; set; }
        public string FlPacienteI { get; set; }
        public string FlPacienteC { get; set; }
        public string FlPacienteA { get; set; }
        public string FlPacienteE { get; set; }
        public string FlMedicamentoI { get; set; }
        public string FlMedicamentoC { get; set; }
        public string FlMedicamentoA { get; set; }
        public string FlMedicamentoE { get; set; }
        public string FlExamesI { get; set; }
        public string FlExamesC { get; set; }
        public string FlExamesA { get; set; }
        public string FlExamesE { get; set; }

    }
}
