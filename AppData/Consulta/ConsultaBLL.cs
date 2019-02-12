﻿using System;
using System.Collections.Generic;
using SGCM.Models.Consulta.CadastroConsultaModel;
using SGCM.Models.Consulta.ConsultaPacienteModel;
using SGCM.AppData.Infraestrutura.UtilMetodo;
using SGCM.Models.Consulta.ConsultarConsultaModel;
using SGCM.Models.Consulta.EditarConsultaModel;

namespace SGCM.AppData.Consulta
{
    public class ConsultaBLL
    {
        public List<ConsultaPacienteModel> ConsultarPaciente(string nome, string cpf, int? idPaciente) {
            if (cpf != null) cpf = UtilMetodo.RemovendoCaracteresEspeciais(cpf);

            ConsultaDAL consultaDAL = new ConsultaDAL();
            return consultaDAL.ConsultarPacienteNome(nome, cpf, idPaciente);
        }

        public int CadastrarConsulta(CadastroConsultaModel model) {
            model.paciente.CPF = UtilMetodo.RemovendoCaracteresEspeciais(model.paciente.CPF);

            DateTime dataInformada = model.consulta.DataConsulta;
            DateTime dataAgora = DateTime.Now;

            var resultadoComparacao = dataInformada.Date.CompareTo(dataAgora.Date);

            if ( resultadoComparacao < 0 ) {
                // Data informada é menor que a data atual.
                return 2;
            } else if ( resultadoComparacao == 0 ) {
                var resultadoComparacaoComHora = dataInformada.CompareTo(dataAgora);
                if (resultadoComparacaoComHora < 0) {
                    return 3;
                }
            }

            model = CorrigirDataConsulta(model);

            ConsultaDAL consultaDAL = new ConsultaDAL();

            var retornoConsultaCadastrada = consultaDAL.verificaConsultaCadastrada(model);

            if ( retornoConsultaCadastrada == 1) {
                return 4;
            }

            string retornoDiaDaSemana = UtilMetodo.VerificaDiaDaSemana(Convert.ToInt32(model.consulta.DataConsulta.ToShortDateString().Split('/')[0]), Convert.ToInt32(model.consulta.DataConsulta.ToShortDateString().Split('/')[1]), Convert.ToInt32(model.consulta.DataConsulta.ToShortDateString().Split('/')[2]));

            if (retornoDiaDaSemana.Equals("sábado")) return 5;
            else if ( retornoDiaDaSemana.Equals("domingo")) return 6;

            int minuto = Convert.ToInt32(model.consulta.DataConsulta.ToShortTimeString().Split(':')[1]);
            Boolean flagMinuto = false;

            if (minuto == 00) flagMinuto = true;
            else if (minuto == 15) flagMinuto = true;
            else if (minuto == 30) flagMinuto = true;
            else if (minuto == 45) flagMinuto = true;

            if (!flagMinuto) return 7;

            return consultaDAL.CadastrarConsulta(model);
        }

        public CadastroConsultaModel CorrigirDataConsulta(CadastroConsultaModel model) {
            try {
                DateTime dataConsulta = model.consulta.DataConsulta;

                int hora = Convert.ToInt32(model.consulta.DataConsulta.ToString().Split(' ')[1].Split(':')[0]);

                if (hora > 11) {
                    var dataCompletaAntiga = model.consulta.DataConsulta.ToString().Split(' ')[0];
                    int ano = Convert.ToInt32(dataCompletaAntiga.Split('/')[2]);
                    int mes = Convert.ToInt32(dataCompletaAntiga.Split('/')[1]);
                    int dia = Convert.ToInt32(dataCompletaAntiga.Split('/')[0]);

                    var horaCompletaAntiga = model.consulta.DataConsulta.ToString().Split(' ')[1];
                    int horaNova = 0;
                    int minutoAntiga = Convert.ToInt32(horaCompletaAntiga.Split(':')[1]);
                    int segundoAntiga = Convert.ToInt32(horaCompletaAntiga.Split(':')[2]);

                    switch (hora) {
                        case 12:
                            horaNova = 12;
                            model.consulta.DataConsulta = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 13:
                            horaNova = 01;
                            model.consulta.DataConsulta = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 14:
                            horaNova = 02;
                            model.consulta.DataConsulta = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 15:
                            horaNova = 03;
                            model.consulta.DataConsulta = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 16:
                            horaNova = 04;
                            model.consulta.DataConsulta = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 17:
                            horaNova = 05;
                            model.consulta.DataConsulta = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 18:
                            horaNova = 06;
                            model.consulta.DataConsulta = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 19:
                            horaNova = 07;
                            model.consulta.DataConsulta = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 20:
                            horaNova = 08;
                            model.consulta.DataConsulta = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 21:
                            horaNova = 09;
                            model.consulta.DataConsulta = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 22:
                            horaNova = 10;
                            model.consulta.DataConsulta = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 23:
                            horaNova = 11;
                            model.consulta.DataConsulta = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        default:
                            break;
                    }
                    model.consulta.flagPM = true;
                }

                return model;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ConsultarConsultasModel ConsultarConsultas(ConsultarConsultasModel model, string data, int id) {
            try {
                DateTime dataAtual = new DateTime();
                if (data == null) dataAtual = DateTime.Today;
                else {
                    dataAtual = new DateTime(Convert.ToInt32(data.Split('/')[2]), Convert.ToInt32(data.Split('/')[1]), Convert.ToInt32(data.Split('/')[0]));
                    if (id == 1) dataAtual = dataAtual.AddDays(-7);
                    else if (id == 2) dataAtual = dataAtual.AddDays(7);
                }

                string diaDaSemana = UtilMetodo.VerificaDiaDaSemana(
                                   Convert.ToInt32(dataAtual.ToShortDateString().Split('/')[0]),
                                   Convert.ToInt32(dataAtual.ToShortDateString().Split('/')[1]),
                                   Convert.ToInt32(dataAtual.ToShortDateString().Split('/')[2]));
                DateTime dataInicial = new DateTime();
                DateTime dataFinal = new DateTime(); ;
                DateTime dataFinalAux = new DateTime();

                if (diaDaSemana == "segunda") {
                    dataInicial = dataAtual;
                    dataFinalAux = dataAtual.AddDays(4);
                    dataFinal = new DateTime(dataFinalAux.Year, dataFinalAux.Month, dataFinalAux.Day, 19, 00, 00, 00);
                } else if (diaDaSemana == "terça") {
                    dataInicial = dataAtual.AddDays(-1);
                    dataFinalAux = dataAtual.AddDays(3);
                    dataFinal = new DateTime(dataFinalAux.Year, dataFinalAux.Month, dataFinalAux.Day, 19, 00, 00, 00);
                } else if (diaDaSemana == "quarta") {
                    dataInicial = dataAtual.AddDays(-2);
                    dataFinalAux = dataAtual.AddDays(2);
                    dataFinal = new DateTime(dataFinalAux.Year, dataFinalAux.Month, dataFinalAux.Day, 19, 00, 00, 00);
                } else if (diaDaSemana == "quinta") {
                    dataInicial = dataAtual.AddDays(-3);
                    dataFinalAux = dataAtual.AddDays(1);
                    dataFinal = new DateTime(dataFinalAux.Year, dataFinalAux.Month, dataFinalAux.Day, 19, 00, 00, 00);
                } else if (diaDaSemana == "sexta") {
                    dataInicial = dataAtual.AddDays(-4);
                    dataFinalAux = dataAtual;
                    dataFinal = new DateTime(dataFinalAux.Year, dataFinalAux.Month, dataFinalAux.Day, 19, 00, 00, 00);
                }

                model.dataSegunda = dataInicial;
                model.dataTerca = dataInicial.AddDays(1);
                model.dataQuarta = dataInicial.AddDays(2);
                model.dataQuinta = dataInicial.AddDays(3);
                model.dataSexta = dataFinal;

                ConsultaDAL consultaDAL = new ConsultaDAL();
                List<ConsultasQuery> consultasCompletas = consultaDAL.ConsultarConsultas(dataInicial, dataFinal);

                if (consultasCompletas == null) return null;
                else {
                    List<ConsultasQuery> listaConsultaSegunda = new List<ConsultasQuery>();
                    List<ConsultasQuery> listaConsultaTerca = new List<ConsultasQuery>();
                    List<ConsultasQuery> listaConsultaQuarta = new List<ConsultasQuery>();
                    List<ConsultasQuery> listaConsultaQuinta = new List<ConsultasQuery>();
                    List<ConsultasQuery> listaConsultaSexta = new List<ConsultasQuery>();

                    foreach (ConsultasQuery consulta in consultasCompletas) {
                        var diaSemana = UtilMetodo.VerificaDiaDaSemana(
                                Convert.ToInt32(consulta.dataConsulta.ToShortDateString().Split('/')[0]),
                                Convert.ToInt32(consulta.dataConsulta.ToShortDateString().Split('/')[1]),
                                Convert.ToInt32(consulta.dataConsulta.ToShortDateString().Split('/')[2]));

                        if (diaSemana == "segunda") {
                            var hora = consulta.dataConsulta.ToShortTimeString().Split(':')[0];
                            var minuto = consulta.dataConsulta.ToShortTimeString().Split(':')[1];
                            UtilMetodo.AdicinarDadosBandoNaModelSegunda(hora, minuto, ref model, consulta);
                        } else if (diaSemana == "terça") {
                            var hora = consulta.dataConsulta.ToShortTimeString().Split(':')[0];
                            var minuto = consulta.dataConsulta.ToShortTimeString().Split(':')[1];
                            UtilMetodo.AdicinarDadosBandoNaModelTerca(hora, minuto, ref model, consulta);
                        } else if (diaSemana == "quarta") {
                            var hora = consulta.dataConsulta.ToShortTimeString().Split(':')[0];
                            var minuto = consulta.dataConsulta.ToShortTimeString().Split(':')[1];
                            UtilMetodo.AdicinarDadosBandoNaModelQuarta(hora, minuto, ref model, consulta);
                        } else if (diaSemana == "quinta") {
                            var hora = consulta.dataConsulta.ToShortTimeString().Split(':')[0];
                            var minuto = consulta.dataConsulta.ToShortTimeString().Split(':')[1];
                            UtilMetodo.AdicinarDadosBandoNaModelQuinta(hora, minuto, ref model, consulta);
                        } else if (diaSemana == "sexta") {
                            var hora = consulta.dataConsulta.ToShortTimeString().Split(':')[0];
                            var minuto = consulta.dataConsulta.ToShortTimeString().Split(':')[1];
                            UtilMetodo.AdicinarDadosBandoNaModelSexta(hora, minuto, ref model, consulta);
                        }
                    }
                    return model;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public EditarConsultaModel ConsultarConsulta(ConsultarConsulta consulta) {
            try {
                ConsultaDAL consultaDAL = new ConsultaDAL();
                return consultaDAL.ConsultarConsulta(consulta);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int EditarConsulta(EditarConsultaModel consulta) {
            try {
                consulta.paciente.CPF = UtilMetodo.RemovendoCaracteresEspeciais(consulta.paciente.CPF);

                ConsultaDAL consultaDAL = new ConsultaDAL();
                return consultaDAL.EditarConsulta(consulta);
            } catch (Exception ex) {
                throw ex;
            }
        }

    }
}