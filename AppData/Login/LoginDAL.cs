using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using SGCM;
using SGCM.Models.Account;
using SGCM.AppData.Login;

namespace SGCM.AppData.Login {

    public class LoginDAL : SGCMContext {
        public LoginTO EfetuarLogin(LoginViewModel usuario) {
            try {
                var connection = new SqlConnection(getStringConnection());
                var DALSQL = new LoginDALSQL();

                connection.Open();
                SqlCommand cmd = new SqlCommand(DALSQL.EfetuarLogin(usuario), connection);
                SqlDataReader dr = cmd.ExecuteReader();
                LoginTO login = new LoginTO();

                if (dr.HasRows) {
                    while (dr.Read()) {
                        login.ID = dr.GetInt32(0);
                        login.username = dr.GetString(1);
                        login.password = dr.GetString(2);
                        login.tipoUsuario = dr.GetInt32(3);
                        login.FlUsuarioI = dr.GetInt32(4);
                        login.FlUsuarioC = dr.GetInt32(5);
                        login.FlUsuarioA = dr.GetInt32(6);
                        login.FlUsuarioE = dr.GetInt32(7);
                        login.FlPacienteI = dr.GetInt32(8);
                        login.FlPacienteC = dr.GetInt32(9);
                        login.FlPacienteA = dr.GetInt32(10);
                        login.FlPacienteE = dr.GetInt32(11);
                        login.FlMedicamentoI = dr.GetInt32(12);
                        login.FlMedicamentoC = dr.GetInt32(13);
                        login.FlMedicamentoA = dr.GetInt32(14);
                        login.FlMedicamentoE = dr.GetInt32(15);
                        login.FlExamesI = dr.GetInt32(16);
                        login.FlExamesC = dr.GetInt32(17);
                        login.FlExamesA = dr.GetInt32(18);
                        login.FlExamesE = dr.GetInt32(19);
                    }
                }
                connection.Close();

                if (!login.Equals(null)) {
                    return login;
                } else {
                    return null;
                }

            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}