using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using SGCM.AppData.Infraestrutura.UtilMetodo;
using System.Data;
using SGCM.Models.Usuario.CadastroUsuarioModel;
using SGCM.Models.Usuario.EditarUsuarioModel;

namespace SGCM.AppData.Usuario {
    public class UsuarioDAL : SGCMContext {

        public List<CadastroUsuarioModel> ConsultarUsuario(int IdPessoa)
        {
            try
            {
                List<CadastroUsuarioModel> usuarioCompletoTOList = new List<CadastroUsuarioModel>();

                SqlConnection connection = new SqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new UsuarioDALSQL();
                SqlCommand cmdUsuario = new SqlCommand(DALSQL.ConsultarUsuario(), connection);
                cmdUsuario.Parameters.Add("@IDPESSOA", SqlDbType.Int).Value = IdPessoa;

                SqlDataReader reader = cmdUsuario.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CadastroUsuarioModel usuarioCompletoTO = new CadastroUsuarioModel();
                        usuarioCompletoTO.pessoa = new Models.Usuario.CadastroUsuarioModel.DadosPessoais();
                        usuarioCompletoTO.usuario = new Models.Usuario.CadastroUsuarioModel.DadosLogin();
                        usuarioCompletoTO.permissoes = new Models.Usuario.CadastroUsuarioModel.DadosPermissoes();

                        usuarioCompletoTO.pessoa.Nome = reader.GetString(0);
                        usuarioCompletoTO.pessoa.CPF = reader.GetString(1);
                        usuarioCompletoTO.pessoa.Telefone_Celular = reader.GetString(2);
                        usuarioCompletoTO.pessoa.IdPessoa = reader.GetInt32(3);
                        usuarioCompletoTO.usuario.IdUsuario = reader.GetInt32(4);
                        usuarioCompletoTO.permissoes.IdPermissoes = reader.GetInt32(5);

                        usuarioCompletoTOList.Add(usuarioCompletoTO);
                    }
                    reader.NextResult();
                }
                reader.Close();
                connection.Close();

                return usuarioCompletoTOList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InserirUsuario(CadastroUsuarioModel usuario) {
            try {
                var DALSQL = new UsuarioDALSQL();
                Decimal retorno = 0;

                using (TransactionScope scope = new TransactionScope()) {

                    using (SqlConnection connection = new SqlConnection(getStringConnection())) {
                        
                        connection.Open();

                        SqlCommand cmdPessoa = new SqlCommand(DALSQL.InserirPessoa(), connection);

                        cmdPessoa.Parameters.Add("@IDMEDICO", SqlDbType.Int).Value = usuario.pessoa.IdMedico;
                        cmdPessoa.Parameters.Add("@TIPOUSUARIO", SqlDbType.Int).Value = usuario.pessoa.TipoUsuario;
                        cmdPessoa.Parameters.Add("@NOME", SqlDbType.Char).Value = usuario.pessoa.Nome;
                        cmdPessoa.Parameters.Add("@CPF", SqlDbType.Char).Value = usuario.pessoa.CPF;
                        cmdPessoa.Parameters.Add("@RG", SqlDbType.Char).Value = usuario.pessoa.RG;
                        cmdPessoa.Parameters.Add("@DATA_NASCIMENTO", SqlDbType.Date).Value = usuario.pessoa.DataNascimento;
                        cmdPessoa.Parameters.Add("@UF", SqlDbType.Char).Value = usuario.pessoa.UF;
                        cmdPessoa.Parameters.Add("@CIDADE", SqlDbType.Char).Value = usuario.pessoa.Cidade;
                        cmdPessoa.Parameters.Add("@BAIRRO", SqlDbType.Char).Value = usuario.pessoa.Bairro;
                        cmdPessoa.Parameters.Add("@LOGRADOURO", SqlDbType.Char).Value = usuario.pessoa.Logradouro;
                        cmdPessoa.Parameters.Add("@NUMERO", SqlDbType.Int).Value = usuario.pessoa.Numero;
                        cmdPessoa.Parameters.Add("@TELEFONECELULAR", SqlDbType.Char).Value = usuario.pessoa.Telefone_Celular;
                        cmdPessoa.Parameters.Add("@EMAIL", SqlDbType.Char).Value = usuario.pessoa.Email;

                        retorno = (Decimal)cmdPessoa.ExecuteScalar();

                        SqlCommand cmdUsuario = new SqlCommand(DALSQL.InserirUsuario(), connection);

                        cmdUsuario.Parameters.Add("@IDPESSOA", SqlDbType.Int).Value = (int)retorno;
                        cmdUsuario.Parameters.Add("@USERNAME", SqlDbType.Char).Value = usuario.usuario.Username;
                        cmdUsuario.Parameters.Add("@PASSWORD", SqlDbType.Char).Value = usuario.usuario.Password;

                        retorno = (Decimal)cmdUsuario.ExecuteScalar();
                        
                        usuario = UtilMetodo.ConversaoPermissoesStringParaInt(usuario);

                        SqlCommand cmdPermissoes = new SqlCommand(DALSQL.InserirPermissoes(), connection);

                        cmdPermissoes.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = (int)retorno;
                        cmdPermissoes.Parameters.Add("@FLUSUARIOI", SqlDbType.Int).Value = Int32.Parse(usuario.permissoes.FlUsuarioI);
                        cmdPermissoes.Parameters.Add("@FLUSUARIOC", SqlDbType.Int).Value = Int32.Parse(usuario.permissoes.FlUsuarioC);
                        cmdPermissoes.Parameters.Add("@FLUSUARIOA", SqlDbType.Int).Value = Int32.Parse(usuario.permissoes.FlUsuarioA);
                        cmdPermissoes.Parameters.Add("@FLUSUARIOE", SqlDbType.Int).Value = Int32.Parse(usuario.permissoes.FlUsuarioE);
                        cmdPermissoes.Parameters.Add("@FLPACIENTEI", SqlDbType.Int).Value = Int32.Parse(usuario.permissoes.FlPacienteI);
                        cmdPermissoes.Parameters.Add("@FLPACIENTEC", SqlDbType.Int).Value = Int32.Parse(usuario.permissoes.FlPacienteC);
                        cmdPermissoes.Parameters.Add("@FLPACIENTEA", SqlDbType.Int).Value = Int32.Parse(usuario.permissoes.FlPacienteA);
                        cmdPermissoes.Parameters.Add("@FLPACIENTEE", SqlDbType.Int).Value = Int32.Parse(usuario.permissoes.FlPacienteE);
                        cmdPermissoes.Parameters.Add("@FLCONSULTAI", SqlDbType.Int).Value = Int32.Parse(usuario.permissoes.FlConsultaI);
                        cmdPermissoes.Parameters.Add("@FLCONSULTAC", SqlDbType.Int).Value = Int32.Parse(usuario.permissoes.FlConsultaC);
                        cmdPermissoes.Parameters.Add("@FLCONSULTAA", SqlDbType.Int).Value = Int32.Parse(usuario.permissoes.FlConsultaA);
                        cmdPermissoes.Parameters.Add("@FLCONSULTAE", SqlDbType.Int).Value = Int32.Parse(usuario.permissoes.FlConsultaE);
                        cmdPermissoes.Parameters.Add("@FLMEDICAMENTOI", SqlDbType.Int).Value = Int32.Parse(usuario.permissoes.FlMedicamentoI);
                        cmdPermissoes.Parameters.Add("@FLMEDICAMENTOC", SqlDbType.Int).Value = Int32.Parse(usuario.permissoes.FlMedicamentoC);
                        cmdPermissoes.Parameters.Add("@FLMEDICAMENTOA", SqlDbType.Int).Value = Int32.Parse(usuario.permissoes.FlMedicamentoA);
                        cmdPermissoes.Parameters.Add("@FLMEDICAMENTOE", SqlDbType.Int).Value = Int32.Parse(usuario.permissoes.FlMedicamentoE);
                        cmdPermissoes.Parameters.Add("@FLEXAMESI", SqlDbType.Int).Value = Int32.Parse(usuario.permissoes.FlExamesI);
                        cmdPermissoes.Parameters.Add("@FLEXAMESC", SqlDbType.Int).Value = Int32.Parse(usuario.permissoes.FlExamesC);
                        cmdPermissoes.Parameters.Add("@FLEXAMESA", SqlDbType.Int).Value = Int32.Parse(usuario.permissoes.FlExamesA);
                        cmdPermissoes.Parameters.Add("@FLEXAMESE", SqlDbType.Int).Value = Int32.Parse(usuario.permissoes.FlExamesE);

                        retorno = (Decimal)cmdPermissoes.ExecuteScalar();

                        if (retorno > 0) {
                            scope.Complete();
                        } else {
                            throw new Exception();
                        }
                    }
                }
                return (int)retorno;
            }
            catch (TransactionAbortedException ex)
            {
                throw ex;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public EditarUsuarioModel ConsultarUsuarioID(int IdPessoa) {
            try {
                SqlConnection connection = new SqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new UsuarioDALSQL();
                SqlCommand cmdUsuario = new SqlCommand(DALSQL.ConsultarUsuarioID(), connection);
                cmdUsuario.Parameters.Add("@IDPESSOA", SqlDbType.Int).Value = IdPessoa;
                SqlDataReader reader = cmdUsuario.ExecuteReader();

                EditarUsuarioModel usuarioCompletoTO = new EditarUsuarioModel();
                usuarioCompletoTO.pessoa = new Models.Usuario.EditarUsuarioModel.DadosPessoais();
                usuarioCompletoTO.usuario = new Models.Usuario.EditarUsuarioModel.DadosLogin();
                usuarioCompletoTO.permissoes = new Models.Usuario.EditarUsuarioModel.DadosPermissoes();

                if (reader.HasRows) {
                    while (reader.Read()) {
                        usuarioCompletoTO.pessoa.IdPessoa = reader.GetInt32(0);
                        usuarioCompletoTO.pessoa.IdMedico = reader.GetInt32(1);
                        usuarioCompletoTO.pessoa.TipoUsuario = reader.GetInt32(2).ToString();
                        usuarioCompletoTO.pessoa.Nome = reader.GetString(3);
                        usuarioCompletoTO.pessoa.CPF = reader.GetString(4);
                        usuarioCompletoTO.pessoa.RG = reader.GetString(5);
                        usuarioCompletoTO.pessoa.DataNascimento = reader.GetString(6);
                        usuarioCompletoTO.pessoa.Estado = reader.GetString(7);
                        usuarioCompletoTO.pessoa.Cidade = reader.GetString(8);
                        usuarioCompletoTO.pessoa.Bairro = reader.GetString(9);
                        usuarioCompletoTO.pessoa.Endereco = reader.GetString(10);
                        usuarioCompletoTO.pessoa.Numero = reader.GetInt32(11);
                        usuarioCompletoTO.pessoa.Telefone_Celular = reader.GetString(12);
                        usuarioCompletoTO.pessoa.Email = reader.GetString(13);

                        usuarioCompletoTO.usuario.IdUsuario = reader.GetInt32(14);
                        usuarioCompletoTO.usuario.Username = reader.GetString(15);
                        usuarioCompletoTO.usuario.Password = reader.GetString(16);

                        if (!reader.IsDBNull(17)) {
                            usuarioCompletoTO.usuario.DatDst = DateTime.Parse(reader.GetString(17));
                        }

                        usuarioCompletoTO.permissoes.IdPermissoes = reader.GetInt32(18);
                        usuarioCompletoTO.permissoes.IdUsuario = reader.GetInt32(19);

                        if (reader.GetInt32(20) == 1) {
                            usuarioCompletoTO.permissoes.FlUsuarioI = "True";
                        } else {
                            usuarioCompletoTO.permissoes.FlUsuarioI = "false";
                        }
                        if (reader.GetInt32(21) == 1) {
                            usuarioCompletoTO.permissoes.FlUsuarioC = "True";
                        } else {
                            usuarioCompletoTO.permissoes.FlUsuarioC = "false";
                        }
                        if (reader.GetInt32(22) == 1) {
                            usuarioCompletoTO.permissoes.FlUsuarioA = "True";
                        } else {
                            usuarioCompletoTO.permissoes.FlUsuarioA = "false";
                        }
                        if (reader.GetInt32(23) == 1) {
                            usuarioCompletoTO.permissoes.FlUsuarioE = "True";
                        } else {
                            usuarioCompletoTO.permissoes.FlUsuarioE = "false";
                        }

                        if (reader.GetInt32(24) == 1) {
                            usuarioCompletoTO.permissoes.FlPacienteI = "True";
                        } else {
                            usuarioCompletoTO.permissoes.FlPacienteI = "false";
                        }
                        if (reader.GetInt32(25) == 1) {
                            usuarioCompletoTO.permissoes.FlPacienteC = "True";
                        } else {
                            usuarioCompletoTO.permissoes.FlPacienteC = "false";
                        }
                        if (reader.GetInt32(26) == 1) {
                            usuarioCompletoTO.permissoes.FlPacienteA = "True";
                        } else {
                            usuarioCompletoTO.permissoes.FlPacienteA = "false";
                        }
                        if (reader.GetInt32(27) == 1) {
                            usuarioCompletoTO.permissoes.FlPacienteE = "True";
                        } else {
                            usuarioCompletoTO.permissoes.FlPacienteE = "false";
                        }

                        if (reader.GetInt32(28) == 1) {
                            usuarioCompletoTO.permissoes.FlConsultaI = "True";
                        } else {
                            usuarioCompletoTO.permissoes.FlConsultaI = "false";
                        }
                        if (reader.GetInt32(29) == 1) {
                            usuarioCompletoTO.permissoes.FlConsultaC = "True";
                        } else {
                            usuarioCompletoTO.permissoes.FlConsultaC = "false";
                        }
                        if (reader.GetInt32(30) == 1) {
                            usuarioCompletoTO.permissoes.FlConsultaA = "True";
                        } else {
                            usuarioCompletoTO.permissoes.FlConsultaA = "false";
                        }
                        if (reader.GetInt32(31) == 1) {
                            usuarioCompletoTO.permissoes.FlConsultaE = "True";
                        } else {
                            usuarioCompletoTO.permissoes.FlConsultaE = "false";
                        }

                        if (reader.GetInt32(32) == 1) {
                            usuarioCompletoTO.permissoes.FlMedicamentoI = "True";
                        } else {
                            usuarioCompletoTO.permissoes.FlMedicamentoI = "false";
                        }
                        if (reader.GetInt32(33) == 1) {
                            usuarioCompletoTO.permissoes.FlMedicamentoC = "True";
                        } else {
                            usuarioCompletoTO.permissoes.FlMedicamentoC = "false";
                        }
                        if (reader.GetInt32(34) == 1) {
                            usuarioCompletoTO.permissoes.FlMedicamentoA = "True";
                        } else {
                            usuarioCompletoTO.permissoes.FlMedicamentoA = "false";
                        }
                        if (reader.GetInt32(35) == 1) {
                            usuarioCompletoTO.permissoes.FlMedicamentoE = "True";
                        } else {
                            usuarioCompletoTO.permissoes.FlMedicamentoE = "false";
                        }

                        if (reader.GetInt32(36) == 1) {
                            usuarioCompletoTO.permissoes.FlExamesI = "True";
                        } else {
                            usuarioCompletoTO.permissoes.FlExamesI = "false";
                        }
                        if (reader.GetInt32(37) == 1) {
                            usuarioCompletoTO.permissoes.FlExamesC = "True";
                        } else {
                            usuarioCompletoTO.permissoes.FlExamesC = "false";
                        }
                        if (reader.GetInt32(35) == 1) {
                            usuarioCompletoTO.permissoes.FlExamesA = "True";
                        } else {
                            usuarioCompletoTO.permissoes.FlExamesA = "false";
                        }
                        if (reader.GetInt32(36) == 1) {
                            usuarioCompletoTO.permissoes.FlExamesE = "True";
                        } else {
                            usuarioCompletoTO.permissoes.FlExamesE = "false";
                        }
                    }
                }

                reader.Close();
                connection.Close();

                return usuarioCompletoTO;

            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
