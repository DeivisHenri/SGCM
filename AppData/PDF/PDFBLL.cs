using SGCM.Models.PDF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCM.AppData.PDF {
    public class PDFBLL {

        public PDFDadosExame ConsultarDadosExamePreencherPDF(int idExame, int idConsulta) {
            PDFDAL pdfDAL = new PDFDAL();
            return pdfDAL.ConsultarDadosExamePreencherPDF(idExame, idConsulta);
        }

        public PDFDadosMedicamento ConsultarDadosMedicamentoPreencherPDF(int idMedicamento, int idConsulta) {
            PDFDAL pdfDAL = new PDFDAL();
            return pdfDAL.ConsultarDadosMedicamentoPreencherPDF(idMedicamento, idConsulta);
        }

        public DPFDadosPacienteModel ConsultarDadosPacientePreencherPDF(int idPaciente) {
            PDFDAL pdfDAL = new PDFDAL();
            return pdfDAL.ConsultarDadosPacientePreencherPDF(idPaciente);
        }
    }
}