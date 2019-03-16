using System.Text;

namespace SGCM.AppData.Medicamento {
    public class MedicamentoDALSQL {
        public string CadastrarMedicamento() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Insert Into medicamento(nomeGenerico,");
            command.AppendLine("                        nomeFabrica,");
            command.AppendLine("                        fabricante)");
            command.AppendLine("VALUES(@NOMEGENERICO,");
            command.AppendLine("       @NOMEFABRICA,");
            command.AppendLine("	   @FABRICANTE)");

            return command.ToString();
        }

        public string ConsultarMedicamento(int sort, string psqNomeGenerico, string psqNomeFabrica, string psqFabricante) {
            StringBuilder command = new StringBuilder();
            bool flagWhere = false;

            command.AppendLine("Select idMedicamento,");
            command.AppendLine("       nomeGenerico,");
            command.AppendLine("       nomeFabrica,");
            command.AppendLine("       fabricante ");
            command.AppendLine("From medicamento ");


            if (psqNomeGenerico != null && psqNomeGenerico != "") {
                command.AppendLine("Where nomeGenerico like @NOMEGENERICO ");
                flagWhere = true;
            }

            if (psqNomeFabrica != null && psqNomeFabrica != "") {
                if (flagWhere == false) {
                    command.AppendLine("Where nomeFabrica like @NOMEFABRICA ");
                    flagWhere = true;
                } else {
                    command.AppendLine("AND nomeFabrica like @NOMEFABRICA ");
                }
            }

            if (psqFabricante != null && psqFabricante != "") {
                if (flagWhere == false) {
                    command.AppendLine("Where fabricante like @FABRICANTE ");
                    flagWhere = true;
                } else {
                    command.AppendLine("AND fabricante like @FABRICANTE ");
                }
            }

            switch (sort) {
                case 1:
                    command.AppendLine("Order By nomeGenerico ASC");
                    break;
                case 2:
                    command.AppendLine("Order By nomeGenerico DESC");
                    break;
                case 3:
                    command.AppendLine("Order By nomeFabrica ASC");
                    break;
                case 4:
                    command.AppendLine("Order By nomeFabrica DESC");
                    break;
                case 5:
                    command.AppendLine("Order By fabricante ASC");
                    break;
                case 6:
                    command.AppendLine("Order By fabricante DESC");
                    break;
            }
            return command.ToString();
        }

        public string ConsultarMedicamentoID()
        {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select idMedicamento,");
            command.AppendLine("       nomeGenerico,");
            command.AppendLine("       nomeFabrica,");
            command.AppendLine("       fabricante");
            command.AppendLine("From medicamento");
            command.AppendLine("Where idMedicamento = @IDMEDICAMENTO");

            return command.ToString();
        }

        public string EditarMedicamento() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Update medicamento");
            command.AppendLine("Set nomeGenerico = @NOMEGENERICO,");
            command.AppendLine("    nomeFabrica = @NOMEFABRICA,");
            command.AppendLine("    fabricante = @FABRICANTE");
            command.AppendLine("Where idMedicamento = @IDMEDICAMENTO");

            return command.ToString();
        }
        public string ExcluirMedicamento()
        {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Delete From medicamento");
            command.AppendLine("Where idMedicamento = @IDMEDICAMENTO");

            return command.ToString();
        }
    }
}
