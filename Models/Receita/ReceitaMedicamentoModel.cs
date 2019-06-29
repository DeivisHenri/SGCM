using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace SGCM.Models.Receita
{
    public class ReceitaModel
    {
        public string sortOrder { get; set; }
        public string NomePaciente { get; set; }

        public IPagedList<ListaReceitaMedicamentoModel> ListaReceitaMedicamentoModel { get; set; }

        public int PageCountMedicamento { get; set; }
        public int PageNumberMedicamento { get; set; }

        public IPagedList<ListaReceitaExameModel> ListaReceitaExameModel { get; set; }

        public int PageCountExame { get; set; }
        public int PageNumberExame { get; set; }
    }

    public class ListaReceitaMedicamentoModel
    {
        /* ---------- TABELA CONSULTA ---------- */
        public int idConsulta { get; set; }
        public int idPacienteConsulta { get; set; }
        public DateTime dataConsulta { get; set; }

        /* ---------- TABELA CONSULTA_MEDICAMENTO ---------- */
        public int idConsulta_Medicamento { get; set; }

        /* ---------- TABELA MEDICAMENTO ---------- */
        public int idMedicamento { get; set; }
        public string nomeGenerico { get; set; }
        public string nomeFabrica { get; set; }
        public string fabricante { get; set; }
    }

    public class ListaReceitaExameModel
    {
        /* ---------- TABELA CONSULTA ---------- */
        public int idConsulta { get; set; }
        public int idPacienteConsulta { get; set; }
        public DateTime dataConsulta { get; set; }

        /* ---------- TABELA EXAME PEDIDO ---------- */
        public int idBaseNomeExameExamePedido { get; set; }

        /* ---------- TABELA BASE NOME EXAME ---------- */
        public string baseNomeExame { get; set; }
    }
}
