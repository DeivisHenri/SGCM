﻿using System;
using System.Collections.Generic;
using System.Web;
using SGCM;
using SGCM.Models.Account;
using SGCM.AppData.Login;
using SGCM.AppData.Usuario;
using System.Data;
using MySql.Data.MySqlClient;

namespace SGCM.AppData.Login {

    public class LoginDAL : SGCMContext {
        public UsuarioCompletoTO EfetuarLogin(LoginViewModel usuario) {
            try
            {
                var connection = new MySqlConnection(getStringConnection());
                var LoginDALSQL = new LoginDALSQL();

                connection.Open();
                MySqlCommand cmdUsuario = new MySqlCommand(LoginDALSQL.EfetuarLogin(), connection);

                cmdUsuario.Parameters.Add("@USUARIO", MySqlDbType.String).Value = usuario.Username;
                cmdUsuario.Parameters.Add("@SENHA", MySqlDbType.String).Value = usuario.Password;

                MySqlDataReader dr = cmdUsuario.ExecuteReader();

                UsuarioCompletoTO loginCompletoTO = new UsuarioCompletoTO();
                loginCompletoTO.usuarioTO = new UsuarioTO();
                loginCompletoTO.pessoaTO = new PessoaTO();
                loginCompletoTO.permissoesTO = new PermissoesTO();
                
                if (dr.HasRows) {
                    while (dr.Read())
                    {
                        if (dr.IsDBNull(56)) {
                            loginCompletoTO.usuarioTO.idUsuario = dr.GetInt32(0);
                            loginCompletoTO.usuarioTO.Usuario = dr.GetString(1);
                            
                            loginCompletoTO.pessoaTO.idPessoa = dr.GetInt32(2);
                            loginCompletoTO.pessoaTO.idMedico = dr.GetInt32(3);
                            loginCompletoTO.pessoaTO.tipoUsuario = dr.GetInt32(4);
                            loginCompletoTO.pessoaTO.Nome = dr.GetString(5);
                            loginCompletoTO.pessoaTO.Cpf = dr.GetString(6);
                            loginCompletoTO.pessoaTO.Rg = dr.GetString(7);
                            loginCompletoTO.pessoaTO.DataNascimento = dr.GetString(8);
                            loginCompletoTO.pessoaTO.Logradouro = dr.GetString(9);
                            loginCompletoTO.pessoaTO.Numero = dr.GetInt32(10);
                            loginCompletoTO.pessoaTO.Bairro = dr.GetString(11);
                            loginCompletoTO.pessoaTO.Cidade = dr.GetString(12);
                            loginCompletoTO.pessoaTO.Uf = dr.GetString(13);
                            loginCompletoTO.pessoaTO.Telefone_Celular = dr.GetString(14);
                            loginCompletoTO.pessoaTO.Email = dr.GetString(15);
                            
                            loginCompletoTO.permissoesTO.flUsuarioI = dr.GetInt32(16);
                            loginCompletoTO.permissoesTO.flUsuarioC = dr.GetInt32(17);
                            loginCompletoTO.permissoesTO.flUsuarioA = dr.GetInt32(18);
                            loginCompletoTO.permissoesTO.flUsuarioE = dr.GetInt32(19);

                            loginCompletoTO.permissoesTO.flPacienteI = dr.GetInt32(20);
                            loginCompletoTO.permissoesTO.flPacienteC = dr.GetInt32(21);
                            loginCompletoTO.permissoesTO.flPacienteA = dr.GetInt32(22);
                            loginCompletoTO.permissoesTO.flPacienteE = dr.GetInt32(23);

                            loginCompletoTO.permissoesTO.flConsultaI = dr.GetInt32(24);
                            loginCompletoTO.permissoesTO.flConsultaC = dr.GetInt32(25);
                            loginCompletoTO.permissoesTO.flConsultaA = dr.GetInt32(26);
                            loginCompletoTO.permissoesTO.flConsultaE = dr.GetInt32(27);

                            loginCompletoTO.permissoesTO.flAusenciaI = dr.GetInt32(28);
                            loginCompletoTO.permissoesTO.flAusenciaC = dr.GetInt32(29);
                            loginCompletoTO.permissoesTO.flAusenciaA = dr.GetInt32(30);
                            loginCompletoTO.permissoesTO.flAusenciaE = dr.GetInt32(31);

                            loginCompletoTO.permissoesTO.flMedicamentoI = dr.GetInt32(32);
                            loginCompletoTO.permissoesTO.flMedicamentoC = dr.GetInt32(33);
                            loginCompletoTO.permissoesTO.flMedicamentoA = dr.GetInt32(34);
                            loginCompletoTO.permissoesTO.flMedicamentoE = dr.GetInt32(35);

                            loginCompletoTO.permissoesTO.flExamesI = dr.GetInt32(36);
                            loginCompletoTO.permissoesTO.flExamesC = dr.GetInt32(37);
                            loginCompletoTO.permissoesTO.flExamesA = dr.GetInt32(38);
                            loginCompletoTO.permissoesTO.flExamesE = dr.GetInt32(39);

                            loginCompletoTO.permissoesTO.flHistoriaMolestiaAtualI = dr.GetInt32(40);
                            loginCompletoTO.permissoesTO.flHistoriaMolestiaAtualC = dr.GetInt32(41);
                            loginCompletoTO.permissoesTO.flHistoriaMolestiaAtualA = dr.GetInt32(42);
                            loginCompletoTO.permissoesTO.flHistoriaMolestiaAtualE = dr.GetInt32(43);

                            loginCompletoTO.permissoesTO.flHistoriaPatologicaPregressaI = dr.GetInt32(44);
                            loginCompletoTO.permissoesTO.flHistoriaPatologicaPregressaC = dr.GetInt32(45);
                            loginCompletoTO.permissoesTO.flHistoriaPatologicaPregressaA = dr.GetInt32(46);
                            loginCompletoTO.permissoesTO.flHistoriaPatologicaPregressaE = dr.GetInt32(47);

                            loginCompletoTO.permissoesTO.flHipoteseDiagnosticaI = dr.GetInt32(48);
                            loginCompletoTO.permissoesTO.flHipoteseDiagnosticaC = dr.GetInt32(49);
                            loginCompletoTO.permissoesTO.flHipoteseDiagnosticaA = dr.GetInt32(50);
                            loginCompletoTO.permissoesTO.flHipoteseDiagnosticaE = dr.GetInt32(51);

                            loginCompletoTO.permissoesTO.flCondutaI = dr.GetInt32(52);
                            loginCompletoTO.permissoesTO.flCondutaC = dr.GetInt32(53);
                            loginCompletoTO.permissoesTO.flCondutaA = dr.GetInt32(54);
                            loginCompletoTO.permissoesTO.flCondutaE = dr.GetInt32(55);
                        } else {
                            loginCompletoTO.IdRetorno = 1;
                            return loginCompletoTO;
                        }
                    }
                } else {
                    loginCompletoTO.IdRetorno = 2;
                    return loginCompletoTO;
                }
                connection.Close();

                return loginCompletoTO;

            } catch (Exception ex) {
                throw ex;
            }
        }

        public UsuarioCompletoTO BuscarDadosUsuario(string usuarioCookie) {
            try {
                var connection = new MySqlConnection(getStringConnection());
                var LoginDALSQL = new LoginDALSQL();

                connection.Open();
                MySqlCommand cmdUsuario = new MySqlCommand(LoginDALSQL.BuscarDadosUsuario(), connection);

                cmdUsuario.Parameters.Add("@USUARIO", MySqlDbType.String).Value = usuarioCookie;

                MySqlDataReader dr = cmdUsuario.ExecuteReader();

                UsuarioCompletoTO loginCompletoTO = new UsuarioCompletoTO();
                loginCompletoTO.usuarioTO = new UsuarioTO();
                loginCompletoTO.pessoaTO = new PessoaTO();
                loginCompletoTO.permissoesTO = new PermissoesTO();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        loginCompletoTO.usuarioTO.idUsuario = dr.GetInt32(0);
                        loginCompletoTO.usuarioTO.Usuario = dr.GetString(1);

                        loginCompletoTO.pessoaTO.idPessoa = dr.GetInt32(2);
                        loginCompletoTO.pessoaTO.idMedico = dr.GetInt32(3);
                        loginCompletoTO.pessoaTO.tipoUsuario = dr.GetInt32(4);
                        loginCompletoTO.pessoaTO.Nome = dr.GetString(5);
                        loginCompletoTO.pessoaTO.Cpf = dr.GetString(6);
                        loginCompletoTO.pessoaTO.Rg = dr.GetString(7);
                        loginCompletoTO.pessoaTO.DataNascimento = dr.GetString(8);
                        loginCompletoTO.pessoaTO.Logradouro = dr.GetString(9);
                        loginCompletoTO.pessoaTO.Numero = dr.GetInt32(10);
                        loginCompletoTO.pessoaTO.Bairro = dr.GetString(11);
                        loginCompletoTO.pessoaTO.Cidade = dr.GetString(12);
                        loginCompletoTO.pessoaTO.Uf = dr.GetString(13);
                        loginCompletoTO.pessoaTO.Telefone_Celular = dr.GetString(14);
                        loginCompletoTO.pessoaTO.Email = dr.GetString(15);

                        loginCompletoTO.permissoesTO.flUsuarioI = dr.GetInt32(16);
                        loginCompletoTO.permissoesTO.flUsuarioC = dr.GetInt32(17);
                        loginCompletoTO.permissoesTO.flUsuarioA = dr.GetInt32(18);
                        loginCompletoTO.permissoesTO.flUsuarioE = dr.GetInt32(19);
                        loginCompletoTO.permissoesTO.flPacienteI = dr.GetInt32(20);
                        loginCompletoTO.permissoesTO.flPacienteC = dr.GetInt32(21);
                        loginCompletoTO.permissoesTO.flPacienteA = dr.GetInt32(22);
                        loginCompletoTO.permissoesTO.flPacienteE = dr.GetInt32(23);
                        loginCompletoTO.permissoesTO.flConsultaI = dr.GetInt32(24);
                        loginCompletoTO.permissoesTO.flConsultaC = dr.GetInt32(25);
                        loginCompletoTO.permissoesTO.flConsultaA = dr.GetInt32(26);
                        loginCompletoTO.permissoesTO.flConsultaE = dr.GetInt32(27);
                        loginCompletoTO.permissoesTO.flMedicamentoI = dr.GetInt32(28);
                        loginCompletoTO.permissoesTO.flMedicamentoC = dr.GetInt32(29);
                        loginCompletoTO.permissoesTO.flMedicamentoA = dr.GetInt32(30);
                        loginCompletoTO.permissoesTO.flMedicamentoE = dr.GetInt32(31);
                        loginCompletoTO.permissoesTO.flExamesI = dr.GetInt32(32);
                        loginCompletoTO.permissoesTO.flExamesC = dr.GetInt32(33);
                        loginCompletoTO.permissoesTO.flExamesA = dr.GetInt32(34);
                        loginCompletoTO.permissoesTO.flExamesE = dr.GetInt32(35);
                    }
                }
                else
                {
                    loginCompletoTO.IdRetorno = 2;
                    return loginCompletoTO;
                }
                connection.Close();

                return loginCompletoTO;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}