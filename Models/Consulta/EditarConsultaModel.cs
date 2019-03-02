using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SGCM.AppData.Infraestrutura.CustomMetadataProvider;

namespace SGCM.Models.Consulta.EditarConsultaModel {
    public class EditarConsultaModel {
        public DadosConsulta Consulta { get; set; }

        public DadosPaciente Paciente { get; set; }

        public List<DadosPaciente> pacienteList { get; set; }

        public DadosMolestiaAtual MolestiaAtual { get; set; }

        public DadosPatologicaPregressa PatologicaPregressa { get; set; }

        public DadosExameFisico ExameFisico { get; set; }

        public List<DadosExameLaboratorial> ExameLaboratorialLista { get; set; }

        public DadosHipoteseDiagnostica HipoteseDiagnostica { get; set; }

        public DadosConduta Conduta { get; set; }

        public string ExamePedido { get; set; }

        public List<DadosExamePedido> ListaExamePedido;
    }

    public class DadosConsulta {
        [Required(ErrorMessage = "O campo Data de Consulta é obrigatório.")]
        [Display(Name = "Data Consulta")]
        public DateTime DataConsulta { get; set; }

        public int idConsulta { get; set; }

        public int status { get; set; }
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

    public class DadosMolestiaAtual {
        public int idMolestiaAtual { get; set; }
        public int idPacienteMolestiaAtual { get; set; }
        public int idConsultaMolestiaAtual { get; set; }
        public string molestiaAtual { get; set; }
    }

    public class DadosPatologicaPregressa {
        public int idPatologicaPregressa { get; set; }
        public int idPacientePatologicaPregressa { get; set; }
        public int idConsultaPatologicaPregressa { get; set; }
        public string patologicaPregressa { get; set; }
    }

    public class DadosExameFisico {
        public int idExameFisico { get; set; }
        public int idPacienteExameFisico { get; set; }
        public int idConsultaExameFisico { get; set; }
        public string exameFisico { get; set; }
    }

    public class DadosExameLaboratorial {
        public int idExameLaboratorial { get; set; }
        public int idPacienteExameLaboratorial { get; set; }
        public int idConsultaExameLaboratorial { get; set; }
        public byte[] exameLaboratorial { get; set; }
        public int tamanhoArquivo { get; set; }
    }

    public class DadosHipoteseDiagnostica {
        public int idHipoteseDiagnostica { get; set; }
        public int idPacienteHipoteseDiagnostica { get; set; }
        public int idConsultaHipoteseDiagnostica { get; set; }
        public string hipoteseDiagnostica { get; set; }
    }

    public class DadosConduta {
        public int idConduta { get; set; }
        public int idPacienteConduta { get; set; }
        public int idConsultaConduta { get; set; }
        public string conduta { get; set; }
    }

    public class DadosExamePedido {
        public int idExamePedido { get; set; }
        public int idBaseNomeExameExamePedido { get; set; }
        public int idPacienteExamePedido { get; set; }
        public int idConsultaExamePedido { get; set; }
    }
}