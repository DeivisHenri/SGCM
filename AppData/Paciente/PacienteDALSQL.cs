using SGCM.Models.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCM.AppData.Paciente
{
    public class PacienteDALSQL {

        //public string ConsultarUsuario()
        //{
        //    StringBuilder command = new StringBuilder();
        //    command.AppendLine("Select Pes.Nome,");
        //    command.AppendLine("       Pes.Cpf,");
        //    command.AppendLine("       Pes.Telefone_Celular,");
        //    command.AppendLine("       Pes.Id_Pessoa,");
        //    command.AppendLine("       Usu.Id_Usuario,");
        //    command.AppendLine("       Per.Id_Permissoes");
        //    command.AppendLine("From [dbo].[Usuario] Usu INNER JOIN[dbo].[Pessoa] Pes ON Usu.Id_Pessoa = Pes.Id_Pessoa INNER JOIN[dbo].[Permissoes] Per ON Usu.Id_Usuario = Per.Id_Usuario");
        //    command.AppendLine("Where Usu.DatDst IS NULL AND Pes.Id_Medico = @IDPESSOA");

        //    return command.ToString();
        //}

        public string InserirPessoa() {

            StringBuilder command = new StringBuilder();
            command.AppendLine("INSERT INTO Pessoa(Id_Medico,");
            command.AppendLine("                   Tipo_Usuario,");
            command.AppendLine("                   Nome,");
            command.AppendLine("                   Cpf,");
            command.AppendLine("                   Rg,");
            command.AppendLine("                   Data_Nascimento,");
            command.AppendLine("                   Estado,");
            command.AppendLine("                   Cidade,");
            command.AppendLine("                   Bairro,");
            command.AppendLine("                   Endereco,");
            command.AppendLine("                   Numero,");
            command.AppendLine("                   Telefone_Celular,");
            command.AppendLine("                   Email)");
            command.AppendLine("       VALUES(@IDMEDICO,");
            command.AppendLine("              @TIPOUSUARIO,");
            command.AppendLine("              @NOME,");
            command.AppendLine("              @CPF,");
            command.AppendLine("              @RG,");
            command.AppendLine("              @DATANASCIMENTO,");
            command.AppendLine("              @ESTADO,");
            command.AppendLine("              @CIDADE,");
            command.AppendLine("              @BAIRRO,");
            command.AppendLine("              @ENDERECO,");
            command.AppendLine("              @NUMERO,");
            command.AppendLine("              @TELEFONECELULAR,");
            command.AppendLine("              @EMAIL); ");
            command.AppendLine("SELECT SCOPE_IDENTITY();");

            return command.ToString();
        }

        public string InserirPaciente()
        {
            StringBuilder command = new StringBuilder();

            command.AppendLine("INSERT INTO Usuario(Id_Pessoa, Username, Password) ");
            command.AppendLine("             VALUES(@IDPESSOA, @USERNAME, @PASSWORD); ");
            command.AppendLine("SELECT SCOPE_IDENTITY();");

            return command.ToString();
        }  

        //public string ConsultarUsuarioID()
        //{
        //    StringBuilder command = new StringBuilder();
        //    command.AppendLine("Select Pes.Id_Pessoa,");
        //    command.AppendLine("	   Pes.Id_Medico,");
        //    command.AppendLine("       Pes.Tipo_Usuario,");
        //    command.AppendLine("	   Pes.Nome,");
        //    command.AppendLine("	   Pes.Cpf,");
        //    command.AppendLine("	   Pes.Estado,");
        //    command.AppendLine("	   Pes.Cidade,");
        //    command.AppendLine("	   Pes.Bairro,");
        //    command.AppendLine("	   Pes.Endereco,");
        //    command.AppendLine("	   Pes.Numero,");
        //    command.AppendLine("	   Pes.Telefone_Celular,");
        //    command.AppendLine("	   Pes.Email,");

        //    command.AppendLine("	   Usu.Id_Usuario,");
        //    command.AppendLine("	   Usu.Username,");
        //    command.AppendLine("	   Usu.Password,");
        //    command.AppendLine("	   Usu.DatDst,");

        //    command.AppendLine("       Per.Id_Permissoes,");
        //    command.AppendLine("       Per.Id_Usuario,");
        //    command.AppendLine("       Per.Fl_Usuario_I,");
        //    command.AppendLine("       Per.Fl_Usuario_C,");
        //    command.AppendLine("       Per.Fl_Usuario_A,");
        //    command.AppendLine("       Per.Fl_Usuario_E,");
        //    command.AppendLine("       Per.Fl_Paciente_I,");
        //    command.AppendLine("       Per.Fl_Paciente_C,");
        //    command.AppendLine("       Per.Fl_Paciente_A,");
        //    command.AppendLine("       Per.Fl_Paciente_E,");
        //    command.AppendLine("       Per.Fl_Consulta_I,");
        //    command.AppendLine("       Per.Fl_Consulta_C,");
        //    command.AppendLine("       Per.Fl_Consulta_A,");
        //    command.AppendLine("       Per.Fl_Consulta_E,");
        //    command.AppendLine("       Per.Fl_Medicamento_I,");
        //    command.AppendLine("       Per.Fl_Medicamento_C,");
        //    command.AppendLine("       Per.Fl_Medicamento_A,");
        //    command.AppendLine("       Per.Fl_Medicamento_E,");
        //    command.AppendLine("       Per.Fl_Exames_I,");
        //    command.AppendLine("       Per.Fl_Exames_C,");
        //    command.AppendLine("       Per.Fl_Exames_A,");
        //    command.AppendLine("       Per.Fl_Exames_E ");
        //    command.AppendLine("From Pessoa Pes INNER JOIN Usuario Usu ON Pes.Id_Pessoa = Usu.Id_Pessoa ");
        //    command.AppendLine("     INNER JOIN Permissoes Per ON Usu.Id_Usuario = Per.Id_Usuario ");
        //    command.AppendLine("Where Pes.Id_Pessoa = @IDPESSOA");

        //    return command.ToString();
        //}

    }
}
