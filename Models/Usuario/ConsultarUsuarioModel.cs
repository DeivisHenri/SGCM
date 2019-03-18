﻿using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace SGCM.Models.Usuario.ConsultarUsuarioModel
{
    public class ConsultarUsuarioModel
    {
        public string sortOrder { get; set; }

        [MinLength(3, ErrorMessage = "O campo 'Nome' deve conter pelo menos 3 caracteres")]
        [StringLength(50, ErrorMessage = "O campo 'Nome' deve conter no máximo 50 caracteres")]
        [Display(Name = "Nome")]
        public string psqNome { get; set; }

        [MinLength(14, ErrorMessage = "O campo 'CPF' deve conter pelo menos 11 caracteres")]
        [StringLength(14, ErrorMessage = "O campo 'CPF' deve conter no máximo 11 caracteres")]
        [Display(Name = "CPF")]
        public string psqCPF { get; set; }

        [MinLength(11, ErrorMessage = "O campo 'Telefone Celular' deve conter pelo menos 11 caracteres")]
        [StringLength(11, ErrorMessage = "O campo 'Telefone Celular' deve conter no máximo 11 caracteres")]
        [Display(Name = "Telefone Celular")]
        public string psqTelefoneCelular { get; set; }

        public IPagedList<ListaConsultarUsuarioModel> ListaConsultarUsuarioModel { get; set; }

        public int PageCount { get; set; }
        public int PageNumber { get; set; }
    }

    public class ListaConsultarUsuarioModel
    {
        public int idUsuario { get; set; }
        public int idPessoa { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string TelefoneCelular { get; set; }
    }
}
