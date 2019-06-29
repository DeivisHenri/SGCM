using System;
using System.Collections.Generic;
using SGCM.AppData.Infraestrutura.UtilMetodo;
using SGCM.Models.Receita;

namespace SGCM.AppData.Receita
{
    public class ReceitaBLL
    {
        public List<ListaReceitaMedicamentoModel> MostrarReceitaMedicamento(int idConsulta, int sortMedicamento)
        {
            ReceitaDAL receitaDAL = new ReceitaDAL();
            return receitaDAL.MostrarReceitaMedicamento(idConsulta, sortMedicamento);
        }

        public List<ListaReceitaExameModel> MostrarReceitaExame(int idConsulta, int sortExame)
        {
            ReceitaDAL receitaDAL = new ReceitaDAL();
            return receitaDAL.MostrarReceitaExame(idConsulta, sortExame);
        }

        public string ConsultaPaciente(int idPaciente)
        {
            ReceitaDAL receitaDAL = new ReceitaDAL();
            return receitaDAL.ConsultaPaciente(idPaciente);
        }

        
    }
}