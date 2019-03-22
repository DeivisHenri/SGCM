using System;
using System.Transactions;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using SGCM.Models.Consulta.CadastroConsultaModel;
using SGCM.Models.Consulta.ConsultaPacienteModel;
using SGCM.Models.Consulta.ConsultarConsultaModel;
using SGCM.Models.Consulta.EditarConsultaModel;
using SGCM.Models.Ausencia.CadastrarAusenciaModel;
using SGCM.Models.Consulta.IniciarAtendimento;
using System.IO;

namespace SGCM.AppData.Consulta
{
    public class ConsultaDAL : SGCMContext {

        public ConsultaPacienteModelBanco ConsultarPacienteNome(string nome, string cpf, int? idPaciente) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new ConsultaDALSQL();
                MySqlCommand cmdPaciente = new MySqlCommand(DALSQL.ConsultarPacienteNome(nome, cpf, idPaciente), connection);
                if ( nome != null ) cmdPaciente.Parameters.AddWithValue("@NOME", "%" + nome + "%");
                if ( cpf != null ) cmdPaciente.Parameters.AddWithValue("@CPF", cpf);
                if (idPaciente != null ) cmdPaciente.Parameters.AddWithValue("@IDPACIENTE", idPaciente);

                MySqlDataReader reader = cmdPaciente.ExecuteReader();
                ConsultaPacienteModelBanco paciente = new ConsultaPacienteModelBanco();
                paciente.ListaConsultaPacienteModel = new List<ConsultaPacienteModel>();

                if (reader.HasRows) {
                    while (reader.Read()) {
                        if (reader.GetInt32(3) == 1) { 
                            ConsultaPacienteModel pacienteQuery = new ConsultaPacienteModel();
                            pacienteQuery.idPaciente = reader.GetInt32(0);
                            pacienteQuery.nome = reader.GetString(1);
                            pacienteQuery.cpf = reader.GetString(2);
                            pacienteQuery.statusDesativado = reader.GetInt32(3);

                            paciente.ListaConsultaPacienteModel.Add(pacienteQuery);
                            paciente.retorno = 3;
                        } else {
                            paciente.retorno = 1;
                        }
                    }
                    reader.Close();
                    connection.Close();
                    return paciente;
                } else {
                    paciente.retorno = 2;
                    reader.Close();
                    connection.Close();
                    return paciente;
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

                        cmdConsulta.Parameters.Add("@IDPACIENTECONSULTA", MySqlDbType.Int32).Value = model.Paciente.idPaciente;
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
                        consulta.consultaFinalizada = reader.GetInt32(5);

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

        public EditarConsultaModel ConsultarConsulta(int idConsulta) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new ConsultaDALSQL();
                EditarConsultaModel retornoConsulta = new EditarConsultaModel();

                // ------ DADOS CONSULTA ------
                MySqlCommand cmdConsulta = new MySqlCommand(DALSQL.ConsultarConsulta(), connection);
                cmdConsulta.Parameters.AddWithValue("@IDCONSULTA", idConsulta);

                MySqlDataReader readerCONSULTA = cmdConsulta.ExecuteReader();

                retornoConsulta.Paciente = new Models.Consulta.EditarConsultaModel.DadosPaciente();
                retornoConsulta.Consulta = new Models.Consulta.EditarConsultaModel.DadosConsulta();

                if (readerCONSULTA.HasRows) {
                    while (readerCONSULTA.Read()) {
                        retornoConsulta.Paciente.Nome = readerCONSULTA.GetString(0);
                        retornoConsulta.Paciente.idPaciente = readerCONSULTA.GetInt32(1);
                        retornoConsulta.Paciente.CPF = readerCONSULTA.GetString(2);

                        retornoConsulta.Consulta.DataConsulta = readerCONSULTA.GetDateTime(3);
                        retornoConsulta.Consulta.idConsulta = readerCONSULTA.GetInt32(4);
                        retornoConsulta.Consulta.status = readerCONSULTA.GetInt32(5);
                    }
                    readerCONSULTA.Close();
                } else {
                    readerCONSULTA.Close();
                }

                // ------ DADOS MOLESTIA ATUAL ------
                MySqlCommand cmdMolestiaAtual = new MySqlCommand(DALSQL.ConsultaMolestiaAtual(), connection);
                cmdMolestiaAtual.Parameters.AddWithValue("@IDCONSULTAMOLESTIAATUAL", idConsulta);

                MySqlDataReader readerMolestiaAtual = cmdMolestiaAtual.ExecuteReader();

                retornoConsulta.MolestiaAtual = new Models.Consulta.EditarConsultaModel.DadosMolestiaAtual();

                if (readerMolestiaAtual.HasRows) {
                    while (readerMolestiaAtual.Read()) {
                        retornoConsulta.MolestiaAtual.idMolestiaAtual = readerMolestiaAtual.GetInt32(0);
                        retornoConsulta.MolestiaAtual.idPacienteMolestiaAtual = readerMolestiaAtual.GetInt32(1);
                        retornoConsulta.MolestiaAtual.idConsultaMolestiaAtual = readerMolestiaAtual.GetInt32(2);
                        retornoConsulta.MolestiaAtual.molestiaAtual = readerMolestiaAtual.IsDBNull(3) ? "" : readerMolestiaAtual.GetString(3);
                    }
                    readerMolestiaAtual.Close();
                } else {
                    readerMolestiaAtual.Close();
                }

                // ------ DADOS PATOLOGICA PREGRESSA ------
                MySqlCommand cmdPatologicaPregressa = new MySqlCommand(DALSQL.ConsultaPatologicaPregressa(), connection);
                cmdPatologicaPregressa.Parameters.AddWithValue("@IDCONSULTAPATOLOGICAPREGRESSA", idConsulta);

                MySqlDataReader readerPatologicaPregressa = cmdPatologicaPregressa.ExecuteReader();

                retornoConsulta.PatologicaPregressa = new Models.Consulta.EditarConsultaModel.DadosPatologicaPregressa();

                if (readerPatologicaPregressa.HasRows) {
                    while (readerPatologicaPregressa.Read()) {
                        retornoConsulta.PatologicaPregressa.idPatologicaPregressa = readerPatologicaPregressa.GetInt32(0);
                        retornoConsulta.PatologicaPregressa.idPacientePatologicaPregressa = readerPatologicaPregressa.GetInt32(1);
                        retornoConsulta.PatologicaPregressa.idConsultaPatologicaPregressa = readerPatologicaPregressa.GetInt32(2);
                        retornoConsulta.PatologicaPregressa.patologicaPregressa = readerPatologicaPregressa.IsDBNull(3) ? "" : readerPatologicaPregressa.GetString(3);
                    }
                    readerPatologicaPregressa.Close();
                } else {
                    readerPatologicaPregressa.Close();
                }

                // ------ DADOS EXAME FÍSICO ------
                MySqlCommand cmdExameFisico = new MySqlCommand(DALSQL.ConsultaExameFisico(), connection);
                cmdExameFisico.Parameters.AddWithValue("@IDCONSULTAEXAMEFISICO", idConsulta);

                MySqlDataReader readerExameFisico = cmdExameFisico.ExecuteReader();

                retornoConsulta.ExameFisico = new Models.Consulta.EditarConsultaModel.DadosExameFisico();

                if (readerExameFisico.HasRows) {
                    while (readerExameFisico.Read()) {
                        retornoConsulta.ExameFisico.idExameFisico = readerExameFisico.GetInt32(0);
                        retornoConsulta.ExameFisico.idPacienteExameFisico = readerExameFisico.GetInt32(1);
                        retornoConsulta.ExameFisico.idConsultaExameFisico = readerExameFisico.GetInt32(2);
                        retornoConsulta.ExameFisico.exameFisico = readerExameFisico.IsDBNull(3) ? "" : readerExameFisico.GetString(3);
                    }
                    readerExameFisico.Close();
                } else {
                    readerExameFisico.Close();
                }

                // ------ DADOS EXAME LABORATORIAL ------
                MySqlCommand cmdListExameLaboratorial = new MySqlCommand(DALSQL.ConsultaExameLaboratorialIdConsulta(), connection);
                cmdListExameLaboratorial.Parameters.AddWithValue("@IDCONSULTAEXAMELABORATORIAL", idConsulta);

                MySqlDataReader readerListExameLaboratorial = cmdListExameLaboratorial.ExecuteReader();
                retornoConsulta.ExameLaboratorialLista = new List<Models.Consulta.EditarConsultaModel.DadosExameLaboratorial>();

                if (readerListExameLaboratorial.HasRows) {
                    while (readerListExameLaboratorial.Read()) {
                        Models.Consulta.EditarConsultaModel.DadosExameLaboratorial exameLaboratorial = new Models.Consulta.EditarConsultaModel.DadosExameLaboratorial();

                        exameLaboratorial.idExameLaboratorial = readerListExameLaboratorial.GetInt32(0);
                        exameLaboratorial.idPacienteExameLaboratorial = readerListExameLaboratorial.GetInt32(1);
                        exameLaboratorial.idConsultaExameLaboratorial = readerListExameLaboratorial.GetInt32(2);
                        exameLaboratorial.tamanhoArquivo = readerListExameLaboratorial.GetInt32(4);

                        exameLaboratorial.exameLaboratorial = new byte[exameLaboratorial.tamanhoArquivo];

                        readerListExameLaboratorial.GetBytes(3, 0, exameLaboratorial.exameLaboratorial, 0, exameLaboratorial.tamanhoArquivo);

                        retornoConsulta.ExameLaboratorialLista.Add(exameLaboratorial);
                    }
                    readerListExameLaboratorial.NextResult();
                } else {
                    readerListExameLaboratorial.Close();
                }
                readerListExameLaboratorial.Close();

                // ------ DADOS HIPOTESE DIAGNOSTICA ------
                MySqlCommand cmdHipoteseDiagnostica = new MySqlCommand(DALSQL.ConsultaHipoteseDiagnostica(), connection);
                cmdHipoteseDiagnostica.Parameters.AddWithValue("@IDCONSULTAHIPOTESEDIAGNOSTICA", idConsulta);

                MySqlDataReader readerHipoteseDiagnostica = cmdHipoteseDiagnostica.ExecuteReader();

                retornoConsulta.HipoteseDiagnostica = new Models.Consulta.EditarConsultaModel.DadosHipoteseDiagnostica();

                if (readerHipoteseDiagnostica.HasRows) {
                    while (readerHipoteseDiagnostica.Read()) {
                        retornoConsulta.HipoteseDiagnostica.idHipoteseDiagnostica = readerHipoteseDiagnostica.GetInt32(0);
                        retornoConsulta.HipoteseDiagnostica.idPacienteHipoteseDiagnostica = readerHipoteseDiagnostica.GetInt32(1);
                        retornoConsulta.HipoteseDiagnostica.idConsultaHipoteseDiagnostica = readerHipoteseDiagnostica.GetInt32(2);
                        retornoConsulta.HipoteseDiagnostica.hipoteseDiagnostica = readerHipoteseDiagnostica.IsDBNull(3) ? "" : readerHipoteseDiagnostica.GetString(3);
                    }
                    readerHipoteseDiagnostica.Close();
                } else {
                    readerHipoteseDiagnostica.Close();
                }

                // ------ DADOS CONDUTA ------
                MySqlCommand cmdConduta = new MySqlCommand(DALSQL.ConsultaConduta(), connection);
                cmdConduta.Parameters.AddWithValue("@IDCONSULTACONDUTA", idConsulta);

                MySqlDataReader readerConduta = cmdConduta.ExecuteReader();

                retornoConsulta.Conduta = new Models.Consulta.EditarConsultaModel.DadosConduta();

                if (readerConduta.HasRows) {
                    while (readerConduta.Read()) {
                        retornoConsulta.Conduta.idConduta = readerConduta.GetInt32(0);
                        retornoConsulta.Conduta.idPacienteConduta = readerConduta.GetInt32(1);
                        retornoConsulta.Conduta.idConsultaConduta = readerConduta.GetInt32(2);
                        retornoConsulta.Conduta.conduta = readerConduta.IsDBNull(3) ? "" : readerConduta.GetString(3);
                    }
                    readerConduta.Close();
                } else {
                    readerConduta.Close();
                }

                // ------ DADOS EXAME PEDIDO ------
                MySqlCommand cmdExamePedido = new MySqlCommand(DALSQL.ConsultaExamePedido(), connection);
                cmdExamePedido.Parameters.AddWithValue("@IDCONSULTAEXAMEPEDIDO", idConsulta);

                MySqlDataReader readerExamePedido = cmdExamePedido.ExecuteReader();

                retornoConsulta.ExamePedido = "";
                Boolean flagPrimeiro = true;

                if (readerExamePedido.HasRows) {
                    while (readerExamePedido.Read()) {
                        if (flagPrimeiro == true) {
                            retornoConsulta.ExamePedido = readerExamePedido.GetString(1);
                            flagPrimeiro = false;
                        } else {
                            retornoConsulta.ExamePedido = retornoConsulta.ExamePedido + "," + readerExamePedido.GetString(1);
                        }
                    }
                    readerExamePedido.Close();
                } else {
                    readerExamePedido.Close();
                }

                // ------ MEDICAMENTO PRESCRITO ------
                MySqlCommand cmdMedicamento = new MySqlCommand(DALSQL.ConsultaMedicamentoPrescrito(), connection);
                cmdMedicamento.Parameters.AddWithValue("@IDCONSULTA", idConsulta);

                var teste = getGeneratedSql(cmdMedicamento);

                MySqlDataReader readerMedicamento = cmdMedicamento.ExecuteReader();

                retornoConsulta.Medicamento = "";
                Boolean flagPrimeiroMedicamento = true;

                if (readerMedicamento.HasRows) {
                    while (readerMedicamento.Read()) {
                        if (flagPrimeiroMedicamento == true) {
                            retornoConsulta.Medicamento = readerMedicamento.GetString(2);
                            flagPrimeiroMedicamento = false;
                        } else {
                            retornoConsulta.Medicamento = retornoConsulta.Medicamento + "," + readerMedicamento.GetString(2);
                        }
                    }
                    readerMedicamento.Close();
                } else {
                    readerMedicamento.Close();
                }

                connection.Close();
                return retornoConsulta;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int EditarConsulta(EditarConsultaModel consulta) {
            using (TransactionScope scope = new TransactionScope()) {
                try {
                    MySqlConnection connection = new MySqlConnection(getStringConnection());
                    connection.Open();
                    var DALSQL = new ConsultaDALSQL();
                    Int32 retorno = 0;

                    // ------ DADOS CONSULTA ------
                    MySqlCommand cmdEditarConsulta = new MySqlCommand(DALSQL.EditarConsulta(consulta), connection);

                    if (consulta.Paciente.idPaciente != 0) {
                        cmdEditarConsulta.Parameters.AddWithValue("@IDPACIENTECONSULTA", consulta.Paciente.idPaciente);
                    }

                    if (consulta.Consulta.DataConsulta != default(DateTime) && consulta.Consulta.flagPM == true) {
                        cmdEditarConsulta.Parameters.AddWithValue("@DATACONSULTA", consulta.Consulta.DataConsulta.ToString());
                        cmdEditarConsulta.Parameters.AddWithValue("@FLAGPM", "PM");
                    } else if (consulta.Consulta.DataConsulta != default(DateTime) && consulta.Consulta.flagPM == false) {
                        cmdEditarConsulta.Parameters.AddWithValue("@DATACONSULTA", consulta.Consulta.DataConsulta.ToString());
                    }

                    cmdEditarConsulta.Parameters.AddWithValue("@IDCONSULTA", consulta.Consulta.idConsulta);

                    var teste = getGeneratedSql(cmdEditarConsulta);


                    retorno = cmdEditarConsulta.ExecuteNonQuery();


                    // ------ DADOS HISTÓRIA DA MOLÉSTIA ATUAL ------
                    if (consulta.MolestiaAtual.idMolestiaAtual != 0) {
                        MySqlCommand cmdEditarMolestiaAtual = new MySqlCommand(DALSQL.EditarMolestiaAtual(consulta.MolestiaAtual), connection);

                        if (consulta.MolestiaAtual.idPacienteMolestiaAtual != 0) {
                            cmdEditarMolestiaAtual.Parameters.AddWithValue("@IDPACIENTEMOLESTIAATUAL", consulta.MolestiaAtual.idPacienteMolestiaAtual);
                        }

                        if (consulta.MolestiaAtual.molestiaAtual != null) {
                            cmdEditarMolestiaAtual.Parameters.AddWithValue("@MOLESTIAATUAL", consulta.MolestiaAtual.molestiaAtual);
                        }
                        cmdEditarMolestiaAtual.Parameters.AddWithValue("@IDMOLESTIAATUAL", consulta.MolestiaAtual.idMolestiaAtual);
                        retorno = retorno + cmdEditarMolestiaAtual.ExecuteNonQuery();
                    } else {
                        MySqlCommand cmdHistoriaMolestiaAtual = new MySqlCommand(DALSQL.InsertHistoriaMolestiaAtual(), connection);
                        cmdHistoriaMolestiaAtual.Parameters.AddWithValue("@IDPACIENTEMOLESTIAATUAL", consulta.Paciente.idPaciente);
                        cmdHistoriaMolestiaAtual.Parameters.AddWithValue("@IDCONSULTAMOLESTIAATUAL", consulta.Consulta.idConsulta);
                        cmdHistoriaMolestiaAtual.Parameters.AddWithValue("@MOLESTIAATUAL", consulta.MolestiaAtual.molestiaAtual);

                        retorno = retorno + cmdHistoriaMolestiaAtual.ExecuteNonQuery();
                    }

                    // ------ DADOS PATOLOGICA PREGRESSA ------
                    if (consulta.PatologicaPregressa.idPatologicaPregressa != 0) {
                        MySqlCommand cmdEditarPatologicaPregressa = new MySqlCommand(DALSQL.EditarPatologicaPregressa(consulta.PatologicaPregressa), connection);

                        if (consulta.PatologicaPregressa.idPacientePatologicaPregressa != 0) {
                            cmdEditarPatologicaPregressa.Parameters.AddWithValue("@IDPACIENTEPATOLOGICAPREGRESSA", consulta.PatologicaPregressa.idPacientePatologicaPregressa);
                        }

                        if (consulta.PatologicaPregressa.patologicaPregressa != null) {
                            cmdEditarPatologicaPregressa.Parameters.AddWithValue("@PATOLOGICAPREGRESSA", consulta.PatologicaPregressa.patologicaPregressa);
                        }
                        cmdEditarPatologicaPregressa.Parameters.AddWithValue("@IDPATOLOGICAPREGRESSA", consulta.PatologicaPregressa.idPatologicaPregressa);
                        retorno = retorno + cmdEditarPatologicaPregressa.ExecuteNonQuery();
                    } else {
                        MySqlCommand cmdPatologicaPregressa = new MySqlCommand(DALSQL.InsertPatologicaPregressa(), connection);
                        cmdPatologicaPregressa.Parameters.AddWithValue("@IDPACIENTEPATOLOGICAPREGRESSA", consulta.Paciente.idPaciente);
                        cmdPatologicaPregressa.Parameters.AddWithValue("@IDCONSULTAPATOLOGICAPREGRESSA", consulta.Consulta.idConsulta);
                        cmdPatologicaPregressa.Parameters.AddWithValue("@PATOLOGICAPREGRESSA", consulta.PatologicaPregressa.patologicaPregressa);

                        retorno = retorno + cmdPatologicaPregressa.ExecuteNonQuery();
                    }

                    // ------ DADOS EXAME FISICO ------
                    if (consulta.ExameFisico.idExameFisico != 0) {
                        MySqlCommand cmdEditarExameFisico = new MySqlCommand(DALSQL.EditarExameFisico(consulta.ExameFisico), connection);

                        if (consulta.ExameFisico.idPacienteExameFisico != 0) {
                            cmdEditarExameFisico.Parameters.AddWithValue("@IDPACIENTEEXAMEFISICO", consulta.ExameFisico.idPacienteExameFisico);
                        }

                        if (consulta.ExameFisico.exameFisico != null) {
                            cmdEditarExameFisico.Parameters.AddWithValue("@EXAMEFISICO", consulta.ExameFisico.exameFisico);
                        }
                        cmdEditarExameFisico.Parameters.AddWithValue("@IDEXAMEFISICO", consulta.ExameFisico.idExameFisico);
                        retorno = retorno + cmdEditarExameFisico.ExecuteNonQuery();
                    } else {
                        MySqlCommand cmdExameFisico = new MySqlCommand(DALSQL.InsertExameFisico(), connection);
                        cmdExameFisico.Parameters.AddWithValue("@IDPACIENTEEXAMEFISICO", consulta.Paciente.idPaciente);
                        cmdExameFisico.Parameters.AddWithValue("@IDCONSULTAEXAMEFISICO", consulta.Consulta.idConsulta);
                        cmdExameFisico.Parameters.AddWithValue("@EXAMEFISICO", consulta.ExameFisico.exameFisico);

                        retorno = retorno + cmdExameFisico.ExecuteNonQuery();
                    }

                    // ------ DADOS HIPOTESE DIAGNOSTICA ------
                    if (consulta.HipoteseDiagnostica.idHipoteseDiagnostica != 0) {
                        MySqlCommand cmdEditarHipoteseDiagnostica = new MySqlCommand(DALSQL.EditarHipoteseDiagnostica(consulta.HipoteseDiagnostica), connection);

                        if (consulta.HipoteseDiagnostica.idPacienteHipoteseDiagnostica != 0) {
                            cmdEditarHipoteseDiagnostica.Parameters.AddWithValue("@IDPACIENTEHIPOTESEDIAGNOSTICA", consulta.HipoteseDiagnostica.idPacienteHipoteseDiagnostica);
                        }

                        if (consulta.HipoteseDiagnostica.hipoteseDiagnostica != null) {
                            cmdEditarHipoteseDiagnostica.Parameters.AddWithValue("@HIPOTESEDIAGNOSTICA", consulta.HipoteseDiagnostica.hipoteseDiagnostica);
                        }
                        cmdEditarHipoteseDiagnostica.Parameters.AddWithValue("@IDHIPOTESEDIAGNOSTICA", consulta.HipoteseDiagnostica.idHipoteseDiagnostica);
                        retorno = retorno + cmdEditarHipoteseDiagnostica.ExecuteNonQuery();
                    } else {
                        MySqlCommand cmdHipoteseDiagnostica = new MySqlCommand(DALSQL.InsertHipoteseDiagnostica(), connection);
                        cmdHipoteseDiagnostica.Parameters.AddWithValue("@IDPACIENTEHIPOTESEDIAGNOSTICA", consulta.Paciente.idPaciente);
                        cmdHipoteseDiagnostica.Parameters.AddWithValue("@IDCONSULTAHIPOTESEDIAGNOSTICA", consulta.Consulta.idConsulta);
                        cmdHipoteseDiagnostica.Parameters.AddWithValue("@HIPOTESEDIAGNOSTICA", consulta.HipoteseDiagnostica.hipoteseDiagnostica);

                        retorno = retorno + cmdHipoteseDiagnostica.ExecuteNonQuery();
                    }

                    // ------ DADOS CONDUTA ------
                    if (consulta.Conduta.idConduta != 0) {
                        MySqlCommand cmdEditarConduta = new MySqlCommand(DALSQL.EditarConduta(consulta.Conduta), connection);

                        if (consulta.Conduta.idPacienteConduta != 0) {
                            cmdEditarConduta.Parameters.AddWithValue("@IDPACIENTECONDUTA", consulta.Conduta.idPacienteConduta);
                        }

                        if (consulta.Conduta.conduta != null) {
                            cmdEditarConduta.Parameters.AddWithValue("@CONDUTA", consulta.Conduta.conduta);
                        }
                        cmdEditarConduta.Parameters.AddWithValue("@IDCONDUTA", consulta.Conduta.idConduta);
                        retorno = retorno + cmdEditarConduta.ExecuteNonQuery();
                    } else {
                        MySqlCommand cmdConduta = new MySqlCommand(DALSQL.InsertConduta(), connection);
                        cmdConduta.Parameters.AddWithValue("@IDPACIENTECONDUTA", consulta.Paciente.idPaciente);
                        cmdConduta.Parameters.AddWithValue("@IDCONSULTACONDUTA", consulta.Consulta.idConsulta);
                        cmdConduta.Parameters.AddWithValue("@CONDUTA", consulta.Conduta.conduta);

                        retorno = retorno + cmdConduta.ExecuteNonQuery();
                    }

                    // ------ INSERT PEDIDO DE EXAME ------
                    //if (consulta.ExamePedido != null) {

                    // BUSCAR DO BANCO, OS PEDIDOS DE EXAMES
                    MySqlCommand cmdListExamePedido = new MySqlCommand(DALSQL.ConsultaExamePedido(), connection);
                    cmdListExamePedido.Parameters.AddWithValue("@IDCONSULTAEXAMEPEDIDO", consulta.Consulta.idConsulta);

                    MySqlDataReader readerListExamePedido = cmdListExamePedido.ExecuteReader();
                    List<DadosExamePedido> listExamPedido = new List<DadosExamePedido>();

                    if (readerListExamePedido.HasRows) {
                        while (readerListExamePedido.Read()) {
                            DadosExamePedido examePedido = new DadosExamePedido();
                            examePedido.idExamePedido = readerListExamePedido.GetInt32(0);
                            examePedido.idBaseNomeExameExamePedido = readerListExamePedido.GetInt32(1);
                            examePedido.idPacienteExamePedido = readerListExamePedido.GetInt32(2);
                            examePedido.idConsultaExamePedido = readerListExamePedido.GetInt32(3);
                            listExamPedido.Add(examePedido);
                        }
                        readerListExamePedido.NextResult();
                    } else {
                        readerListExamePedido.Close();
                    }
                    readerListExamePedido.Close();

                    List<String> listExamePedido = new List<String>();

                    if (consulta.ExamePedido != null) {
                        foreach (var idExamePedido in consulta.ExamePedido.Split(',')) {
                            if (idExamePedido != "") listExamePedido.Add(idExamePedido);
                        }
                    }

                    List<String> listaExamePedidoInsert = new List<String>();
                    List<String> listaExamePedidoDelete = new List<String>();

                    foreach (var idExamePedido in listExamePedido) {
                        var resultado = listExamPedido.Find(x => x.idBaseNomeExameExamePedido == Convert.ToInt32(idExamePedido));
                        if (resultado == null) listaExamePedidoInsert.Add(idExamePedido);
                    }

                    foreach (var idExamePedidoBanco in listExamPedido) {
                        var resultado = listExamePedido.Find(x => Convert.ToInt32(x) == idExamePedidoBanco.idBaseNomeExameExamePedido);
                        if (resultado == null) listaExamePedidoDelete.Add(idExamePedidoBanco.idBaseNomeExameExamePedido.ToString());
                    }


                    foreach (var examePedidoInsert in listaExamePedidoInsert) {
                        MySqlCommand cmdExamePedido = new MySqlCommand(DALSQL.InsertExamePedido(), connection);
                        cmdExamePedido.Parameters.AddWithValue("@IDBASENOMEEXAMEEXAMEPEDIDO", Convert.ToInt32(examePedidoInsert));
                        cmdExamePedido.Parameters.AddWithValue("@IDPACIENTEEXAMEPEDIDO", consulta.Paciente.idPaciente);
                        cmdExamePedido.Parameters.AddWithValue("@IDCONSULTAEXAMEPEDIDO", consulta.Consulta.idConsulta);

                        retorno = retorno + cmdExamePedido.ExecuteNonQuery();
                    }

                    foreach (var examePedidoInsert in listaExamePedidoDelete)  {
                        MySqlCommand cmdExamePedido = new MySqlCommand(DALSQL.DeleteExamePedido(), connection);
                        cmdExamePedido.Parameters.AddWithValue("@IDBASENOMEEXAMEEXAMEPEDIDO", Convert.ToInt32(examePedidoInsert));

                        retorno = retorno + cmdExamePedido.ExecuteNonQuery();
                    }

                    //}



                    // ------ INSERT MEDICAMENTO ------
                    //if (consulta.Medicamento != null) {

                    // BUSCAR DO BANCO, OS MEDICAMENTOS
                    MySqlCommand cmdListMedicamento = new MySqlCommand(DALSQL.ConsultaMedicamentoPrescrito(), connection);
                    cmdListMedicamento.Parameters.AddWithValue("@IDCONSULTA", consulta.Consulta.idConsulta);

                    MySqlDataReader readerListMedicamento = cmdListMedicamento.ExecuteReader();
                    List<DadosMedicamentoConsulta> listMedicamento = new List<DadosMedicamentoConsulta>();

                    if (readerListMedicamento.HasRows) {
                        while (readerListMedicamento.Read()) {
                            DadosMedicamentoConsulta medicamentoConsulta = new DadosMedicamentoConsulta();
                            medicamentoConsulta.idConsulta_Medicamento = readerListMedicamento.GetInt32(0);
                            medicamentoConsulta.idConsultaConsulta_Medicamento = readerListMedicamento.GetInt32(1);
                            medicamentoConsulta.idMedicamentoConsulta_Medicamento = readerListMedicamento.GetInt32(2);
                            listMedicamento.Add(medicamentoConsulta);
                        }
                        readerListMedicamento.NextResult();
                    }
                    readerListMedicamento.Close();

                    List<String> listMedicamentoConsulta = new List<String>();

                    if (consulta.Medicamento != null) {
                        foreach (var idMedicamento in consulta.Medicamento.Split(',')) {
                            if (idMedicamento != "") listMedicamentoConsulta.Add(idMedicamento);
                        }
                    }

                    List<String> listaMedicamentoInsert = new List<String>();
                    List<String> listaMedicamentoDelete = new List<String>();

                    foreach (var idMedicamento in listMedicamentoConsulta) {
                        var resultado = listMedicamento.Find(x => x.idMedicamentoConsulta_Medicamento == Convert.ToInt32(idMedicamento));
                        if (resultado == null) listaMedicamentoInsert.Add(idMedicamento);
                    }

                    foreach (var medicamento in listMedicamento) {
                        var resultado = listMedicamentoConsulta.Find(x => Convert.ToInt32(x) == medicamento.idMedicamentoConsulta_Medicamento);
                        if (resultado == null) listaMedicamentoDelete.Add(medicamento.idMedicamentoConsulta_Medicamento.ToString());
                    }


                    foreach (var medicamentoInsert in listaMedicamentoInsert) {
                        MySqlCommand cmdMedicamentoConsultaInsert = new MySqlCommand(DALSQL.InsertMedicamentoConsulta(), connection);
                        cmdMedicamentoConsultaInsert.Parameters.AddWithValue("@IDCONSULTACONSULTA_MEDICAMENTO", consulta.Consulta.idConsulta);
                        cmdMedicamentoConsultaInsert.Parameters.AddWithValue("@IDMEDICAMENTOCONSULTA_MEDICAMENTO", Convert.ToInt32(medicamentoInsert));

                        retorno = retorno + cmdMedicamentoConsultaInsert.ExecuteNonQuery();
                    }

                    foreach (var medicamentoDelete in listaMedicamentoDelete) {
                        MySqlCommand cmdMedicamentoConsultaDelete = new MySqlCommand(DALSQL.DeleteMedicamentoConsulta(), connection);
                        cmdMedicamentoConsultaDelete.Parameters.AddWithValue("@IDCONSULTACONSULTA_MEDICAMENTO", consulta.Consulta.idConsulta);
                        cmdMedicamentoConsultaDelete.Parameters.AddWithValue("@IDMEDICAMENTOCONSULTA_MEDICAMENTO", Convert.ToInt32(medicamentoDelete));

                        retorno = retorno + cmdMedicamentoConsultaDelete.ExecuteNonQuery();
                    }

                    //}
                    connection.Close();

                    if (retorno > 0) {
                        scope.Complete();
                        return -1;
                    } else {
                        scope.Dispose();
                        return 3;
                    }
                } catch (Exception ex) {
                    scope.Dispose();
                    throw ex;
                }
            }
        }

        public CadastrarAusenciaBancoModel ConsultarAusencia(DateTime dataInicial) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new ConsultaDALSQL();
                MySqlCommand cmdAusencia = new MySqlCommand(DALSQL.ConsultarAusencia(), connection);
                cmdAusencia.Parameters.AddWithValue("@DATAINICIAL", dataInicial.ToShortDateString());

                var teste = getGeneratedSql(cmdAusencia);

                MySqlDataReader reader = cmdAusencia.ExecuteReader();
                CadastrarAusenciaBancoModel ausencia = new CadastrarAusenciaBancoModel();

                if (reader.HasRows) {
                    while (reader.Read()) {
                        ausencia.idAusencia = reader.GetInt32(0);
                        ausencia.DataFinal = reader.GetDateTime(1);
                        ausencia.DataFinal = reader.GetDateTime(2);
                        ausencia.Seis = reader.GetInt32(3);
                        ausencia.SeisMeia = reader.GetInt32(4);
                        ausencia.Sete = reader.GetInt32(5);
                        ausencia.SeteMeia = reader.GetInt32(6);
                        ausencia.Oito = reader.GetInt32(7);
                        ausencia.OitoMeia = reader.GetInt32(8);
                        ausencia.Nove = reader.GetInt32(9);
                        ausencia.NoveMeia = reader.GetInt32(10);
                        ausencia.Dez = reader.GetInt32(11);
                        ausencia.DezMeia = reader.GetInt32(12);
                        ausencia.Onze = reader.GetInt32(13);
                        ausencia.OnzeMeia = reader.GetInt32(14);
                        ausencia.Doze = reader.GetInt32(15);
                        ausencia.DozeMeia = reader.GetInt32(16);
                        ausencia.Treze = reader.GetInt32(17);
                        ausencia.TrezeMeia = reader.GetInt32(18);
                        ausencia.Quatorze = reader.GetInt32(19);
                        ausencia.QuatorzeMeia = reader.GetInt32(20);
                        ausencia.Quinze = reader.GetInt32(21);
                        ausencia.QuinzeMeia = reader.GetInt32(22);
                        ausencia.Dezesseis = reader.GetInt32(23);
                        ausencia.DezesseisMeia = reader.GetInt32(24);
                        ausencia.Dezessete = reader.GetInt32(25);
                        ausencia.DezesseteMeia = reader.GetInt32(26);
                        ausencia.Dezoito = reader.GetInt32(27);
                        ausencia.DezoitoMeia = reader.GetInt32(28);
                    }
                    reader.Close();
                    connection.Close();
                    return ausencia;
                } else {
                    reader.Close();
                    connection.Close();
                    return null;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public IniciarAtendimentoModel CarregarDadosAtendimento(int idConsulta) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new ConsultaDALSQL();

                // ------ DADOS PESSOAIS, PACIENTE e CONSULTA ------
                MySqlCommand cmdDadosPessoais = new MySqlCommand(DALSQL.DadosPessoaisPaciente(), connection);
                cmdDadosPessoais.Parameters.AddWithValue("@IDCONSULTA", idConsulta);
                MySqlDataReader readerDadosPessoais = cmdDadosPessoais.ExecuteReader();

                IniciarAtendimentoModel iniciarAtendimento = new IniciarAtendimentoModel();
                iniciarAtendimento.Pessoa = new DadosPessoais();
                iniciarAtendimento.Paciente = new Models.Consulta.IniciarAtendimento.DadosPaciente();
                iniciarAtendimento.Consulta = new Models.Consulta.IniciarAtendimento.DadosConsulta();

                if (readerDadosPessoais.HasRows) {
                    while (readerDadosPessoais.Read()) {
                        iniciarAtendimento.Pessoa.IdPessoa = readerDadosPessoais.GetInt32(0);
                        iniciarAtendimento.Pessoa.Nome = readerDadosPessoais.GetString(1);
                        iniciarAtendimento.Pessoa.CPF = readerDadosPessoais.GetString(2);
                        iniciarAtendimento.Pessoa.RG = readerDadosPessoais.GetString(3);
                        iniciarAtendimento.Pessoa.Sexo = readerDadosPessoais.GetString(4);
                        iniciarAtendimento.Pessoa.DataNascimento = readerDadosPessoais.GetDateTime(5);
                        iniciarAtendimento.Pessoa.Logradouro = readerDadosPessoais.GetString(6);
                        iniciarAtendimento.Pessoa.Numero = readerDadosPessoais.GetInt32(7);
                        iniciarAtendimento.Pessoa.Bairro = readerDadosPessoais.GetString(8);
                        iniciarAtendimento.Pessoa.Cidade = readerDadosPessoais.GetString(9);
                        iniciarAtendimento.Pessoa.Uf = readerDadosPessoais.GetString(10);
                        iniciarAtendimento.Pessoa.TelefoneCelular = readerDadosPessoais.GetString(11);
                        iniciarAtendimento.Pessoa.Email = readerDadosPessoais.GetString(12);

                        iniciarAtendimento.Paciente.idPaciente = readerDadosPessoais.GetInt32(13);

                        iniciarAtendimento.Consulta.idConsulta = readerDadosPessoais.GetInt32(14);
                        iniciarAtendimento.Consulta.idPacienteConsulta = readerDadosPessoais.GetInt32(15);
                        iniciarAtendimento.Consulta.dataConsulta = readerDadosPessoais.GetDateTime(16);
                        iniciarAtendimento.Consulta.finalizada = readerDadosPessoais.GetInt32(17);
                    }
                    readerDadosPessoais.NextResult();
                } else {
                    readerDadosPessoais.Close();
                }
                readerDadosPessoais.Close();

                // ------ DADOS CONSULTA LISTA ------
                MySqlCommand cmdConsultaLista = new MySqlCommand(DALSQL.ConsultaLista(), connection);
                cmdConsultaLista.Parameters.AddWithValue("@IDPACIENTECONSULTA", iniciarAtendimento.Paciente.idPaciente);

                MySqlDataReader readerConsultaLista = cmdConsultaLista.ExecuteReader();
                iniciarAtendimento.ConsultaLista = new List<Models.Consulta.IniciarAtendimento.DadosConsulta>();

                if (readerConsultaLista.HasRows) {
                    while (readerConsultaLista.Read()) {
                        Models.Consulta.IniciarAtendimento.DadosConsulta consulta = new Models.Consulta.IniciarAtendimento.DadosConsulta();

                        consulta.idConsulta = readerConsultaLista.GetInt32(0);
                        consulta.idPacienteConsulta = readerConsultaLista.GetInt32(1);
                        consulta.dataConsulta = readerConsultaLista.GetDateTime(2);
                        consulta.finalizada = readerConsultaLista.GetInt32(3);

                        iniciarAtendimento.ConsultaLista.Add(consulta);
                    }
                    readerConsultaLista.NextResult();
                } else {
                    readerConsultaLista.Close();
                }
                readerConsultaLista.Close();

                // ------ DADOS EXAME LABORATORIAL ------
                MySqlCommand cmdListExameLaboratorial = new MySqlCommand(DALSQL.ConsultaExameLaboratorial(), connection);
                cmdListExameLaboratorial.Parameters.AddWithValue("@IDPACIENTEEXAMELABORATORIAL", iniciarAtendimento.Paciente.idPaciente);

                MySqlDataReader readerListExameLaboratorial = cmdListExameLaboratorial.ExecuteReader();
                iniciarAtendimento.ExameLaboratorialLista = new List<Models.Consulta.IniciarAtendimento.DadosExameLaboratorial>();

                if (readerListExameLaboratorial.HasRows) {
                    while (readerListExameLaboratorial.Read()) {
                        Models.Consulta.IniciarAtendimento.DadosExameLaboratorial exameLaboratorial = new Models.Consulta.IniciarAtendimento.DadosExameLaboratorial();

                        exameLaboratorial.idExameLaboratorial = readerListExameLaboratorial.GetInt32(0);
                        exameLaboratorial.idPacienteExameLaboratorial = readerListExameLaboratorial.GetInt32(1);
                        exameLaboratorial.idConsultaExameLaboratorial = readerListExameLaboratorial.GetInt32(2);
                        exameLaboratorial.tamanhoArquivo = readerListExameLaboratorial.GetInt32(4);

                        exameLaboratorial.exameLaboratorial = new byte[exameLaboratorial.tamanhoArquivo];

                        readerListExameLaboratorial.GetBytes(3, 0, exameLaboratorial.exameLaboratorial, 0, exameLaboratorial.tamanhoArquivo);

                        iniciarAtendimento.ExameLaboratorialLista.Add(exameLaboratorial);
                    }
                    readerListExameLaboratorial.NextResult();
                } else {
                    readerListExameLaboratorial.Close();
                }
                readerListExameLaboratorial.Close();

                connection.Close();
                return iniciarAtendimento;

            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<Models.Consulta.IniciarAtendimento.DadosConsulta> ConsultaLista(int idPaciente) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new ConsultaDALSQL();
                
                // ------ DADOS CONSULTA LISTA ------
                MySqlCommand cmdConsultaLista = new MySqlCommand(DALSQL.ConsultaLista(), connection);
                cmdConsultaLista.Parameters.AddWithValue("@IDPACIENTECONSULTA", idPaciente);

                MySqlDataReader readerConsultaLista = cmdConsultaLista.ExecuteReader();
                List<Models.Consulta.IniciarAtendimento.DadosConsulta> consultaLista = new List<Models.Consulta.IniciarAtendimento.DadosConsulta>();

                if (readerConsultaLista.HasRows) {
                    while (readerConsultaLista.Read()) {
                        Models.Consulta.IniciarAtendimento.DadosConsulta consulta = new Models.Consulta.IniciarAtendimento.DadosConsulta();

                        consulta.idConsulta = readerConsultaLista.GetInt32(0);
                        consulta.idPacienteConsulta = readerConsultaLista.GetInt32(1);
                        consulta.dataConsulta = readerConsultaLista.GetDateTime(2);
                        consulta.finalizada = readerConsultaLista.GetInt32(3);

                        consultaLista.Add(consulta);
                    }
                    readerConsultaLista.NextResult();
                } else {
                    readerConsultaLista.Close();
                    connection.Close();
                }

                readerConsultaLista.Close();
                connection.Close();
                return consultaLista;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<Models.Consulta.IniciarAtendimento.DadosExameLaboratorial> ExameLaboratorialLista(int idPaciente) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new ConsultaDALSQL();

                // ------ DADOS EXAME LABORATORIAL ------
                MySqlCommand cmdListExameLaboratorial = new MySqlCommand(DALSQL.ConsultaExameLaboratorial(), connection);
                cmdListExameLaboratorial.Parameters.AddWithValue("@IDPACIENTEEXAMELABORATORIAL", idPaciente);

                MySqlDataReader readerListExameLaboratorial = cmdListExameLaboratorial.ExecuteReader();
                List<Models.Consulta.IniciarAtendimento.DadosExameLaboratorial> exameLaboratorialLista = new List<Models.Consulta.IniciarAtendimento.DadosExameLaboratorial>();

                if (readerListExameLaboratorial.HasRows) {
                    while (readerListExameLaboratorial.Read()) {
                        Models.Consulta.IniciarAtendimento.DadosExameLaboratorial exameLaboratorial = new Models.Consulta.IniciarAtendimento.DadosExameLaboratorial();

                        exameLaboratorial.idExameLaboratorial = readerListExameLaboratorial.GetInt32(0);
                        exameLaboratorial.idPacienteExameLaboratorial = readerListExameLaboratorial.GetInt32(1);
                        exameLaboratorial.idConsultaExameLaboratorial = readerListExameLaboratorial.GetInt32(2);
                        exameLaboratorial.tamanhoArquivo = readerListExameLaboratorial.GetInt32(4);

                        exameLaboratorial.exameLaboratorial = new byte[exameLaboratorial.tamanhoArquivo];

                        readerListExameLaboratorial.GetBytes(3, 0, exameLaboratorial.exameLaboratorial, 0, exameLaboratorial.tamanhoArquivo);

                        exameLaboratorialLista.Add(exameLaboratorial);
                    }
                    readerListExameLaboratorial.NextResult();
                } else {
                    readerListExameLaboratorial.Close();
                    connection.Close();
                }
                readerListExameLaboratorial.Close();

                connection.Close();
                return exameLaboratorialLista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.Consulta.EditarConsultaModel.DadosExameLaboratorial> EditarExameLaboratorialLista(int idPaciente) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new ConsultaDALSQL();

                // ------ DADOS EXAME LABORATORIAL ------
                MySqlCommand cmdListExameLaboratorial = new MySqlCommand(DALSQL.ConsultaExameLaboratorial(), connection);
                cmdListExameLaboratorial.Parameters.AddWithValue("@IDPACIENTEEXAMELABORATORIAL", idPaciente);

                MySqlDataReader readerListExameLaboratorial = cmdListExameLaboratorial.ExecuteReader();
                List<Models.Consulta.EditarConsultaModel.DadosExameLaboratorial> exameLaboratorialLista = new List<Models.Consulta.EditarConsultaModel.DadosExameLaboratorial>();

                if (readerListExameLaboratorial.HasRows)
                {
                    while (readerListExameLaboratorial.Read())
                    {
                        Models.Consulta.EditarConsultaModel.DadosExameLaboratorial exameLaboratorial = new Models.Consulta.EditarConsultaModel.DadosExameLaboratorial();

                        exameLaboratorial.idExameLaboratorial = readerListExameLaboratorial.GetInt32(0);
                        exameLaboratorial.idPacienteExameLaboratorial = readerListExameLaboratorial.GetInt32(1);
                        exameLaboratorial.idConsultaExameLaboratorial = readerListExameLaboratorial.GetInt32(2);
                        exameLaboratorial.tamanhoArquivo = readerListExameLaboratorial.GetInt32(4);

                        exameLaboratorial.exameLaboratorial = new byte[exameLaboratorial.tamanhoArquivo];

                        readerListExameLaboratorial.GetBytes(3, 0, exameLaboratorial.exameLaboratorial, 0, exameLaboratorial.tamanhoArquivo);

                        exameLaboratorialLista.Add(exameLaboratorial);
                    }
                    readerListExameLaboratorial.NextResult();
                } else {
                    readerListExameLaboratorial.Close();
                    connection.Close();
                }
                readerListExameLaboratorial.Close();

                connection.Close();
                return exameLaboratorialLista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int FinalizarAtendimento(IniciarAtendimentoModel model) {
            using (TransactionScope scope = new TransactionScope()) {
                try {
                    MySqlConnection connection = new MySqlConnection(getStringConnection());
                    connection.Open();

                    var DALSQL = new ConsultaDALSQL();
                    var retornoAtendimento = 0;

                    // ------ INSERT HISTORIA DA MOLESTIA ATUAL ------
                    if (model.MolestiaAtual != null && model.MolestiaAtual.molestiaAtual != null) {
                        MySqlCommand cmdHistoriaMolestiaAtual = new MySqlCommand(DALSQL.InsertHistoriaMolestiaAtual(), connection);
                        cmdHistoriaMolestiaAtual.Parameters.AddWithValue("@IDPACIENTEMOLESTIAATUAL", model.Paciente.idPaciente);
                        cmdHistoriaMolestiaAtual.Parameters.AddWithValue("@IDCONSULTAMOLESTIAATUAL", model.Consulta.idConsulta);
                        cmdHistoriaMolestiaAtual.Parameters.AddWithValue("@MOLESTIAATUAL", model.MolestiaAtual.molestiaAtual);

                        retornoAtendimento = cmdHistoriaMolestiaAtual.ExecuteNonQuery();
                    }

                    // ------ INSERT HISTORIA PATOLÓGICA PREGRESSA ------
                    if (model.PatologicaPregressa != null && model.PatologicaPregressa.patologicaPregressa != null) {
                        MySqlCommand cmdPatologicaPregressa = new MySqlCommand(DALSQL.InsertPatologicaPregressa(), connection);
                        cmdPatologicaPregressa.Parameters.AddWithValue("@IDPACIENTEPATOLOGICAPREGRESSA", model.Paciente.idPaciente);
                        cmdPatologicaPregressa.Parameters.AddWithValue("@IDCONSULTAPATOLOGICAPREGRESSA", model.Consulta.idConsulta);
                        cmdPatologicaPregressa.Parameters.AddWithValue("@PATOLOGICAPREGRESSA", model.PatologicaPregressa.patologicaPregressa);

                        retornoAtendimento = retornoAtendimento + cmdPatologicaPregressa.ExecuteNonQuery();
                    }

                    // ------ INSERT EXAME FÍSICO ------
                    if (model.ExameFisico != null && model.ExameFisico.exameFisico != null) {
                        MySqlCommand cmdExameFisico = new MySqlCommand(DALSQL.InsertExameFisico(), connection);
                        cmdExameFisico.Parameters.AddWithValue("@IDPACIENTEEXAMEFISICO", model.Paciente.idPaciente);
                        cmdExameFisico.Parameters.AddWithValue("@IDCONSULTAEXAMEFISICO", model.Consulta.idConsulta);
                        cmdExameFisico.Parameters.AddWithValue("@EXAMEFISICO", model.ExameFisico.exameFisico);

                        retornoAtendimento = retornoAtendimento + cmdExameFisico.ExecuteNonQuery();
                    }

                    // ------ INSERT HIPOTESE DIAGNOSTICA ------
                    if (model.HipoteseDiagnostica != null && model.HipoteseDiagnostica.hipoteseDiagnostica != null) {
                        MySqlCommand cmdHipoteseDiagnostica = new MySqlCommand(DALSQL.InsertHipoteseDiagnostica(), connection);
                        cmdHipoteseDiagnostica.Parameters.AddWithValue("@IDPACIENTEHIPOTESEDIAGNOSTICA", model.Paciente.idPaciente);
                        cmdHipoteseDiagnostica.Parameters.AddWithValue("@IDCONSULTAHIPOTESEDIAGNOSTICA", model.Consulta.idConsulta);
                        cmdHipoteseDiagnostica.Parameters.AddWithValue("@HIPOTESEDIAGNOSTICA", model.HipoteseDiagnostica.hipoteseDiagnostica);

                        retornoAtendimento = retornoAtendimento + cmdHipoteseDiagnostica.ExecuteNonQuery();
                    }

                    // ------ INSERT CONDUTA ------
                    if (model.Conduta != null && model.Conduta.conduta != null) {
                        MySqlCommand cmdConduta = new MySqlCommand(DALSQL.InsertConduta(), connection);
                        cmdConduta.Parameters.AddWithValue("@IDPACIENTECONDUTA", model.Paciente.idPaciente);
                        cmdConduta.Parameters.AddWithValue("@IDCONSULTACONDUTA", model.Consulta.idConsulta);
                        cmdConduta.Parameters.AddWithValue("@CONDUTA", model.Conduta.conduta);

                        retornoAtendimento = retornoAtendimento + cmdConduta.ExecuteNonQuery();
                    }

                    // ------ INSERT PEDIDO DE EXAME ------
                    if (model.ExamePedido != null) { 
                        var listaExamePedido = model.ExamePedido.Split(',');
                        foreach (var idExamePedido in listaExamePedido) {
                            MySqlCommand cmdExamePedido = new MySqlCommand(DALSQL.InsertExamePedido(), connection);
                            cmdExamePedido.Parameters.AddWithValue("@IDBASENOMEEXAMEEXAMEPEDIDO", Convert.ToInt32(idExamePedido));
                            cmdExamePedido.Parameters.AddWithValue("@IDPACIENTEEXAMEPEDIDO", model.Paciente.idPaciente);
                            cmdExamePedido.Parameters.AddWithValue("@IDCONSULTAEXAMEPEDIDO", model.Consulta.idConsulta);

                            retornoAtendimento = retornoAtendimento + cmdExamePedido.ExecuteNonQuery();
                        }
                    }

                    // ------ INSERT PEDIDO DE EXAME ------
                    if (model.Medicamento != null) {
                        var listaMedicamento = model.Medicamento.Split(',');
                        foreach (var idMedicamento in listaMedicamento) {
                            MySqlCommand cmdExamePedido = new MySqlCommand(DALSQL.InsertMedicamentoConsulta(), connection);
                            cmdExamePedido.Parameters.AddWithValue("@IDCONSULTACONSULTA_MEDICAMENTO", model.Consulta.idConsulta);
                            cmdExamePedido.Parameters.AddWithValue("@IDMEDICAMENTOCONSULTA_MEDICAMENTO", Convert.ToInt32(idMedicamento));

                            retornoAtendimento = retornoAtendimento + cmdExamePedido.ExecuteNonQuery();
                        }
                    }

                    // ------ UPDATE CONSULTA STATUS ------
                    MySqlCommand cmdConsultaStatus = new MySqlCommand(DALSQL.UpdateConsultaStatus(), connection);
                    cmdConsultaStatus.Parameters.AddWithValue("@CONSULTAFINALIZADA", 1);
                    cmdConsultaStatus.Parameters.AddWithValue("@IDCONSULTA", model.Consulta.idConsulta);

                    retornoAtendimento = retornoAtendimento + cmdConsultaStatus.ExecuteNonQuery();

                    connection.Close();
                    scope.Complete();
                    return retornoAtendimento;
                } catch (Exception ex) {
                    scope.Dispose();
                    throw ex;
                }
            }
        }

        public List<BaseNomeExame> GetBaseNomeExame() {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new ConsultaDALSQL();

                // ------ BASE NOME EXAME ------
                MySqlCommand cmdListBaseNomeExame = new MySqlCommand(DALSQL.GetBaseNomeExame(), connection);

                MySqlDataReader readerListBaseNomeExame = cmdListBaseNomeExame.ExecuteReader();
                List<BaseNomeExame> listBaseNomeExame = new List<BaseNomeExame>();

                if (readerListBaseNomeExame.HasRows) {
                    while (readerListBaseNomeExame.Read()) {
                        BaseNomeExame baseNomeExame = new BaseNomeExame();

                        baseNomeExame.idBaseNomeExame = readerListBaseNomeExame.GetInt32(0);
                        baseNomeExame.baseNomeExame = readerListBaseNomeExame.GetString(1);

                        listBaseNomeExame.Add(baseNomeExame);
                    }
                    readerListBaseNomeExame.NextResult();
                } else {
                    readerListBaseNomeExame.Close();
                    connection.Close();
                }
                readerListBaseNomeExame.Close();

                connection.Close();
                return listBaseNomeExame;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<GetMedicamento> GetMedicamento() {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new ConsultaDALSQL();

                // ------ MEDICAMENTOS ------
                MySqlCommand cmdListBaseNomeExame = new MySqlCommand(DALSQL.GetMedicamento(), connection);

                MySqlDataReader readerListMedicamento = cmdListBaseNomeExame.ExecuteReader();
                List<GetMedicamento> listMedicamento = new List<GetMedicamento>();

                if (readerListMedicamento.HasRows) {
                    while (readerListMedicamento.Read()) {
                        GetMedicamento medicamento = new GetMedicamento();

                        medicamento.idMedicamento = readerListMedicamento.GetInt32(0);
                        medicamento.nomeGenerico = readerListMedicamento.GetString(1);
                        medicamento.nomeFabrica = readerListMedicamento.GetString(2);
                        medicamento.fabricante = readerListMedicamento.GetString(3);

                        listMedicamento.Add(medicamento);
                    }
                    readerListMedicamento.NextResult();
                } else {
                    readerListMedicamento.Close();
                    connection.Close();
                }
                readerListMedicamento.Close();

                connection.Close();
                return listMedicamento;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int CancelarConsulta(int idConsulta) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new ConsultaDALSQL();

                MySqlCommand cmdCancelarConsulta = new MySqlCommand(DALSQL.CancelarConsulta(), connection);
                cmdCancelarConsulta.Parameters.AddWithValue("@IDCONSULTA", idConsulta);
                
                var retorno = cmdCancelarConsulta.ExecuteNonQuery();

                if (retorno > 0) {
                    return retorno;
                } else {
                    return -1;
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