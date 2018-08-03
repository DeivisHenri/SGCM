using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGCM.Models;


namespace SGCM.Controllers
{
    public class PacienteController : Controller
    {
        // GET: /Patient/CadastroPaciente 
        public ActionResult CadastroPaciente()
        {
            if ((HttpContext.Session.GetInt32("ID") != null) && (HttpContext.Session.GetInt32("ID") != 0))
            {
                if (HttpContext.Session.GetInt32("FlPacienteC") == 1) { 
                    CarregaDadosUsuarioSessaoParaTela();
                    return View();
                }
                else
                {
                    HttpContext.Session.SetInt32("Login", 1);
                    HttpContext.Session.SetString("Message", "Entre no sistema antes de tentar navegar por ele!");
                    return Redirect("/Home/Error");
                }
            } else{
                HttpContext.Session.SetInt32("Login", 1);
                HttpContext.Session.SetString("Message", "Entre no sistema antes de tentar navegar por ele!");
                return Redirect("/Home/Error");
            }

        }
        private void CarregaDadosUsuarioSessaoParaTela()
        {
            ViewBag.ID = HttpContext.Session.GetInt32("ID");
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            ViewBag.TipoUsuario = HttpContext.Session.GetInt32("TipoUsuario");

            ViewBag.FlUsuarioI = HttpContext.Session.GetInt32("FlUsuarioI");
            ViewBag.FlUsuarioC = HttpContext.Session.GetInt32("FlUsuarioC");
            ViewBag.FlUsuarioA = HttpContext.Session.GetInt32("FlUsuarioA");
            ViewBag.FlUsuarioE = HttpContext.Session.GetInt32("FlUsuarioE");

            ViewBag.FlPacienteI = HttpContext.Session.GetInt32("FlPacienteI");
            ViewBag.FlPacienteC = HttpContext.Session.GetInt32("FlPacienteC");
            ViewBag.FlPacienteA = HttpContext.Session.GetInt32("FlPacienteA");
            ViewBag.FlPacienteE = HttpContext.Session.GetInt32("FlPacienteE");

            ViewBag.FlMedicamentoI = HttpContext.Session.GetInt32("FlMedicamentoI");
            ViewBag.FlMedicamentoC = HttpContext.Session.GetInt32("FlMedicamentoC");
            ViewBag.FlMedicamentoA = HttpContext.Session.GetInt32("FlMedicamentoA");
            ViewBag.FlMedicamentoE = HttpContext.Session.GetInt32("FlMedicamentoE");

            ViewBag.FlExamesI = HttpContext.Session.GetInt32("FlExamesI");
            ViewBag.FlExamesC = HttpContext.Session.GetInt32("FlExamesC");
            ViewBag.FlExamesA = HttpContext.Session.GetInt32("FlExamesA");
            ViewBag.FlExamesE = HttpContext.Session.GetInt32("FlExamesE");
        }
    }
}
