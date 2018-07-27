using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SGCM.Models {

    public class LoginRegistroModel {
        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} caracteres.", MinimumLength = 5)]
        [Display(Name = "Usuário")]
        public string User { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "A senha e a senha de confirmação não coincidem.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginTrocarSenhaModel {

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha atual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova senha")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar nova senha")]
        [Compare("NewPassword", ErrorMessage = "A nova senha e a senha de confirmação não coincidem.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginExcluirModel {
        [Required]
        [Display(Name = "Provedor de logon")]
        public string LoginProvider { get; set; }

        [Required]
        [Display(Name = "Chave do Provedor")]
        public string ProviderKey { get; set; }
    }

    public class EfetuarLoginModel {

        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} caracteres.", MinimumLength = 5)]
        [Display(Name = "Usuário")]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [Display(Name = "Senha")]
        public string password { get; set; }
    }
}