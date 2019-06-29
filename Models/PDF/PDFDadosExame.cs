using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCM.Models.PDF
{
    public class PDFDadosExame
    {
        public string nome { get; set; }
        public string rg { get; set; }
        public DateTime dataNascimento { get; set; }
        public DateTime dataConsulta { get; set; }
        public string baseNomeExame { get; set; }
    }
}
