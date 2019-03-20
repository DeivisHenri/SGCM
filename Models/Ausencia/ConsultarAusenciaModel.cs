using System;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace SGCM.Models.Ausencia.ConsultarAusenciaModel {

    public class ConsultarAusenciaBancoModel
    {
        public string sortOrder { get; set; }

        [Display(Name = "Data Ausência")]
        public DateTime psqDataAusencia { get; set; }

        public IPagedList<ListaConsultarAusenciaModel> ListaConsultarAusenciaModel { get; set; }

        public int PageCount { get; set; }
        public int PageNumber { get; set; }
    }

    public class ListaConsultarAusenciaModel
    {
        public Int32 idAusencia { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public Int32 Seis { get; set; }
        public Int32 SeisMeia { get; set; }
        public Int32 Sete { get; set; }
        public Int32 SeteMeia { get; set; }
        public Int32 Oito { get; set; }
        public Int32 OitoMeia { get; set; }
        public Int32 Nove { get; set; }
        public Int32 NoveMeia { get; set; }
        public Int32 Dez { get; set; }
        public Int32 DezMeia { get; set; }
        public Int32 Onze { get; set; }
        public Int32 OnzeMeia { get; set; }
        public Int32 Doze { get; set; }
        public Int32 DozeMeia { get; set; }
        public Int32 Treze { get; set; }
        public Int32 TrezeMeia { get; set; }
        public Int32 Quatorze { get; set; }
        public Int32 QuatorzeMeia { get; set; }
        public Int32 Quinze { get; set; }
        public Int32 QuinzeMeia { get; set; }
        public Int32 Dezesseis { get; set; }
        public Int32 DezesseisMeia { get; set; }
        public Int32 Dezessete { get; set; }
        public Int32 DezesseteMeia { get; set; }
        public Int32 Dezoito { get; set; }
        public Int32 DezoitoMeia { get; set; }
    }


    
}
