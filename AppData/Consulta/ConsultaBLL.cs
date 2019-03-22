using System;
using System.Collections.Generic;
using SGCM.Models.Consulta.CadastroConsultaModel;
using SGCM.Models.Consulta.ConsultaPacienteModel;
using SGCM.AppData.Infraestrutura.UtilMetodo;
using SGCM.Models.Consulta.ConsultarConsultaModel;
using SGCM.Models.Consulta.EditarConsultaModel;
using SGCM.Models.Ausencia.CadastrarAusenciaModel;
using SGCM.Models.Consulta.IniciarAtendimento;

namespace SGCM.AppData.Consulta
{
    public class ConsultaBLL
    {
        public ConsultaPacienteModelBanco ConsultarPaciente(string nome, string cpf, int? idPaciente) {
            if (cpf != null) cpf = UtilMetodo.RemovendoCaracteresEspeciais(cpf);

            ConsultaDAL consultaDAL = new ConsultaDAL();
            return consultaDAL.ConsultarPacienteNome(nome, cpf, idPaciente);
        }

        public int CadastrarConsulta(CadastroConsultaModel model) {
            model.Paciente.CPF = UtilMetodo.RemovendoCaracteresEspeciais(model.Paciente.CPF);

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

            DateTime retornoDataConsultaCorrigida = CorrigirDataConsulta(model.consulta.DataConsulta);

            if (retornoDataConsultaCorrigida != default(DateTime)) {
                model.consulta.DataConsulta = retornoDataConsultaCorrigida;
                model.consulta.flagPM = true;
            }

            ConsultaDAL consultaDAL = new ConsultaDAL();

            var retornoConsultaCadastrada = consultaDAL.verificaConsultaCadastrada(model);

            if ( retornoConsultaCadastrada == 1) {
                return 4;
            }

            string retornoDiaDaSemana = UtilMetodo.VerificaDiaDaSemana(Convert.ToInt32(model.consulta.DataConsulta.ToShortDateString().Split('/')[0]), Convert.ToInt32(model.consulta.DataConsulta.ToShortDateString().Split('/')[1]), Convert.ToInt32(model.consulta.DataConsulta.ToShortDateString().Split('/')[2]));

            if (retornoDiaDaSemana.Equals("sabado")) return 5;
            else if ( retornoDiaDaSemana.Equals("domingo")) return 6;

            int minuto = Convert.ToInt32(model.consulta.DataConsulta.ToShortTimeString().Split(':')[1]);
            Boolean flagMinuto = false;

            if (minuto == 00) flagMinuto = true;
            else if (minuto == 30) flagMinuto = true;

            if (!flagMinuto) return 7;

            CadastrarAusenciaBancoModel ausenciaBancoModel = consultaDAL.ConsultarAusencia(model.consulta.DataConsulta);

            if (ausenciaBancoModel != null) {
                CadastrarAusenciaBancoModel ausenciaComDataConsulta = UtilMetodo.ConvertandoHoraViewParaObjeto(model.consulta.DataConsulta);

                int hora = Convert.ToInt32(model.consulta.DataConsulta.ToShortTimeString().Split(':')[0]);
                int minutoDataConsulta = Convert.ToInt32(model.consulta.DataConsulta.ToShortTimeString().Split(':')[1]);

                Boolean flag = false;
                switch (ausenciaComDataConsulta.retorno) {
                    case 1:
                        if (ausenciaComDataConsulta.Seis == ausenciaBancoModel.Seis) flag = true;
                        break;
                    case 2:
                        if (ausenciaComDataConsulta.SeisMeia == ausenciaBancoModel.SeisMeia) flag = true;
                        break;
                    case 3:
                        if (ausenciaComDataConsulta.Sete == ausenciaBancoModel.Sete) flag = true;
                        break;
                    case 4:
                        if (ausenciaComDataConsulta.SeteMeia == ausenciaBancoModel.SeteMeia) flag = true;
                        break;
                    case 5:
                        if (ausenciaComDataConsulta.Oito == ausenciaBancoModel.Oito) flag = true;
                        break;
                    case 6:
                        if (ausenciaComDataConsulta.OitoMeia == ausenciaBancoModel.OitoMeia) flag = true;
                        break;
                    case 7:
                        if (ausenciaComDataConsulta.Nove == ausenciaBancoModel.Nove) flag = true;
                        break;
                    case 8:
                        if (ausenciaComDataConsulta.NoveMeia == ausenciaBancoModel.NoveMeia) flag = true;
                        break;
                    case 9:
                        if (ausenciaComDataConsulta.Dez == ausenciaBancoModel.Dez) flag = true;
                        break;
                    case 10:
                        if (ausenciaComDataConsulta.DezMeia == ausenciaBancoModel.DezMeia) flag = true;
                        break;
                    case 11:
                        if (ausenciaComDataConsulta.Onze == ausenciaBancoModel.Onze) flag = true;
                        break;
                    case 12:
                        if (ausenciaComDataConsulta.OnzeMeia == ausenciaBancoModel.OnzeMeia) flag = true;
                        break;
                    case 13:
                        if (ausenciaComDataConsulta.Doze == ausenciaBancoModel.Doze) flag = true;
                        break;
                    case 14:
                        if (ausenciaComDataConsulta.DozeMeia == ausenciaBancoModel.DozeMeia) flag = true;
                        break;
                    case 15:
                        if (ausenciaComDataConsulta.Treze == ausenciaBancoModel.Treze) flag = true;
                        break;
                    case 16:
                        if (ausenciaComDataConsulta.TrezeMeia == ausenciaBancoModel.TrezeMeia) flag = true;
                        break;
                    case 17:
                        if (ausenciaComDataConsulta.Quatorze == ausenciaBancoModel.Quatorze) flag = true;
                        break;
                    case 18:
                        if (ausenciaComDataConsulta.QuatorzeMeia == ausenciaBancoModel.QuatorzeMeia) flag = true;
                        break;
                    case 19:
                        if (ausenciaComDataConsulta.Quinze == ausenciaBancoModel.Quinze) flag = true;
                        break;
                    case 20:
                        if (ausenciaComDataConsulta.QuinzeMeia == ausenciaBancoModel.QuinzeMeia) flag = true;
                        break;
                    case 21:
                        if (ausenciaComDataConsulta.Dezesseis == ausenciaBancoModel.Dezesseis) flag = true;
                        break;
                    case 22:
                        if (ausenciaComDataConsulta.DezesseisMeia == ausenciaBancoModel.DezesseisMeia) flag = true;
                        break;
                    case 23:
                        if (ausenciaComDataConsulta.Dezessete == ausenciaBancoModel.Dezessete) flag = true;
                        break;
                    case 24:
                        if (ausenciaComDataConsulta.DezesseteMeia == ausenciaBancoModel.DezesseteMeia) flag = true;
                        break;
                    case 25:
                        if (ausenciaComDataConsulta.Dezoito == ausenciaBancoModel.Dezoito) flag = true;
                        break;
                    case 26:
                        if (ausenciaComDataConsulta.DezoitoMeia == ausenciaBancoModel.DezoitoMeia) flag = true;
                        break;

                }
                if (flag) return 8;
            }

            return consultaDAL.CadastrarConsulta(model);
        }

        public DateTime CorrigirDataConsulta(DateTime dataConsulta) {
            try {
                DateTime dataRetorno = new DateTime();
                int hora = Convert.ToInt32(dataConsulta.ToString().Split(' ')[1].Split(':')[0]);

                if (hora > 11) {
                    var dataCompletaAntiga = dataConsulta.ToString().Split(' ')[0];
                    int ano = Convert.ToInt32(dataCompletaAntiga.Split('/')[2]);
                    int mes = Convert.ToInt32(dataCompletaAntiga.Split('/')[1]);
                    int dia = Convert.ToInt32(dataCompletaAntiga.Split('/')[0]);

                    var horaCompletaAntiga = dataConsulta.ToString().Split(' ')[1];
                    int horaNova = 0;
                    int minutoAntiga = Convert.ToInt32(horaCompletaAntiga.Split(':')[1]);
                    int segundoAntiga = Convert.ToInt32(horaCompletaAntiga.Split(':')[2]);

                    switch (hora)
                    {
                        case 12:
                            horaNova = 12;
                            dataRetorno = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 13:
                            horaNova = 01;
                            dataRetorno = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 14:
                            horaNova = 02;
                            dataRetorno = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 15:
                            horaNova = 03;
                            dataRetorno = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 16:
                            horaNova = 04;
                            dataRetorno = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 17:
                            horaNova = 05;
                            dataRetorno = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 18:
                            horaNova = 06;
                            dataRetorno = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 19:
                            horaNova = 07;
                            dataRetorno = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 20:
                            horaNova = 08;
                            dataRetorno = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 21:
                            horaNova = 09;
                            dataRetorno = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 22:
                            horaNova = 10;
                            dataRetorno = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        case 23:
                            horaNova = 11;
                            dataRetorno = new DateTime(ano, mes, dia, horaNova, minutoAntiga, segundoAntiga);
                            break;
                        default:
                            break;
                    }
                }

                return dataRetorno;
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
                } else if (diaDaSemana == "sabado") {
                    dataInicial = dataAtual.AddDays(-5);
                    dataFinalAux = dataAtual.AddDays(-1);
                    dataFinal = new DateTime(dataFinalAux.Year, dataFinalAux.Month, dataFinalAux.Day, 19, 00, 00, 00);
                } else if (diaDaSemana == "domingo") {
                    dataInicial = dataAtual.AddDays(-6);
                    dataFinalAux = dataAtual.AddDays(-2);
                    dataFinal = new DateTime(dataFinalAux.Year, dataFinalAux.Month, dataFinalAux.Day, 19, 00, 00, 00);
                }

                model.dataSegunda = dataInicial;
                model.dataTerca = dataInicial.AddDays(1);
                model.dataQuarta = dataInicial.AddDays(2);
                model.dataQuinta = dataInicial.AddDays(3);
                model.dataSexta = dataFinal;

                ConsultaDAL consultaDAL = new ConsultaDAL();

                CadastrarAusenciaBancoModel dataAusenciaBancoModelSegunda = consultaDAL.ConsultarAusencia(model.dataSegunda);
                if (dataAusenciaBancoModelSegunda != null)
                {
                    model.dataSegundaAusenciaBancoModel.Seis = dataAusenciaBancoModelSegunda.Seis;
                    model.dataSegundaAusenciaBancoModel.SeisMeia = dataAusenciaBancoModelSegunda.SeisMeia;
                    model.dataSegundaAusenciaBancoModel.Sete = dataAusenciaBancoModelSegunda.Sete;
                    model.dataSegundaAusenciaBancoModel.SeteMeia = dataAusenciaBancoModelSegunda.SeteMeia;
                    model.dataSegundaAusenciaBancoModel.Oito = dataAusenciaBancoModelSegunda.Oito;
                    model.dataSegundaAusenciaBancoModel.OitoMeia = dataAusenciaBancoModelSegunda.OitoMeia;
                    model.dataSegundaAusenciaBancoModel.Nove = dataAusenciaBancoModelSegunda.Nove;
                    model.dataSegundaAusenciaBancoModel.NoveMeia = dataAusenciaBancoModelSegunda.NoveMeia;
                    model.dataSegundaAusenciaBancoModel.Dez = dataAusenciaBancoModelSegunda.Dez;
                    model.dataSegundaAusenciaBancoModel.DezMeia = dataAusenciaBancoModelSegunda.DezMeia;
                    model.dataSegundaAusenciaBancoModel.Onze = dataAusenciaBancoModelSegunda.Onze;
                    model.dataSegundaAusenciaBancoModel.OnzeMeia = dataAusenciaBancoModelSegunda.OnzeMeia;
                    model.dataSegundaAusenciaBancoModel.Doze = dataAusenciaBancoModelSegunda.Doze;
                    model.dataSegundaAusenciaBancoModel.DozeMeia = dataAusenciaBancoModelSegunda.DozeMeia;
                    model.dataSegundaAusenciaBancoModel.Treze = dataAusenciaBancoModelSegunda.Treze;
                    model.dataSegundaAusenciaBancoModel.TrezeMeia = dataAusenciaBancoModelSegunda.TrezeMeia;
                    model.dataSegundaAusenciaBancoModel.Quatorze = dataAusenciaBancoModelSegunda.Quatorze;
                    model.dataSegundaAusenciaBancoModel.QuatorzeMeia = dataAusenciaBancoModelSegunda.QuatorzeMeia;
                    model.dataSegundaAusenciaBancoModel.Quinze = dataAusenciaBancoModelSegunda.Quinze;
                    model.dataSegundaAusenciaBancoModel.QuinzeMeia = dataAusenciaBancoModelSegunda.QuinzeMeia;
                    model.dataSegundaAusenciaBancoModel.Dezesseis = dataAusenciaBancoModelSegunda.Dezesseis;
                    model.dataSegundaAusenciaBancoModel.DezesseisMeia = dataAusenciaBancoModelSegunda.DezesseisMeia;
                    model.dataSegundaAusenciaBancoModel.Dezessete = dataAusenciaBancoModelSegunda.Dezessete;
                    model.dataSegundaAusenciaBancoModel.DezesseteMeia = dataAusenciaBancoModelSegunda.DezesseteMeia;
                    model.dataSegundaAusenciaBancoModel.Dezoito = dataAusenciaBancoModelSegunda.Dezoito;
                    model.dataSegundaAusenciaBancoModel.DezoitoMeia = dataAusenciaBancoModelSegunda.DezoitoMeia;
                }

                CadastrarAusenciaBancoModel dataAusenciaBancoModelTerca = consultaDAL.ConsultarAusencia(model.dataTerca);
                if (dataAusenciaBancoModelTerca != null)
                {
                    model.dataTercaAusenciaBancoModel.Seis = dataAusenciaBancoModelTerca.Seis;
                    model.dataTercaAusenciaBancoModel.SeisMeia = dataAusenciaBancoModelTerca.SeisMeia;
                    model.dataTercaAusenciaBancoModel.Sete = dataAusenciaBancoModelTerca.Sete;
                    model.dataTercaAusenciaBancoModel.SeteMeia = dataAusenciaBancoModelTerca.SeteMeia;
                    model.dataTercaAusenciaBancoModel.Oito = dataAusenciaBancoModelTerca.Oito;
                    model.dataTercaAusenciaBancoModel.OitoMeia = dataAusenciaBancoModelTerca.OitoMeia;
                    model.dataTercaAusenciaBancoModel.Nove = dataAusenciaBancoModelTerca.Nove;
                    model.dataTercaAusenciaBancoModel.NoveMeia = dataAusenciaBancoModelTerca.NoveMeia;
                    model.dataTercaAusenciaBancoModel.Dez = dataAusenciaBancoModelTerca.Dez;
                    model.dataTercaAusenciaBancoModel.DezMeia = dataAusenciaBancoModelTerca.DezMeia;
                    model.dataTercaAusenciaBancoModel.Onze = dataAusenciaBancoModelTerca.Onze;
                    model.dataTercaAusenciaBancoModel.OnzeMeia = dataAusenciaBancoModelTerca.OnzeMeia;
                    model.dataTercaAusenciaBancoModel.Doze = dataAusenciaBancoModelTerca.Doze;
                    model.dataTercaAusenciaBancoModel.DozeMeia = dataAusenciaBancoModelTerca.DozeMeia;
                    model.dataTercaAusenciaBancoModel.Treze = dataAusenciaBancoModelTerca.Treze;
                    model.dataTercaAusenciaBancoModel.TrezeMeia = dataAusenciaBancoModelTerca.TrezeMeia;
                    model.dataTercaAusenciaBancoModel.Quatorze = dataAusenciaBancoModelTerca.Quatorze;
                    model.dataTercaAusenciaBancoModel.QuatorzeMeia = dataAusenciaBancoModelTerca.QuatorzeMeia;
                    model.dataTercaAusenciaBancoModel.Quinze = dataAusenciaBancoModelTerca.Quinze;
                    model.dataTercaAusenciaBancoModel.QuinzeMeia = dataAusenciaBancoModelTerca.QuinzeMeia;
                    model.dataTercaAusenciaBancoModel.Dezesseis = dataAusenciaBancoModelTerca.Dezesseis;
                    model.dataTercaAusenciaBancoModel.DezesseisMeia = dataAusenciaBancoModelTerca.DezesseisMeia;
                    model.dataTercaAusenciaBancoModel.Dezessete = dataAusenciaBancoModelTerca.Dezessete;
                    model.dataTercaAusenciaBancoModel.DezesseteMeia = dataAusenciaBancoModelTerca.DezesseteMeia;
                    model.dataTercaAusenciaBancoModel.Dezoito = dataAusenciaBancoModelTerca.Dezoito;
                    model.dataTercaAusenciaBancoModel.DezoitoMeia = dataAusenciaBancoModelTerca.DezoitoMeia;
                }

                CadastrarAusenciaBancoModel dataAusenciaBancoModelQuarta = consultaDAL.ConsultarAusencia(model.dataQuarta);
                if (dataAusenciaBancoModelQuarta != null)
                {
                    model.dataQuartaAusenciaBancoModel.Seis = dataAusenciaBancoModelQuarta.Seis;
                    model.dataQuartaAusenciaBancoModel.SeisMeia = dataAusenciaBancoModelQuarta.SeisMeia;
                    model.dataQuartaAusenciaBancoModel.Sete = dataAusenciaBancoModelQuarta.Sete;
                    model.dataQuartaAusenciaBancoModel.SeteMeia = dataAusenciaBancoModelQuarta.SeteMeia;
                    model.dataQuartaAusenciaBancoModel.Oito = dataAusenciaBancoModelQuarta.Oito;
                    model.dataQuartaAusenciaBancoModel.OitoMeia = dataAusenciaBancoModelQuarta.OitoMeia;
                    model.dataQuartaAusenciaBancoModel.Nove = dataAusenciaBancoModelQuarta.Nove;
                    model.dataQuartaAusenciaBancoModel.NoveMeia = dataAusenciaBancoModelQuarta.NoveMeia;
                    model.dataQuartaAusenciaBancoModel.Dez = dataAusenciaBancoModelQuarta.Dez;
                    model.dataQuartaAusenciaBancoModel.DezMeia = dataAusenciaBancoModelQuarta.DezMeia;
                    model.dataQuartaAusenciaBancoModel.Onze = dataAusenciaBancoModelQuarta.Onze;
                    model.dataQuartaAusenciaBancoModel.OnzeMeia = dataAusenciaBancoModelQuarta.OnzeMeia;
                    model.dataQuartaAusenciaBancoModel.Doze = dataAusenciaBancoModelQuarta.Doze;
                    model.dataQuartaAusenciaBancoModel.DozeMeia = dataAusenciaBancoModelQuarta.DozeMeia;
                    model.dataQuartaAusenciaBancoModel.Treze = dataAusenciaBancoModelQuarta.Treze;
                    model.dataQuartaAusenciaBancoModel.TrezeMeia = dataAusenciaBancoModelQuarta.TrezeMeia;
                    model.dataQuartaAusenciaBancoModel.Quatorze = dataAusenciaBancoModelQuarta.Quatorze;
                    model.dataQuartaAusenciaBancoModel.QuatorzeMeia = dataAusenciaBancoModelQuarta.QuatorzeMeia;
                    model.dataQuartaAusenciaBancoModel.Quinze = dataAusenciaBancoModelQuarta.Quinze;
                    model.dataQuartaAusenciaBancoModel.QuinzeMeia = dataAusenciaBancoModelQuarta.QuinzeMeia;
                    model.dataQuartaAusenciaBancoModel.Dezesseis = dataAusenciaBancoModelQuarta.Dezesseis;
                    model.dataQuartaAusenciaBancoModel.DezesseisMeia = dataAusenciaBancoModelQuarta.DezesseisMeia;
                    model.dataQuartaAusenciaBancoModel.Dezessete = dataAusenciaBancoModelQuarta.Dezessete;
                    model.dataQuartaAusenciaBancoModel.DezesseteMeia = dataAusenciaBancoModelQuarta.DezesseteMeia;
                    model.dataQuartaAusenciaBancoModel.Dezoito = dataAusenciaBancoModelQuarta.Dezoito;
                    model.dataQuartaAusenciaBancoModel.DezoitoMeia = dataAusenciaBancoModelQuarta.DezoitoMeia;
                }

                CadastrarAusenciaBancoModel dataAusenciaBancoModelQuinta = consultaDAL.ConsultarAusencia(model.dataQuinta);
                if (dataAusenciaBancoModelQuinta != null)
                {
                    model.dataQuintaAusenciaBancoModel.Seis = dataAusenciaBancoModelQuinta.Seis;
                    model.dataQuintaAusenciaBancoModel.SeisMeia = dataAusenciaBancoModelQuinta.SeisMeia;
                    model.dataQuintaAusenciaBancoModel.Sete = dataAusenciaBancoModelQuinta.Sete;
                    model.dataQuintaAusenciaBancoModel.SeteMeia = dataAusenciaBancoModelQuinta.SeteMeia;
                    model.dataQuintaAusenciaBancoModel.Oito = dataAusenciaBancoModelQuinta.Oito;
                    model.dataQuintaAusenciaBancoModel.OitoMeia = dataAusenciaBancoModelQuinta.OitoMeia;
                    model.dataQuintaAusenciaBancoModel.Nove = dataAusenciaBancoModelQuinta.Nove;
                    model.dataQuintaAusenciaBancoModel.NoveMeia = dataAusenciaBancoModelQuinta.NoveMeia;
                    model.dataQuintaAusenciaBancoModel.Dez = dataAusenciaBancoModelQuinta.Dez;
                    model.dataQuintaAusenciaBancoModel.DezMeia = dataAusenciaBancoModelQuinta.DezMeia;
                    model.dataQuintaAusenciaBancoModel.Onze = dataAusenciaBancoModelQuinta.Onze;
                    model.dataQuintaAusenciaBancoModel.OnzeMeia = dataAusenciaBancoModelQuinta.OnzeMeia;
                    model.dataQuintaAusenciaBancoModel.Doze = dataAusenciaBancoModelQuinta.Doze;
                    model.dataQuintaAusenciaBancoModel.DozeMeia = dataAusenciaBancoModelQuinta.DozeMeia;
                    model.dataQuintaAusenciaBancoModel.Treze = dataAusenciaBancoModelQuinta.Treze;
                    model.dataQuintaAusenciaBancoModel.TrezeMeia = dataAusenciaBancoModelQuinta.TrezeMeia;
                    model.dataQuintaAusenciaBancoModel.Quatorze = dataAusenciaBancoModelQuinta.Quatorze;
                    model.dataQuintaAusenciaBancoModel.QuatorzeMeia = dataAusenciaBancoModelQuinta.QuatorzeMeia;
                    model.dataQuintaAusenciaBancoModel.Quinze = dataAusenciaBancoModelQuinta.Quinze;
                    model.dataQuintaAusenciaBancoModel.QuinzeMeia = dataAusenciaBancoModelQuinta.QuinzeMeia;
                    model.dataQuintaAusenciaBancoModel.Dezesseis = dataAusenciaBancoModelQuinta.Dezesseis;
                    model.dataQuintaAusenciaBancoModel.DezesseisMeia = dataAusenciaBancoModelQuinta.DezesseisMeia;
                    model.dataQuintaAusenciaBancoModel.Dezessete = dataAusenciaBancoModelQuinta.Dezessete;
                    model.dataQuintaAusenciaBancoModel.DezesseteMeia = dataAusenciaBancoModelQuinta.DezesseteMeia;
                    model.dataQuintaAusenciaBancoModel.Dezoito = dataAusenciaBancoModelQuinta.Dezoito;
                    model.dataQuintaAusenciaBancoModel.DezoitoMeia = dataAusenciaBancoModelQuinta.DezoitoMeia;
                }

                CadastrarAusenciaBancoModel dataAusenciaBancoModelSexta = consultaDAL.ConsultarAusencia(model.dataSexta);
                if (dataAusenciaBancoModelSexta != null)
                {
                    model.dataSextaAusenciaBancoModel.Seis = dataAusenciaBancoModelSexta.Seis;
                    model.dataSextaAusenciaBancoModel.SeisMeia = dataAusenciaBancoModelSexta.SeisMeia;
                    model.dataSextaAusenciaBancoModel.Sete = dataAusenciaBancoModelSexta.Sete;
                    model.dataSextaAusenciaBancoModel.SeteMeia = dataAusenciaBancoModelSexta.SeteMeia;
                    model.dataSextaAusenciaBancoModel.Oito = dataAusenciaBancoModelSexta.Oito;
                    model.dataSextaAusenciaBancoModel.OitoMeia = dataAusenciaBancoModelSexta.OitoMeia;
                    model.dataSextaAusenciaBancoModel.Nove = dataAusenciaBancoModelSexta.Nove;
                    model.dataSextaAusenciaBancoModel.NoveMeia = dataAusenciaBancoModelSexta.NoveMeia;
                    model.dataSextaAusenciaBancoModel.Dez = dataAusenciaBancoModelSexta.Dez;
                    model.dataSextaAusenciaBancoModel.DezMeia = dataAusenciaBancoModelSexta.DezMeia;
                    model.dataSextaAusenciaBancoModel.Onze = dataAusenciaBancoModelSexta.Onze;
                    model.dataSextaAusenciaBancoModel.OnzeMeia = dataAusenciaBancoModelSexta.OnzeMeia;
                    model.dataSextaAusenciaBancoModel.Doze = dataAusenciaBancoModelSexta.Doze;
                    model.dataSextaAusenciaBancoModel.DozeMeia = dataAusenciaBancoModelSexta.DozeMeia;
                    model.dataSextaAusenciaBancoModel.Treze = dataAusenciaBancoModelSexta.Treze;
                    model.dataSextaAusenciaBancoModel.TrezeMeia = dataAusenciaBancoModelSexta.TrezeMeia;
                    model.dataSextaAusenciaBancoModel.Quatorze = dataAusenciaBancoModelSexta.Quatorze;
                    model.dataSextaAusenciaBancoModel.QuatorzeMeia = dataAusenciaBancoModelSexta.QuatorzeMeia;
                    model.dataSextaAusenciaBancoModel.Quinze = dataAusenciaBancoModelSexta.Quinze;
                    model.dataSextaAusenciaBancoModel.QuinzeMeia = dataAusenciaBancoModelSexta.QuinzeMeia;
                    model.dataSextaAusenciaBancoModel.Dezesseis = dataAusenciaBancoModelSexta.Dezesseis;
                    model.dataSextaAusenciaBancoModel.DezesseisMeia = dataAusenciaBancoModelSexta.DezesseisMeia;
                    model.dataSextaAusenciaBancoModel.Dezessete = dataAusenciaBancoModelSexta.Dezessete;
                    model.dataSextaAusenciaBancoModel.DezesseteMeia = dataAusenciaBancoModelSexta.DezesseteMeia;
                    model.dataSextaAusenciaBancoModel.Dezoito = dataAusenciaBancoModelSexta.Dezoito;
                    model.dataSextaAusenciaBancoModel.DezoitoMeia = dataAusenciaBancoModelSexta.DezoitoMeia;
                }

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

        public EditarConsultaModel ConsultarConsulta(int idConsulta) {
            try {
                ConsultaDAL consultaDAL = new ConsultaDAL();
                return consultaDAL.ConsultarConsulta(idConsulta);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int EditarConsulta(EditarConsultaModel consulta) {
            try {
                consulta.Paciente.CPF = UtilMetodo.RemovendoCaracteresEspeciais(consulta.Paciente.CPF);

                if (consulta.Paciente.idPaciente != consulta.MolestiaAtual.idPacienteMolestiaAtual) {
                    consulta.MolestiaAtual.idPacienteMolestiaAtual = consulta.Paciente.idPaciente;
                }

                if (consulta.Paciente.idPaciente != consulta.PatologicaPregressa.idPacientePatologicaPregressa) {
                    consulta.PatologicaPregressa.idPacientePatologicaPregressa = consulta.Paciente.idPaciente;
                }

                if (consulta.Paciente.idPaciente != consulta.ExameFisico.idPacienteExameFisico) {
                    consulta.ExameFisico.idPacienteExameFisico = consulta.Paciente.idPaciente;
                }

                if (consulta.Paciente.idPaciente != consulta.HipoteseDiagnostica.idPacienteHipoteseDiagnostica) {
                    consulta.HipoteseDiagnostica.idPacienteHipoteseDiagnostica = consulta.Paciente.idPaciente;
                }

                if (consulta.Paciente.idPaciente != consulta.Conduta.idPacienteConduta) {
                    consulta.Conduta.idPacienteConduta = consulta.Paciente.idPaciente;
                }

                DateTime retornoDataConsultaCorrigida = CorrigirDataConsulta(consulta.Consulta.DataConsulta);

                if (retornoDataConsultaCorrigida != default(DateTime)) {
                    consulta.Consulta.DataConsulta = retornoDataConsultaCorrigida;
                    consulta.Consulta.flagPM = true;
                }

                ConsultaDAL consultaDAL = new ConsultaDAL();
                return consultaDAL.EditarConsulta(consulta);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public IniciarAtendimentoModel CarregarDadosAtendimento(int idConsulta) {
            try {
                ConsultaDAL consultaDAL = new ConsultaDAL();
                return consultaDAL.CarregarDadosAtendimento(idConsulta);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<Models.Consulta.IniciarAtendimento.DadosConsulta> ConsultaLista(int idPaciente) {
            try {
                ConsultaDAL consultaDAL = new ConsultaDAL();
                return consultaDAL.ConsultaLista(idPaciente);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<Models.Consulta.IniciarAtendimento.DadosExameLaboratorial> ExameLaboratorialLista(int idPaciente) {
            try {
                ConsultaDAL consultaDAL = new ConsultaDAL();
                return consultaDAL.ExameLaboratorialLista(idPaciente);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<Models.Consulta.EditarConsultaModel.DadosExameLaboratorial> EditarExameLaboratorialLista(int idPaciente) {
            try {
                ConsultaDAL consultaDAL = new ConsultaDAL();
                return consultaDAL.EditarExameLaboratorialLista(idPaciente);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int FinalizarAtendimento(IniciarAtendimentoModel model) {
            try {
                if (model.ExamePedido != null) { 
                    var listaExamePedido = model.ExamePedido.Split(',');
                    var listaExamePedidoFinal = "";
                    for (var i = 0; i < listaExamePedido.Length; i++) {
                        if (listaExamePedido[i] != "") { 
                            if (listaExamePedidoFinal == "") {
                                listaExamePedidoFinal = listaExamePedido[i];
                            } else {
                                listaExamePedidoFinal = listaExamePedidoFinal + "," + listaExamePedido[i];
                            }
                        }
                    }
                    model.ExamePedido = listaExamePedidoFinal;
                }

                if (model.Medicamento != null) {
                    var listaMedicamento = model.Medicamento.Split(',');
                    var listaMedicamentoFinal = "";
                    for (var i = 0; i < listaMedicamento.Length; i++) {
                        if (listaMedicamento[i] != "") {
                            if (listaMedicamentoFinal == "") {
                                listaMedicamentoFinal = listaMedicamento[i];
                            } else {
                                listaMedicamentoFinal = listaMedicamentoFinal + "," + listaMedicamento[i];
                            }
                        }
                    }
                    model.Medicamento = listaMedicamentoFinal;
                }

                ConsultaDAL consultaDAL = new ConsultaDAL();
                return consultaDAL.FinalizarAtendimento(model);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<BaseNomeExame> GetBaseNomeExame() {
            try {
                ConsultaDAL consultaDAL = new ConsultaDAL();
                return consultaDAL.GetBaseNomeExame();
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<GetMedicamento> GetMedicamento() {
            try {
                ConsultaDAL consultaDAL = new ConsultaDAL();
                return consultaDAL.GetMedicamento();
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int CancelarConsulta(int idConsulta) {
            try {
                ConsultaDAL consultaDAL = new ConsultaDAL();
                return consultaDAL.CancelarConsulta(idConsulta);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}