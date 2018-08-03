using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGCM.AppData.Login {

    public class LoginTO {

        public int ID { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public int tipoUsuario { get; set; }

        public int FlUsuarioI { get; set; }
        public int FlUsuarioC { get; set; }
        public int FlUsuarioA { get; set; }
        public int FlUsuarioE { get; set; }
                   
        public int FlPacienteI { get; set; }
        public int FlPacienteC { get; set; }
        public int FlPacienteA { get; set; }
        public int FlPacienteE { get; set; }

        public int FlMedicamentoI { get; set; }
        public int FlMedicamentoC { get; set; }
        public int FlMedicamentoA { get; set; }
        public int FlMedicamentoE { get; set; }

        public int FlExamesI { get; set; }
        public int FlExamesC { get; set; }
        public int FlExamesA { get; set; }
        public int FlExamesE { get; set; }
        

    }
}