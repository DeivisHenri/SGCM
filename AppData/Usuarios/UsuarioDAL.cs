using System;
using System.Collections.Generic;
using System.Transactions;
using SGCM.AppData.Infraestrutura.UtilMetodo;
using SGCM.Models.Usuario.CadastroUsuarioModel;
using SGCM.Models.Usuario.EditarUsuarioModel;
using MySql.Data.MySqlClient;

namespace SGCM.AppData.Usuario {
    public class UsuarioDAL : SGCMContext {

        public List<CadastroUsuarioModel> ConsultarUsuario(int IdPessoa)
        {
            try
            {
                List<CadastroUsuarioModel> usuarioCompletoTOList = new List<CadastroUsuarioModel>();

                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new UsuarioDALSQL();
                MySqlCommand cmdUsuario = new MySqlCommand(DALSQL.ConsultarUsuario(), connection);
                cmdUsuario.Parameters.Add("@IDPESSOA", MySqlDbType.Int32).Value = IdPessoa;

                MySqlDataReader reader = cmdUsuario.ExecuteReader();
                if (reader.HasRows) {
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
                } else {
                    reader.Close();
                    connection.Close();
                    return null;
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
            using (TransactionScope scope = new TransactionScope()) {
                try {
                    var DALSQL = new UsuarioDALSQL();
                    object lastId;
                    int linhaInserida;

                    using (MySqlConnection connection = new MySqlConnection(getStringConnection())) {

                        connection.Open();

                        MySqlCommand cmdLastId = new MySqlCommand(UtilMetodo.ConsultarUltimoIdInseridoNoBanco(), connection);
                        
                        MySqlCommand cmdPessoa = new MySqlCommand(DALSQL.InserirPessoa(), connection);

                        cmdPessoa.Parameters.Add("@IDMEDICO", MySqlDbType.Int32).Value = usuario.pessoa.IdMedico;
                        cmdPessoa.Parameters.Add("@SEXO", MySqlDbType.Int32).Value = usuario.pessoa.Sexo;
                        cmdPessoa.Parameters.Add("@NOME", MySqlDbType.String).Value = usuario.pessoa.Nome;
                        cmdPessoa.Parameters.Add("@CPF", MySqlDbType.String).Value = usuario.pessoa.CPF;
                        cmdPessoa.Parameters.Add("@RG", MySqlDbType.String).Value = usuario.pessoa.RG;
                        cmdPessoa.Parameters.Add("@DATANASCIMENTO", MySqlDbType.String).Value = usuario.pessoa.DataNascimento.ToShortDateString();
                        cmdPessoa.Parameters.Add("@LOGRADOURO", MySqlDbType.String).Value = usuario.pessoa.Logradouro;
                        cmdPessoa.Parameters.Add("@NUMERO", MySqlDbType.Int32).Value = usuario.pessoa.Numero;
                        cmdPessoa.Parameters.Add("@BAIRRO", MySqlDbType.String).Value = usuario.pessoa.Bairro;
                        cmdPessoa.Parameters.Add("@CIDADE", MySqlDbType.String).Value = usuario.pessoa.Cidade;
                        cmdPessoa.Parameters.Add("@UF", MySqlDbType.String).Value = usuario.pessoa.UF;
                        cmdPessoa.Parameters.Add("@TELEFONECELULAR", MySqlDbType.String).Value = usuario.pessoa.Telefone_Celular;
                        cmdPessoa.Parameters.Add("@EMAIL", MySqlDbType.String).Value = usuario.pessoa.Email;

                        linhaInserida = cmdPessoa.ExecuteNonQuery();

                        lastId = cmdLastId.ExecuteScalar();

                        MySqlCommand cmdUsuario = new MySqlCommand(DALSQL.InserirUsuario(), connection);

                        cmdUsuario.Parameters.Add("@IDPESSOA", MySqlDbType.Int32).Value = lastId;
                        cmdUsuario.Parameters.Add("@USUARIO", MySqlDbType.String).Value = usuario.usuario.Username;
                        cmdUsuario.Parameters.Add("@SENHA", MySqlDbType.String).Value = usuario.usuario.Password;
                        cmdUsuario.Parameters.Add("@TIPOUSUARIO", MySqlDbType.Int32).Value = usuario.usuario.TipoUsuario;

                        linhaInserida = linhaInserida + cmdUsuario.ExecuteNonQuery();

                        lastId = cmdLastId.ExecuteScalar();

                        usuario.permissoes = UtilMetodo.ConversaoPermissoesStringParaIntCadastro(usuario.permissoes);

                        MySqlCommand cmdPermissoes = new MySqlCommand(DALSQL.InserirPermissoes(), connection);

                        cmdPermissoes.Parameters.Add("@IDUSUARIO", MySqlDbType.Int32).Value = lastId;
                        cmdPermissoes.Parameters.Add("@FLUSUARIOI", MySqlDbType.Int32).Value = Int32.Parse(usuario.permissoes.FlUsuarioI);
                        cmdPermissoes.Parameters.Add("@FLUSUARIOC", MySqlDbType.Int32).Value = Int32.Parse(usuario.permissoes.FlUsuarioC);
                        cmdPermissoes.Parameters.Add("@FLUSUARIOA", MySqlDbType.Int32).Value = Int32.Parse(usuario.permissoes.FlUsuarioA);
                        cmdPermissoes.Parameters.Add("@FLUSUARIOE", MySqlDbType.Int32).Value = Int32.Parse(usuario.permissoes.FlUsuarioE);
                        cmdPermissoes.Parameters.Add("@FLPACIENTEI", MySqlDbType.Int32).Value = Int32.Parse(usuario.permissoes.FlPacienteI);
                        cmdPermissoes.Parameters.Add("@FLPACIENTEC", MySqlDbType.Int32).Value = Int32.Parse(usuario.permissoes.FlPacienteC);
                        cmdPermissoes.Parameters.Add("@FLPACIENTEA", MySqlDbType.Int32).Value = Int32.Parse(usuario.permissoes.FlPacienteA);
                        cmdPermissoes.Parameters.Add("@FLPACIENTEE", MySqlDbType.Int32).Value = Int32.Parse(usuario.permissoes.FlPacienteE);
                        cmdPermissoes.Parameters.Add("@FLCONSULTAI", MySqlDbType.Int32).Value = Int32.Parse(usuario.permissoes.FlConsultaI);
                        cmdPermissoes.Parameters.Add("@FLCONSULTAC", MySqlDbType.Int32).Value = Int32.Parse(usuario.permissoes.FlConsultaC);
                        cmdPermissoes.Parameters.Add("@FLCONSULTAA", MySqlDbType.Int32).Value = Int32.Parse(usuario.permissoes.FlConsultaA);
                        cmdPermissoes.Parameters.Add("@FLCONSULTAE", MySqlDbType.Int32).Value = Int32.Parse(usuario.permissoes.FlConsultaE);
                        cmdPermissoes.Parameters.Add("@FLMEDICAMENTOI", MySqlDbType.Int32).Value = Int32.Parse(usuario.permissoes.FlMedicamentoI);
                        cmdPermissoes.Parameters.Add("@FLMEDICAMENTOC", MySqlDbType.Int32).Value = Int32.Parse(usuario.permissoes.FlMedicamentoC);
                        cmdPermissoes.Parameters.Add("@FLMEDICAMENTOA", MySqlDbType.Int32).Value = Int32.Parse(usuario.permissoes.FlMedicamentoA);
                        cmdPermissoes.Parameters.Add("@FLMEDICAMENTOE", MySqlDbType.Int32).Value = Int32.Parse(usuario.permissoes.FlMedicamentoE);
                        cmdPermissoes.Parameters.Add("@FLEXAMESI", MySqlDbType.Int32).Value = Int32.Parse(usuario.permissoes.FlExamesI);
                        cmdPermissoes.Parameters.Add("@FLEXAMESC", MySqlDbType.Int32).Value = Int32.Parse(usuario.permissoes.FlExamesC);
                        cmdPermissoes.Parameters.Add("@FLEXAMESA", MySqlDbType.Int32).Value = Int32.Parse(usuario.permissoes.FlExamesA);
                        cmdPermissoes.Parameters.Add("@FLEXAMESE", MySqlDbType.Int32).Value = Int32.Parse(usuario.permissoes.FlExamesE);

                        linhaInserida = linhaInserida + cmdPermissoes.ExecuteNonQuery();

                        if (linhaInserida == 3) {
                            scope.Complete();
                            return linhaInserida;
                        } else {
                            throw new Exception();
                        }
                    }
                } catch (TransactionAbortedException ex) {
                    scope.Dispose();
                    throw ex;
                } catch (Exception ex) {
                    scope.Dispose();
                    throw ex;
                }
            }
        }

        public EditarUsuarioModel ConsultarUsuarioID(int IdPessoa) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new UsuarioDALSQL();
                MySqlCommand cmdUsuario = new MySqlCommand(DALSQL.ConsultarUsuarioID(), connection);

                cmdUsuario.Parameters.Add("@IDPESSOA", MySqlDbType.Int32).Value = IdPessoa;

                MySqlDataReader reader = cmdUsuario.ExecuteReader();

                EditarUsuarioModel usuarioCompletoTO = new EditarUsuarioModel();
                usuarioCompletoTO.pessoa = new Models.Usuario.EditarUsuarioModel.DadosPessoais();
                usuarioCompletoTO.usuario = new Models.Usuario.EditarUsuarioModel.DadosLogin();
                usuarioCompletoTO.permissoes = new Models.Usuario.EditarUsuarioModel.DadosPermissoes();

                if (reader.HasRows) {
                    while (reader.Read()) {
                        usuarioCompletoTO.pessoa.IdPessoa = reader.GetInt32(0);
                        usuarioCompletoTO.pessoa.IdMedico = reader.GetInt32(1);
                        usuarioCompletoTO.pessoa.Sexo = reader.GetInt32(2).ToString();
                        usuarioCompletoTO.pessoa.Nome = reader.GetString(3);
                        usuarioCompletoTO.pessoa.CPF = reader.GetString(4);
                        usuarioCompletoTO.pessoa.RG = reader.GetString(5);
                        usuarioCompletoTO.pessoa.DataNascimento = reader.GetDateTime(6);
                        usuarioCompletoTO.pessoa.Logradouro = reader.GetString(7);
                        usuarioCompletoTO.pessoa.Numero = reader.GetInt32(8);
                        usuarioCompletoTO.pessoa.Bairro = reader.GetString(9);
                        usuarioCompletoTO.pessoa.Cidade = reader.GetString(10);
                        usuarioCompletoTO.pessoa.UF = reader.GetString(11);
                        usuarioCompletoTO.pessoa.Telefone_Celular = reader.GetString(12);
                        usuarioCompletoTO.pessoa.Email = reader.GetString(13);

                        usuarioCompletoTO.usuario.IdUsuario = reader.GetInt32(14);
                        usuarioCompletoTO.usuario.Username = reader.GetString(15);
                        usuarioCompletoTO.usuario.TipoUsuario = reader.GetInt32(16).ToString();
                        usuarioCompletoTO.usuario.DataCadastro = Convert.ToDateTime(reader.GetString(17));
                        if (!(reader.IsDBNull(18)))
                            usuarioCompletoTO.usuario.DataDesativacao = Convert.ToDateTime(reader.GetString(18));
                        else
                            usuarioCompletoTO.usuario.DataDesativacao = new DateTime();

                        usuarioCompletoTO.permissoes.IdPermissoes = reader.GetInt32(19);
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
                        if (reader.GetInt32(38) == 1) {
                            usuarioCompletoTO.permissoes.FlExamesA = "True";
                        } else {
                            usuarioCompletoTO.permissoes.FlExamesA = "false";
                        }
                        if (reader.GetInt32(39) == 1) {
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

        public int EditarUsuario(EditarUsuarioModel usuarioModel) {
            using (TransactionScope scope = new TransactionScope()) {
                try {
                    var DALSQL = new UsuarioDALSQL();
                    using (MySqlConnection connection = new MySqlConnection(getStringConnection())) {
                        var retorno = 0;

                        connection.Open();

                        MySqlCommand cmdPessoa = new MySqlCommand(DALSQL.EditarPessoa(usuarioModel), connection);

                        cmdPessoa.Parameters.Add("@IDPESSOA", MySqlDbType.Int32).Value = usuarioModel.pessoa.IdPessoa;
                        cmdPessoa.Parameters.Add("@IDMEDICO", MySqlDbType.Int32).Value = usuarioModel.pessoa.IdMedico;
                        cmdPessoa.Parameters.Add("@SEXO", MySqlDbType.Int32).Value = usuarioModel.pessoa.Sexo;
                        cmdPessoa.Parameters.Add("@NOME", MySqlDbType.String).Value = usuarioModel.pessoa.Nome;
                        cmdPessoa.Parameters.Add("@CPF", MySqlDbType.String).Value = usuarioModel.pessoa.CPF;
                        cmdPessoa.Parameters.Add("@RG", MySqlDbType.String).Value = usuarioModel.pessoa.RG;
                        cmdPessoa.Parameters.Add("@DATANASCIMENTO", MySqlDbType.String).Value = usuarioModel.pessoa.DataNascimento.ToShortDateString();
                        cmdPessoa.Parameters.Add("@LOGRADOURO", MySqlDbType.String).Value = usuarioModel.pessoa.Logradouro;
                        cmdPessoa.Parameters.Add("@NUMERO", MySqlDbType.Int32).Value = usuarioModel.pessoa.Numero;
                        cmdPessoa.Parameters.Add("@BAIRRO", MySqlDbType.String).Value = usuarioModel.pessoa.Bairro;
                        cmdPessoa.Parameters.Add("@CIDADE", MySqlDbType.String).Value = usuarioModel.pessoa.Cidade;
                        cmdPessoa.Parameters.Add("@UF", MySqlDbType.String).Value = usuarioModel.pessoa.UF;
                        cmdPessoa.Parameters.Add("@TELEFONECELULAR", MySqlDbType.String).Value = usuarioModel.pessoa.Telefone_Celular;
                        cmdPessoa.Parameters.Add("@EMAIL", MySqlDbType.String).Value = usuarioModel.pessoa.Email;

                        retorno = cmdPessoa.ExecuteNonQuery();

                        MySqlCommand cmdUsuario = new MySqlCommand(DALSQL.EditarUsuario(usuarioModel), connection);

                        cmdUsuario.Parameters.Add("@IDUSUARIO", MySqlDbType.Int32).Value = usuarioModel.usuario.IdUsuario;
                        cmdUsuario.Parameters.Add("@IDPESSOA", MySqlDbType.Int32).Value = usuarioModel.pessoa.IdPessoa;
                        cmdUsuario.Parameters.Add("@USUARIO", MySqlDbType.String).Value = usuarioModel.usuario.Username;
                        cmdUsuario.Parameters.Add("@SENHA", MySqlDbType.String).Value = usuarioModel.usuario.Password;
                        cmdUsuario.Parameters.Add("@TIPOUSUARIO", MySqlDbType.Int32).Value = Convert.ToInt32(usuarioModel.usuario.TipoUsuario);
                        cmdUsuario.Parameters.Add("@DATADESATIVACAO", MySqlDbType.String).Value = usuarioModel.usuario.DataDesativacao;

                        retorno = retorno + cmdUsuario.ExecuteNonQuery();


                        usuarioModel.permissoes = UtilMetodo.ConversaoPermissoesStringParaIntEditar(usuarioModel.permissoes);

                        MySqlCommand cmdPermissoes = new MySqlCommand(DALSQL.EditarPermissoes(usuarioModel), connection);

                        cmdPermissoes.Parameters.Add("@IDUSUARIO", MySqlDbType.Int32).Value = usuarioModel.usuario.IdUsuario;
                        cmdPermissoes.Parameters.Add("@IDPERMISSOES", MySqlDbType.Int32).Value = usuarioModel.permissoes.IdPermissoes;
                        cmdPermissoes.Parameters.Add("@FLUSUARIOI", MySqlDbType.Int32).Value = Int32.Parse(usuarioModel.permissoes.FlUsuarioI);
                        cmdPermissoes.Parameters.Add("@FLUSUARIOC", MySqlDbType.Int32).Value = Int32.Parse(usuarioModel.permissoes.FlUsuarioC);
                        cmdPermissoes.Parameters.Add("@FLUSUARIOA", MySqlDbType.Int32).Value = Int32.Parse(usuarioModel.permissoes.FlUsuarioA);
                        cmdPermissoes.Parameters.Add("@FLUSUARIOE", MySqlDbType.Int32).Value = Int32.Parse(usuarioModel.permissoes.FlUsuarioE);
                        cmdPermissoes.Parameters.Add("@FLPACIENTEI", MySqlDbType.Int32).Value = Int32.Parse(usuarioModel.permissoes.FlPacienteI);
                        cmdPermissoes.Parameters.Add("@FLPACIENTEC", MySqlDbType.Int32).Value = Int32.Parse(usuarioModel.permissoes.FlPacienteC);
                        cmdPermissoes.Parameters.Add("@FLPACIENTEA", MySqlDbType.Int32).Value = Int32.Parse(usuarioModel.permissoes.FlPacienteA);
                        cmdPermissoes.Parameters.Add("@FLPACIENTEE", MySqlDbType.Int32).Value = Int32.Parse(usuarioModel.permissoes.FlPacienteE);
                        cmdPermissoes.Parameters.Add("@FLCONSULTAI", MySqlDbType.Int32).Value = Int32.Parse(usuarioModel.permissoes.FlConsultaI);
                        cmdPermissoes.Parameters.Add("@FLCONSULTAC", MySqlDbType.Int32).Value = Int32.Parse(usuarioModel.permissoes.FlConsultaC);
                        cmdPermissoes.Parameters.Add("@FLCONSULTAA", MySqlDbType.Int32).Value = Int32.Parse(usuarioModel.permissoes.FlConsultaA);
                        cmdPermissoes.Parameters.Add("@FLCONSULTAE", MySqlDbType.Int32).Value = Int32.Parse(usuarioModel.permissoes.FlConsultaE);
                        cmdPermissoes.Parameters.Add("@FLMEDICAMENTOI", MySqlDbType.Int32).Value = Int32.Parse(usuarioModel.permissoes.FlMedicamentoI);
                        cmdPermissoes.Parameters.Add("@FLMEDICAMENTOC", MySqlDbType.Int32).Value = Int32.Parse(usuarioModel.permissoes.FlMedicamentoC);
                        cmdPermissoes.Parameters.Add("@FLMEDICAMENTOA", MySqlDbType.Int32).Value = Int32.Parse(usuarioModel.permissoes.FlMedicamentoA);
                        cmdPermissoes.Parameters.Add("@FLMEDICAMENTOE", MySqlDbType.Int32).Value = Int32.Parse(usuarioModel.permissoes.FlMedicamentoE);
                        cmdPermissoes.Parameters.Add("@FLEXAMESI", MySqlDbType.Int32).Value = Int32.Parse(usuarioModel.permissoes.FlExamesI);
                        cmdPermissoes.Parameters.Add("@FLEXAMESC", MySqlDbType.Int32).Value = Int32.Parse(usuarioModel.permissoes.FlExamesC);
                        cmdPermissoes.Parameters.Add("@FLEXAMESA", MySqlDbType.Int32).Value = Int32.Parse(usuarioModel.permissoes.FlExamesA);
                        cmdPermissoes.Parameters.Add("@FLEXAMESE", MySqlDbType.Int32).Value = Int32.Parse(usuarioModel.permissoes.FlExamesE);

                        retorno = retorno + cmdPermissoes.ExecuteNonQuery();

                        if (retorno == 3) {
                            scope.Complete();
                            return 3;
                        } else {
                            throw new Exception();
                        }
                    }
                } catch (TransactionAbortedException ex) {
                    scope.Dispose();
                    throw ex;
                } catch (Exception ex) {
                    scope.Dispose();
                    throw ex;
                }
            }
        }
    }
}
