using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGCM.Models;

namespace SGCM.AppData {

    public class SGCMContext {

        public string StringConnection { get; }

        /*
         String de conecção para o NOOTBOOK
         */
        //public string getStringConnection() {
        //    return "Server=LAPTOP-VDTPL8DF\\SQLEXPRESS;Database=SisGerCliMed;Trusted_Connection=True;MultipleActiveResultSets=true";
        //}

        /*
         String de conecção para o DESKTOP
         */
        public string getStringConnection()
        {
            return "Server=DESKTOP-1ASKAE7\\SQLEXPRESS;Database=SisGerCliMed;Trusted_Connection=True;MultipleActiveResultSets=true";
        }
    }
    //DESKTOP-1ASKAE7
    //np:\\.\pipe\LOCALDB#DDA78D54\tsql\query
    //DESKTOP-1ASKAE7\LOCALDB#DDA78D54
}
