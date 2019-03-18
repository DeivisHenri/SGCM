using SGCM.Models.Paciente.CadastroPacienteModel;
using SGCM.Models.Paciente.ConsultarPacienteModel;
using SGCM.Models.Paciente.EditarPacienteModel;
using System;
using System.Transactions;
using MySql.Data.MySqlClient;
using SGCM.AppData.Infraestrutura.UtilMetodo;
using System.Collections.Generic;

namespace SGCM.AppData.Paciente
{
    public class PacienteDAL : SGCMContext {

        public int InserirPaciente(CadastroPacienteModel paciente) {
            using (TransactionScope scope = new TransactionScope()) {
                try {
                    var DALSQL = new PacienteDALSQL();
                    Decimal retorno = 0;

                    using (MySqlConnection connection = new MySqlConnection(getStringConnection())) {
                      
                        connection.Open();

                        MySqlCommand cmdPessoa = new MySqlCommand(DALSQL.InserirPessoa(), connection);

                        cmdPessoa.Parameters.Add("@IDMEDICO", MySqlDbType.String).Value = paciente.pessoa.IdMedico;
                        cmdPessoa.Parameters.Add("@NOME", MySqlDbType.String).Value = paciente.pessoa.Nome;
                        cmdPessoa.Parameters.Add("@SEXO", MySqlDbType.Int32).Value = paciente.pessoa.Sexo;
                        cmdPessoa.Parameters.Add("@CPF", MySqlDbType.String).Value = paciente.pessoa.CPF;
                        cmdPessoa.Parameters.Add("@RG", MySqlDbType.String).Value = paciente.pessoa.RG;
                        cmdPessoa.Parameters.Add("@DATANASCIMENTO", MySqlDbType.String).Value = paciente.pessoa.DataNascimento;
                        cmdPessoa.Parameters.Add("@LOGRADOURO", MySqlDbType.String).Value = paciente.pessoa.Logradouro;
                        cmdPessoa.Parameters.Add("@NUMERO", MySqlDbType.Int32).Value = paciente.pessoa.Numero;
                        cmdPessoa.Parameters.Add("@BAIRRO", MySqlDbType.String).Value = paciente.pessoa.Bairro;
                        cmdPessoa.Parameters.Add("@CIDADE", MySqlDbType.String).Value = paciente.pessoa.Cidade;
                        cmdPessoa.Parameters.Add("@UF", MySqlDbType.String).Value = paciente.pessoa.Uf;
                        cmdPessoa.Parameters.Add("@TELEFONECELULAR", MySqlDbType.String).Value = paciente.pessoa.TelefoneCelular;
                        cmdPessoa.Parameters.Add("@EMAIL", MySqlDbType.String).Value = paciente.pessoa.Email;

                        retorno = cmdPessoa.ExecuteNonQuery();

                        MySqlCommand cmdLastId = new MySqlCommand(UtilMetodo.ConsultarUltimoIdInseridoNoBanco(), connection);
                        var lastId = cmdLastId.ExecuteScalar();

                        MySqlCommand cmdConsulta = new MySqlCommand(DALSQL.ConsultaIdConsulta(), connection);
                        var idConsulta = cmdConsulta.ExecuteScalar();

                        if (idConsulta.ToString() == "") {
                            idConsulta = 1;
                        } else {
                            idConsulta = (int)idConsulta + 1;
                        }

                        MySqlCommand cmdExame = new MySqlCommand(DALSQL.ConsultaIdExame(), connection);
                        var IdExame = cmdExame.ExecuteScalar();

                        if (IdExame.ToString() == "") {
                            IdExame = 1;
                        } else {
                            IdExame = (int)IdExame + 1;
                        }

                        MySqlCommand cmdMedicamento = new MySqlCommand(DALSQL.ConsultaIdMedicamento(), connection);
                        var IdMedicamento = cmdMedicamento.ExecuteScalar();

                        if (IdMedicamento.ToString() == "") {
                            IdMedicamento = 1;
                        } else {
                            IdMedicamento = (int)IdMedicamento + 1;
                        }

                        MySqlCommand cmdReceita = new MySqlCommand(DALSQL.ConsultaIdReceita(), connection);
                        var IdReceita = cmdReceita.ExecuteScalar();

                        if (IdReceita.ToString() == "") {
                            IdReceita = 1;
                        } else {
                            IdReceita = (int)IdReceita + 1;
                        }

                        MySqlCommand cmdPaciente = new MySqlCommand(DALSQL.InserirPaciente(), connection);

                        cmdPaciente.Parameters.AddWithValue("@IDPESSOA", Convert.ToInt32(lastId.ToString()));
                        cmdPaciente.Parameters.AddWithValue("@IDMEDICO", Convert.ToInt32(paciente.pessoa.IdMedico));
                        cmdPaciente.Parameters.AddWithValue("@IDCONSULTA", Convert.ToInt32(idConsulta.ToString()));
                        cmdPaciente.Parameters.AddWithValue("@IDEXAME", Convert.ToInt32(IdExame.ToString()));
                        cmdPaciente.Parameters.AddWithValue("@IDMEDICAMENTO", Convert.ToInt32(IdMedicamento.ToString()));
                        cmdPaciente.Parameters.AddWithValue("@IDRECEITA", Convert.ToInt32(IdReceita.ToString()));
                        cmdPaciente.Parameters.AddWithValue("@STATUSDESATIVADO", 1);

                        retorno = retorno + cmdPaciente.ExecuteNonQuery();

                        if (retorno == 2) {
                            scope.Complete();
                            connection.Close();
                            return (int) retorno;
                        } else {
                            scope.Dispose();
                            connection.Close();
                            throw new Exception();
                        }
                    }
                } catch (Exception ex) {
                    throw ex;
                }
            }
        }

        public List<ListaConsultarPacienteModel> ConsultarPaciente(int IdMedico, int sortOrder, string psqNome, string psqCPF, string psqTelefoneCelular) {
            MySqlConnection connection = new MySqlConnection(getStringConnection());

            try {
                List<ListaConsultarPacienteModel> pacienteList = new List<ListaConsultarPacienteModel>();                
                connection.Open();

                var DALSQL = new PacienteDALSQL();
                MySqlCommand cmdConsultarPaciente = new MySqlCommand(DALSQL.ConsultarPaciente(sortOrder, psqNome, psqCPF, psqTelefoneCelular), connection);
                cmdConsultarPaciente.Parameters.Add("@IDMEDICO", MySqlDbType.Int32).Value = IdMedico;
                cmdConsultarPaciente.Parameters.AddWithValue("@NOME", "%" + psqNome + "%");
                cmdConsultarPaciente.Parameters.AddWithValue("@CPF", "%" + psqCPF + "%");
                cmdConsultarPaciente.Parameters.AddWithValue("@TELEFONECELULAR", "%" + psqTelefoneCelular + "%");

                MySqlDataReader reader = cmdConsultarPaciente.ExecuteReader();

                if (reader.HasRows) {
                    while (reader.Read()) {
                        ListaConsultarPacienteModel pacienteModel = new ListaConsultarPacienteModel();

                        pacienteModel.idPessoa = reader.GetInt32(0);
                        pacienteModel.Nome = reader.GetString(1);
                        pacienteModel.CPF = reader.GetString(2);
                        pacienteModel.TelefoneCelular = reader.GetString(3);
                        pacienteModel.idPaciente = reader.GetInt32(4);
                        pacienteModel.Status = reader.GetInt32(5).ToString();

                        pacienteList.Add(pacienteModel);
                    }
                    reader.NextResult();
                } else {
                    reader.Close();
                    connection.Close();
                    return null;
                }
                reader.Close();
                connection.Close();

                return pacienteList;
            }
            catch (Exception ex) {
                connection.Close();
                throw ex;
            }
        }

        public EditarPacienteModel ConsultarPacienteID(int idPaciente) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                //----- Consulta OS DADOS PESSOAS DO PACIENTE -----

                var DALSQL = new PacienteDALSQL();
                MySqlCommand cmdPaciente = new MySqlCommand(DALSQL.ConsultarPacienteID(), connection);
                cmdPaciente.Parameters.AddWithValue("@IDPACIENTE", idPaciente);
                MySqlDataReader readerPaciente = cmdPaciente.ExecuteReader();

                EditarPacienteModel pacienteCompleto = new EditarPacienteModel();
                pacienteCompleto.Pessoa = new Models.Paciente.EditarPacienteModel.DadosPessoais();

                if (readerPaciente.HasRows) {
                    while (readerPaciente.Read()) {
                        pacienteCompleto.Pessoa.IdPessoa = readerPaciente.GetInt32(0);
                        pacienteCompleto.Pessoa.Nome = readerPaciente.GetString(1);
                        pacienteCompleto.Pessoa.CPF = readerPaciente.GetString(2);
                        pacienteCompleto.Pessoa.RG = readerPaciente.GetString(3);
                        pacienteCompleto.Pessoa.Sexo = readerPaciente.GetString(4);
                        pacienteCompleto.Pessoa.DataNascimento = readerPaciente.GetDateTime(5);
                        pacienteCompleto.Pessoa.Logradouro = readerPaciente.GetString(6);
                        pacienteCompleto.Pessoa.Numero = readerPaciente.GetInt32(7);
                        pacienteCompleto.Pessoa.Bairro = readerPaciente.GetString(8);
                        pacienteCompleto.Pessoa.Cidade = readerPaciente.GetString(9);
                        pacienteCompleto.Pessoa.Uf = readerPaciente.GetString(10);
                        pacienteCompleto.Pessoa.TelefoneCelular = readerPaciente.GetString(11);
                        pacienteCompleto.Pessoa.Email = readerPaciente.GetString(12);
                        pacienteCompleto.Pessoa.Status = readerPaciente.GetInt32(13).ToString();
                    }
                }
                readerPaciente.Close();

                //----- -----

                //----- CONSULTA OS DADOS DA CONSULTA DO PACIENTE -----

                MySqlCommand cmdConsultaPaciente = new MySqlCommand(DALSQL.ConsultarPacienteConsulta(), connection);
                cmdConsultaPaciente.Parameters.AddWithValue("@IDPACIENTECONSULTA", idPaciente);
                MySqlDataReader readerConsultaPaciente = cmdConsultaPaciente.ExecuteReader();

                pacienteCompleto.Consulta = new List<DadosConsulta>();

                if (readerConsultaPaciente.HasRows) {
                    while (readerConsultaPaciente.Read()) {
                        DadosConsulta consulta = new DadosConsulta();

                        consulta.idConsulta = readerConsultaPaciente.GetInt32(0);
                        consulta.idPacienteConsulta = readerConsultaPaciente.GetInt32(1);
                        consulta.dataConsulta = readerConsultaPaciente.GetDateTime(2);
                        consulta.finalizada = readerConsultaPaciente.GetInt32(3);

                        pacienteCompleto.Consulta.Add(consulta);
                    }
                    readerConsultaPaciente.NextResult();
                }
                readerConsultaPaciente.Close();
                //----- -----

                connection.Close();
                return pacienteCompleto;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int EditarPaciente(EditarPacienteModel pacienteModel) {
            using (TransactionScope scope = new TransactionScope()) {
                try {
                    var DALSQL = new PacienteDALSQL();
                    using (MySqlConnection connection = new MySqlConnection(getStringConnection())) {
                        var retorno = 0;

                        connection.Open();

                        MySqlCommand cmdPessoa = new MySqlCommand(DALSQL.EditarPessoa(pacienteModel), connection);

                        cmdPessoa.Parameters.Add("@IDPESSOA", MySqlDbType.Int32).Value = pacienteModel.Pessoa.IdPessoa;
                        cmdPessoa.Parameters.Add("@SEXO", MySqlDbType.Int32).Value = pacienteModel.Pessoa.Sexo;
                        cmdPessoa.Parameters.Add("@NOME", MySqlDbType.String).Value = pacienteModel.Pessoa.Nome;
                        cmdPessoa.Parameters.Add("@CPF", MySqlDbType.String).Value = pacienteModel.Pessoa.CPF;
                        cmdPessoa.Parameters.Add("@RG", MySqlDbType.String).Value = pacienteModel.Pessoa.RG;
                        cmdPessoa.Parameters.Add("@DATANASCIMENTO", MySqlDbType.String).Value = pacienteModel.Pessoa.DataNascimento.ToShortDateString();
                        cmdPessoa.Parameters.Add("@LOGRADOURO", MySqlDbType.String).Value = pacienteModel.Pessoa.Logradouro;
                        cmdPessoa.Parameters.Add("@NUMERO", MySqlDbType.Int32).Value = pacienteModel.Pessoa.Numero;
                        cmdPessoa.Parameters.Add("@BAIRRO", MySqlDbType.String).Value = pacienteModel.Pessoa.Bairro;
                        cmdPessoa.Parameters.Add("@CIDADE", MySqlDbType.String).Value = pacienteModel.Pessoa.Cidade;
                        cmdPessoa.Parameters.Add("@UF", MySqlDbType.String).Value = pacienteModel.Pessoa.Uf;
                        cmdPessoa.Parameters.Add("@TELEFONECELULAR", MySqlDbType.String).Value = pacienteModel.Pessoa.TelefoneCelular;
                        cmdPessoa.Parameters.Add("@EMAIL", MySqlDbType.String).Value = pacienteModel.Pessoa.Email;

                        retorno = cmdPessoa.ExecuteNonQuery();

                        MySqlCommand cmdPaciente = new MySqlCommand(DALSQL.EditarPaciente(pacienteModel), connection);
                        cmdPaciente.Parameters.AddWithValue("@STATUSDESATIVADO", Convert.ToInt32(pacienteModel.Pessoa.Status));
                        cmdPaciente.Parameters.AddWithValue("@IDPESSOAPACIENTE", pacienteModel.Pessoa.IdPessoa);

                        var teste2 = getGeneratedSql(cmdPaciente);

                        retorno = retorno + cmdPaciente.ExecuteNonQuery();
                        

                        if (retorno > 0) {
                            scope.Complete();
                            connection.Close();
                            return retorno;
                        } else {
                            connection.Close();
                            throw new Exception();
                        }
                    }
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
