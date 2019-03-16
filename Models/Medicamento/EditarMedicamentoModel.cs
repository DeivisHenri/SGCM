using System;
using System.ComponentModel.DataAnnotations;

namespace SGCM.Models.Medicamento
{
    public class EditarMedicamentoModel
    {
        public int idMedicamento { get; set; }
        [Required(ErrorMessage = "O campo 'Nome Genérico' é obrigatório.")]
        [MinLength(5, ErrorMessage = "O campo 'Nome Genérico' deve conter pelo menos 5 caracteres")]
        [StringLength(50, ErrorMessage = "O campo 'Nome Genérico' deve conter no máximo 50 caracteres")]
        [Display(Name = "Nome Genérico")]
        public string nomeGenerico { get; set; }

        [Required(ErrorMessage = "O campo 'Nome de Fábrica' é obrigatório.")]
        [MinLength(5, ErrorMessage = "O campo 'Nome de Fábrica' deve conter pelo menos 5 caracteres")]
        [StringLength(50, ErrorMessage = "O campo 'Nome de Fábrica' deve conter no máximo 50 caracteres.")]
        [Display(Name = "Nome de Fábrica")]
        public string nomeFrabica { get; set; }

        [Required(ErrorMessage = "O campo 'Fabricante' é obrigatório.")]
        [MinLength(5, ErrorMessage = "O campo 'Fabricante' deve conter pelo menos 5 caracteres")]
        [StringLength(45, ErrorMessage = "O campo 'Fabricante' deve conter no máximo 50 caracteres.")]
        [Display(Name = "Fabricante")]
        public string fabricante { get; set; }
    }
}
