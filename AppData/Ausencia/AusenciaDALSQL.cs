using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCM.AppData.Ausencia
{
    public class AusenciaDALSQL
    {
        public string CadastrarAusencia() {
            StringBuilder command = new StringBuilder();
            
            command.AppendLine("Insert Into ausencia(idUsuarioAusencia,");
            command.AppendLine("                     dataInicial,");
            command.AppendLine("                     dataFinal,");
            command.AppendLine("                     seis,");
            command.AppendLine("                     seisMeia,");
            command.AppendLine("                     sete,");
            command.AppendLine("                     seteMeia,");
            command.AppendLine("                     oito,");
            command.AppendLine("                     oitoMeia,");
            command.AppendLine("                     nove,");
            command.AppendLine("                     noveMeia,");
            command.AppendLine("                     dez,");
            command.AppendLine("                     dezMeia,");
            command.AppendLine("                     onze,");
            command.AppendLine("                     onzeMeia,");
            command.AppendLine("                     doze,");
            command.AppendLine("                     dozeMeia,");
            command.AppendLine("                     treze,");
            command.AppendLine("                     trezeMeia,");
            command.AppendLine("                     quatorze,");
            command.AppendLine("                     quatorzeMeia,");
            command.AppendLine("                     quinze,");
            command.AppendLine("                     quinzeMeia,");
            command.AppendLine("                     dezesseis,");
            command.AppendLine("                     dezesseisMeia,");
            command.AppendLine("                     dezessete,");
            command.AppendLine("                     dezesseteMeia,");
            command.AppendLine("                     dezoito,");
            command.AppendLine("                     dezoitoMeia)");
            command.AppendLine("VALUES(@IDUSUARIOAUSENCIA,"); 
            command.AppendLine("       @DATAINICIAL,"); 
            command.AppendLine("	   @DATAFINAL,");
            command.AppendLine("       @SEIS,");
            command.AppendLine("       @SEISMEIA,");
            command.AppendLine("       @SETE,");
            command.AppendLine("       @SETEMEIA,");
            command.AppendLine("       @OITO,");
            command.AppendLine("       @OITOMEIA,");
            command.AppendLine("       @NOVE,");
            command.AppendLine("       @NOVEMEIA,");
            command.AppendLine("       @DEZ,");
            command.AppendLine("       @DEZMEIA,");
            command.AppendLine("       @ONZE,");
            command.AppendLine("       @ONZEMEIA,");
            command.AppendLine("       @DOZE,");
            command.AppendLine("       @DOZEMEIA,");
            command.AppendLine("       @TREZE,");
            command.AppendLine("       @TREZEMEIA,");
            command.AppendLine("       @QUATORZE,");
            command.AppendLine("       @QUATORZEMEIA,");
            command.AppendLine("       @QUINZE,");
            command.AppendLine("       @QUINZEMEIA,");
            command.AppendLine("       @DEZESSEIS,");
            command.AppendLine("       @DEZESSEISMEIA,");
            command.AppendLine("       @DEZESSETE,");
            command.AppendLine("       @DEZESSETEMEIA,");
            command.AppendLine("       @DEZOITO,");
            command.AppendLine("       @DEZOITOMEIA)");

            return command.ToString();
        }

        public string ConsultarAusencia(int sortOrder, DateTime psqDataAusencia) {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select idAusencia,");
            command.AppendLine("       dataInicial,");
            command.AppendLine("       dataFinal,");
            command.AppendLine("       seis,");
            command.AppendLine("       seisMeia,");
            command.AppendLine("       sete,");
            command.AppendLine("       seteMeia,");
            command.AppendLine("       oito,");
            command.AppendLine("       oitoMeia,");
            command.AppendLine("       nove,");
            command.AppendLine("       noveMeia,");
            command.AppendLine("       dez,");
            command.AppendLine("       dezMeia,");
            command.AppendLine("       onze,");
            command.AppendLine("       onzeMeia,");
            command.AppendLine("       doze,");
            command.AppendLine("       dozeMeia,");
            command.AppendLine("       treze,");
            command.AppendLine("       trezeMeia,");
            command.AppendLine("       quatorze,");
            command.AppendLine("       quatorzeMeia,");
            command.AppendLine("       quinze,");
            command.AppendLine("       quinzeMeia,");
            command.AppendLine("       dezesseis,");
            command.AppendLine("       dezesseisMeia,");
            command.AppendLine("       dezessete,");
            command.AppendLine("       dezesseteMeia,");
            command.AppendLine("       dezoito,");
            command.AppendLine("       dezoitoMeia");
            command.AppendLine("From ausencia");
            command.AppendLine("Where idUsuarioAusencia = @IDUSUARIOAUSENCIA ");

            if (psqDataAusencia != null && psqDataAusencia != default(DateTime)) {
                command.AppendLine("AND dataInicial = STR_TO_DATE(@DATAINICIAL, '%d/%m/%Y')");
            }

            switch (sortOrder)
            {
                case 1:
                    command.AppendLine("Order By dataInicial ASC");
                    break;
                case 2:
                    command.AppendLine("Order By dataInicial DESC");
                    break;
            }

            return command.ToString();
        }

        public string ConsultarAusenciaIdAusencia() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select idAusencia,");
            command.AppendLine("       idUsuarioAusencia,");
            command.AppendLine("       dataInicial,");
            command.AppendLine("       dataFinal,");
            command.AppendLine("       seis,");
            command.AppendLine("       seisMeia,");
            command.AppendLine("       sete,");
            command.AppendLine("       seteMeia,");
            command.AppendLine("       oito,");
            command.AppendLine("       oitoMeia,");
            command.AppendLine("       nove,");
            command.AppendLine("       noveMeia,");
            command.AppendLine("       dez,");
            command.AppendLine("       dezMeia,");
            command.AppendLine("       onze,");
            command.AppendLine("       onzeMeia,");
            command.AppendLine("       doze,");
            command.AppendLine("       dozeMeia,");
            command.AppendLine("       treze,");
            command.AppendLine("       trezeMeia,");
            command.AppendLine("       quatorze,");
            command.AppendLine("       quatorzeMeia,");
            command.AppendLine("       quinze,");
            command.AppendLine("       quinzeMeia,");
            command.AppendLine("       dezesseis,");
            command.AppendLine("       dezesseisMeia,");
            command.AppendLine("       dezessete,");
            command.AppendLine("       dezesseteMeia,");
            command.AppendLine("       dezoito,");
            command.AppendLine("       dezoitoMeia");
            command.AppendLine("From ausencia");
            command.AppendLine("Where idAusencia = @IDAUSENCIA");

            return command.ToString();
        }

        public string EditarAusencia() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Update ausencia");
            command.AppendLine("Set dataInicial = @DATAINICIAL,");
            command.AppendLine("    dataFinal = @DATAFINAL,");
            command.AppendLine("    seis = @SEIS,");
            command.AppendLine("    seisMeia = @SEISMEIA,");
            command.AppendLine("    sete = @SETE,");
            command.AppendLine("    seteMeia = @SETEMEIA,");
            command.AppendLine("    oito = @OITO,");
            command.AppendLine("    oitoMeia = @OITOMEIA,");
            command.AppendLine("    nove = @NOVE,");
            command.AppendLine("    noveMeia = @NOVEMEIA,");
            command.AppendLine("    dez = @DEZ,");
            command.AppendLine("    dezMeia = @DEZMEIA,");
            command.AppendLine("    onze = @ONZE,");
            command.AppendLine("    onzeMeia = @ONZEMEIA,");
            command.AppendLine("    doze = @DOZE,");
            command.AppendLine("    dozeMeia = @DOZEMEIA,");
            command.AppendLine("    treze = @TREZE,");
            command.AppendLine("    trezeMeia = @TREZEMEIA,");
            command.AppendLine("    quatorze = @QUATORZE,");
            command.AppendLine("    quatorzeMeia = @QUATORZEMEIA,");
            command.AppendLine("    quinze = @QUINZE,");
            command.AppendLine("    quinzeMeia = @QUINZEMEIA,");
            command.AppendLine("    dezesseis = @DEZESSEIS,");
            command.AppendLine("    dezesseisMeia = @DEZESSEISMEIA,");
            command.AppendLine("    dezessete = @DEZESSETE,");
            command.AppendLine("    dezesseteMeia = @DEZESSETEMEIA,");
            command.AppendLine("    dezoito = @DEZOITO,");
            command.AppendLine("    dezoitoMeia = @DEZOITOMEIA");
            command.AppendLine("Where idAusencia = @IDAUSENCIA");

            return command.ToString();
        }
    }
}