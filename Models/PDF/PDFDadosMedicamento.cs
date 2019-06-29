using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCM.Models.PDF
{
    public class PDFDadosMedicamento
    {
        public string nome { get; set; }
        public string rg { get; set; }
        public DateTime dataNascimento { get; set; }
        public DateTime dataConsulta { get; set; }
        public string nomeGenerico { get; set; }
        public string nomeFabrica { get; set; }
    }
}
