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
            if ((HttpContext.Session.GetInt32("ID") != null) && (HttpContext.Session.GetInt32("ID") != 0))
                CarregarDadosUsuarioParaTela();
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
            ViewData.Add("nome", HttpContext.Session.GetInt32("nome"));
            ViewData.Add("cpf", HttpContext.Session.GetInt32("cpf"));
            ViewData.Add("rg", HttpContext.Session.GetInt32("rg"));
            ViewData.Add("dataNascimento", HttpContext.Session.GetInt32("dataNascimento"));
            ViewData.Add("logradouro", HttpContext.Session.GetInt32("logradouro"));
            ViewData.Add("numero", HttpContext.Session.GetInt32("numero"));
            ViewData.Add("bairro", HttpContext.Session.GetInt32("bairro"));
            ViewData.Add("cidade", HttpContext.Session.GetInt32("cidade"));
            ViewData.Add("uf", HttpContext.Session.GetInt32("uf"));
            ViewData.Add("telefoneCelular", HttpContext.Session.GetInt32("telefoneCelular"));
            ViewData.Add("email", HttpContext.Session.GetInt32("email"));

            ViewData.Add("IdPermissoes", HttpContext.Session.GetInt32("IdPermissoes"));

            ViewData.Add("FlUsuarioI", HttpContext.Session.GetInt32("FlUsuarioI"));
            ViewData.Add("FlUsuarioC", HttpContext.Session.GetInt32("FlUsuarioC"));
            ViewData.Add("FlUsuarioA", HttpContext.Session.GetInt32("FlUsuarioA"));
            ViewData.Add("FlUsuarioE", HttpContext.Session.GetInt32("FlUsuarioE"));

            ViewData.Add("FlPacienteI", HttpContext.Session.GetInt32("FlPacienteI"));
            ViewData.Add("FlPacienteC", HttpContext.Session.GetInt32("FlPacienteC"));
            ViewData.Add("FlPacienteA", HttpContext.Session.GetInt32("FlPacienteA"));
            ViewData.Add("FlPacienteE", HttpContext.Session.GetInt32("FlPacienteE"));

            ViewData.Add("FlConsultaI", HttpContext.Session.GetInt32("FlConsultaI"));
            ViewData.Add("FlConsultaC", HttpContext.Session.GetInt32("FlConsultaC"));
            ViewData.Add("FlConsultaA", HttpContext.Session.GetInt32("FlConsultaA"));
            ViewData.Add("FlConsultaE", HttpContext.Session.GetInt32("FlConsultaE"));

            ViewData.Add("FlMedicamentoI", HttpContext.Session.GetInt32("FlMedicamentoI"));
            ViewData.Add("FlMedicamentoC", HttpContext.Session.GetInt32("FlMedicamentoC"));
            ViewData.Add("FlMedicamentoA", HttpContext.Session.GetInt32("FlMedicamentoA"));
            ViewData.Add("FlMedicamentoE", HttpContext.Session.GetInt32("FlMedicamentoE"));

            ViewData.Add("FlExamesI", HttpContext.Session.GetInt32("FlExamesI"));
            ViewData.Add("FlExamesC", HttpContext.Session.GetInt32("FlExamesC"));
            ViewData.Add("FlExamesA", HttpContext.Session.GetInt32("FlExamesA"));
            ViewData.Add("flExamesE", HttpContext.Session.GetInt32("flExamesE"));
        }
    }
}
