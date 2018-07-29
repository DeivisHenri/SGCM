using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGCM.Models;

namespace SGCM.AppData {

    public class SGCMContext {

        public string StringConnection { get; }

        public string getStringConnection() {
            return "Server=LAPTOP-VDTPL8DF\\SQLEXPRESS;Database=SisGerCliMed;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

    }
}
