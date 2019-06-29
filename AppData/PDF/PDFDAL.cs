using MySql.Data.MySqlClient;
using SGCM.Models.PDF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCM.AppData.PDF {

    public class PDFDAL : SGCMContext {

        public PDFDadosExame ConsultarDadosExamePreencherPDF(int idExame, int idConsulta) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new PDFDALSQL();
                MySqlCommand cmdDadosExame = new MySqlCommand(DALSQL.ConsultarDadosExamePreencherPDF(), connection);
                cmdDadosExame.Parameters.AddWithValue("@IDBASENOMEEXAME", idExame);
                cmdDadosExame.Parameters.AddWithValue("@IDCONSULTA", idConsulta);

                var teste = getGeneratedSql(cmdDadosExame);

                MySqlDataReader reader = cmdDadosExame.ExecuteReader();
                PDFDadosExame dadosExame = new PDFDadosExame();
                
                if (reader.HasRows) {
                    while (reader.Read()) {
                        dadosExame.nome = reader.GetString(0);
                        dadosExame.rg = reader.GetString(1);
                        dadosExame.dataNascimento = reader.GetDateTime(2);
                        dadosExame.dataConsulta = reader.GetDateTime(3);
                        dadosExame.baseNomeExame = reader.GetString(4);
                    }
                    reader.Close();
                    connection.Close();
                } else {
                    dadosExame = null;
                    reader.Close();
                    connection.Close();
                }

                return dadosExame;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public PDFDadosMedicamento ConsultarDadosMedicamentoPreencherPDF(int idMedicamento, int idConsulta) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new PDFDALSQL();
                MySqlCommand cmdDadosMedicamento = new MySqlCommand(DALSQL.ConsultarDadosMedicamentoPreencherPDF(), connection);
                cmdDadosMedicamento.Parameters.AddWithValue("@IDMEDICAMENTOCONSULTA_MEDICAMENTO", idMedicamento);
                cmdDadosMedicamento.Parameters.AddWithValue("@IDCONSULTA", idConsulta);

                //var teste = getGeneratedSql(cmdDadosMedicamento);

                MySqlDataReader reader = cmdDadosMedicamento.ExecuteReader();
                PDFDadosMedicamento dadosMedicamento = new PDFDadosMedicamento();

                if (reader.HasRows) {
                    while (reader.Read()) {
                        dadosMedicamento.nome = reader.GetString(0);
                        dadosMedicamento.rg = reader.GetString(1);
                        dadosMedicamento.dataNascimento = reader.GetDateTime(2);
                        dadosMedicamento.dataConsulta = reader.GetDateTime(3);
                        dadosMedicamento.nomeGenerico = reader.GetString(4);
                        dadosMedicamento.nomeFabrica = reader.GetString(5);
                    }
                    reader.Close();
                    connection.Close();
                } else {
                    dadosMedicamento = null;
                    reader.Close();
                    connection.Close();
                }

                return dadosMedicamento;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public DPFDadosPacienteModel ConsultarDadosPacientePreencherPDF(int idPaciente) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new PDFDALSQL();
                MySqlCommand cmdDadosPaciente = new MySqlCommand(DALSQL.ConsultarDadosPacientePreencherPDF(), connection);

                cmdDadosPaciente.Parameters.AddWithValue("@IDPACIENTE", idPaciente);

                var teste = getGeneratedSql(cmdDadosPaciente);

                MySqlDataReader reader = cmdDadosPaciente.ExecuteReader();
                DPFDadosPacienteModel dadosPaciente = new DPFDadosPacienteModel();
                dadosPaciente.ListPaciente = new List<ListPaciente>();

                if (reader.HasRows) {
                    while (reader.Read()) {

                        ListPaciente paciente = new ListPaciente();

                        if (dadosPaciente.nome == null || dadosPaciente.nome == string.Empty) dadosPaciente.nome = reader.GetString(0);
                        if (dadosPaciente.rg == null || dadosPaciente.rg == string.Empty) dadosPaciente.rg = reader.GetString(1);
                        if (dadosPaciente.dataNascimento == null || dadosPaciente.dataNascimento != default(DateTime)) dadosPaciente.dataNascimento = reader.GetDateTime(2);

                        paciente.dataConsulta = reader.GetDateTime(3);
                        paciente.status = reader.GetInt32(4);

                        dadosPaciente.ListPaciente.Add(paciente);
                    }
                    reader.Close();
                    connection.Close();
                } else {
                    dadosPaciente = null;
                    reader.Close();
                    connection.Close();
                }

                return dadosPaciente;
            } catch (Exception ex) {
                throw ex;
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
