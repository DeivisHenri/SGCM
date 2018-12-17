using SGCM.Models.Paciente.CadastroPacienteModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Data.SqlClient;
using SGCM.AppData.Paciente;
using System;

namespace SGCM.Controllers
{
    public class PacienteController : Controller
    {
        //GET: /Paciente/CadastroPaciente
        [HttpGet]
        public ActionResult CadastroPaciente()
        {
            CarregarDadosUsuarioParaTela();
            if ((ViewBag.ID != null) && (ViewBag.ID != 0))
            {
                if (ViewBag.FlPacienteI != 0) {

                    ViewBag.Title = "Cadastro Paciente";
                    var viewModel = new CadastroPacienteModel();
                    return View(viewModel);
                } else {
                    HttpContext.Session.SetString("MensagemErro", "Você não tem premissão para acessar o cadastro de pacientes!");
                    HttpContext.Session.SetInt32("FlMensagemErro", 1);
                    return RedirectToAction("Index", "Home");
                }
            } else {
                HttpContext.Session.SetString("MensagemErro", "Você não está logado no sistema! Realize o Login antes de acessar essa página!");
                HttpContext.Session.SetInt32("FlMensagemErro", 1);
                return RedirectToAction("Index", "Home");
            }
        }

        //POST: /Paciente/CadastroPaciente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroPaciente(CadastroPacienteModel model) {
            try {
                if (!ModelState.IsValid)
                    return View(model);

                model.pessoa.IdMedico = (int)HttpContext.Session.GetInt32("Id_Pessoa");
                //ViewBag.Id_Medico

                var objPacienteBLL = new PacienteBLL();
                var retorno = objPacienteBLL.InserirPaciente(model);

                if (retorno > 0) {
                    HttpContext.Session.SetString("MensagemErro", "Paciente " + model.pessoa.Nome + " cadastrado com sucesso!");
                    HttpContext.Session.SetInt32("FlMensagemErro", 1);
                    return RedirectToAction("CadastroPaciente", "Paciente");
                } else {
                    HttpContext.Session.SetString("MensagemErro", "Cadastro do paciente " + model.pessoa.Nome + " não realizado!");
                    HttpContext.Session.SetInt32("FlMensagemErro", 1);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex) {
                return null;
            }
        }

        //public ActionResult CadastroUsuario(CadastroUsuarioModel model)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return View(model);
        //        }

        //        model.pessoa.IdMedico = (int)HttpContext.Session.GetInt32("Id_Pessoa");

        //        var objUsuariosBLL = new UsuarioBLL();
        //        var retorno = objUsuariosBLL.InserirUsuario(model);

        //        if (retorno > 0)
        //        {
        //            HttpContext.Session.SetString("MensagemErro", "Cadastro realizado com sucesso!");
        //            HttpContext.Session.SetInt32("FlMensagemErro", 1);
        //            return RedirectToAction("Index", "Home");
        //            //return View(model);
        //        }
        //        else
        //        {
        //            //HttpContext.Session.SetString("MensagemErro", "Ocorreu algum!");
        //            //HttpContext.Session.SetInt32("FlMensagemErro", 1);
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }
        //    catch (SqlException exSQL)
        //    {
        //        ModelState.AddModelError(string.Empty, exSQL.Message);
        //        return View(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, ex.Message);
        //        return View(model);
        //    }
        //}

        private void CarregarDadosUsuarioParaTela()
        {
            ViewBag.ID = HttpContext.Session.GetInt32("ID");
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Password = HttpContext.Session.GetString("Password");

            ViewBag.Id_Pessoa = HttpContext.Session.GetInt32("Id_Pessoa");
            ViewBag.Id_Medico = HttpContext.Session.GetInt32("Id_Medico");
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
