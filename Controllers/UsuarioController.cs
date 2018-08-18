﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using SGCM.AppData.Usuario;
using System.Collections.Generic;
using SGCM.Models.Usuario.CadastroUsuarioModel;
using SGCM.Models.Usuario.EditarUsuarioModel;

namespace SGCM.Controllers {

    public class UsuarioController : Controller {

        //GET: /Usuario/CadastroUsuario
        [HttpGet]
        public ActionResult CadastroUsuario() {
            CarregarDadosUsuarioParaTela();
            if ((ViewBag.ID != null) && (ViewBag.ID != 0)) {
                if (ViewBag.FlUsuarioI != 0) {

                    ViewBag.Title = "Cadastro Usuário";
                    var viewModel = new CadastroUsuarioModel();
                    viewModel.usuario = new Models.Usuario.CadastroUsuarioModel.DadosLogin();
                    viewModel.permissoes = new Models.Usuario.CadastroUsuarioModel.DadosPermissoes();
                    viewModel.pessoa = new Models.Usuario.CadastroUsuarioModel.DadosPessoais();

                    return View(viewModel);
                } else {
                    HttpContext.Session.SetString("MensagemErro", "Você não tem premissão para acessar o cadastro de usuários!");
                    HttpContext.Session.SetInt32("FlMensagemErro", 1);
                    return RedirectToAction("Index", "Home");
                }
            } else {
                HttpContext.Session.SetString("MensagemErro", "Você não está logado no sistema! Realize o Login antes de acessar essa página!");
                HttpContext.Session.SetInt32("FlMensagemErro", 1); 
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: /Usuario/CadastroUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroUsuario(CadastroUsuarioModel model)
        {
            try
            {
                if (!ModelState.IsValid) {
                    return View(model);
                }

                model.pessoa.IdMedico = (int)HttpContext.Session.GetInt32("Id_Pessoa");

                var objUsuariosBLL = new UsuarioBLL();
                var retorno = objUsuariosBLL.InserirUsuario(model);

                if (retorno > 0) {
                    HttpContext.Session.SetString("MensagemErro", "Cadastro realizado com sucesso!");
                    HttpContext.Session.SetInt32("FlMensagemErro", 1);
                    return RedirectToAction("Index", "Home");
                    //return View(model);
                } else {
                    //HttpContext.Session.SetString("MensagemErro", "Ocorreu algum!");
                    //HttpContext.Session.SetInt32("FlMensagemErro", 1);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (SqlException exSQL)
            {
                ModelState.AddModelError(string.Empty, exSQL.Message);
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        //GET: /Usuario/ConsultaUsuario
        [HttpGet]
        public ActionResult ConsultaUsuario()
        {
            CarregarDadosUsuarioParaTela();
            if ((ViewBag.ID != null) && (ViewBag.ID != 0)) {
                if (ViewBag.FlUsuarioI != 0) {

                    ViewBag.Title = "Consultar Usuário";
                    
                    var objUsuariosBLL = new UsuarioBLL();
                    List<CadastroUsuarioModel> viewModel = objUsuariosBLL.ConsultarUsuario((int) ViewBag.Id_Pessoa);

                    return View(viewModel);
                } else {
                    HttpContext.Session.SetString("MensagemErro", "Você não tem premissão para acessar a tela de Cadastro de Usuários!");
                    HttpContext.Session.SetInt32("FlMensagemErro", 1);
                    return RedirectToAction("Index", "Home");
                }
            } else {
                HttpContext.Session.SetString("MensagemErro", "Você não está logado no sistema! Realize o Login antes de acessar essa página!");
                HttpContext.Session.SetInt32("FlMensagemErro", 1);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult EditarUsuario(int id) {
            CarregarDadosUsuarioParaTela();
            if ((ViewBag.ID != null) && (ViewBag.ID != 0)) {
                if (ViewBag.FlUsuarioA != 0) {
                    ViewBag.Title = "Editar Usuário";

                    var objUsuarioBLL = new UsuarioBLL();
                    EditarUsuarioModel viewModel = objUsuarioBLL.ConsultarUsuarioID(id);

                    CarregarDadosUsuarioParaSession(viewModel);

                    return View(viewModel);
                } else {
                    HttpContext.Session.SetString("MensagemErro", "Você não tem premissão para acessar a tela de Edição de Usuários!");
                    HttpContext.Session.SetInt32("FlMensagemErro", 1);
                    return RedirectToAction("Index", "Home");
                }

            } else {
                HttpContext.Session.SetString("MensagemErro", "Você não está logado no sistema! Realize o Login antes de acessar essa página!");
                HttpContext.Session.SetInt32("FlMensagemErro", 1);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarUsuario(EditarUsuarioModel model) {
            CarregarDadosUsuarioParaTela();
            if ((ViewBag.ID != null) && (ViewBag.ID != 0)) {
                if (ViewBag.FlUsuarioA != 0) {
                    ViewBag.Title = "Editar Usuário";
                    return View();
                } else {
                    HttpContext.Session.SetString("MensagemErro", "Você não tem premissão para acessar a tela de Edição de Usuários!");
                    HttpContext.Session.SetInt32("FlMensagemErro", 1);
                    return RedirectToAction("Index", "Home");
                }
            } else {
                HttpContext.Session.SetString("MensagemErro", "Você não está logado no sistema! Realize o Login antes de acessar essa página!");
                HttpContext.Session.SetInt32("FlMensagemErro", 1);
                return RedirectToAction("Index", "Home");
            }
        }


        //GET: /Usuario/Relatorio
        [HttpGet]
        public ActionResult Relatorio()
        {
            ViewBag.Title = "Relatório";

            return View();
        }

        private void CarregarDadosUsuarioParaSession(EditarUsuarioModel usuarioCompletoTO)
        {
            HttpContext.Session.SetInt32("ID", usuarioCompletoTO.usuario.IdUsuario);
            HttpContext.Session.SetString("Username", usuarioCompletoTO.usuario.Username);
            HttpContext.Session.SetString("Password", usuarioCompletoTO.usuario.Password);
            HttpContext.Session.SetString("DatDst", usuarioCompletoTO.usuario.DatDst.ToShortDateString());

            HttpContext.Session.SetInt32("Id_Pessoa", usuarioCompletoTO.pessoa.IdPessoa);
            HttpContext.Session.SetInt32("Id_Medico", usuarioCompletoTO.pessoa.IdMedico);
            HttpContext.Session.SetString("Nome", usuarioCompletoTO.pessoa.Nome);
            HttpContext.Session.SetString("Cpf", usuarioCompletoTO.pessoa.CPF);
            HttpContext.Session.SetString("Estado", usuarioCompletoTO.pessoa.Estado);
            HttpContext.Session.SetString("Cidade", usuarioCompletoTO.pessoa.Cidade);
            HttpContext.Session.SetString("Bairro", usuarioCompletoTO.pessoa.Bairro);
            HttpContext.Session.SetString("Endereco", usuarioCompletoTO.pessoa.Endereco);
            HttpContext.Session.SetInt32("Numero", usuarioCompletoTO.pessoa.Numero);
            HttpContext.Session.SetString("Telefone_Celular", usuarioCompletoTO.pessoa.Telefone_Celular);
            HttpContext.Session.SetString("Email", usuarioCompletoTO.pessoa.Email);
            HttpContext.Session.SetInt32("Tipo_Usuario", Int32.Parse(usuarioCompletoTO.pessoa.TipoUsuario));

            HttpContext.Session.SetInt32("IdPermissoes", usuarioCompletoTO.permissoes.IdPermissoes);
            HttpContext.Session.SetInt32("FlUsuarioI", Int32.Parse(usuarioCompletoTO.permissoes.FlUsuarioI));
            HttpContext.Session.SetInt32("FlUsuarioC", Int32.Parse(usuarioCompletoTO.permissoes.FlUsuarioC));
            HttpContext.Session.SetInt32("FlUsuarioA", Int32.Parse(usuarioCompletoTO.permissoes.FlUsuarioA));
            HttpContext.Session.SetInt32("FlUsuarioE", Int32.Parse(usuarioCompletoTO.permissoes.FlUsuarioE));
            HttpContext.Session.SetInt32("FlPacienteI", Int32.Parse(usuarioCompletoTO.permissoes.FlPacienteI));
            HttpContext.Session.SetInt32("FlPacienteC", Int32.Parse(usuarioCompletoTO.permissoes.FlPacienteC));
            HttpContext.Session.SetInt32("FlPacienteA", Int32.Parse(usuarioCompletoTO.permissoes.FlPacienteA));
            HttpContext.Session.SetInt32("FlPacienteE", Int32.Parse(usuarioCompletoTO.permissoes.FlPacienteE));
            HttpContext.Session.SetInt32("FlConsultaI", Int32.Parse(usuarioCompletoTO.permissoes.FlPacienteI));
            HttpContext.Session.SetInt32("FlConsultaC", Int32.Parse(usuarioCompletoTO.permissoes.FlPacienteC));
            HttpContext.Session.SetInt32("FlConsultaA", Int32.Parse(usuarioCompletoTO.permissoes.FlPacienteA));
            HttpContext.Session.SetInt32("FlConsultaE", Int32.Parse(usuarioCompletoTO.permissoes.FlPacienteE));
            HttpContext.Session.SetInt32("FlMedicamentoI", Int32.Parse(usuarioCompletoTO.permissoes.FlMedicamentoI));
            HttpContext.Session.SetInt32("FlMedicamentoC", Int32.Parse(usuarioCompletoTO.permissoes.FlMedicamentoC));
            HttpContext.Session.SetInt32("FlMedicamentoA", Int32.Parse(usuarioCompletoTO.permissoes.FlMedicamentoA));
            HttpContext.Session.SetInt32("FlMedicamentoE", Int32.Parse(usuarioCompletoTO.permissoes.FlMedicamentoE));
            HttpContext.Session.SetInt32("FlExamesI", Int32.Parse(usuarioCompletoTO.permissoes.FlExamesI));
            HttpContext.Session.SetInt32("FlExamesC", Int32.Parse(usuarioCompletoTO.permissoes.FlExamesC));
            HttpContext.Session.SetInt32("FlExamesA", Int32.Parse(usuarioCompletoTO.permissoes.FlExamesA));
            HttpContext.Session.SetInt32("FlExamesE", Int32.Parse(usuarioCompletoTO.permissoes.FlExamesE));
        }

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