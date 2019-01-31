using System;
using System.Collections.Generic;
using SGCM.Models.Consulta.CadastroConsultaModel;
using SGCM.Models.Consulta.ConsultaPacienteModel;
using SGCM.AppData.Infraestrutura.UtilMetodo;

namespace SGCM.AppData.Consulta
{
    public class ConsultaBLL
    {
        public List<ConsultaPacienteModel> ConsultarPaciente(string nome, string cpf) {
            if (cpf != null) cpf = UtilMetodo.RemovendoCaracteresEspeciais(cpf);

            ConsultaDAL consultaDAL = new ConsultaDAL();
            return consultaDAL.ConsultarPacienteNome(nome, cpf);
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
    }
}