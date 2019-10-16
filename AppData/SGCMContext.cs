using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using SGCM.Models;

namespace SGCM.AppData {
    public class SGCMContext {
        /* CONEXÃO LOCALHOST */
        //private static string Server = "localhost";
        //private static string DataBase = "sgcm";
        //private static string User = "root";
        //private static string Password = "";

        //private string ConnectionString = $"Server={Server};DataBase={DataBase};Uid={User};Pwd={Password};Sslmode=none;"

        /* CONEXÃO SMARTERNET */
        private static string Server = "MYSQL5012.site4now.net";
        private static string DataBase = "db_a4a495_deivish";
        private static string User = "a4a495_deivish";
        private static string Password = "ShaftDeivis123";

        private string ConnectionString = $"Server={Server};Database={DataBase};Uid={User};Pwd={Password}";

        public string StringConnection { get; }

        public string getStringConnection()
        {
            return ConnectionString;
        }

    }


    /*
     * 
     * String de conexão para o SQL Server
     */
    //public class SGCMContext {

    //    public string StringConnection { get; }

    //    /*
    //     String de conecção para o NOOTBOOK
    //     */
    //    public string getStringConnection() {
    //        return "Server=LAPTOP-VDTPL8DF\\SQLEXPRESS;Database=SisGerCliMed;Trusted_Connection=True;MultipleActiveResultSets=true";
    //    }
    //    /*
    //     String de conecção para o DESKTOP
    //    /*
    //    public string getStringConnection()
    //    {
    //       return "Server=DESKTOP-1ASKAE7\\SQLEXPRESS;Database=SisGerCliMed;Trusted_Connection=True;MultipleActiveResultSets=true";
    //    }
    //}
    //DESKTOP-1ASKAE7
    //np:\\.\pipe\LOCALDB#DDA78D54\tsql\query
    //DESKTOP-1ASKAE7\LOCALDB#DDA78D54
}
