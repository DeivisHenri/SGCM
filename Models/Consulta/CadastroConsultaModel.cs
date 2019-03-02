using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SGCM.AppData.Infraestrutura.CustomMetadataProvider;

namespace SGCM.Models.Consulta.CadastroConsultaModel {

    public class CadastroConsultaModel {
        public DadosConsulta consulta { get; set; }
        public DadosPaciente Paciente { get; set; }
        public List<DadosPaciente> pacienteList { get; set; }

    }

    public class DadosConsulta {
        [Required(ErrorMessage = "O campo Data de Consulta é obrigatório.")]
        [Display(Name = "Data Consulta")]
        public DateTime DataConsulta { get; set; }

        public int idConsulta { get; set; }

        public Boolean flagPM { get; set; }
    }

    public class DadosPaciente {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo Nome deve ter no máximo 50 caracteres.", MinimumLength = 3)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [StringLength(14, ErrorMessage = "O campo CPF deve conter os 11 caracteres.", MinimumLength = 14)]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        public int idPaciente { get; set; }
    }
}