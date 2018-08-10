using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGCM.Models;
using static SGCM.AppData.Infraestrutura.UtilObjetos.UtilObjetos;

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
            HttpContext.Session.SetInt32("ID", usuarioCompletoTO.usuarioTO.ID_Usuario);
            HttpContext.Session.SetString("Username", usuarioCompletoTO.usuarioTO.Username);
            HttpContext.Session.SetString("Password", usuarioCompletoTO.usuarioTO.Password);

            HttpContext.Session.SetInt32("Id_Pessoa", usuarioCompletoTO.pessoaTO.Id_Pessoa);
            HttpContext.Session.SetString("Nome", usuarioCompletoTO.pessoaTO.Nome);
            HttpContext.Session.SetString("Cpf", usuarioCompletoTO.pessoaTO.Cpf);
            HttpContext.Session.SetString("Estado", usuarioCompletoTO.pessoaTO.Estado);
            HttpContext.Session.SetString("Cidade", usuarioCompletoTO.pessoaTO.Cidade);
            HttpContext.Session.SetString("Bairro", usuarioCompletoTO.pessoaTO.Bairro);
            HttpContext.Session.SetString("Endereco", usuarioCompletoTO.pessoaTO.Endereco);
            HttpContext.Session.SetInt32("Numero", usuarioCompletoTO.pessoaTO.Numero);
            HttpContext.Session.SetString("Telefone_Celular", usuarioCompletoTO.pessoaTO.Telefone_Celular);
            HttpContext.Session.SetString("Email", usuarioCompletoTO.pessoaTO.Email);
            HttpContext.Session.SetInt32("Tipo_Usuario", usuarioCompletoTO.pessoaTO.Tipo_Usuario);

            HttpContext.Session.SetInt32("FlUsuarioI", usuarioCompletoTO.permissoesTO.Fl_Usuario_I);
            HttpContext.Session.SetInt32("FlUsuarioC", usuarioCompletoTO.permissoesTO.Fl_Usuario_C);
            HttpContext.Session.SetInt32("FlUsuarioA", usuarioCompletoTO.permissoesTO.Fl_Usuario_A);
            HttpContext.Session.SetInt32("FlUsuarioE", usuarioCompletoTO.permissoesTO.Fl_Usuario_E);

            HttpContext.Session.SetInt32("FlPacienteI", usuarioCompletoTO.permissoesTO.Fl_Paciente_I);
            HttpContext.Session.SetInt32("FlPacienteC", usuarioCompletoTO.permissoesTO.Fl_Paciente_C);
            HttpContext.Session.SetInt32("FlPacienteA", usuarioCompletoTO.permissoesTO.Fl_Paciente_A);
            HttpContext.Session.SetInt32("FlPacienteE", usuarioCompletoTO.permissoesTO.Fl_Paciente_E);

            HttpContext.Session.SetInt32("FlConsultaI", usuarioCompletoTO.permissoesTO.Fl_Paciente_I);
            HttpContext.Session.SetInt32("FlConsultaC", usuarioCompletoTO.permissoesTO.Fl_Paciente_C);
            HttpContext.Session.SetInt32("FlConsultaA", usuarioCompletoTO.permissoesTO.Fl_Paciente_A);
            HttpContext.Session.SetInt32("FlConsultaE", usuarioCompletoTO.permissoesTO.Fl_Paciente_E);

            HttpContext.Session.SetInt32("FlMedicamentoI", usuarioCompletoTO.permissoesTO.Fl_Medicamento_I);
            HttpContext.Session.SetInt32("FlMedicamentoC", usuarioCompletoTO.permissoesTO.Fl_Medicamento_C);
            HttpContext.Session.SetInt32("FlMedicamentoA", usuarioCompletoTO.permissoesTO.Fl_Medicamento_A);
            HttpContext.Session.SetInt32("FlMedicamentoE", usuarioCompletoTO.permissoesTO.Fl_Medicamento_E);

            HttpContext.Session.SetInt32("FlExamesI", usuarioCompletoTO.permissoesTO.Fl_Exames_I);
            HttpContext.Session.SetInt32("FlExamesC", usuarioCompletoTO.permissoesTO.Fl_Exames_C);
            HttpContext.Session.SetInt32("FlExamesA", usuarioCompletoTO.permissoesTO.Fl_Exames_A);
            HttpContext.Session.SetInt32("FlExamesE", usuarioCompletoTO.permissoesTO.Fl_Exames_E);
        }

        private void CarregarDadosUsuarioParaTela()
        {
            ViewBag.ID = HttpContext.Session.GetInt32("ID");
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Password = HttpContext.Session.GetString("Password");

            ViewBag.Id_Pessoa = HttpContext.Session.GetInt32("Id_Pessoa");
            ViewBag.Nome = HttpContext.Session.GetString("Nome");
            ViewBag.Cpf = HttpContext.Session.GetString("Cpf");
            ViewBag.Estado = HttpContext.Session.GetString("Estado");
            ViewBag.Cidade = HttpContext.Session.GetString("Cidade");
            ViewBag.Bairro = HttpContext.Session.GetString("Bairro");
            ViewBag.Endereco = HttpContext.Session.GetString("Endereco");
            ViewBag.Numero = HttpContext.Session.GetInt32("Numero");
            ViewBag.Telefone_Celular = HttpContext.Session.GetString("Telefone_Celular");
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Tipo_Usuario = HttpContext.Session.GetInt32("Tipo_Usuario");

            ViewBag.FlUsuarioI = HttpContext.Session.GetInt32("FlUsuarioI");
            ViewBag.FlUsuarioC = HttpContext.Session.GetInt32("FlUsuarioC");
            ViewBag.FlUsuarioA = HttpContext.Session.GetInt32("FlUsuarioA");
            ViewBag.FlUsuarioE = HttpContext.Session.GetInt32("FlUsuarioE");

            ViewBag.FlPacienteI = HttpContext.Session.GetInt32("FlPacienteI");
            ViewBag.FlPacienteC = HttpContext.Session.GetInt32("FlPacienteC");
            ViewBag.FlPacienteA = HttpContext.Session.GetInt32("FlPacienteA");
            ViewBag.FlPacienteE = HttpContext.Session.GetInt32("FlPacienteE");

            ViewBag.FlConsultaI = HttpContext.Session.GetInt32("FlConsultaI");
            ViewBag.FlConsultaC = HttpContext.Session.GetInt32("FlConsultaC");
            ViewBag.FlConsultaA = HttpContext.Session.GetInt32("FlConsultaA");
            ViewBag.FlConsultaE = HttpContext.Session.GetInt32("FlConsultaE");

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
