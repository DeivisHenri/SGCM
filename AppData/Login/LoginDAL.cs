using SGCM.Models;
using System;
using System.Collections.Generic;
using System.Web;
using SGCM.AppData.Login;
using System.Data.SqlClient;
using SGCM;

namespace SGCM.AppData.Login {

    public class LoginDAL : SGCMContext {
        public LoginTO EfetuarLogin(EfetuarLoginModel usuario) {
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