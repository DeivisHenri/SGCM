using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using SGCM;
using SGCM.Models.Account;
using SGCM.AppData.Login;
using static SGCM.AppData.Infraestrutura.UtilObjetos.UtilObjetos;

namespace SGCM.AppData.Login {

    public class LoginDAL : SGCMContext {
        public UsuarioCompletoTO EfetuarLogin(LoginViewModel usuario) {
            try
            {
                var connection = new SqlConnection(getStringConnection());
                var LoginDALSQL = new LoginDALSQL();

                connection.Open();
                SqlCommand cmdUsuario = new SqlCommand(LoginDALSQL.EfetuarLogin(usuario), connection);
                SqlDataReader dr = cmdUsuario.ExecuteReader();
                UsuarioCompletoTO loginCompletoTO = new UsuarioCompletoTO();
                loginCompletoTO.usuarioTO = new UsuarioTO();
                loginCompletoTO.pessoaTO = new PessoaTO();
                loginCompletoTO.permissoesTO = new PermissoesTO();

                if (dr.HasRows) {
                    while (dr.Read())
                    {
                        loginCompletoTO.usuarioTO.ID_Usuario = dr.GetInt32(0);
                        loginCompletoTO.usuarioTO.Username = dr.GetString(1);
                        loginCompletoTO.usuarioTO.Password = dr.GetString(2);

                        loginCompletoTO.pessoaTO.Id_Pessoa = dr.GetInt32(3);
                        loginCompletoTO.pessoaTO.Nome = dr.GetString(4);
                        loginCompletoTO.pessoaTO.Cpf = dr.GetString(5);
                        loginCompletoTO.pessoaTO.Estado = dr.GetString(6);
                        loginCompletoTO.pessoaTO.Cidade = dr.GetString(7);
                        loginCompletoTO.pessoaTO.Bairro = dr.GetString(8);
                        loginCompletoTO.pessoaTO.Endereco = dr.GetString(9);
                        loginCompletoTO.pessoaTO.Numero = dr.GetInt32(10);
                        loginCompletoTO.pessoaTO.Telefone_Celular = dr.GetString(11);
                        loginCompletoTO.pessoaTO.Email = dr.GetString(12);
                        loginCompletoTO.pessoaTO.Tipo_Usuario = dr.GetInt32(13);

                        loginCompletoTO.permissoesTO.Id_Permissoes = dr.GetInt32(14);
                        loginCompletoTO.permissoesTO.Id_Usuario = dr.GetInt32(15);
                        loginCompletoTO.permissoesTO.Fl_Usuario_I = dr.GetInt32(16);
                        loginCompletoTO.permissoesTO.Fl_Usuario_C = dr.GetInt32(17);
                        loginCompletoTO.permissoesTO.Fl_Usuario_A = dr.GetInt32(18);
                        loginCompletoTO.permissoesTO.Fl_Usuario_E = dr.GetInt32(19);
                        loginCompletoTO.permissoesTO.Fl_Paciente_I = dr.GetInt32(20);
                        loginCompletoTO.permissoesTO.Fl_Paciente_C = dr.GetInt32(21);
                        loginCompletoTO.permissoesTO.Fl_Paciente_A = dr.GetInt32(22);
                        loginCompletoTO.permissoesTO.Fl_Paciente_E = dr.GetInt32(23);
                        loginCompletoTO.permissoesTO.Fl_Consulta_I = dr.GetInt32(24);
                        loginCompletoTO.permissoesTO.Fl_Consulta_C = dr.GetInt32(25);
                        loginCompletoTO.permissoesTO.Fl_Consulta_A = dr.GetInt32(26);
                        loginCompletoTO.permissoesTO.Fl_Consulta_E = dr.GetInt32(27);
                        loginCompletoTO.permissoesTO.Fl_Medicamento_I = dr.GetInt32(28);
                        loginCompletoTO.permissoesTO.Fl_Medicamento_C = dr.GetInt32(29);
                        loginCompletoTO.permissoesTO.Fl_Medicamento_A = dr.GetInt32(30);
                        loginCompletoTO.permissoesTO.Fl_Medicamento_E = dr.GetInt32(31);
                        loginCompletoTO.permissoesTO.Fl_Exames_I = dr.GetInt32(32);
                        loginCompletoTO.permissoesTO.Fl_Exames_C = dr.GetInt32(33);
                        loginCompletoTO.permissoesTO.Fl_Exames_A = dr.GetInt32(34);
                        loginCompletoTO.permissoesTO.Fl_Exames_E = dr.GetInt32(35);
                    }
                }
                connection.Close();

                return loginCompletoTO;

            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}