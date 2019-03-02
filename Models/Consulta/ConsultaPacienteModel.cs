using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCM.Models.Consulta.ConsultaPacienteModel
{

    public class ConsultaPacienteModelBanco
    {
        public List<ConsultaPacienteModel> ListaConsultaPacienteModel { get; set; }
        public int retorno { get; set; }
    }

    public class ConsultaPacienteModel
    {
        public string nome { get; set; }
        public string cpf { get; set; }
        public int idPaciente { get; set; }
        public int statusDesativado { get; set; }
    }
}
