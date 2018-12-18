using SGCM.Models.Paciente.CadastroPacienteModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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
            if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                if ((int)ViewData["FlPacienteI"] != 0) {

                    ViewData["Title"] = "Cadastro Paciente";
                    var viewModel = new CadastroPacienteModel();
                    return View(viewModel);
                } else {
                    HttpContext.Session.SetString("MensagemErro", "Você não tem premissão para acessar o cadastro de pacientes!");
                    HttpContext.Session.SetInt32("FlMensagemErro", 1);
                    return RedirectToAction("Index", "Home");
                }
            } else {
                ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
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
                //ViewData[""].Id_Medico

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

            ViewData.Add("flMedicamentoI", HttpContext.Session.GetInt32("flMedicamentoI"));
            ViewData.Add("flMedicamentoC", HttpContext.Session.GetInt32("flMedicamentoC"));
            ViewData.Add("flMedicamentoA", HttpContext.Session.GetInt32("flMedicamentoA"));
            ViewData.Add("flMedicamentoE", HttpContext.Session.GetInt32("flMedicamentoE"));

            ViewData.Add("flExamesI", HttpContext.Session.GetInt32("flExamesI"));
            ViewData.Add("flExamesC", HttpContext.Session.GetInt32("flExamesC"));
            ViewData.Add("flExamesA", HttpContext.Session.GetInt32("flExamesA"));
            ViewData.Add("flExamesE", HttpContext.Session.GetInt32("flExamesE"));
        }
    }

    
}
