using MySql.Data.MySqlClient;
using SGCM.Models.Ausencia.CadastrarAusenciaModel;
using SGCM.Models.Ausencia.ConsultarAusenciaModel;
using SGCM.Models.Ausencia.EditarAusenciaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace SGCM.AppData.Ausencia {
    public class AusenciaDAL : SGCMContext {
        public int CadastrarAusencia(List<CadastrarAusenciaBancoModel> listAusenciaBancoModels) {
            using (TransactionScope scope = new TransactionScope()) {
                try {
                    var DALSQL = new AusenciaDALSQL();
                    var retorno = 0;

                    using (MySqlConnection connection = new MySqlConnection(getStringConnection())) {
                        connection.Open();

                        for (int i = 0; i < listAusenciaBancoModels.Count; i++) {
                            MySqlCommand cmdMarcarAusencia = new MySqlCommand(DALSQL.CadastrarAusencia(), connection);

                            cmdMarcarAusencia.Parameters.AddWithValue("@IDUSUARIOAUSENCIA", listAusenciaBancoModels[i].idUsuarioAusencia);
                            cmdMarcarAusencia.Parameters.AddWithValue("@DATAINICIAL", listAusenciaBancoModels[i].DataInicio);
                            cmdMarcarAusencia.Parameters.AddWithValue("@DATAFINAL", listAusenciaBancoModels[i].DataFinal);
                            cmdMarcarAusencia.Parameters.AddWithValue("@SEIS", listAusenciaBancoModels[i].Seis);
                            cmdMarcarAusencia.Parameters.AddWithValue("@SEISMEIA", listAusenciaBancoModels[i].SeisMeia);
                            cmdMarcarAusencia.Parameters.AddWithValue("@SETE", listAusenciaBancoModels[i].Sete);
                            cmdMarcarAusencia.Parameters.AddWithValue("@SETEMEIA", listAusenciaBancoModels[i].SeteMeia);
                            cmdMarcarAusencia.Parameters.AddWithValue("@OITO", listAusenciaBancoModels[i].Oito);
                            cmdMarcarAusencia.Parameters.AddWithValue("@OITOMEIA", listAusenciaBancoModels[i].OitoMeia);
                            cmdMarcarAusencia.Parameters.AddWithValue("@NOVE", listAusenciaBancoModels[i].Nove);
                            cmdMarcarAusencia.Parameters.AddWithValue("@NOVEMEIA", listAusenciaBancoModels[i].NoveMeia);
                            cmdMarcarAusencia.Parameters.AddWithValue("@DEZ", listAusenciaBancoModels[i].Dez);
                            cmdMarcarAusencia.Parameters.AddWithValue("@DEZMEIA", listAusenciaBancoModels[i].DezMeia);
                            cmdMarcarAusencia.Parameters.AddWithValue("@ONZE", listAusenciaBancoModels[i].Onze);
                            cmdMarcarAusencia.Parameters.AddWithValue("@ONZEMEIA", listAusenciaBancoModels[i].OnzeMeia);
                            cmdMarcarAusencia.Parameters.AddWithValue("@DOZE", listAusenciaBancoModels[i].Doze);
                            cmdMarcarAusencia.Parameters.AddWithValue("@DOZEMEIA", listAusenciaBancoModels[i].DozeMeia);
                            cmdMarcarAusencia.Parameters.AddWithValue("@TREZE", listAusenciaBancoModels[i].Treze);
                            cmdMarcarAusencia.Parameters.AddWithValue("@TREZEMEIA", listAusenciaBancoModels[i].TrezeMeia);
                            cmdMarcarAusencia.Parameters.AddWithValue("@QUATORZE", listAusenciaBancoModels[i].Quatorze);
                            cmdMarcarAusencia.Parameters.AddWithValue("@QUATORZEMEIA", listAusenciaBancoModels[i].QuatorzeMeia);
                            cmdMarcarAusencia.Parameters.AddWithValue("@QUINZE", listAusenciaBancoModels[i].Quinze);
                            cmdMarcarAusencia.Parameters.AddWithValue("@QUINZEMEIA", listAusenciaBancoModels[i].QuinzeMeia);
                            cmdMarcarAusencia.Parameters.AddWithValue("@DEZESSEIS", listAusenciaBancoModels[i].Dezesseis);
                            cmdMarcarAusencia.Parameters.AddWithValue("@DEZESSEISMEIA", listAusenciaBancoModels[i].DezesseisMeia);
                            cmdMarcarAusencia.Parameters.AddWithValue("@DEZESSETE", listAusenciaBancoModels[i].Dezessete);
                            cmdMarcarAusencia.Parameters.AddWithValue("@DEZESSETEMEIA", listAusenciaBancoModels[i].DezesseteMeia);
                            cmdMarcarAusencia.Parameters.AddWithValue("@DEZOITO", listAusenciaBancoModels[i].Dezoito);
                            cmdMarcarAusencia.Parameters.AddWithValue("@DEZOITOMEIA", listAusenciaBancoModels[i].DezoitoMeia);

                            retorno = retorno + cmdMarcarAusencia.ExecuteNonQuery();
                        }

                        if (retorno > 0) {
                            scope.Complete();
                            return -1;
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
        
        public List<ListaConsultarAusenciaModel> ConsultarAusencia(int idUsuario, int sortOrder, DateTime psqDataAusencia) {
            try {
                var DALSQL = new AusenciaDALSQL();
                List<ListaConsultarAusenciaModel> listAusenciaBancoModel = new List<ListaConsultarAusenciaModel>();

                using (MySqlConnection connection = new MySqlConnection(getStringConnection())) {
                    connection.Open();

                    MySqlCommand cmdConsultarAusencia = new MySqlCommand(DALSQL.ConsultarAusencia(sortOrder, psqDataAusencia), connection);
                    cmdConsultarAusencia.Parameters.AddWithValue("@IDUSUARIOAUSENCIA", idUsuario);

                    var dataArray = psqDataAusencia.ToShortDateString().Split('/');

                    cmdConsultarAusencia.Parameters.AddWithValue("@DATAINICIAL", psqDataAusencia.ToShortDateString());

                    var teste = getGeneratedSql(cmdConsultarAusencia);

                    MySqlDataReader reader = cmdConsultarAusencia.ExecuteReader();

                    if (reader.HasRows) {
                        while (reader.Read()) {
                            ListaConsultarAusenciaModel ausenciaBanco = new ListaConsultarAusenciaModel();
                            ausenciaBanco.idAusencia = reader.GetInt32(0);
                            ausenciaBanco.DataInicio = reader.GetDateTime(1);
                            ausenciaBanco.DataFinal = reader.GetDateTime(2);
                            ausenciaBanco.Seis = reader.GetInt32(3);
                            ausenciaBanco.SeisMeia = reader.GetInt32(4);
                            ausenciaBanco.Sete = reader.GetInt32(5);
                            ausenciaBanco.SeteMeia = reader.GetInt32(6);
                            ausenciaBanco.Oito = reader.GetInt32(7);
                            ausenciaBanco.OitoMeia = reader.GetInt32(8);
                            ausenciaBanco.Nove = reader.GetInt32(9);
                            ausenciaBanco.NoveMeia = reader.GetInt32(10);
                            ausenciaBanco.Dez = reader.GetInt32(11);
                            ausenciaBanco.DezMeia = reader.GetInt32(12);
                            ausenciaBanco.Onze = reader.GetInt32(13);
                            ausenciaBanco.OnzeMeia = reader.GetInt32(14);
                            ausenciaBanco.Doze = reader.GetInt32(15);
                            ausenciaBanco.DozeMeia = reader.GetInt32(16);
                            ausenciaBanco.Treze = reader.GetInt32(17);
                            ausenciaBanco.TrezeMeia = reader.GetInt32(18);
                            ausenciaBanco.Quatorze = reader.GetInt32(19);
                            ausenciaBanco.QuatorzeMeia = reader.GetInt32(20);
                            ausenciaBanco.Quinze = reader.GetInt32(21);
                            ausenciaBanco.QuinzeMeia = reader.GetInt32(22);
                            ausenciaBanco.Dezesseis = reader.GetInt32(23);
                            ausenciaBanco.DezesseisMeia = reader.GetInt32(24);
                            ausenciaBanco.Dezessete = reader.GetInt32(25);
                            ausenciaBanco.DezesseteMeia = reader.GetInt32(26);
                            ausenciaBanco.Dezoito = reader.GetInt32(27);
                            ausenciaBanco.DezoitoMeia = reader.GetInt32(26);

                            listAusenciaBancoModel.Add(ausenciaBanco);
                        }
                        reader.NextResult();
                    } else {
                        reader.Close();
                        connection.Close();
                        return null;
                    }
                    reader.Close();
                    connection.Close();
                    return listAusenciaBancoModel;
                }
            } catch (Exception ex) {
                throw ex; 
            }
        }

        public EditarAusenciaBancoModel ConsultarAusenciaIdAusencia(int idAusencia) {
            try {
                var DALSQL = new AusenciaDALSQL();
                EditarAusenciaBancoModel ausenciaBanco = new EditarAusenciaBancoModel();

                using (MySqlConnection connection = new MySqlConnection(getStringConnection())) {
                    connection.Open();

                    MySqlCommand cmdConsultarAusencia = new MySqlCommand(DALSQL.ConsultarAusenciaIdAusencia(), connection);
                    cmdConsultarAusencia.Parameters.AddWithValue("@IDAUSENCIA", idAusencia);
                    MySqlDataReader reader = cmdConsultarAusencia.ExecuteReader();

                    if (reader.HasRows) {
                        while (reader.Read()) {
                            ausenciaBanco.idAusencia = reader.GetInt32(0);
                            ausenciaBanco.idUsuarioAusencia = reader.GetInt32(1);
                            ausenciaBanco.DataInicio = reader.GetDateTime(2);
                            ausenciaBanco.DataFinal = reader.GetDateTime(3);
                            ausenciaBanco.Seis = reader.GetInt32(4);
                            ausenciaBanco.SeisMeia = reader.GetInt32(5);
                            ausenciaBanco.Sete = reader.GetInt32(6);
                            ausenciaBanco.SeteMeia = reader.GetInt32(7);
                            ausenciaBanco.Oito = reader.GetInt32(8);
                            ausenciaBanco.OitoMeia = reader.GetInt32(9);
                            ausenciaBanco.Nove = reader.GetInt32(10);
                            ausenciaBanco.NoveMeia = reader.GetInt32(11);
                            ausenciaBanco.Dez = reader.GetInt32(12);
                            ausenciaBanco.DezMeia = reader.GetInt32(13);
                            ausenciaBanco.Onze = reader.GetInt32(14);
                            ausenciaBanco.OnzeMeia = reader.GetInt32(15);
                            ausenciaBanco.Doze = reader.GetInt32(16);
                            ausenciaBanco.DozeMeia = reader.GetInt32(17);
                            ausenciaBanco.Treze = reader.GetInt32(18);
                            ausenciaBanco.TrezeMeia = reader.GetInt32(19);
                            ausenciaBanco.Quatorze = reader.GetInt32(20);
                            ausenciaBanco.QuatorzeMeia = reader.GetInt32(21);
                            ausenciaBanco.Quinze = reader.GetInt32(22);
                            ausenciaBanco.QuinzeMeia = reader.GetInt32(23);
                            ausenciaBanco.Dezesseis = reader.GetInt32(24);
                            ausenciaBanco.DezesseisMeia = reader.GetInt32(25);
                            ausenciaBanco.Dezessete = reader.GetInt32(26);
                            ausenciaBanco.DezesseteMeia = reader.GetInt32(27);
                            ausenciaBanco.Dezoito = reader.GetInt32(28);
                            ausenciaBanco.DezoitoMeia = reader.GetInt32(29);
                        }
                        reader.NextResult();
                    } else {
                        reader.Close();
                        connection.Close();
                        return null;
                    }
                    reader.Close();
                    connection.Close();
                    return ausenciaBanco;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int EditarAusencia(EditarAusenciaBancoModel model) {
            using (TransactionScope scope = new TransactionScope()) {
                try {
                    var DALSQL = new AusenciaDALSQL();
                    var retorno = 0;

                    using (MySqlConnection connection = new MySqlConnection(getStringConnection())) {
                        connection.Open();

                        MySqlCommand cmdMarcarAusencia = new MySqlCommand(DALSQL.EditarAusencia(), connection);

                        cmdMarcarAusencia.Parameters.AddWithValue("@IDAUSENCIA", model.idAusencia);
                        cmdMarcarAusencia.Parameters.AddWithValue("@DATAINICIAL", model.DataInicio);
                        cmdMarcarAusencia.Parameters.AddWithValue("@DATAFINAL", model.DataFinal);
                        cmdMarcarAusencia.Parameters.AddWithValue("@SEIS", model.Seis);
                        cmdMarcarAusencia.Parameters.AddWithValue("@SEISMEIA", model.SeisMeia);
                        cmdMarcarAusencia.Parameters.AddWithValue("@SETE", model.Sete);
                        cmdMarcarAusencia.Parameters.AddWithValue("@SETEMEIA", model.SeteMeia);
                        cmdMarcarAusencia.Parameters.AddWithValue("@OITO", model.Oito);
                        cmdMarcarAusencia.Parameters.AddWithValue("@OITOMEIA", model.OitoMeia);
                        cmdMarcarAusencia.Parameters.AddWithValue("@NOVE", model.Nove);
                        cmdMarcarAusencia.Parameters.AddWithValue("@NOVEMEIA", model.NoveMeia);
                        cmdMarcarAusencia.Parameters.AddWithValue("@DEZ", model.Dez);
                        cmdMarcarAusencia.Parameters.AddWithValue("@DEZMEIA", model.DezMeia);
                        cmdMarcarAusencia.Parameters.AddWithValue("@ONZE", model.Onze);
                        cmdMarcarAusencia.Parameters.AddWithValue("@ONZEMEIA", model.OnzeMeia);
                        cmdMarcarAusencia.Parameters.AddWithValue("@DOZE", model.Doze);
                        cmdMarcarAusencia.Parameters.AddWithValue("@DOZEMEIA", model.DozeMeia);
                        cmdMarcarAusencia.Parameters.AddWithValue("@TREZE", model.Treze);
                        cmdMarcarAusencia.Parameters.AddWithValue("@TREZEMEIA", model.TrezeMeia);
                        cmdMarcarAusencia.Parameters.AddWithValue("@QUATORZE", model.Quatorze);
                        cmdMarcarAusencia.Parameters.AddWithValue("@QUATORZEMEIA", model.QuatorzeMeia);
                        cmdMarcarAusencia.Parameters.AddWithValue("@QUINZE", model.Quinze);
                        cmdMarcarAusencia.Parameters.AddWithValue("@QUINZEMEIA", model.QuinzeMeia);
                        cmdMarcarAusencia.Parameters.AddWithValue("@DEZESSEIS", model.Dezesseis);
                        cmdMarcarAusencia.Parameters.AddWithValue("@DEZESSEISMEIA", model.DezesseisMeia);
                        cmdMarcarAusencia.Parameters.AddWithValue("@DEZESSETE", model.Dezessete);
                        cmdMarcarAusencia.Parameters.AddWithValue("@DEZESSETEMEIA", model.DezesseteMeia);
                        cmdMarcarAusencia.Parameters.AddWithValue("@DEZOITO", model.Dezoito);
                        cmdMarcarAusencia.Parameters.AddWithValue("@DEZOITOMEIA", model.DezoitoMeia);

                        retorno = cmdMarcarAusencia.ExecuteNonQuery();

                        if (retorno > 0) {
                            scope.Complete();
                            return -1;
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

        private string getGeneratedSql(MySqlCommand cmd) {
            string result = cmd.CommandText.ToString();
            foreach (MySqlParameter p in cmd.Parameters) {
                string isQuted = (p.Value is string) ? "'" : "";
                result = result.Replace(p.ParameterName.ToString(), isQuted + p.Value.ToString() + isQuted);
            }
            return result;
        }
    }
}
