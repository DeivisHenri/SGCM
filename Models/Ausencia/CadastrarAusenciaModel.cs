using System;
using System.ComponentModel.DataAnnotations;

namespace SGCM.Models.Ausencia.CadastrarAusenciaModel {

    public class CadastrarAusenciaModel {
        [Required(ErrorMessage = "O campo Data Início é obrigatório.")]
        [Display(Name = "Data Início")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "O campo Hora Início é obrigatório.")]
        [Display(Name = "Hora Início")]
        public Int32 HoraInicio { get; set; }

        [Required(ErrorMessage = "O campo Data Final é obrigatório.")]
        [Display(Name = "Data Final")]
        public DateTime DataFinal { get; set; }

        [Required(ErrorMessage = "O campo Hora Final é obrigatório.")]
        [Display(Name = "Hora Final")]
        public Int32 HoraFinal { get; set; }

        public Int32 idUsuarioAusencia { get; set; }
    }

    public class CadastrarAusenciaBancoModel {
        public Int32 idAusencia { get; set; }
        public Int32 idUsuarioAusencia { get; set; }
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
        public Int32 horaInicio { get; set; }
        public Int32 horaFinal { get; set; }
    }
}