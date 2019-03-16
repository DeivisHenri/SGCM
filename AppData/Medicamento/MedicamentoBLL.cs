using SGCM.Models.Medicamento;
using System;
using System.Collections.Generic;
using X.PagedList;

namespace SGCM.AppData.Medicamento {
    public class MedicamentoBLL {

        public int CadastrarMedicamento(CadastrarMedicamentoModel model)
        {
            try
            {
                MedicamentoDAL objMedicamentoDAL = new MedicamentoDAL();
                return objMedicamentoDAL.CadastrarMedicamento(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ListaConsultaMedicamentoModel> ConsultarMedicamento(int sort, string psqNomeGenerico, string psqNomeFabrica, string psqFabricante)
        {
            try
            {
                MedicamentoDAL objMedicamentoDAL = new MedicamentoDAL();
                return objMedicamentoDAL.ConsultarMedicamento(sort, psqNomeGenerico, psqNomeFabrica, psqFabricante);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EditarMedicamentoModel ConsultarMedicamentoID(int idMedicamento)
        {
            try
            {
                MedicamentoDAL objMedicamentoDAL = new MedicamentoDAL();
                return objMedicamentoDAL.ConsultarMedicamentoID(idMedicamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int EditarMedicamento(EditarMedicamentoModel model)
        {
            try
            {
                MedicamentoDAL objMedicamentoDAL = new MedicamentoDAL();
                return objMedicamentoDAL.EditarMedicamento(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public int ExcluirMedicamento(int idMedicamento) {
            try
            {
                MedicamentoDAL objMedicamentoDAL = new MedicamentoDAL();
                return objMedicamentoDAL.ExcluirMedicamento(idMedicamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
