using System.ComponentModel.DataAnnotations;

namespace SGCM.Models.Account
{
    public class LoginViewModel
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

        [Display(Name = "Me lembrar?")]
        public bool RememberMe { get; set; }
    }
}
