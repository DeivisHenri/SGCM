using SGCM.Models.Paciente.CadastroPacienteModel;
using SGCM.Models.Paciente.ConsultarPacienteModel;
using SGCM.Models.Paciente.EditarPacienteModel;
using System;
using System.Transactions;
using MySql.Data.MySqlClient;
using SGCM.AppData.Infraestrutura.UtilMetodo;
using System.Collections.Generic;

namespace SGCM.AppData.Paciente
{
    public class PacienteDAL : SGCMContext {

        //public List<CadastroUsuarioModel> ConsultarUsuario(int IdPessoa)
        //{
        //    try
        //    {
        //        List<CadastroUsuarioModel> usuarioCompletoTOList = new List<CadastroUsuarioModel>();

        //        SqlConnection connection = new SqlConnection(getStringConnection());
        //        connection.Open();

        //        var DALSQL = new UsuarioDALSQL();
        //        SqlCommand cmdUsuario = new SqlCommand(DALSQL.ConsultarUsuario(), connection);
        //        cmdUsuario.Parameters.Add("@IDPESSOA", SqlDbType.Int).Value = IdPessoa;

        //        SqlDataReader reader = cmdUsuario.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                CadastroUsuarioModel usuarioCompletoTO = new CadastroUsuarioModel();
        //                usuarioCompletoTO.pessoa = new Models.Usuario.CadastroUsuarioModel.DadosPessoais();
        //                usuarioCompletoTO.usuario = new Models.Usuario.CadastroUsuarioModel.DadosLogin();
        //                usuarioCompletoTO.permissoes = new Models.Usuario.CadastroUsuarioModel.DadosPermissoes();

        //                usuarioCompletoTO.pessoa.Nome = reader.GetString(0);
        //                usuarioCompletoTO.pessoa.CPF = reader.GetString(1);
        //                usuarioCompletoTO.pessoa.Telefone_Celular = reader.GetString(2);
        //                usuarioCompletoTO.pessoa.IdPessoa = reader.GetInt32(3);
        //                usuarioCompletoTO.usuario.IdUsuario = reader.GetInt32(4);
        //                usuarioCompletoTO.permissoes.IdPermissoes = reader.GetInt32(5);

        //                usuarioCompletoTOList.Add(usuarioCompletoTO);
        //            }
        //            reader.NextResult();
        //        }
        //        reader.Close();
        //        connection.Close();

        //        return usuarioCompletoTOList;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public int InserirPaciente(CadastroPacienteModel paciente) {
            using (TransactionScope scope = new TransactionScope()) {
                try {
                    var DALSQL = new PacienteDALSQL();
                    Decimal retorno = 0;

                    using (MySqlConnection connection = new MySqlConnection(getStringConnection())) {
                      
                        connection.Open();

                        MySqlCommand cmdPessoa = new MySqlCommand(DALSQL.InserirPessoa(), connection);

                        cmdPessoa.Parameters.Add("@IDMEDICO", MySqlDbType.String).Value = paciente.pessoa.IdMedico;
                        cmdPessoa.Parameters.Add("@NOME", MySqlDbType.String).Value = paciente.pessoa.Nome;
                        cmdPessoa.Parameters.Add("@SEXO", MySqlDbType.Int32).Value = paciente.pessoa.Sexo;
                        cmdPessoa.Parameters.Add("@CPF", MySqlDbType.String).Value = paciente.pessoa.CPF;
                        cmdPessoa.Parameters.Add("@RG", MySqlDbType.String).Value = paciente.pessoa.RG;
                        cmdPessoa.Parameters.Add("@DATANASCIMENTO", MySqlDbType.String).Value = paciente.pessoa.DataNascimento;
                        cmdPessoa.Parameters.Add("@LOGRADOURO", MySqlDbType.String).Value = paciente.pessoa.Logradouro;
                        cmdPessoa.Parameters.Add("@NUMERO", MySqlDbType.Int32).Value = paciente.pessoa.Numero;
                        cmdPessoa.Parameters.Add("@BAIRRO", MySqlDbType.String).Value = paciente.pessoa.Bairro;
                        cmdPessoa.Parameters.Add("@CIDADE", MySqlDbType.String).Value = paciente.pessoa.Cidade;
                        cmdPessoa.Parameters.Add("@UF", MySqlDbType.String).Value = paciente.pessoa.Uf;
                        cmdPessoa.Parameters.Add("@TELEFONECELULAR", MySqlDbType.String).Value = paciente.pessoa.TelefoneCelular;
                        cmdPessoa.Parameters.Add("@EMAIL", MySqlDbType.String).Value = paciente.pessoa.Email;

                        retorno = cmdPessoa.ExecuteNonQuery();

                        MySqlCommand cmdLastId = new MySqlCommand(UtilMetodo.ConsultarUltimoIdInseridoNoBanco(), connection);
                        var lastId = cmdLastId.ExecuteScalar();

                        MySqlCommand cmdConsulta = new MySqlCommand(DALSQL.ConsultaIdConsulta(), connection);
                        var idConsulta = cmdConsulta.ExecuteScalar();

                        if (idConsulta.ToString() == "") {
                            idConsulta = 1;
                        } else {
                            idConsulta = (int)idConsulta + 1;
                        }

                        MySqlCommand cmdExame = new MySqlCommand(DALSQL.ConsultaIdExame(), connection);
                        var IdExame = cmdExame.ExecuteScalar();

                        if (IdExame.ToString() == "") {
                            IdExame = 1;
                        } else {
                            IdExame = (int)IdExame + 1;
                        }

                        MySqlCommand cmdMedicamento = new MySqlCommand(DALSQL.ConsultaIdMedicamento(), connection);
                        var IdMedicamento = cmdMedicamento.ExecuteScalar();

                        if (IdMedicamento.ToString() == "") {
                            IdMedicamento = 1;
                        } else {
                            IdMedicamento = (int)IdMedicamento + 1;
                        }

                        MySqlCommand cmdReceita = new MySqlCommand(DALSQL.ConsultaIdReceita(), connection);
                        var IdReceita = cmdReceita.ExecuteScalar();

                        if (IdReceita.ToString() == "") {
                            IdReceita = 1;
                        } else {
                            IdReceita = (int)IdReceita + 1;
                        }

                        MySqlCommand cmdPaciente = new MySqlCommand(DALSQL.InserirPaciente(), connection);

                        cmdPaciente.Parameters.Add("@IDPESSOA", MySqlDbType.Int32).Value = Convert.ToInt32(lastId.ToString());
                        cmdPaciente.Parameters.Add("@IDMEDICO", MySqlDbType.Int32).Value = Convert.ToInt32(paciente.pessoa.IdMedico);
                        cmdPaciente.Parameters.Add("@IDCONSULTA", MySqlDbType.Int32).Value = Convert.ToInt32(idConsulta.ToString());
                        cmdPaciente.Parameters.Add("@IDEXAME", MySqlDbType.Int32).Value = Convert.ToInt32(IdExame.ToString());
                        cmdPaciente.Parameters.Add("@IDMEDICAMENTO", MySqlDbType.Int32).Value = Convert.ToInt32(IdMedicamento.ToString());
                        cmdPaciente.Parameters.Add("@IDRECEITA", MySqlDbType.Int32).Value = Convert.ToInt32(IdReceita.ToString());

                        retorno = retorno + cmdPaciente.ExecuteNonQuery();

                        if (retorno == 2) {
                            scope.Complete();
                            connection.Close();
                            return (int) retorno;
                        } else {
                            scope.Dispose();
                            connection.Close();
                            throw new Exception();
                        }
                    }
                } catch (Exception ex) {
                    throw ex;
                }
            }
        }

        public List<ConsultarPacienteModel> ConsultarPaciente(int IdMedico) {
            MySqlConnection connection = new MySqlConnection(getStringConnection());

            try {
                List<ConsultarPacienteModel> pacienteList = new List<ConsultarPacienteModel>();                
                connection.Open();

                var DALSQL = new PacienteDALSQL();
                MySqlCommand cmdConsultarPaciente = new MySqlCommand(DALSQL.ConsultarPaciente(), connection);
                cmdConsultarPaciente.Parameters.Add("@IDMEDICO", MySqlDbType.Int32).Value = IdMedico;

                MySqlDataReader reader = cmdConsultarPaciente.ExecuteReader();

                if (reader.HasRows) {
                    while (reader.Read()) {
                        ConsultarPacienteModel pacienteListModel = new ConsultarPacienteModel();
                        pacienteListModel.pessoa = new Models.Paciente.ConsultarPacienteModel.DadosPessoais();

                        pacienteListModel.pessoa.IdPessoa = reader.GetInt32(0);
                        pacienteListModel.pessoa.Nome = reader.GetString(1);
                        pacienteListModel.pessoa.CPF = reader.GetString(2);
                        pacienteListModel.pessoa.TelefoneCelular = reader.GetString(3);

                        pacienteList.Add(pacienteListModel);
                    }
                    reader.NextResult();
                } else {
                    reader.Close();
                    connection.Close();
                    return null;
                }
                reader.Close();
                connection.Close();

                return pacienteList;
            }
            catch (Exception ex) {
                connection.Close();
                throw ex;
            }
        }

        public EditarPacienteModel ConsultarPacienteID(int IdPessoa) {
            try {
                MySqlConnection connection = new MySqlConnection(getStringConnection());
                connection.Open();

                var DALSQL = new PacienteDALSQL();
                MySqlCommand cmdUsuario = new MySqlCommand(DALSQL.ConsultarPacienteID(), connection);
                cmdUsuario.Parameters.Add("@IDPESSOA", MySqlDbType.Int32).Value = IdPessoa;
                MySqlDataReader reader = cmdUsuario.ExecuteReader();

                EditarPacienteModel pacienteCompleto = new EditarPacienteModel();
                pacienteCompleto.pessoa = new Models.Paciente.EditarPacienteModel.DadosPessoais();

                if (reader.HasRows) {
                    while (reader.Read()) {
                        pacienteCompleto.pessoa.IdPessoa = reader.GetInt32(0);
                        pacienteCompleto.pessoa.Nome = reader.GetString(1);
                        pacienteCompleto.pessoa.CPF = reader.GetString(2);
                        pacienteCompleto.pessoa.RG = reader.GetString(3);
                        pacienteCompleto.pessoa.Sexo = reader.GetString(4);
                        pacienteCompleto.pessoa.DataNascimento = reader.GetDateTime(5);
                        pacienteCompleto.pessoa.Logradouro = reader.GetString(6);
                        pacienteCompleto.pessoa.Numero = reader.GetInt32(7);
                        pacienteCompleto.pessoa.Bairro = reader.GetString(8);
                        pacienteCompleto.pessoa.Cidade = reader.GetString(9);
                        pacienteCompleto.pessoa.Uf = reader.GetString(10);
                        pacienteCompleto.pessoa.TelefoneCelular = reader.GetString(11);
                        pacienteCompleto.pessoa.Email = reader.GetString(12);
                    }
                }
                reader.Close();
                connection.Close();

                return pacienteCompleto;

            } catch (Exception ex) {
                throw ex;
            }
        }

        public int EditarPaciente(EditarPacienteModel pacienteModel) {
            using (TransactionScope scope = new TransactionScope()) {
                try {
                    var DALSQL = new PacienteDALSQL();
                    using (MySqlConnection connection = new MySqlConnection(getStringConnection())) {
                        var retorno = 0;

                        connection.Open();

                        MySqlCommand cmdPessoa = new MySqlCommand(DALSQL.EditarPessoa(pacienteModel), connection);

                        cmdPessoa.Parameters.Add("@IDPESSOA", MySqlDbType.Int32).Value = pacienteModel.pessoa.IdPessoa;
                        cmdPessoa.Parameters.Add("@SEXO", MySqlDbType.Int32).Value = pacienteModel.pessoa.Sexo;
                        cmdPessoa.Parameters.Add("@NOME", MySqlDbType.String).Value = pacienteModel.pessoa.Nome;
                        cmdPessoa.Parameters.Add("@CPF", MySqlDbType.String).Value = pacienteModel.pessoa.CPF;
                        cmdPessoa.Parameters.Add("@RG", MySqlDbType.String).Value = pacienteModel.pessoa.RG;
                        cmdPessoa.Parameters.Add("@DATANASCIMENTO", MySqlDbType.String).Value = pacienteModel.pessoa.DataNascimento.ToShortDateString();
                        cmdPessoa.Parameters.Add("@LOGRADOURO", MySqlDbType.String).Value = pacienteModel.pessoa.Logradouro;
                        cmdPessoa.Parameters.Add("@NUMERO", MySqlDbType.Int32).Value = pacienteModel.pessoa.Numero;
                        cmdPessoa.Parameters.Add("@BAIRRO", MySqlDbType.String).Value = pacienteModel.pessoa.Bairro;
                        cmdPessoa.Parameters.Add("@CIDADE", MySqlDbType.String).Value = pacienteModel.pessoa.Cidade;
                        cmdPessoa.Parameters.Add("@UF", MySqlDbType.String).Value = pacienteModel.pessoa.Uf;
                        cmdPessoa.Parameters.Add("@TELEFONECELULAR", MySqlDbType.String).Value = pacienteModel.pessoa.TelefoneCelular;
                        cmdPessoa.Parameters.Add("@EMAIL", MySqlDbType.String).Value = pacienteModel.pessoa.Email;

                        retorno = cmdPessoa.ExecuteNonQuery();

                        if (retorno == 1) {
                            scope.Complete();
                            connection.Close();
                            return retorno;
                        } else {
                            connection.Close();
                            throw new Exception();
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
