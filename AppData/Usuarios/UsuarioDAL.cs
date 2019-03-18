using System;
using System.Collections.Generic;
using System.Transactions;
using SGCM.AppData.Infraestrutura.UtilMetodo;
using SGCM.Models.Usuario.CadastroUsuarioModel;
using SGCM.Models.Usuario.EditarUsuarioModel;
using SGCM.Models.Usuario.ConsultarUsuarioModel;
using MySql.Data.MySqlClient;

namespace SGCM.AppData.Usuario {
    public class UsuarioDAL : SGCMContext {

        public List<ListaConsultarUsuarioModel> ConsultarUsuario(int IdPessoa, int sort, string psqNome, string psqCPF, string psqTelefoneCelular)
        {
            try
            {
                List<ListaConsultarUsuarioModel> usuarioCompletoTOList = new List<ListaConsultarUsuarioModel>();

                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new UsuarioDALSQL();
                MySqlCommand cmdConsultarUsuario = new MySqlCommand(DALSQL.ConsultarUsuario(sort, psqNome, psqCPF, psqTelefoneCelular), connection);
                cmdConsultarUsuario.Parameters.Add("@IDPESSOA", MySqlDbType.Int32).Value = IdPessoa;
                cmdConsultarUsuario.Parameters.AddWithValue("@NOME", "%" + psqNome + "%");
                cmdConsultarUsuario.Parameters.AddWithValue("@CPF", "%" + psqCPF + "%");
                cmdConsultarUsuario.Parameters.AddWithValue("@TELEFONECELULAR", "%" + psqTelefoneCelular + "%");

                MySqlDataReader reader = cmdConsultarUsuario.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        ListaConsultarUsuarioModel usuarioCompletoTO = new ListaConsultarUsuarioModel();
                        usuarioCompletoTO.Nome = reader.GetString(0);
                        usuarioCompletoTO.CPF = reader.GetString(1);
                        usuarioCompletoTO.TelefoneCelular = reader.GetString(2);
                        usuarioCompletoTO.idPessoa = reader.GetInt32(3);
                        usuarioCompletoTO.idUsuario = reader.GetInt32(4);

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

                        cmdPermissoes.Parameters.AddWithValue("@IDUSUARIO", lastId);
                        cmdPermissoes.Parameters.AddWithValue("@FLUSUARIOI", Int32.Parse(usuario.permissoes.flUsuarioI));
                        cmdPermissoes.Parameters.AddWithValue("@FLUSUARIOC", Int32.Parse(usuario.permissoes.flUsuarioC));
                        cmdPermissoes.Parameters.AddWithValue("@FLUSUARIOA", Int32.Parse(usuario.permissoes.flUsuarioA));
                        cmdPermissoes.Parameters.AddWithValue("@FLUSUARIOE", Int32.Parse(usuario.permissoes.flUsuarioE));

                        cmdPermissoes.Parameters.AddWithValue("@FLPACIENTEI", Int32.Parse(usuario.permissoes.flPacienteI));
                        cmdPermissoes.Parameters.AddWithValue("@FLPACIENTEC", Int32.Parse(usuario.permissoes.flPacienteC));
                        cmdPermissoes.Parameters.AddWithValue("@FLPACIENTEA", Int32.Parse(usuario.permissoes.flPacienteA));
                        cmdPermissoes.Parameters.AddWithValue("@FLPACIENTEE", Int32.Parse(usuario.permissoes.flPacienteE));

                        cmdPermissoes.Parameters.AddWithValue("@FLCONSULTAI", Int32.Parse(usuario.permissoes.flConsultaI));
                        cmdPermissoes.Parameters.AddWithValue("@FLCONSULTAC", Int32.Parse(usuario.permissoes.flConsultaC));
                        cmdPermissoes.Parameters.AddWithValue("@FLCONSULTAA", Int32.Parse(usuario.permissoes.flConsultaA));
                        cmdPermissoes.Parameters.AddWithValue("@FLCONSULTAE", Int32.Parse(usuario.permissoes.flConsultaE));

                        cmdPermissoes.Parameters.AddWithValue("@FLAUSENCIAI", Int32.Parse(usuario.permissoes.flAusenciaI));
                        cmdPermissoes.Parameters.AddWithValue("@FLAUSENCIAC", Int32.Parse(usuario.permissoes.flAusenciaC));
                        cmdPermissoes.Parameters.AddWithValue("@FLAUSENCIAA", Int32.Parse(usuario.permissoes.flAusenciaA));
                        cmdPermissoes.Parameters.AddWithValue("@FLAUSENCIAE", Int32.Parse(usuario.permissoes.flAusenciaE));

                        cmdPermissoes.Parameters.AddWithValue("@FLMEDICAMENTOI", Int32.Parse(usuario.permissoes.flMedicamentoI));
                        cmdPermissoes.Parameters.AddWithValue("@FLMEDICAMENTOC", Int32.Parse(usuario.permissoes.flMedicamentoC));
                        cmdPermissoes.Parameters.AddWithValue("@FLMEDICAMENTOA", Int32.Parse(usuario.permissoes.flMedicamentoA));
                        cmdPermissoes.Parameters.AddWithValue("@FLMEDICAMENTOE", Int32.Parse(usuario.permissoes.flMedicamentoE));

                        cmdPermissoes.Parameters.AddWithValue("@FLEXAMESI", Int32.Parse(usuario.permissoes.flExamesI));
                        cmdPermissoes.Parameters.AddWithValue("@FLEXAMESC", Int32.Parse(usuario.permissoes.flExamesC));
                        cmdPermissoes.Parameters.AddWithValue("@FLEXAMESA", Int32.Parse(usuario.permissoes.flExamesA));
                        cmdPermissoes.Parameters.AddWithValue("@FLEXAMESE", Int32.Parse(usuario.permissoes.flExamesE));

                        cmdPermissoes.Parameters.AddWithValue("@FLHISTORIAMOLESTIAATUALI", Int32.Parse(usuario.permissoes.flHistoriaMolestiaAtualI));
                        cmdPermissoes.Parameters.AddWithValue("@FLHISTORIAMOLESTIAATUALC", Int32.Parse(usuario.permissoes.flHistoriaMolestiaAtualC));
                        cmdPermissoes.Parameters.AddWithValue("@FLHISTORIAMOLESTIAATUALA", Int32.Parse(usuario.permissoes.flHistoriaMolestiaAtualA));
                        cmdPermissoes.Parameters.AddWithValue("@FLHISTORIAMOLESTIAATUALE", Int32.Parse(usuario.permissoes.flHistoriaMolestiaAtualE));

                        cmdPermissoes.Parameters.AddWithValue("@FLHISTORIAPATOLOGICAPREGRESSAI", Int32.Parse(usuario.permissoes.flHistoriaPatologicaPregressaI));
                        cmdPermissoes.Parameters.AddWithValue("@FLHISTORIAPATOLOGICAPREGRESSAC", Int32.Parse(usuario.permissoes.flHistoriaPatologicaPregressaC));
                        cmdPermissoes.Parameters.AddWithValue("@FLHISTORIAPATOLOGICAPREGRESSAA", Int32.Parse(usuario.permissoes.flHistoriaPatologicaPregressaA));
                        cmdPermissoes.Parameters.AddWithValue("@FLHISTORIAPATOLOGICAPREGRESSAE", Int32.Parse(usuario.permissoes.flHistoriaPatologicaPregressaE));

                        cmdPermissoes.Parameters.AddWithValue("@FLHIPOTESEDIAGNOSTICAI", Int32.Parse(usuario.permissoes.flHipoteseDiagnosticaI));
                        cmdPermissoes.Parameters.AddWithValue("@FLHIPOTESEDIAGNOSTICAC", Int32.Parse(usuario.permissoes.flHipoteseDiagnosticaC));
                        cmdPermissoes.Parameters.AddWithValue("@FLHIPOTESEDIAGNOSTICAA", Int32.Parse(usuario.permissoes.flHipoteseDiagnosticaA));
                        cmdPermissoes.Parameters.AddWithValue("@FLHIPOTESEDIAGNOSTICAE", Int32.Parse(usuario.permissoes.flHipoteseDiagnosticaE));

                        cmdPermissoes.Parameters.AddWithValue("@FLCONDUTAI", Int32.Parse(usuario.permissoes.flCondutaI));
                        cmdPermissoes.Parameters.AddWithValue("@FLCONDUTAC", Int32.Parse(usuario.permissoes.flCondutaC));
                        cmdPermissoes.Parameters.AddWithValue("@FLCONDUTAA", Int32.Parse(usuario.permissoes.flCondutaA));
                        cmdPermissoes.Parameters.AddWithValue("@FLCONDUTAE", Int32.Parse(usuario.permissoes.flCondutaE));

                        cmdPermissoes.Parameters.AddWithValue("@FLINICIARATENDIMENTO", MySqlDbType.Int32).Value = Int32.Parse(usuario.permissoes.flIniciarAtendimento);

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
                        usuarioCompletoTO.usuario.statusDesativado = Convert.ToInt32(reader.GetString(18));

                        usuarioCompletoTO.permissoes.IdPermissoes = reader.GetInt32(19);
                        if (reader.GetInt32(20) == 1) {
                            usuarioCompletoTO.permissoes.flUsuarioI = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flUsuarioI = "false";
                        }
                        if (reader.GetInt32(21) == 1) {
                            usuarioCompletoTO.permissoes.flUsuarioC = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flUsuarioC = "false";
                        }
                        if (reader.GetInt32(22) == 1) {
                            usuarioCompletoTO.permissoes.flUsuarioA = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flUsuarioA = "false";
                        }
                        if (reader.GetInt32(23) == 1) {
                            usuarioCompletoTO.permissoes.flUsuarioE = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flUsuarioE = "false";
                        }

                        if (reader.GetInt32(24) == 1) {
                            usuarioCompletoTO.permissoes.flPacienteI = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flPacienteI = "false";
                        }
                        if (reader.GetInt32(25) == 1) {
                            usuarioCompletoTO.permissoes.flPacienteC = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flPacienteC = "false";
                        }
                        if (reader.GetInt32(26) == 1) {
                            usuarioCompletoTO.permissoes.flPacienteA = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flPacienteA = "false";
                        }
                        if (reader.GetInt32(27) == 1) {
                            usuarioCompletoTO.permissoes.flPacienteE = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flPacienteE = "false";
                        }

                        if (reader.GetInt32(28) == 1) {
                            usuarioCompletoTO.permissoes.flConsultaI = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flConsultaI = "false";
                        }
                        if (reader.GetInt32(29) == 1) {
                            usuarioCompletoTO.permissoes.flConsultaC = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flConsultaC = "false";
                        }
                        if (reader.GetInt32(30) == 1) {
                            usuarioCompletoTO.permissoes.flConsultaA = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flConsultaA = "false";
                        }
                        if (reader.GetInt32(31) == 1) {
                            usuarioCompletoTO.permissoes.flConsultaE = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flConsultaE = "false";
                        }

                        if (reader.GetInt32(32) == 1) {
                            usuarioCompletoTO.permissoes.flAusenciaI = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flAusenciaI = "false";
                        }
                        if (reader.GetInt32(33) == 1) {
                            usuarioCompletoTO.permissoes.flAusenciaC = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flAusenciaC = "false";
                        }
                        if (reader.GetInt32(34) == 1) {
                            usuarioCompletoTO.permissoes.flAusenciaA = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flAusenciaA = "false";
                        }
                        if (reader.GetInt32(35) == 1) {
                            usuarioCompletoTO.permissoes.flAusenciaE = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flAusenciaE = "false";
                        }

                        if (reader.GetInt32(36) == 1) {
                            usuarioCompletoTO.permissoes.flMedicamentoI = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flMedicamentoI = "false";
                        }
                        if (reader.GetInt32(37) == 1) {
                            usuarioCompletoTO.permissoes.flMedicamentoC = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flMedicamentoC = "false";
                        }
                        if (reader.GetInt32(38) == 1) {
                            usuarioCompletoTO.permissoes.flMedicamentoA = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flMedicamentoA = "false";
                        }
                        if (reader.GetInt32(39) == 1) {
                            usuarioCompletoTO.permissoes.flMedicamentoE = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flMedicamentoE = "false";
                        }

                        if (reader.GetInt32(40) == 1) {
                            usuarioCompletoTO.permissoes.flExamesI = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flExamesI = "false";
                        }
                        if (reader.GetInt32(41) == 1) {
                            usuarioCompletoTO.permissoes.flExamesC = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flExamesC = "false";
                        }
                        if (reader.GetInt32(42) == 1) {
                            usuarioCompletoTO.permissoes.flExamesA = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flExamesA = "false";
                        }
                        if (reader.GetInt32(43) == 1) {
                            usuarioCompletoTO.permissoes.flExamesE = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flExamesE = "false";
                        }

                        if (reader.GetInt32(44) == 1) {
                            usuarioCompletoTO.permissoes.flHistoriaMolestiaAtualI = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flHistoriaMolestiaAtualI = "false";
                        }
                        if (reader.GetInt32(45) == 1) {
                            usuarioCompletoTO.permissoes.flHistoriaMolestiaAtualC = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flHistoriaMolestiaAtualC = "false";
                        }
                        if (reader.GetInt32(46) == 1) {
                            usuarioCompletoTO.permissoes.flHistoriaMolestiaAtualA = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flHistoriaMolestiaAtualA = "false";
                        }
                        if (reader.GetInt32(47) == 1) {
                            usuarioCompletoTO.permissoes.flHistoriaMolestiaAtualE = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flHistoriaMolestiaAtualE = "false";
                        }

                        if (reader.GetInt32(48) == 1) {
                            usuarioCompletoTO.permissoes.flHistoriaPatologicaPregressaI = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flHistoriaPatologicaPregressaI = "false";
                        }
                        if (reader.GetInt32(49) == 1) {
                            usuarioCompletoTO.permissoes.flHistoriaPatologicaPregressaC = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flHistoriaPatologicaPregressaC = "false";
                        }
                        if (reader.GetInt32(50) == 1) {
                            usuarioCompletoTO.permissoes.flHistoriaPatologicaPregressaA = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flHistoriaPatologicaPregressaA = "false";
                        }
                        if (reader.GetInt32(51) == 1) {
                            usuarioCompletoTO.permissoes.flHistoriaPatologicaPregressaE = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flHistoriaPatologicaPregressaE = "false";
                        }

                        if (reader.GetInt32(52) == 1) {
                            usuarioCompletoTO.permissoes.flHipoteseDiagnosticaI = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flHipoteseDiagnosticaI = "false";
                        }
                        if (reader.GetInt32(53) == 1) {
                            usuarioCompletoTO.permissoes.flHipoteseDiagnosticaC = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flHipoteseDiagnosticaC = "false";
                        }
                        if (reader.GetInt32(54) == 1) {
                            usuarioCompletoTO.permissoes.flHipoteseDiagnosticaA = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flHipoteseDiagnosticaA = "false";
                        }
                        if (reader.GetInt32(55) == 1) {
                            usuarioCompletoTO.permissoes.flHipoteseDiagnosticaE = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flHipoteseDiagnosticaE = "false";
                        }

                        if (reader.GetInt32(56) == 1) {
                            usuarioCompletoTO.permissoes.flCondutaI = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flCondutaI = "false";
                        }
                        if (reader.GetInt32(57) == 1) {
                            usuarioCompletoTO.permissoes.flCondutaC = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flCondutaC = "false";
                        }
                        if (reader.GetInt32(58) == 1) {
                            usuarioCompletoTO.permissoes.flCondutaA = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flCondutaA = "false";
                        }
                        if (reader.GetInt32(59) == 1) {
                            usuarioCompletoTO.permissoes.flCondutaE = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flCondutaE = "false";
                        }

                        if (reader.GetInt32(60) == 1) {
                            usuarioCompletoTO.permissoes.flIniciarAtendimento = "True";
                        } else {
                            usuarioCompletoTO.permissoes.flIniciarAtendimento = "false";
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
                        cmdUsuario.Parameters.Add("@STATUSDESATIVACAO", MySqlDbType.Int32).Value = Convert.ToInt32(usuarioModel.pessoa.Status);

                        retorno = retorno + cmdUsuario.ExecuteNonQuery();


                        usuarioModel.permissoes = UtilMetodo.ConversaoPermissoesStringParaIntEditar(usuarioModel.permissoes);

                        MySqlCommand cmdPermissoes = new MySqlCommand(DALSQL.EditarPermissoes(usuarioModel), connection);

                        cmdPermissoes.Parameters.Add("@IDUSUARIO", MySqlDbType.Int32).Value = usuarioModel.usuario.IdUsuario;
                        cmdPermissoes.Parameters.Add("@IDPERMISSOES", MySqlDbType.Int32).Value = usuarioModel.permissoes.IdPermissoes;

                        cmdPermissoes.Parameters.AddWithValue("@FLUSUARIOI", Int32.Parse(usuarioModel.permissoes.flUsuarioI));
                        cmdPermissoes.Parameters.AddWithValue("@FLUSUARIOC", Int32.Parse(usuarioModel.permissoes.flUsuarioC));
                        cmdPermissoes.Parameters.AddWithValue("@FLUSUARIOA", Int32.Parse(usuarioModel.permissoes.flUsuarioA));
                        cmdPermissoes.Parameters.AddWithValue("@FLUSUARIOE", Int32.Parse(usuarioModel.permissoes.flUsuarioE));

                        cmdPermissoes.Parameters.AddWithValue("@FLPACIENTEI", Int32.Parse(usuarioModel.permissoes.flPacienteI));
                        cmdPermissoes.Parameters.AddWithValue("@FLPACIENTEC", Int32.Parse(usuarioModel.permissoes.flPacienteC));
                        cmdPermissoes.Parameters.AddWithValue("@FLPACIENTEA", Int32.Parse(usuarioModel.permissoes.flPacienteA));
                        cmdPermissoes.Parameters.AddWithValue("@FLPACIENTEE", Int32.Parse(usuarioModel.permissoes.flPacienteE));

                        cmdPermissoes.Parameters.AddWithValue("@FLCONSULTAI", Int32.Parse(usuarioModel.permissoes.flConsultaI));
                        cmdPermissoes.Parameters.AddWithValue("@FLCONSULTAC", Int32.Parse(usuarioModel.permissoes.flConsultaC));
                        cmdPermissoes.Parameters.AddWithValue("@FLCONSULTAA", Int32.Parse(usuarioModel.permissoes.flConsultaA));
                        cmdPermissoes.Parameters.AddWithValue("@FLCONSULTAE", Int32.Parse(usuarioModel.permissoes.flConsultaE));

                        cmdPermissoes.Parameters.AddWithValue("@FLAUSENCIAI", Int32.Parse(usuarioModel.permissoes.flAusenciaI));
                        cmdPermissoes.Parameters.AddWithValue("@FLAUSENCIAC", Int32.Parse(usuarioModel.permissoes.flAusenciaC));
                        cmdPermissoes.Parameters.AddWithValue("@FLAUSENCIAA", Int32.Parse(usuarioModel.permissoes.flAusenciaA));
                        cmdPermissoes.Parameters.AddWithValue("@FLAUSENCIAE", Int32.Parse(usuarioModel.permissoes.flAusenciaE));

                        cmdPermissoes.Parameters.AddWithValue("@FLMEDICAMENTOI", Int32.Parse(usuarioModel.permissoes.flMedicamentoI));
                        cmdPermissoes.Parameters.AddWithValue("@FLMEDICAMENTOC", Int32.Parse(usuarioModel.permissoes.flMedicamentoC));
                        cmdPermissoes.Parameters.AddWithValue("@FLMEDICAMENTOA", Int32.Parse(usuarioModel.permissoes.flMedicamentoA));
                        cmdPermissoes.Parameters.AddWithValue("@FLMEDICAMENTOE", Int32.Parse(usuarioModel.permissoes.flMedicamentoE));

                        cmdPermissoes.Parameters.AddWithValue("@FLEXAMESI", Int32.Parse(usuarioModel.permissoes.flExamesI));
                        cmdPermissoes.Parameters.AddWithValue("@FLEXAMESC", Int32.Parse(usuarioModel.permissoes.flExamesC));
                        cmdPermissoes.Parameters.AddWithValue("@FLEXAMESA", Int32.Parse(usuarioModel.permissoes.flExamesA));
                        cmdPermissoes.Parameters.AddWithValue("@FLEXAMESE", Int32.Parse(usuarioModel.permissoes.flExamesE));

                        cmdPermissoes.Parameters.AddWithValue("@FLHISTORIAMOLESTIAATUALI", Int32.Parse(usuarioModel.permissoes.flHistoriaMolestiaAtualI));
                        cmdPermissoes.Parameters.AddWithValue("@FLHISTORIAMOLESTIAATUALC", Int32.Parse(usuarioModel.permissoes.flHistoriaMolestiaAtualC));
                        cmdPermissoes.Parameters.AddWithValue("@FLHISTORIAMOLESTIAATUALA", Int32.Parse(usuarioModel.permissoes.flHistoriaMolestiaAtualA));
                        cmdPermissoes.Parameters.AddWithValue("@FLHISTORIAMOLESTIAATUALE", Int32.Parse(usuarioModel.permissoes.flHistoriaMolestiaAtualE));

                        cmdPermissoes.Parameters.AddWithValue("@FLHISTORIAPATOLOGICAPREGRESSAI", Int32.Parse(usuarioModel.permissoes.flHistoriaPatologicaPregressaI));
                        cmdPermissoes.Parameters.AddWithValue("@FLHISTORIAPATOLOGICAPREGRESSAC", Int32.Parse(usuarioModel.permissoes.flHistoriaPatologicaPregressaC));
                        cmdPermissoes.Parameters.AddWithValue("@FLHISTORIAPATOLOGICAPREGRESSAA", Int32.Parse(usuarioModel.permissoes.flHistoriaPatologicaPregressaA));
                        cmdPermissoes.Parameters.AddWithValue("@FLHISTORIAPATOLOGICAPREGRESSAE", Int32.Parse(usuarioModel.permissoes.flHistoriaPatologicaPregressaE));

                        cmdPermissoes.Parameters.AddWithValue("@FLHIPOTESEDIAGNOSTICAI", Int32.Parse(usuarioModel.permissoes.flHipoteseDiagnosticaI));
                        cmdPermissoes.Parameters.AddWithValue("@FLHIPOTESEDIAGNOSTICAC", Int32.Parse(usuarioModel.permissoes.flHipoteseDiagnosticaC));
                        cmdPermissoes.Parameters.AddWithValue("@FLHIPOTESEDIAGNOSTICAA", Int32.Parse(usuarioModel.permissoes.flHipoteseDiagnosticaA));
                        cmdPermissoes.Parameters.AddWithValue("@FLHIPOTESEDIAGNOSTICAE", Int32.Parse(usuarioModel.permissoes.flHipoteseDiagnosticaE));

                        cmdPermissoes.Parameters.AddWithValue("@FLCONDUTAI", Int32.Parse(usuarioModel.permissoes.flCondutaI));
                        cmdPermissoes.Parameters.AddWithValue("@FLCONDUTAC", Int32.Parse(usuarioModel.permissoes.flCondutaC));
                        cmdPermissoes.Parameters.AddWithValue("@FLCONDUTAA", Int32.Parse(usuarioModel.permissoes.flCondutaA));
                        cmdPermissoes.Parameters.AddWithValue("@FLCONDUTAE", Int32.Parse(usuarioModel.permissoes.flCondutaE));

                        cmdPermissoes.Parameters.AddWithValue("@FLINICIARATENDIMENTO", Int32.Parse(usuarioModel.permissoes.flIniciarAtendimento));

                        var teste = getGeneratedSql(cmdPermissoes);

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

        private string getGeneratedSql(MySqlCommand cmd) {
            string result = cmd.CommandText.ToString();
            foreach (MySqlParameter p in cmd.Parameters)
            {
                string isQuted = (p.Value is string) ? "'" : "";
                result = result.Replace(p.ParameterName.ToString(), isQuted + p.Value.ToString() + isQuted);
            }
            return result;
        }
    }
}
