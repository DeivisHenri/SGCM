using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SGCM.AppData.Infraestrutura.CustomMetadataProvider;

namespace SGCM.Models.Consulta.ConsultarConsultaModel {

    public class ConsultarConsultasModel {

        // -------- DATAS SEMANAIS --------
        public DateTime dataSegunda { get; set; }
        public DateTime dataTerca { get; set; }
        public DateTime dataQuarta { get; set; }
        public DateTime dataQuinta { get; set; }
        public DateTime dataSexta { get; set; }

        // -------- COMEÇO SEGUNDA --------
        public QuadroSegundaSeis quadroSegundaSeis { get; set; }
        public QuadroSegundaSeisMeia quadroSegundaSeisMeia { get; set; }
        public QuadroSegundaSete quadroSegundaSete { get; set; }
        public QuadroSegundaSeteMeia quadroSegundaSeteMeia { get; set; }
        public QuadroSegundaOito quadroSegundaOito { get; set; }
        public QuadroSegundaOitoMeia quadroSegundaOitoMeia { get; set; }
        public QuadroSegundaNove quadroSegundaNove { get; set; }
        public QuadroSegundaNoveMeia quadroSegundaNoveMeia { get; set; }
        public QuadroSegundaDez quadroSegundaDez { get; set; }
        public QuadroSegundaDezMeia quadroSegundaDezMeia { get; set; }
        public QuadroSegundaOnze quadroSegundaOnze { get; set; }
        public QuadroSegundaOnzeMeia quadroSegundaOnzeMeia { get; set; }
        public QuadroSegundaDoze quadroSegundaDoze { get; set; }
        public QuadroSegundaDozeMeia quadroSegundaDozeMeia { get; set; }
        public QuadroSegundaTreze quadroSegundaTreze { get; set; }
        public QuadroSegundaTrezeMeia quadroSegundaTrezeMeia { get; set; }
        public QuadroSegundaQuatorze quadroSegundaQuatorze { get; set; }
        public QuadroSegundaQuatorzeMeia quadroSegundaQuatorzeMeia { get; set; }
        public QuadroSegundaQuinze quadroSegundaQuinze { get; set; }
        public QuadroSegundaQuinzeMeia quadroSegundaQuinzeMeia { get; set; }
        public QuadroSegundaDezesseis quadroSegundaDezesseis { get; set; }
        public QuadroSegundaDezesseisMeia quadroSegundaDezesseisMeia { get; set; }
        public QuadroSegundaDezessete quadroSegundaDezessete { get; set; }
        public QuadroSegundaDezesseteMeia quadroSegundaDezesseteMeia { get; set; }
        public QuadroSegundaDezoito quadroSegundaDezoito { get; set; }
        public QuadroSegundaDezoitoMeia quadroSegundaDezoitoMeia { get; set; }

         // -------- COMEÇO TERÇA --------
        public QuadroTercaSeis quadroTercaSeis { get; set; }
        public QuadroTercaSeisMeia quadroTercaSeisMeia { get; set; }
        public QuadroTercaSete quadroTercaSete { get; set; }
        public QuadroTercaSeteMeia quadroTercaSeteMeia { get; set; }
        public QuadroTercaOito quadroTercaOito { get; set; }
        public QuadroTercaOitoMeia quadroTercaOitoMeia { get; set; }
        public QuadroTercaNove quadroTercaNove { get; set; }
        public QuadroTercaNoveMeia quadroTercaNoveMeia { get; set; }
        public QuadroTercaDez quadroTercaDez { get; set; }
        public QuadroTercaDezMeia quadroTercaDezMeia { get; set; }
        public QuadroTercaOnze quadroTercaOnze { get; set; }
        public QuadroTercaOnzeMeia quadroTercaOnzeMeia { get; set; }
        public QuadroTercaDoze quadroTercaDoze { get; set; }
        public QuadroTercaDozeMeia quadroTercaDozeMeia { get; set; }
        public QuadroTercaTreze quadroTercaTreze { get; set; }
        public QuadroTercaTrezeMeia quadroTercaTrezeMeia { get; set; }
        public QuadroTercaQuatorze quadroTercaQuatorze { get; set; }
        public QuadroTercaQuatorzeMeia quadroTercaQuatorzeMeia { get; set; }
        public QuadroTercaQuinze quadroTercaQuinze { get; set; }
        public QuadroTercaQuinzeMeia quadroTercaQuinzeMeia { get; set; }
        public QuadroTercaDezesseis quadroTercaDezesseis { get; set; }
        public QuadroTercaDezesseisMeia quadroTercaDezesseisMeia { get; set; }
        public QuadroTercaDezessete quadroTercaDezessete { get; set; }
        public QuadroTercaDezesseteMeia quadroTercaDezesseteMeia { get; set; }
        public QuadroTercaDezoito quadroTercaDezoito { get; set; }
        public QuadroTercaDezoitoMeia quadroTercaDezoitoMeia { get; set; }

        // -------- COMEÇO QUARTA --------
        public QuadroQuartaSeis quadroQuartaSeis { get; set; }
        public QuadroQuartaSeisMeia quadroQuartaSeisMeia { get; set; }
        public QuadroQuartaSete quadroQuartaSete { get; set; }
        public QuadroQuartaSeteMeia quadroQuartaSeteMeia { get; set; }
        public QuadroQuartaOito quadroQuartaOito { get; set; }
        public QuadroQuartaOitoMeia quadroQuartaOitoMeia { get; set; }
        public QuadroQuartaNove quadroQuartaNove { get; set; }
        public QuadroQuartaNoveMeia quadroQuartaNoveMeia { get; set; }
        public QuadroQuartaDez quadroQuartaDez { get; set; }
        public QuadroQuartaDezMeia quadroQuartaDezMeia { get; set; }
        public QuadroQuartaOnze quadroQuartaOnze { get; set; }
        public QuadroQuartaOnzeMeia quadroQuartaOnzeMeia { get; set; }
        public QuadroQuartaDoze quadroQuartaDoze { get; set; }
        public QuadroQuartaDozeMeia quadroQuartaDozeMeia { get; set; }
        public QuadroQuartaTreze quadroQuartaTreze { get; set; }
        public QuadroQuartaTrezeMeia quadroQuartaTrezeMeia { get; set; }
        public QuadroQuartaQuatorze quadroQuartaQuatorze { get; set; }
        public QuadroQuartaQuatorzeMeia quadroQuartaQuatorzeMeia { get; set; }
        public QuadroQuartaQuinze quadroQuartaQuinze { get; set; }
        public QuadroQuartaQuinzeMeia quadroQuartaQuinzeMeia { get; set; }
        public QuadroQuartaDezesseis quadroQuartaDezesseis { get; set; }
        public QuadroQuartaDezesseisMeia quadroQuartaDezesseisMeia { get; set; }
        public QuadroQuartaDezessete quadroQuartaDezessete { get; set; }
        public QuadroQuartaDezesseteMeia quadroQuartaDezesseteMeia { get; set; }
        public QuadroQuartaDezoito quadroQuartaDezoito { get; set; }
        public QuadroQuartaDezoitoMeia quadroQuartaDezoitoMeia { get; set; }

        // -------- COMEÇO QUINTA --------
        public QuadroQuintaSeis quadroQuintaSeis { get; set; }
        public QuadroQuintaSeisMeia quadroQuintaSeisMeia { get; set; }
        public QuadroQuintaSete quadroQuintaSete { get; set; }
        public QuadroQuintaSeteMeia quadroQuintaSeteMeia { get; set; }
        public QuadroQuintaOito quadroQuintaOito { get; set; }
        public QuadroQuintaOitoMeia quadroQuintaOitoMeia { get; set; }
        public QuadroQuintaNove quadroQuintaNove { get; set; }
        public QuadroQuintaNoveMeia quadroQuintaNoveMeia { get; set; }
        public QuadroQuintaDez quadroQuintaDez { get; set; }
        public QuadroQuintaDezMeia quadroQuintaDezMeia { get; set; }
        public QuadroQuintaOnze quadroQuintaOnze { get; set; }
        public QuadroQuintaOnzeMeia quadroQuintaOnzeMeia { get; set; }
        public QuadroQuintaDoze quadroQuintaDoze { get; set; }
        public QuadroQuintaDozeMeia quadroQuintaDozeMeia { get; set; }
        public QuadroQuintaTreze quadroQuintaTreze { get; set; }
        public QuadroQuintaTrezeMeia quadroQuintaTrezeMeia { get; set; }
        public QuadroQuintaQuatorze quadroQuintaQuatorze { get; set; }
        public QuadroQuintaQuatorzeMeia quadroQuintaQuatorzeMeia { get; set; }
        public QuadroQuintaQuinze quadroQuintaQuinze { get; set; }
        public QuadroQuintaQuinzeMeia quadroQuintaQuinzeMeia { get; set; }
        public QuadroQuintaDezesseis quadroQuintaDezesseis { get; set; }
        public QuadroQuintaDezesseisMeia quadroQuintaDezesseisMeia { get; set; }
        public QuadroQuintaDezessete quadroQuintaDezessete { get; set; }
        public QuadroQuintaDezesseteMeia quadroQuintaDezesseteMeia { get; set; }
        public QuadroQuintaDezoito quadroQuintaDezoito { get; set; }
        public QuadroQuintaDezoitoMeia quadroQuintaDezoitoMeia { get; set; }

        // -------- COMEÇO SEXTA --------
        public QuadroSextaSeis quadroSextaSeis { get; set; }
        public QuadroSextaSeisMeia quadroSextaSeisMeia { get; set; }
        public QuadroSextaSete quadroSextaSete { get; set; }
        public QuadroSextaSeteMeia quadroSextaSeteMeia { get; set; }
        public QuadroSextaOito quadroSextaOito { get; set; }
        public QuadroSextaOitoMeia quadroSextaOitoMeia { get; set; }
        public QuadroSextaNove quadroSextaNove { get; set; }
        public QuadroSextaNoveMeia quadroSextaNoveMeia { get; set; }
        public QuadroSextaDez quadroSextaDez { get; set; }
        public QuadroSextaDezMeia quadroSextaDezMeia { get; set; }
        public QuadroSextaOnze quadroSextaOnze { get; set; }
        public QuadroSextaOnzeMeia quadroSextaOnzeMeia { get; set; }
        public QuadroSextaDoze quadroSextaDoze { get; set; }
        public QuadroSextaDozeMeia quadroSextaDozeMeia { get; set; }
        public QuadroSextaTreze quadroSextaTreze { get; set; }
        public QuadroSextaTrezeMeia quadroSextaTrezeMeia { get; set; }
        public QuadroSextaQuatorze quadroSextaQuatorze { get; set; }
        public QuadroSextaQuatorzeMeia quadroSextaQuatorzeMeia { get; set; }
        public QuadroSextaQuinze quadroSextaQuinze { get; set; }
        public QuadroSextaQuinzeMeia quadroSextaQuinzeMeia { get; set; }
        public QuadroSextaDezesseis quadroSextaDezesseis { get; set; }
        public QuadroSextaDezesseisMeia quadroSextaDezesseisMeia { get; set; }
        public QuadroSextaDezessete quadroSextaDezessete { get; set; }
        public QuadroSextaDezesseteMeia quadroSextaDezesseteMeia { get; set; }
        public QuadroSextaDezoito quadroSextaDezoito { get; set; }
        public QuadroSextaDezoitoMeia quadroSextaDezoitoMeia { get; set; }

        public MarcarDataAusenciaBancoModel dataSegundaAusenciaBancoModel { get; set; }
        public MarcarDataAusenciaBancoModel dataTercaAusenciaBancoModel { get; set; }
        public MarcarDataAusenciaBancoModel dataQuartaAusenciaBancoModel { get; set; }
        public MarcarDataAusenciaBancoModel dataQuintaAusenciaBancoModel { get; set; }
        public MarcarDataAusenciaBancoModel dataSextaAusenciaBancoModel { get; set; }

    }

    // -------- COMEÇO SEGUNDA --------
    public class QuadroSegundaSeis {
        public string seis { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }

    }

    public class QuadroSegundaSeisMeia
    {
        public string seisMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }

    }

    public class QuadroSegundaSete {
        public string sete { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaSeteMeia {
        public string seteMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaOito {
        public string oito { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaOitoMeia {
        public string oitoMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaNove {
        public string nove { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaNoveMeia {
        public string noveMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaDez {
        public string dez { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaDezMeia {
        public string dezMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaOnze {
        public string onze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaOnzeMeia {
        public string onzeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaDoze {
        public string doze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaDozeMeia {
        public string dozeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaTreze {
        public string treze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaTrezeMeia {
        public string trezeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaQuatorze {
        public string quatorze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaQuatorzeMeia {
        public string quatorzeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaQuinze {
        public string quinze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaQuinzeMeia {
        public string quinzeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaDezesseis {
        public string dezesseis { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaDezesseisMeia {
        public string dezesseisMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaDezessete {
        public string dezessete { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaDezesseteMeia {
        public string dezesseteMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaDezoito {
        public string dezoito { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSegundaDezoitoMeia {
        public string dezoitoMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    // -------- COMEÇO TERÇA --------
    public class QuadroTercaSeis {
        public string seis { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }

    }

    public class QuadroTercaSeisMeia {
        public string seisMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }

    }

    public class QuadroTercaSete {
        public string sete { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaSeteMeia {
        public string seteMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaOito {
        public string oito { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaOitoMeia {
        public string oitoMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaNove {
        public string nove { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaNoveMeia {
        public string noveMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaDez {
        public string dez { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaDezMeia {
        public string dezMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaOnze {
        public string onze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaOnzeMeia {
        public string onzeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaDoze {
        public string doze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaDozeMeia {
        public string dozeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaTreze {
        public string treze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaTrezeMeia {
        public string trezeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaQuatorze {
        public string quatorze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaQuatorzeMeia {
        public string quatorzeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaQuinze {
        public string quinze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaQuinzeMeia {
        public string quinzeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaDezesseis {
        public string dezesseis { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaDezesseisMeia {
        public string dezesseisMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaDezessete {
        public string dezessete { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaDezesseteMeia {
        public string dezesseteMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaDezoito {
        public string dezoito { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroTercaDezoitoMeia {
        public string dezoitoMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }


    // -------- COMEÇO QUARTA --------
    public class QuadroQuartaSeis {
        public string seis { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaSeisMeia {
        public string seisMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaSete {
        public string sete { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaSeteMeia {
        public string seteMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaOito {
        public string oito { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaOitoMeia {
        public string oitoMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaNove {
        public string nove { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaNoveMeia {
        public string noveMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaDez {
        public string dez { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaDezMeia {
        public string dezMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaOnze {
        public string onze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaOnzeMeia {
        public string onzeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaDoze {
        public string doze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaDozeMeia {
        public string dozeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaTreze {
        public string treze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaTrezeMeia {
        public string trezeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaQuatorze {
        public string quatorze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaQuatorzeMeia {
        public string quatorzeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaQuinze {
        public string quinze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaQuinzeMeia {
        public string quinzeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaDezesseis {
        public string dezesseis { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaDezesseisMeia {
        public string dezesseisMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaDezessete {
        public string dezessete { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaDezesseteMeia {
        public string dezesseteMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaDezoito {
        public string dezoito { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuartaDezoitoMeia {
        public string dezoitoMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    // -------- COMEÇO QUINTA --------
    public class QuadroQuintaSeis {
        public string seis { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaSeisMeia {
        public string seisMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaSete {
        public string sete { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaSeteMeia {
        public string seteMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaOito {
        public string oito { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaOitoMeia {
        public string oitoMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaNove {
        public string nove { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaNoveMeia {
        public string noveMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaDez {
        public string dez { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaDezMeia {
        public string dezMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaOnze {
        public string onze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaOnzeMeia {
        public string onzeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaDoze {
        public string doze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaDozeMeia {
        public string dozeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaTreze {
        public string treze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaTrezeMeia {
        public string trezeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaQuatorze {
        public string quatorze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaQuatorzeMeia {
        public string quatorzeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaQuinze {
        public string quinze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaQuinzeMeia {
        public string quinzeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaDezesseis {
        public string dezesseis { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaDezesseisMeia {
        public string dezesseisMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaDezessete {
        public string dezessete { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaDezesseteMeia {
        public string dezesseteMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaDezoito {
        public string dezoito { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroQuintaDezoitoMeia {
        public string dezoitoMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    // -------- COMEÇO SEXTA --------
    public class QuadroSextaSeis {
        public string seis { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaSeisMeia {
        public string seisMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaSete {
        public string sete { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaSeteMeia {
        public string seteMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaOito {
        public string oito { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaOitoMeia {
        public string oitoMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaNove {
        public string nove { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaNoveMeia {
        public string noveMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaDez {
        public string dez { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaDezMeia {
        public string dezMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaOnze {
        public string onze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaOnzeMeia {
        public string onzeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaDoze {
        public string doze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaDozeMeia {
        public string dozeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaTreze {
        public string treze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaTrezeMeia {
        public string trezeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaQuatorze {
        public string quatorze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaQuatorzeMeia {
        public string quatorzeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaQuinze {
        public string quinze { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaQuinzeMeia {
        public string quinzeMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaDezesseis {
        public string dezesseis { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaDezesseisMeia {
        public string dezesseisMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaDezessete {
        public string dezessete { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaDezesseteMeia {
        public string dezesseteMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaDezoito {
        public string dezoito { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class QuadroSextaDezoitoMeia {
        public string dezoitoMeia { get; set; }
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idPacienteConsulta { get; set; }
    }

    public class ConsultasQuery {
        public int idPaciente { get; set; }
        public string nome { get; set; }
        public int idConsulta { get; set; }
        public int idPacienteConsulta { get; set; }
        public DateTime dataConsulta { get; set; }
    }

    public class ConsultarConsulta {
        public int idConsulta { get; set; }
        public int idPacienteConsulta { get; set; }
        public DateTime dataConsulta { get; set; }
    }

    public class MarcarDataAusenciaBancoModel {
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public Int32 Seis { get; set; }
        public Int32 SeisMeia { get; set; }
        public Int32 Sete { get; set; }
        public Int32 SeteMeia { get; set; }
        public Int32 Oito { get; set; }
        public Int32 OitoMeia { get; set; }
        public Int32 Nove { get; set; }
        public Int32 NoveMeia { get; set; }
        public Int32 Dez { get; set; }
        public Int32 DezMeia { get; set; }
        public Int32 Onze { get; set; }
        public Int32 OnzeMeia { get; set; }
        public Int32 Doze { get; set; }
        public Int32 DozeMeia { get; set; }
        public Int32 Treze { get; set; }
        public Int32 TrezeMeia { get; set; }
        public Int32 Quatorze { get; set; }
        public Int32 QuatorzeMeia { get; set; }
        public Int32 Quinze { get; set; }
        public Int32 QuinzeMeia { get; set; }
        public Int32 Dezesseis { get; set; }
        public Int32 DezesseisMeia { get; set; }
        public Int32 Dezessete { get; set; }
        public Int32 DezesseteMeia { get; set; }
        public Int32 Dezoito { get; set; }
        public Int32 DezoitoMeia { get; set; }
        public Int32 horaInicio { get; set; }
        public Int32 horaFinal { get; set; }
    }
}