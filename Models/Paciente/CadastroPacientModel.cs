using System.ComponentModel.DataAnnotations;
using static SGCM.AppData.Infraestrutura.CustomMetadataProvider;

namespace SGCM.Models.Paciente.CadastroPacienteModel
{
    public class CadastroPacienteModel
    {
        public DadosPessoais pessoa { get; set; }
    }

    public class DadosPessoais
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo Nome deve ter no máximo 50 caracteres.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [StringLength(14, ErrorMessage = "O campo CPF deve conter os 11 caracteres.", MinimumLength = 14)]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo RG é obrigatório.")]
        [StringLength(14, ErrorMessage = "O campo CPF deve conter os 8 caracteres.", MinimumLength = 10)]
        [Display(Name = "RG")]
        public string RG { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        [StringLength(20, ErrorMessage = "O campo Estado deve conter no máximo 20 caracteres.")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        [StringLength(30, ErrorMessage = "O campo Estado deve conter no máximo 30 caracteres.")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório.")]
        [StringLength(40, ErrorMessage = "O campo Bairro deve conter no máximo 40 caracteres.")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo Endereço é obrigatório.")]
        [StringLength(35, ErrorMessage = "O campo Endereco deve conter no máximo 35 caracteres.")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O campo Número é obrigatório.")]
        [Display(Name = "Número")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O campo Celular é obrigatório.")]
        [StringLength(15, ErrorMessage = "O campo Celular deve conter os 11 digitos com DDD.", MinimumLength = 15)]
        [Display(Name = "Celular")]
        [HTMLMaskAttribute("mask", "(99) 99999-9999")] //phone format 
        public string Telefone_Celular { get; set; }

        [StringLength(40, ErrorMessage = "O campo E-mail deve conter no máximo 40 caracteres.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        [StringLength(10, ErrorMessage = "O campo Data de Nascimento deve conter no máximo 10 caracteres")]
        [Display(Name = "Data Nascimento")]
        public string DataNascimento { get; set; }

        public int TipoUsuario { get; set; }

        public int IdPessoa { get; set; }

        public int IdMedico { get; set; }
    }

}