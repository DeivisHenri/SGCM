using SGCM.AppData.Infraestrutura.UtilMetodo;
using SGCM.Models.Ausencia.CadastrarAusenciaModel;
using SGCM.Models.Ausencia.ConsultarAusenciaModel;
using SGCM.Models.Ausencia.EditarAusenciaModel;
using System;
using System.Collections.Generic;

namespace SGCM.AppData.Ausencia {
    public class AusenciaBLL {
        public int CadastrarAusencia(CadastrarAusenciaModel model) {
            try {
                DateTime dataInicio = new DateTime(model.DataInicio.Year, model.DataInicio.Month, model.DataInicio.Day, UtilMetodo.DescobrirHora(model.HoraInicio)[0], UtilMetodo.DescobrirHora(model.HoraInicio)[1], 0);
                DateTime dataFinal = new DateTime(model.DataFinal.Year, model.DataFinal.Month, model.DataFinal.Day, UtilMetodo.DescobrirHora(model.HoraFinal)[0], UtilMetodo.DescobrirHora(model.HoraFinal)[1], 0);
                DateTime dataAgora = DateTime.Now;

                if ((dataAgora - dataInicio).Ticks > 0) return 1;

                TimeSpan qtdDias = model.DataFinal - model.DataInicio;

                List<DateTime> listData = new List<DateTime>();
                List<CadastrarAusenciaBancoModel> listAusenciaBancoModels = new List<CadastrarAusenciaBancoModel>();

                if (qtdDias.Days < 0) {
                    return 2;
                } else if (qtdDias.Days == 0) {
                    if ((model.HoraFinal - model.HoraInicio) < 0) {
                        return 3;
                    } else {
                        int[] horaInicial = UtilMetodo.DescobrirHora(model.HoraInicio);
                        int[] horaFinal = UtilMetodo.DescobrirHora(model.HoraFinal);

                        int[] listAusencia = new int[26];
                        int o = model.HoraInicio;
                        int p = model.HoraFinal;

                        for (int i = 1; i <= 26; i++) {
                            if ((i == o) && (o <= p)) {
                                listAusencia[i - 1] = 1;
                                o++;
                            } else {
                                listAusencia[i - 1] = 0;
                            }
                        }

                        CadastrarAusenciaBancoModel ausenciaBancoModel = new CadastrarAusenciaBancoModel();
                        ausenciaBancoModel.DataInicio = new DateTime(model.DataInicio.Year, model.DataInicio.Month, model.DataInicio.Day);
                        ausenciaBancoModel.DataFinal = new DateTime(model.DataFinal.Year, model.DataFinal.Month, model.DataFinal.Day);
                        ausenciaBancoModel.horaInicio = model.HoraInicio;
                        ausenciaBancoModel.horaFinal = model.HoraFinal;
                        ausenciaBancoModel.idUsuarioAusencia = model.idUsuarioAusencia;

                        ausenciaBancoModel = UtilMetodo.MarcarAusenciaCadastrarNoBancoModel(ausenciaBancoModel, listAusencia);
                        listAusenciaBancoModels.Add(ausenciaBancoModel);
                    }
                } else {
                    listData.Add(model.DataInicio);
                    for (int i = 1; i < (qtdDias.Days); i++) listData.Add(model.DataInicio.AddDays(i));
                    listData.Add(model.DataFinal);

                    int ordemDatas = 1;

                    foreach (DateTime data in listData) {
                        int[] listAusencia = new int[26];
                        int o = model.HoraInicio;
                        int p = model.HoraFinal;

                        if (ordemDatas == 1) {
                            o = model.HoraInicio;
                            p = 26;
                            int[] horaInicial = UtilMetodo.DescobrirHora(model.HoraInicio);
                            int[] horaFinal = UtilMetodo.DescobrirHora(26);
                        } else if (ordemDatas == listData.Count) {
                            o = 1;
                            p = 26;
                            int[] horaInicial = UtilMetodo.DescobrirHora(1);
                            int[] horaFinal = UtilMetodo.DescobrirHora(model.HoraFinal);
                        } else {
                            o = 1;
                            p = 26;
                            int[] horaInicial = UtilMetodo.DescobrirHora(1);
                            int[] horaFinal = UtilMetodo.DescobrirHora(26);
                        }

                        ordemDatas++;

                        for (int i = 1; i <= 26; i++) {
                            if ((i == o) && (o <= p)) {
                                listAusencia[i - 1] = 1;
                                o++;
                            } else {
                                listAusencia[i - 1] = 0;
                            }
                        }

                        CadastrarAusenciaBancoModel ausenciaBancoModel = new CadastrarAusenciaBancoModel();
                        ausenciaBancoModel.DataInicio = new DateTime(data.Year, data.Month, data.Day);
                        ausenciaBancoModel.DataFinal = new DateTime(data.Year, data.Month, data.Day);

                        ausenciaBancoModel.idUsuarioAusencia = model.idUsuarioAusencia;

                        ausenciaBancoModel = UtilMetodo.MarcarAusenciaCadastrarNoBancoModel(ausenciaBancoModel, listAusencia);
                        listAusenciaBancoModels.Add(ausenciaBancoModel);
                    }
                }

                AusenciaDAL objAusenciaDAL = new AusenciaDAL();
                return objAusenciaDAL.CadastrarAusencia(listAusenciaBancoModels);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<ConsultarAusenciaBancoModel> ConsultarAusencia(int idUsuario) {
            try {
                AusenciaDAL objAusenciaDAL = new AusenciaDAL();
                return objAusenciaDAL.ConsultarAusencia(idUsuario);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public EditarAusenciaBancoModel ConsultarAusenciaIdAusencia(int idAusencia) {
            try {
                AusenciaDAL objAusenciaDAL = new AusenciaDAL();
                return objAusenciaDAL.ConsultarAusenciaIdAusencia(idAusencia);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int EditarAusencia(EditarAusenciaViewModel model) {
            try
            {

                DateTime dataInicio = new DateTime(model.DataInicio.Year, model.DataInicio.Month, model.DataInicio.Day, UtilMetodo.DescobrirHora(model.HoraInicio)[0], UtilMetodo.DescobrirHora(model.HoraInicio)[1], 0);
                DateTime dataFinal = new DateTime(model.DataFinal.Year, model.DataFinal.Month, model.DataFinal.Day, UtilMetodo.DescobrirHora(model.HoraFinal)[0], UtilMetodo.DescobrirHora(model.HoraFinal)[1], 0);
                DateTime dataAgora = DateTime.Now;

                if ((dataAgora - dataInicio).Ticks > 0) return 1;

                TimeSpan qtdDias = model.DataFinal - model.DataInicio;

                List<DateTime> listData = new List<DateTime>();
                List<CadastrarAusenciaBancoModel> listAusenciaBancoModels = new List<CadastrarAusenciaBancoModel>();

                if (qtdDias.Days < 0) {
                    return 2;
                } else if (qtdDias.Days == 0) {
                    if ((model.HoraFinal - model.HoraInicio) < 0) {
                        return 3;
                    } else {
                        int[] horaInicial = UtilMetodo.DescobrirHora(model.HoraInicio);
                        int[] horaFinal = UtilMetodo.DescobrirHora(model.HoraFinal);

                        int[] listAusencia = new int[26];
                        int o = model.HoraInicio;
                        int p = model.HoraFinal;

                        for (int i = 1; i <= 26; i++)
                        {
                            if ((i == o) && (o <= p))
                            {
                                listAusencia[i - 1] = 1;
                                o++;
                            }
                            else
                            {
                                listAusencia[i - 1] = 0;
                            }
                        }

                        EditarAusenciaBancoModel ausenciaBancoModel = new EditarAusenciaBancoModel();
                        ausenciaBancoModel.DataInicio = new DateTime(model.DataInicio.Year, model.DataInicio.Month, model.DataInicio.Day);
                        ausenciaBancoModel.DataFinal = new DateTime(model.DataFinal.Year, model.DataFinal.Month, model.DataFinal.Day);
                        ausenciaBancoModel = UtilMetodo.MarcarAusenciaEditarNoBancoModel(ausenciaBancoModel, listAusencia);
                        ausenciaBancoModel.idAusencia = model.idAusencia;
                        AusenciaDAL objAusenciaDAL = new AusenciaDAL();
                        return objAusenciaDAL.EditarAusencia(ausenciaBancoModel);
                    }
                }

                return 4;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
