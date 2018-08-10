using SGCM.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCM.AppData.Usuarios {
    public class UsuariosDALSQL {

        public string ConsultarPessoa(int Id_Pessoa)
        {
            StringBuilder command = new StringBuilder();
            command.AppendLine("Select Id_Pessoa, Nome, Cpf, Estado, Cidade, Bairro,");
            command.AppendLine("       Endereco, Numero, Telefone_Celular, Email, Tipo_Usuario");
            command.AppendLine("From [dbo].[Pessoa]");
            command.AppendLine("Where Id_Pessoa = " + Id_Pessoa);

            return command.ToString();
        }

        public string InserirPessoa(PessoaTO pessoa) {

            StringBuilder command = new StringBuilder();
            command.AppendLine("INSERT INTO Pessoa(Nome,");
            command.AppendLine("                   Cpf,");
            command.AppendLine("                   Estado,");
            command.AppendLine("                   Cidade,");
            command.AppendLine("                   Bairro,");
            command.AppendLine("                   Endereco,");
            command.AppendLine("                   Numero,");
            command.AppendLine("                   Telefone_Celular,");
            command.AppendLine("                   Email,");
            command.AppendLine("                   Tipo_Usuario)");
            command.AppendLine("       VALUES('" + pessoa.Nome + "',");
            command.AppendLine("              '" + pessoa.Cpf + "',");
            command.AppendLine("              '" + pessoa.Estado + "',");
            command.AppendLine("              '" + pessoa.Cidade + "',");
            command.AppendLine("              '" + pessoa.Bairro + "',");
            command.AppendLine("              '" + pessoa.Endereco + "',");
            command.AppendLine("              '" + pessoa.Numero + "',");
            command.AppendLine("              '" + pessoa.Telefone_Celular + "',");
            command.AppendLine("              '" + pessoa.Email + "',");
            command.AppendLine("              '" + pessoa.Tipo_Usuario + "')");

            return command.ToString();
        }

        public string InserirUsuario(UsuariosTO usuario)
        {
            StringBuilder command = new StringBuilder();

            command.AppendLine("INSERT INTO Usuario(Id_Pessoa, Username, Password) ");
            command.AppendLine("             VALUES(" + usuario.ID_Pessoa + ", '" + usuario.Username + "', '" + usuario.Password + "')");

            return command.ToString();
        }

        public string InserirPermissoes(PermissoesTO permissoes)
        {
            StringBuilder command = new StringBuilder();

            command.AppendLine("INSERT INTO Permissoes(Id_Usuario,");
            command.AppendLine("                       Fl_Usuario_I,");
            command.AppendLine("                       Fl_Usuario_C,");
            command.AppendLine("                       Fl_Usuario_A,");
            command.AppendLine("                       Fl_Usuario_E,");
            command.AppendLine("                       Fl_Paciente_I,");
            command.AppendLine("                       Fl_Paciente_C,");
            command.AppendLine("                       Fl_Paciente_A,");
            command.AppendLine("                       Fl_Paciente_E,");
            command.AppendLine("                       Fl_Consulta_I,");
            command.AppendLine("                       Fl_Consulta_C,");
            command.AppendLine("                       Fl_Consulta_A,");
            command.AppendLine("                       Fl_Consulta_E,");
            command.AppendLine("                       Fl_Medicamento_I,");
            command.AppendLine("                       Fl_Medicamento_C,");
            command.AppendLine("                       Fl_Medicamento_A,");
            command.AppendLine("                       Fl_Medicamento_E,");
            command.AppendLine("                       Fl_Exames_I,");
            command.AppendLine("                       Fl_Exames_C,");
            command.AppendLine("                       Fl_Exames_A,");
            command.AppendLine("                       Fl_Exames_E) ");
            command.AppendLine("VALUES(" + permissoes.Id_Usuario + ",");
            command.AppendLine("       " + permissoes.Fl_Usuario_I + ",");
            command.AppendLine("       " + permissoes.Fl_Usuario_C + ",");
            command.AppendLine("       " + permissoes.Fl_Usuario_A + ",");
            command.AppendLine("       " + permissoes.Fl_Usuario_E + ",");
            command.AppendLine("       " + permissoes.Fl_Paciente_I + ",");
            command.AppendLine("       " + permissoes.Fl_Paciente_C + ",");
            command.AppendLine("       " + permissoes.Fl_Paciente_A + ",");
            command.AppendLine("       " + permissoes.Fl_Paciente_E + ",");
            command.AppendLine("       " + permissoes.Fl_Consulta_I + ",");
            command.AppendLine("       " + permissoes.Fl_Consulta_C + ",");
            command.AppendLine("       " + permissoes.Fl_Consulta_A + ",");
            command.AppendLine("       " + permissoes.Fl_Consulta_E + ",");
            command.AppendLine("       " + permissoes.Fl_Medicamento_I + ",");
            command.AppendLine("       " + permissoes.Fl_Medicamento_C + ",");
            command.AppendLine("       " + permissoes.Fl_Medicamento_A + ",");
            command.AppendLine("       " + permissoes.Fl_Medicamento_E + ",");
            command.AppendLine("       " + permissoes.Fl_Exames_I + ",");
            command.AppendLine("       " + permissoes.Fl_Exames_C + ",");
            command.AppendLine("       " + permissoes.Fl_Exames_A + ",");
            command.AppendLine("       " + permissoes.Fl_Exames_E + ")");

            return command.ToString();
        }

        public string GetLastIdInserted()
        {
            StringBuilder command = new StringBuilder();

            command.AppendLine("SELECT SCOPE_IDENTITY();");

            return command.ToString();
        }

        public string ConsultarUsuario() {
            StringBuilder command = new StringBuilder();
            command.AppendLine("Select Pes.Nome,");
            command.AppendLine("       Pes.Cpf,");
            command.AppendLine("       Pes.Telefone_Celular,");
            command.AppendLine("       Pes.Id_Pessoa,");
            command.AppendLine("       Usu.Id_Usuario,");
            command.AppendLine("       Per.Id_Permissoes");
            command.AppendLine("From[dbo].[Usuario] Usu INNER JOIN[dbo].[Pessoa] Pes ON Usu.Id_Pessoa = Pes.Id_Pessoa INNER JOIN[dbo].[Permissoes] Per ON Usu.Id_Usuario = Per.Id_Usuario");
            command.AppendLine("Where Usu.DatDst IS NULL");

            return command.ToString();
        }
    }
}
