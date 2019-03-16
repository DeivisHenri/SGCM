using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace SGCM.Models.Medicamento
{
    public class ConsultarMedicamentoModel
    {
        public string sortOrder { get; set; }

        [MinLength(3, ErrorMessage = "O campo 'Nome Genérico' deve conter pelo menos 3 caracteres")]
        [StringLength(50, ErrorMessage = "O campo 'Nome Genérico' deve conter no máximo 50 caracteres")]
        [Display(Name = "Nome Genérico")]
        public string psqNomeGenerico { get; set; }

        [MinLength(3, ErrorMessage = "O campo 'Nome Genérico' deve conter pelo menos 3 caracteres")]
        [StringLength(50, ErrorMessage = "O campo 'Nome Genérico' deve conter no máximo 50 caracteres")]
        [Display(Name = "Nome de Fabrica")]
        public string psqNomeFabrica { get; set; }

        [MinLength(3, ErrorMessage = "O campo 'Nome Genérico' deve conter pelo menos 3 caracteres")]
        [StringLength(45, ErrorMessage = "O campo 'Nome Genérico' deve conter no máximo 45 caracteres")]
        [Display(Name = "Fabricante")]
        public string psqFabricante { get; set; }

        public IPagedList<ListaConsultaMedicamentoModel> ListaConsultaMedicamentoModel { get; set; }

        public int PageCount { get; set; }
        public int PageNumber { get; set; }

}

    public class ListaConsultaMedicamentoModel
    {
        public int idMedicamento { get; set; }
        public string nomeGenerico { get; set; }
        public string nomeFrabica { get; set; }
        public string fabricante { get; set; }
    }
}
