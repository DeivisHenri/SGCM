﻿using System;
using System.ComponentModel.DataAnnotations;
using static SGCM.AppData.Infraestrutura.CustomMetadataProvider;

namespace SGCM.Models.Usuario.EditarUsuarioModel
{
    public class EditarUsuarioModel
    {
        public DadosPessoais pessoa { get; set; }
        public DadosLogin usuario { get; set; }
        public DadosPermissoes permissoes { get; set; }
    }

    public class DadosPessoais
    {
        [StringLength(50, ErrorMessage = "O campo Nome deve ter no máximo 50 caracteres.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [StringLength(14, ErrorMessage = "O campo CPF deve conter os 11 caracteres.", MinimumLength = 14)]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo RG é obrigatório.")]
        [StringLength(14, ErrorMessage = "O campo RG deve conter os 8 caracteres.", MinimumLength = 10)]
        [Display(Name = "RG")]
        public string RG { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        [Display(Name = "Data Nascimento")]
        public DateTime  DataNascimento { get; set; }

        [StringLength(35, ErrorMessage = "O campo Logradouro deve conter no máximo 35 caracteres.")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }
        [Display(Name = "Número")]
        public int Numero { get; set; }

        [StringLength(40, ErrorMessage = "O campo Bairro deve conter no máximo 40 caracteres.")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [StringLength(30, ErrorMessage = "O campo Estado deve conter no máximo 30 caracteres.")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [StringLength(2, ErrorMessage = "O campo Estado deve conter no máximo 2 caracteres.")]
        [Display(Name = "UF")]
        public string UF { get; set; }

        [StringLength(15, ErrorMessage = "O campo Celular deve conter os 11 digitos com DDD.", MinimumLength = 15)]
        [Display(Name = "Celular")]
        [HTMLMaskAttribute("mask", "(99) 99999-9999")] //phone format 
        public string Telefone_Celular { get; set; }

        [StringLength(40, ErrorMessage = "O campo E-mail deve conter no máximo 40 caracteres.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Tipo Usuário")]
        public string TipoUsuario { get; set; }

        [Display(Name = "Status do Usuário")]
        public string Status { get; set; }

        public int IdPessoa { get; set; }

        public int IdMedico { get; set; }
    }

    public class DadosLogin
    {
        [Display(Name = "Usuário")]
        [StringLength(20, ErrorMessage = "O campo Usuário deve ter no mínimo 5 caracteres e no máximo 20.", MinimumLength = 5)]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "O campo Senha deve ter no mínimo 6 caracteres e no máximo 20.", MinimumLength = 6)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [StringLength(20, ErrorMessage = "O campo Senha deve ter no mínimo 6 caracteres e no máximo 20.", MinimumLength = 6)]
        [Compare("Password", ErrorMessage = "A campo Senha não é igual ao campo Confirmar Senha.")]
        public string ConfirmPassword { get; set; }

        public int IdUsuario { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataDesativacao { get; set; }
    }

    public class DadosPermissoes
    {
        public string FlUsuarioI { get; set; }
        public string FlUsuarioC { get; set; }
        public string FlUsuarioA { get; set; }
        public string FlUsuarioE { get; set; }
        public string FlPacienteI { get; set; }
        public string FlPacienteC { get; set; }
        public string FlPacienteA { get; set; }
        public string FlPacienteE { get; set; }
        public string FlConsultaI { get; set; }
        public string FlConsultaC { get; set; }
        public string FlConsultaA { get; set; }
        public string FlConsultaE { get; set; }
        public string FlMedicamentoI { get; set; }
        public string FlMedicamentoC { get; set; }
        public string FlMedicamentoA { get; set; }
        public string FlMedicamentoE { get; set; }
        public string FlExamesI { get; set; }
        public string FlExamesC { get; set; }
        public string FlExamesA { get; set; }
        public string FlExamesE { get; set; }

        public int IdPermissoes { get; set; }

        public int IdUsuario { get; set; }
    }
}
