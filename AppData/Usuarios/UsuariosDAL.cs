using SGCM.Models.Usuarios;
using System;
using System.Web;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using SGCM;
using System.Threading.Tasks;
using System.Transactions;
using SGCM.AppData.Infraestrutura.UtilMetodo;

namespace SGCM.AppData.Usuarios {
    public class UsuariosDAL : SGCMContext {
        public int InserirUsuario(UsuariosModel usuario) {
            try {
                var DALSQL = new UsuariosDALSQL();
                int retorno = 0;

                using (TransactionScope scope = new TransactionScope()) {

                    using (SqlConnection connection = new SqlConnection(getStringConnection())) {
                        
                        connection.Open();

                        PessoaTO pessoaTO = new PessoaTO {
                            Nome = usuario.pessoa.Nome,
                            Cpf = usuario.pessoa.CPF,
                            Estado = usuario.pessoa.Estado,
                            Cidade = usuario.pessoa.Cidade,
                            Bairro = usuario.pessoa.Bairro,
                            Endereco = usuario.pessoa.Endereco,
                            Numero = usuario.pessoa.Numero,
                            Telefone_Celular = usuario.pessoa.Telefone_Celular,
                            Email = usuario.pessoa.Email,
                            Tipo_Usuario = Int32.Parse(usuario.pessoa.TipoUsuario)
                        };

                        SqlCommand cmdPessoa = new SqlCommand(DALSQL.InserirPessoa(pessoaTO), connection);
                        retorno = cmdPessoa.ExecuteNonQuery();

                        SqlCommand cmdGetLastIdInserted = new SqlCommand(DALSQL.GetLastIdInserted(), connection);
                        Decimal lastID = (Decimal) cmdGetLastIdInserted.ExecuteScalar();

                        UsuariosTO usuariosTO = new UsuariosTO {
                            ID_Pessoa = (int)lastID,
                            Username = usuario.usuario.Username,
                            Password = usuario.usuario.Password
                        };

                        SqlCommand cmdUsuario = new SqlCommand(DALSQL.InserirUsuario(usuariosTO), connection);
                        retorno += cmdUsuario.ExecuteNonQuery();

                        lastID = (Decimal)cmdGetLastIdInserted.ExecuteScalar();

                        PermissoesTO permissoesTO = new PermissoesTO {
                            Id_Usuario = (int)lastID,
                        };

                        permissoesTO = UtilMetodo.ConversaoPermissoesStringParaInt(permissoesTO, usuario);

                        SqlCommand cmdPermissoes = new SqlCommand(DALSQL.InserirPermissoes(permissoesTO), connection);
                        retorno += cmdPermissoes.ExecuteNonQuery();

                        if (retorno == 3) {
                            scope.Complete();
                        } else {
                            throw new Exception();
                        }
                    }
                }
                return retorno;
            }
            catch (TransactionAbortedException ex)
            {
                throw ex;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public List<UsuariosModel> ConsultarUsuario() {
            try {
                var DALSQL = new UsuariosDALSQL();

                SqlConnection connection = new SqlConnection(getStringConnection());

                connection.Open();

                SqlCommand cmdUsuario = new SqlCommand(DALSQL.ConsultarUsuario(), connection);
                SqlDataReader dr = cmdUsuario.ExecuteReader();

                UsuariosModel usuarioCompletoTO = new UsuariosModel();
                usuarioCompletoTO.pessoa = new DadosPessoais();
                usuarioCompletoTO.usuario = new DadosLogin();
                usuarioCompletoTO.permissoes = new DadosPermissoes();

                List<UsuariosModel> usuarioCompletoTOList = new List<UsuariosModel>();

                if (dr.HasRows) {
                    while (dr.Read()) {
                        usuarioCompletoTO.pessoa.Nome = dr.GetString(0);
                        usuarioCompletoTO.pessoa.CPF = dr.GetString(1);
                        usuarioCompletoTO.pessoa.Telefone_Celular = dr.GetString(2);
                        usuarioCompletoTO.pessoa.IdPessoa = dr.GetInt32(3);
                        usuarioCompletoTO.usuario.IdUsuario = dr.GetInt32(4);
                        usuarioCompletoTO.permissoes.IdPermissoes = dr.GetInt32(5);

                        usuarioCompletoTOList.Add(usuarioCompletoTO);
                    }
                }
                connection.Close();

                return usuarioCompletoTOList;

            } catch (Exception ex) {
                throw ex;
            }

        }
    }
}
