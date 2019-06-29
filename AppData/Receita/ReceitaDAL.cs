using System;
using System.Transactions;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using SGCM.Models.Receita;

namespace SGCM.AppData.Receita
{
    public class ReceitaDAL : SGCMContext {

        public List<ListaReceitaMedicamentoModel> MostrarReceitaMedicamento(int idConsulta, int sortMedicamento) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                ReceitaDALSQL DALSQL = new ReceitaDALSQL();

                /* ---------- BUSCANDO OS MEDICAMENTOS DA CONSULTA ---------- */
                MySqlCommand cmdMedicamento = new MySqlCommand(DALSQL.ConsultarMedicamento(sortMedicamento), connection);
                cmdMedicamento.Parameters.AddWithValue("@IDCONSULTA", idConsulta);

                MySqlDataReader readerExame = cmdMedicamento.ExecuteReader();

                List<ListaReceitaMedicamentoModel> listaReceitaMedicamento = new List<ListaReceitaMedicamentoModel>();

                if (readerExame.HasRows) {
                    while (readerExame.Read()) {
                        ListaReceitaMedicamentoModel receitaMedicamento = new ListaReceitaMedicamentoModel();
                        receitaMedicamento.idConsulta = readerExame.GetInt32(0);
                        receitaMedicamento.idPacienteConsulta = readerExame.GetInt32(1);
                        receitaMedicamento.dataConsulta = readerExame.GetDateTime(2);

                        receitaMedicamento.idConsulta_Medicamento = readerExame.GetInt32(3);

                        receitaMedicamento.idMedicamento = readerExame.GetInt32(4);
                        receitaMedicamento.nomeGenerico = readerExame.GetString(5);
                        receitaMedicamento.nomeFabrica = readerExame.GetString(6);
                        receitaMedicamento.fabricante = readerExame.GetString(7);

                        listaReceitaMedicamento.Add(receitaMedicamento);
                    }
                    readerExame.Close();
                    connection.Close();
                    return listaReceitaMedicamento;
                } else {
                    readerExame.Close();
                    connection.Close();
                    return null;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<ListaReceitaExameModel> MostrarReceitaExame(int idConsulta, int sortExame) {
            try
            {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                ReceitaDALSQL DALSQL = new ReceitaDALSQL();

                /* ---------- BUSCANDO OS EXAMES DA CONSULTA ---------- */
                MySqlCommand cmdExame = new MySqlCommand(DALSQL.ConsultarExame(sortExame), connection);
                cmdExame.Parameters.AddWithValue("@IDCONSULTA", idConsulta);

                MySqlDataReader readerMedicamento = cmdExame.ExecuteReader();

                List<ListaReceitaExameModel> listaReceitaExame = new List<ListaReceitaExameModel>();

                if (readerMedicamento.HasRows)
                {
                    while (readerMedicamento.Read())
                    {
                        ListaReceitaExameModel receitaExame = new ListaReceitaExameModel();

                        receitaExame.idConsulta = readerMedicamento.GetInt32(0);
                        receitaExame.idPacienteConsulta = readerMedicamento.GetInt32(1);
                        receitaExame.dataConsulta = readerMedicamento.GetDateTime(2);

                        receitaExame.idBaseNomeExameExamePedido = readerMedicamento.GetInt32(3);

                        receitaExame.baseNomeExame = readerMedicamento.GetString(4);

                        listaReceitaExame.Add(receitaExame);
                    }
                    readerMedicamento.Close();
                    connection.Close();
                    return listaReceitaExame;
                } else {
                    readerMedicamento.Close();
                    connection.Close();
                    return null;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public String ConsultaPaciente(int idPaciente) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                ReceitaDALSQL DALSQL = new ReceitaDALSQL();

                /* ---------- BUSCANDO O PACIENTE ---------- */
                MySqlCommand cmdPaciente = new MySqlCommand(DALSQL.ConsultaPaciente(), connection);
                cmdPaciente.Parameters.AddWithValue("@IDPACIENTE", idPaciente);

                MySqlDataReader readerPaciente = cmdPaciente.ExecuteReader();

                String nomePaciente = "";

                if (readerPaciente.HasRows) {
                    while (readerPaciente.Read()) {
                        nomePaciente = readerPaciente.GetString(0);
                    }
                    readerPaciente.Close();
                    connection.Close();
                    return nomePaciente;
                } else {
                    readerPaciente.Close();
                    connection.Close();
                    return nomePaciente;
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