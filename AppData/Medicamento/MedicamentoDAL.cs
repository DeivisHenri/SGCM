using MySql.Data.MySqlClient;
using SGCM.Models.Medicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using X.PagedList;

namespace SGCM.AppData.Medicamento {

    public class MedicamentoDAL : SGCMContext {

        public int CadastrarMedicamento(CadastrarMedicamentoModel model) {
            using (TransactionScope scope = new TransactionScope()) {
                try {
                    var DALSQL = new MedicamentoDALSQL();
                    var retorno = 0;

                    using (MySqlConnection connection = new MySqlConnection(getStringConnection())) {
                        connection.Open();

                        MySqlCommand cmdCadastrarMedicamento = new MySqlCommand(DALSQL.CadastrarMedicamento(), connection);

                        cmdCadastrarMedicamento.Parameters.AddWithValue("@NOMEGENERICO", model.nomeGenerico);
                        cmdCadastrarMedicamento.Parameters.AddWithValue("@NOMEFABRICA", model.nomeFrabica);
                        cmdCadastrarMedicamento.Parameters.AddWithValue("@FABRICANTE", model.fabricante);

                        retorno = cmdCadastrarMedicamento.ExecuteNonQuery();

                        if (retorno == 1) {
                            scope.Complete();
                            return retorno;
                        } else {
                            throw new Exception();
                        }
                    }
                } catch (Exception ex) {
                    scope.Dispose();
                    throw ex;
                }
            }
        }

        public List<ListaConsultaMedicamentoModel> ConsultarMedicamento(int sort, string psqNomeGenerico, string psqNomeFabrica, string psqFabricante) {
            try {
                var DALSQL = new MedicamentoDALSQL();
                List<ListaConsultaMedicamentoModel> listMedicamento = new List<ListaConsultaMedicamentoModel>();

                using (MySqlConnection connection = new MySqlConnection(getStringConnection())) {
                    connection.Open();

                    MySqlCommand cmdConsultaMedicamento = new MySqlCommand(DALSQL.ConsultarMedicamento(sort, psqNomeGenerico, psqNomeFabrica, psqFabricante), connection);

                    cmdConsultaMedicamento.Parameters.AddWithValue("@NOMEGENERICO", "%" + psqNomeGenerico + "%");
                    cmdConsultaMedicamento.Parameters.AddWithValue("@NOMEFABRICA", "%" + psqNomeFabrica + "%");
                    cmdConsultaMedicamento.Parameters.AddWithValue("@FABRICANTE", "%" + psqFabricante + "%");

                    MySqlDataReader reader = cmdConsultaMedicamento.ExecuteReader();

                    if (reader.HasRows) {
                        while (reader.Read()) {
                            ListaConsultaMedicamentoModel medicamento = new ListaConsultaMedicamentoModel();

                            medicamento.idMedicamento = reader.GetInt32(0);
                            medicamento.nomeGenerico = reader.GetString(1);
                            medicamento.nomeFrabica = reader.GetString(2);
                            medicamento.fabricante = reader.GetString(3);

                            listMedicamento.Add(medicamento);
                        }
                        reader.NextResult();
                    } else {
                        reader.Close();
                        connection.Close();
                        return null;
                    }
                    reader.Close();
                    connection.Close();
                    return listMedicamento;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public EditarMedicamentoModel ConsultarMedicamentoID(int idMedicamento) {
            try {
                var DALSQL = new MedicamentoDALSQL();

                using (MySqlConnection connection = new MySqlConnection(getStringConnection())) {
                    connection.Open();

                    MySqlCommand cmdEditarMedicamento = new MySqlCommand(DALSQL.ConsultarMedicamentoID(), connection);
                    cmdEditarMedicamento.Parameters.AddWithValue("@IDMEDICAMENTO", idMedicamento);

                    MySqlDataReader reader = cmdEditarMedicamento.ExecuteReader();

                    EditarMedicamentoModel medicamento = new EditarMedicamentoModel();

                    if (reader.HasRows) {
                        while (reader.Read()) {

                            medicamento.idMedicamento = reader.GetInt32(0);
                            medicamento.nomeGenerico = reader.GetString(1);
                            medicamento.nomeFrabica = reader.GetString(2);
                            medicamento.fabricante = reader.GetString(3);
                        }
                        reader.NextResult();
                    } else {
                        reader.Close();
                        connection.Close();
                        return null;
                    }
                    reader.Close();
                    connection.Close();
                    return medicamento;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int EditarMedicamento(EditarMedicamentoModel model) {
            using (TransactionScope scope = new TransactionScope()) {
                try {
                    var DALSQL = new MedicamentoDALSQL();
                    var retorno = 0;

                    using (MySqlConnection connection = new MySqlConnection(getStringConnection())) {
                        connection.Open();

                        MySqlCommand cmdEditarMedicamento = new MySqlCommand(DALSQL.EditarMedicamento(), connection);

                        cmdEditarMedicamento.Parameters.AddWithValue("@IDMEDICAMENTO", model.idMedicamento);
                        cmdEditarMedicamento.Parameters.AddWithValue("@NOMEGENERICO", model.nomeGenerico);
                        cmdEditarMedicamento.Parameters.AddWithValue("@NOMEFABRICA", model.nomeFrabica);
                        cmdEditarMedicamento.Parameters.AddWithValue("@FABRICANTE", model.fabricante);

                        retorno = cmdEditarMedicamento.ExecuteNonQuery();

                        if (retorno == 1) {
                            scope.Complete();
                            return retorno;
                        } else {
                            scope.Dispose();
                            return 0;
                        }
                    }
                } catch (Exception ex) {
                    scope.Dispose();
                    throw ex;
                }
            }
        }

        public int ExcluirMedicamento(int idMedicamento) {
            using (TransactionScope scope = new TransactionScope()) {
                try {
                    var DALSQL = new MedicamentoDALSQL();
                    var retorno = 0;

                    using (MySqlConnection connection = new MySqlConnection(getStringConnection())) {
                        connection.Open();

                        MySqlCommand cmdEditarMedicamento = new MySqlCommand(DALSQL.ExcluirMedicamento(), connection);

                        cmdEditarMedicamento.Parameters.AddWithValue("@IDMEDICAMENTO", idMedicamento);

                        retorno = cmdEditarMedicamento.ExecuteNonQuery();

                        if (retorno == 1) {
                            scope.Complete();
                            return retorno;
                        } else {
                            scope.Dispose();
                            return 0;
                        }
                    }
                } catch (Exception ex) {
                    scope.Dispose();
                    throw ex;
                }
            }
        }
    }
}
