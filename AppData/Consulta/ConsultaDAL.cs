using System;
using System.Transactions;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using SGCM.Models.Consulta.CadastroConsultaModel;
using SGCM.Models.Consulta.ConsultaPacienteModel;

namespace SGCM.AppData.Consulta
{
    public class ConsultaDAL : SGCMContext {

        public List<ConsultaPacienteModel> ConsultarPacienteNome(string nome, string cpf) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new ConsultaDALSQL();
                MySqlCommand cmdPaciente = new MySqlCommand(DALSQL.ConsultarPacienteNome(nome, cpf), connection);
                if ( nome != null ) cmdPaciente.Parameters.AddWithValue("@NOME", "%" + nome + "%");
                if ( cpf != null ) cmdPaciente.Parameters.AddWithValue("@CPF", cpf);

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

                        var teste = getGeneratedSql(cmdConsulta);

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

                var teste = getGeneratedSql(cmdConsulta);

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
