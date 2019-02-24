using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGCM.Models;
using SGCM.AppData.Usuario;

namespace SGCM.Controllers
{
    public class SessionController : Controller
    {
        public ActionResult SessionView(){
            if ((HttpContext.Session.GetInt32("idUsuario") != null) && (HttpContext.Session.GetInt32("idUsuario") != 0))
            {
                CarregarDadosUsuarioParaTela();
            }
            else
            {
                ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
            }
            return View();
        }

        private void CarregarDadosUsuarioParaSession(UsuarioCompletoTO usuarioCompletoTO)
        {
            HttpContext.Session.SetInt32("idUsuario", usuarioCompletoTO.usuarioTO.idUsuario);
            HttpContext.Session.SetString("usuario", usuarioCompletoTO.usuarioTO.Usuario);

            HttpContext.Session.SetInt32("idPessoa", usuarioCompletoTO.pessoaTO.idPessoa);
            HttpContext.Session.SetInt32("idMedico", usuarioCompletoTO.pessoaTO.idMedico);
            HttpContext.Session.SetInt32("tipoUsuario", usuarioCompletoTO.pessoaTO.tipoUsuario);
            HttpContext.Session.SetString("nome", usuarioCompletoTO.pessoaTO.Nome);
            HttpContext.Session.SetString("cpf", usuarioCompletoTO.pessoaTO.Cpf);
            HttpContext.Session.SetString("rg", usuarioCompletoTO.pessoaTO.Rg);
            HttpContext.Session.SetString("dataNascimento", usuarioCompletoTO.pessoaTO.DataNascimento);
            HttpContext.Session.SetString("logradouro", usuarioCompletoTO.pessoaTO.Logradouro);
            HttpContext.Session.SetInt32("numero", usuarioCompletoTO.pessoaTO.Numero);
            HttpContext.Session.SetString("bairro", usuarioCompletoTO.pessoaTO.Bairro);
            HttpContext.Session.SetString("cidade", usuarioCompletoTO.pessoaTO.Cidade);
            HttpContext.Session.SetString("uf", usuarioCompletoTO.pessoaTO.Uf);
            HttpContext.Session.SetString("telefoneCelular", usuarioCompletoTO.pessoaTO.Telefone_Celular);
            HttpContext.Session.SetString("email", usuarioCompletoTO.pessoaTO.Email);

            HttpContext.Session.SetInt32("FlUsuarioI", usuarioCompletoTO.permissoesTO.flUsuarioI);
            HttpContext.Session.SetInt32("FlUsuarioC", usuarioCompletoTO.permissoesTO.flUsuarioC);
            HttpContext.Session.SetInt32("FlUsuarioA", usuarioCompletoTO.permissoesTO.flUsuarioA);
            HttpContext.Session.SetInt32("FlUsuarioE", usuarioCompletoTO.permissoesTO.flUsuarioE);

            HttpContext.Session.SetInt32("FlPacienteI", usuarioCompletoTO.permissoesTO.flPacienteI);
            HttpContext.Session.SetInt32("FlPacienteC", usuarioCompletoTO.permissoesTO.flPacienteC);
            HttpContext.Session.SetInt32("FlPacienteA", usuarioCompletoTO.permissoesTO.flPacienteA);
            HttpContext.Session.SetInt32("FlPacienteE", usuarioCompletoTO.permissoesTO.flPacienteE);

            HttpContext.Session.SetInt32("FlConsultaI", usuarioCompletoTO.permissoesTO.flPacienteI);
            HttpContext.Session.SetInt32("FlConsultaC", usuarioCompletoTO.permissoesTO.flPacienteC);
            HttpContext.Session.SetInt32("FlConsultaA", usuarioCompletoTO.permissoesTO.flPacienteA);
            HttpContext.Session.SetInt32("FlConsultaE", usuarioCompletoTO.permissoesTO.flPacienteE);

            HttpContext.Session.SetInt32("FlMedicamentoI", usuarioCompletoTO.permissoesTO.flMedicamentoI);
            HttpContext.Session.SetInt32("FlMedicamentoC", usuarioCompletoTO.permissoesTO.flMedicamentoC);
            HttpContext.Session.SetInt32("FlMedicamentoA", usuarioCompletoTO.permissoesTO.flMedicamentoA);
            HttpContext.Session.SetInt32("FlMedicamentoE", usuarioCompletoTO.permissoesTO.flMedicamentoE);

            HttpContext.Session.SetInt32("FlExamesI", usuarioCompletoTO.permissoesTO.flExamesI);
            HttpContext.Session.SetInt32("FlExamesC", usuarioCompletoTO.permissoesTO.flExamesC);
            HttpContext.Session.SetInt32("FlExamesA", usuarioCompletoTO.permissoesTO.flExamesA);
            HttpContext.Session.SetInt32("FlExamesE", usuarioCompletoTO.permissoesTO.flExamesE);
        }

        private void CarregarDadosUsuarioParaTela()
        {
            ViewData.Add("idUsuario", HttpContext.Session.GetInt32("idUsuario"));
            ViewData.Add("usuario", HttpContext.Session.GetString("usuario"));

            ViewData.Add("idPessoa", HttpContext.Session.GetInt32("idPessoa"));
            ViewData.Add("idMedico", HttpContext.Session.GetInt32("idMedico"));
            ViewData.Add("tipoUsuario", HttpContext.Session.GetInt32("tipoUsuario"));
            ViewData.Add("nome", HttpContext.Session.GetString("nome"));
            ViewData.Add("cpf", HttpContext.Session.GetString("cpf"));
            ViewData.Add("rg", HttpContext.Session.GetString("rg"));
            ViewData.Add("dataNascimento", HttpContext.Session.GetString("dataNascimento"));
            ViewData.Add("logradouro", HttpContext.Session.GetString("logradouro"));
            ViewData.Add("numero", HttpContext.Session.GetInt32("numero"));
            ViewData.Add("bairro", HttpContext.Session.GetString("bairro"));
            ViewData.Add("cidade", HttpContext.Session.GetString("cidade"));
            ViewData.Add("uf", HttpContext.Session.GetString("uf"));
            ViewData.Add("telefoneCelular", HttpContext.Session.GetString("telefoneCelular"));
            ViewData.Add("email", HttpContext.Session.GetString("email"));

            ViewData.Add("flUsuarioI", HttpContext.Session.GetInt32("flUsuarioI"));
            ViewData.Add("flUsuarioC", HttpContext.Session.GetInt32("flUsuarioC"));
            ViewData.Add("flUsuarioA", HttpContext.Session.GetInt32("flUsuarioA"));
            ViewData.Add("flUsuarioE", HttpContext.Session.GetInt32("flUsuarioE"));

            ViewData.Add("flPacienteI", HttpContext.Session.GetInt32("flPacienteI"));
            ViewData.Add("flPacienteC", HttpContext.Session.GetInt32("flPacienteC"));
            ViewData.Add("flPacienteA", HttpContext.Session.GetInt32("flPacienteA"));
            ViewData.Add("flPacienteE", HttpContext.Session.GetInt32("flPacienteE"));

            ViewData.Add("flConsultaI", HttpContext.Session.GetInt32("flConsultaI"));
            ViewData.Add("flConsultaC", HttpContext.Session.GetInt32("flConsultaC"));
            ViewData.Add("flConsultaA", HttpContext.Session.GetInt32("flConsultaA"));
            ViewData.Add("flConsultaE", HttpContext.Session.GetInt32("flConsultaE"));

            ViewData.Add("flAusenciaI", HttpContext.Session.GetInt32("flAusenciaI"));
            ViewData.Add("flAusenciaC", HttpContext.Session.GetInt32("flAusenciaC"));
            ViewData.Add("flAusenciaA", HttpContext.Session.GetInt32("flAusenciaA"));
            ViewData.Add("flAusenciaE", HttpContext.Session.GetInt32("flAusenciaE"));

            ViewData.Add("flMedicamentoI", HttpContext.Session.GetInt32("flMedicamentoI"));
            ViewData.Add("flMedicamentoC", HttpContext.Session.GetInt32("flMedicamentoC"));
            ViewData.Add("flMedicamentoA", HttpContext.Session.GetInt32("flMedicamentoA"));
            ViewData.Add("flMedicamentoE", HttpContext.Session.GetInt32("flMedicamentoE"));

            ViewData.Add("flExamesI", HttpContext.Session.GetInt32("flExamesI"));
            ViewData.Add("flExamesC", HttpContext.Session.GetInt32("flExamesC"));
            ViewData.Add("flExamesA", HttpContext.Session.GetInt32("flExamesA"));
            ViewData.Add("flExamesE", HttpContext.Session.GetInt32("flExamesE"));

            ViewData.Add("flHistoriaMolestiaAtualI", HttpContext.Session.GetInt32("flHistoriaMolestiaAtualI"));
            ViewData.Add("flHistoriaMolestiaAtualC", HttpContext.Session.GetInt32("flHistoriaMolestiaAtualC"));
            ViewData.Add("flHistoriaMolestiaAtualA", HttpContext.Session.GetInt32("flHistoriaMolestiaAtualA"));
            ViewData.Add("flHistoriaMolestiaAtualE", HttpContext.Session.GetInt32("flHistoriaMolestiaAtualE"));

            ViewData.Add("flHistoriaPatologicaPregressaI", HttpContext.Session.GetInt32("flHistoriaPatologicaPregressaI"));
            ViewData.Add("flHistoriaPatologicaPregressaC", HttpContext.Session.GetInt32("flHistoriaPatologicaPregressaC"));
            ViewData.Add("flHistoriaPatologicaPregressaA", HttpContext.Session.GetInt32("flHistoriaPatologicaPregressaA"));
            ViewData.Add("flHistoriaPatologicaPregressaE", HttpContext.Session.GetInt32("flHistoriaPatologicaPregressaE"));

            ViewData.Add("flHipoteseDiagnosticaI", HttpContext.Session.GetInt32("flHipoteseDiagnosticaI"));
            ViewData.Add("flHipoteseDiagnosticaC", HttpContext.Session.GetInt32("flHipoteseDiagnosticaC"));
            ViewData.Add("flHipoteseDiagnosticaA", HttpContext.Session.GetInt32("flHipoteseDiagnosticaA"));
            ViewData.Add("flHipoteseDiagnosticaE", HttpContext.Session.GetInt32("flHipoteseDiagnosticaE"));

            ViewData.Add("flCondutaI", HttpContext.Session.GetInt32("flCondutaI"));
            ViewData.Add("flCondutaC", HttpContext.Session.GetInt32("flCondutaC"));
            ViewData.Add("flCondutaA", HttpContext.Session.GetInt32("flCondutaA"));
            ViewData.Add("flCondutaE", HttpContext.Session.GetInt32("flCondutaE"));
        }
    }
}
