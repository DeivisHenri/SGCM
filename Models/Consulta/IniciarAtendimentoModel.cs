using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SGCM.AppData.Infraestrutura.CustomMetadataProvider;

namespace SGCM.Models.Consulta.IniciarAtendimento
{
    public class IniciarAtendimentoModel
    {
        public DadosPessoais Pessoa { get; set; }

        public DadosPaciente Paciente { get; set; }

        public List<DadosConsulta> ConsultaLista { get; set; }

        public DadosConsulta Consulta { get; set; }

        public DadosMolestiaAtual MolestiaAtual { get; set; }

        public DadosPatologicaPregressa PatologicaPregressa { get; set; }

        public DadosExameFisico ExameFisico { get; set; }

        public List<DadosExameLaboratorial> ExameLaboratorialLista { get; set; }

        public DadosHipoteseDiagnostica HipoteseDiagnostica { get; set; }

        public DadosConduta Conduta { get; set; }

        public string ExamePedido { get; set; }

        public string Medicamento { get; set; }
    }

    public class DadosPessoais
    {
        [StringLength(50, ErrorMessage = "O campo Nome deve ter no máximo 50 caracteres.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [StringLength(14, ErrorMessage = "O campo CPF deve conter os 11 caracteres.", MinimumLength = 14)]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [StringLength(14, ErrorMessage = "O campo CPF deve conter os 8 caracteres.", MinimumLength = 10)]
        [Display(Name = "RG")]
        public string RG { get; set; }

        [Display(Name = "Data Nascimento")]
        public DateTime DataNascimento { get; set; }

        [StringLength(35, ErrorMessage = "O campo Logradouro deve conter no máximo 35 caracteres.")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Display(Name = "Número")]
        public int Numero { get; set; }

        [StringLength(40, ErrorMessage = "O campo Bairro deve conter no máximo 40 caracteres.")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [StringLength(30, ErrorMessage = "O campo Cidade deve conter no máximo 30 caracteres.")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [StringLength(20, ErrorMessage = "O campo UF deve conter no máximo 20 caracteres.")]
        [Display(Name = "UF")]
        public string Uf { get; set; }

        [StringLength(15, ErrorMessage = "O campo Celular deve conter os 11 digitos com DDD.", MinimumLength = 15)]
        [Display(Name = "Celular")]
        [HTMLMaskAttribute("mask", "(99) 99999-9999")] //phone format 
        public string TelefoneCelular { get; set; }

        [StringLength(40, ErrorMessage = "O campo E-mail deve conter no máximo 40 caracteres.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public int IdPessoa { get; set; }
    }

    public class DadosPaciente {
        public int idPaciente { get; set; }
    }

    public class DadosConsulta {
        public int idConsulta { get; set; }
        public int idPacienteConsulta { get; set; }
        public DateTime dataConsulta { get; set; }
        public int finalizada { get; set; }
    }

    public class DadosMolestiaAtual {
        public int idMolestiaAtual { get; set; }
        public int idConsultaMolestiaAtual { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "O campo História da Moléstia Atual deve conter no máximo 1000 caracteres.")]
        [Display(Name = "História da Moléstia Atual")]
        public string molestiaAtual { get; set; }
    }

    public class DadosPatologicaPregressa {
        public int idPatologicaPregressa { get; set; }
        public int idConsultaPatologicaPregressa { get; set; }
        [StringLength(1000, ErrorMessage = "O campo História Patológica Pregressa deve conter no máximo 1000 caracteres.")]
        [Display(Name = "História Patológica Pregressa")]
        public string patologicaPregressa { get; set; }
    }

    public class DadosExameFisico {
        public int idExameFisico { get; set; }
        public int idConsultaExameFisico { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "O campo Exame Físico deve conter no máximo 500 caracteres.")]
        [Display(Name = "Exame Físico")]
        public string exameFisico { get; set; }

    }

    public class DadosExameLaboratorial {
        public int idExameLaboratorial { get; set; }
        public int idPacienteExameLaboratorial { get; set; }
        public int idConsultaExameLaboratorial { get; set; }
        public byte[] exameLaboratorial { get; set; }
        public int tamanhoArquivo { get; set; }
    }

    public class DadosHipoteseDiagnostica
    {
        public int idHipoteseDiagnostica { get; set; }
        public int idConsultaHipoteseDiagnostica { get; set; }
        [StringLength(500, ErrorMessage = "O campo Conduta deve conter no máximo 500 caracteres.")]
        [Display(Name = "Conduta")]
        public string hipoteseDiagnostica { get; set; }

    }

    public class DadosConduta
    {
        public int idConduta { get; set; }
        public int idConsultaConduta { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "O campo Conduta deve conter no máximo 500 caracteres.")]
        [Display(Name = "Conduta")]
        public string conduta { get; set; }
    }

    public class BaseNomeExame {
        public int idBaseNomeExame { get; set; }
        public string baseNomeExame { get; set; }
    }

    public class GetMedicamento
    {
        public int idMedicamento { get; set; }
        public string nomeGenerico { get; set; }
        public string nomeFabrica { get; set; }
        public string fabricante { get; set; }
    }
}