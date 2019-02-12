using System;
using System.Transactions;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using SGCM.Models.Consulta.CadastroConsultaModel;
using SGCM.Models.Consulta.ConsultaPacienteModel;
using SGCM.Models.Consulta.ConsultarConsultaModel;
using SGCM.Models.Consulta.EditarConsultaModel;

namespace SGCM.AppData.Consulta
{
    public class ConsultaDAL : SGCMContext {

        public List<ConsultaPacienteModel> ConsultarPacienteNome(string nome, string cpf, int? idPaciente) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new ConsultaDALSQL();
                MySqlCommand cmdPaciente = new MySqlCommand(DALSQL.ConsultarPacienteNome(nome, cpf, idPaciente), connection);
                if ( nome != null ) cmdPaciente.Parameters.AddWithValue("@NOME", "%" + nome + "%");
                if ( cpf != null ) cmdPaciente.Parameters.AddWithValue("@CPF", cpf);
                if (idPaciente != null ) cmdPaciente.Parameters.AddWithValue("@IDPACIENTE", idPaciente);

                MySqlDataReader reader = cmdPaciente.ExecuteReader();
                List<ConsultaPacienteModel> pacienteList = new List<ConsultaPacienteModel>();

                if (reader.HasRows) {
                    while (reader.Read()) {
                        ConsultaPacienteModel pacienteQuery = new ConsultaPacienteModel();
                        pacienteQuery.idPaciente = reader.GetInt32(0);
                        pacienteQuery.nome = reader.GetString(1);
                        pacienteQuery.cpf = reader.GetString(2);

                        pacienteList.Add(pacienteQuery);
                    }
                    reader.Close();
                    connection.Close();
                    return pacienteList;
                } else {
                    reader.Close();
                    connection.Close();
                    return null;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int CadastrarConsulta(CadastroConsultaModel model) {
            using (TransactionScope scope = new TransactionScope()) {
                try {
                    var DALSQL = new ConsultaDALSQL();
                    var retorno = 0;

                    using (MySqlConnection connection = new MySqlConnection(getStringConnection())) {
                        connection.Open();

                        MySqlCommand cmdConsulta = new MySqlCommand(DALSQL.CadastrarConsulta(model), connection);

                        cmdConsulta.Parameters.Add("@IDPACIENTECONSULTA", MySqlDbType.Int32).Value = model.paciente.idPaciente;
                        if (model.consulta.flagPM) cmdConsulta.Parameters.Add("@FLAGPM", MySqlDbType.String).Value = "PM";
                        cmdConsulta.Parameters.Add("@DATACONSULTA", MySqlDbType.String).Value = model.consulta.DataConsulta.ToString();

                        retorno = cmdConsulta.ExecuteNonQuery();

                        if (retorno == 1) {
                            scope.Complete();
                            return retorno;
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

        public int verificaConsultaCadastrada(CadastroConsultaModel model) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new ConsultaDALSQL();
                MySqlCommand cmdConsulta = new MySqlCommand(DALSQL.verificaConsultaCadastrada(model), connection);
                var dataHoraString = model.consulta.DataConsulta.ToString();

                if (!model.consulta.flagPM) {
                    var dataCompleta = dataHoraString.Split(' ')[0];
                    var dataOrganizada = dataCompleta.Split('/')[2] + "-" + dataCompleta.Split('/')[1] + "-" + dataCompleta.Split('/')[0] + " " + dataHoraString.Split(' ')[1];
                    cmdConsulta.Parameters.AddWithValue("@DATACONSULTA", dataOrganizada);
                } else {
                    cmdConsulta.Parameters.AddWithValue("@DATACONSULTA", dataHoraString);
                    cmdConsulta.Parameters.AddWithValue("@FLAGPM", "PM");
                }

                MySqlDataReader reader = cmdConsulta.ExecuteReader();

                if (reader.HasRows) {
                    return 1;
                } else {
                    return 0;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<ConsultasQuery> ConsultarConsultas(DateTime dataInicial, DateTime dataFinal) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new ConsultaDALSQL();
                MySqlCommand cmdConsulta = new MySqlCommand(DALSQL.ConsultarConsultas(), connection);
                cmdConsulta.Parameters.AddWithValue("@DATAINICIAL", dataInicial);
                cmdConsulta.Parameters.AddWithValue("@DATAFINAL", dataFinal);

                MySqlDataReader reader = cmdConsulta.ExecuteReader();

                List<ConsultasQuery> consultasCompletas = new List<ConsultasQuery>();

                if (reader.HasRows) {
                    while (reader.Read()) {
                        ConsultasQuery consulta = new ConsultasQuery();
                        consulta.idPaciente = reader.GetInt32(0);
                        consulta.nome = reader.GetString(1);
                        consulta.idConsulta = reader.GetInt32(2);
                        consulta.idPacienteConsulta = reader.GetInt32(3);
                        consulta.dataConsulta = reader.GetDateTime(4);

                        consultasCompletas.Add(consulta);
                    }
                    reader.Close();
                    connection.Close();
                    return consultasCompletas;
                } else {
                    reader.Close();
                    connection.Close();
                    return null;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public EditarConsultaModel ConsultarConsulta(ConsultarConsulta consulta) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new ConsultaDALSQL();
                MySqlCommand cmdConsulta = new MySqlCommand(DALSQL.ConsultarConsulta(), connection);
                cmdConsulta.Parameters.AddWithValue("@IDCONSULTA", consulta.idConsulta);

                MySqlDataReader reader = cmdConsulta.ExecuteReader();

                EditarConsultaModel retornoConsulta = new EditarConsultaModel();
                retornoConsulta.paciente = new Models.Consulta.EditarConsultaModel.DadosPaciente();
                retornoConsulta.consulta = new Models.Consulta.EditarConsultaModel.DadosConsulta();

                if (reader.HasRows) {
                    while (reader.Read()) {
                        retornoConsulta.paciente.Nome = reader.GetString(0);
                        retornoConsulta.paciente.idPaciente = reader.GetInt32(1);
                        retornoConsulta.paciente.CPF = reader.GetString(2);
                        retornoConsulta.consulta.DataConsulta = reader.GetDateTime(3);
                        retornoConsulta.consulta.idConsulta = reader.GetInt32(4);
                    }
                    reader.Close();
                    connection.Close();
                    return retornoConsulta;
                } else {
                    reader.Close();
                    connection.Close();
                    return null;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int EditarConsulta(EditarConsultaModel consulta) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new ConsultaDALSQL();
                MySqlCommand cmdEditarConsulta = new MySqlCommand(DALSQL.EditarConsulta(consulta), connection);
                if (consulta.paciente.idPaciente != 0) cmdEditarConsulta.Parameters.AddWithValue("@IDPACIENTECONSULTA", consulta.paciente.idPaciente);
                if (consulta.consulta.DataConsulta != default(DateTime)) cmdEditarConsulta.Parameters.Add("@DATACONSULTA", MySqlDbType.String).Value = consulta.consulta.DataConsulta.ToString();
                cmdEditarConsulta.Parameters.AddWithValue("@IDCONSULTA", consulta.consulta.idConsulta);

                Int32 retorno = cmdEditarConsulta.ExecuteNonQuery();

                connection.Close();
                return retorno;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private string getGeneratedSql(MySqlCommand cmd)
        {
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
