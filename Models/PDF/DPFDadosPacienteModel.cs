using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCM.Models.PDF
{
    public class DPFDadosPacienteModel {
        public int idPaciente { get; set; }
        public string nome { get; set; }
        public string rg { get; set; }
        public DateTime dataNascimento { get; set; }
        public List<ListPaciente> ListPaciente { get; set; }
    }

    public class ListPaciente {
        public DateTime dataConsulta { get; set; }
        public int status { get; set; }
    }
}