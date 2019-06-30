using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SGCM.AppData.Usuario;
using SGCM.Models.Usuario.CadastroUsuarioModel;
using SGCM.Models.Usuario.EditarUsuarioModel;
using SGCM.Models.Usuario.ConsultarUsuarioModel;

using SGCM.AppData.Infraestrutura.PDFEstrutura;

using System.IO;// A BIBLIOTECA DE ENTRADA E SAIDA DE ARQUIVOS
using iTextSharp;//E A BIBLIOTECA ITEXTSHARP E SUAS EXTENÇÕES
using iTextSharp.text;//ESTENSAO 1 (TEXT)
using iTextSharp.text.pdf;//ESTENSAO 2 (PDF)
using X.PagedList;

namespace SGCM.Controllers {

    public class UsuarioController : Controller {

        //GET: /Usuario/CadastroUsuario
        [HttpGet]
        public ActionResult CadastroUsuario() {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flUsuarioI"] == 1) {
                        ViewData["Title"] = "Cadastro Usuário";

                        var viewModel = new CadastroUsuarioModel();

                        viewModel.usuario = new Models.Usuario.CadastroUsuarioModel.DadosLogin();
                        viewModel.permissoes = new Models.Usuario.CadastroUsuarioModel.DadosPermissoes();
                        viewModel.pessoa = new Models.Usuario.CadastroUsuarioModel.DadosPessoais();

                        return View(viewModel);
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Usuario/CadastroUsuario'");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    HttpContext.Session.SetString("MensagemBody", "Você não está logado no sistema! Realize o Login antes de acessar essa a página: '" + ViewData["ReturnUrl"] + "' !");
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: UsuarioController";
                ViewBag.MensagemBodyAction = "Action: CadastroUsuario - GET";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        // POST: /Usuario/CadastroUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroUsuario(CadastroUsuarioModel model) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                if (!ModelState.IsValid) return View(model);

                model.pessoa.IdMedico = (int)HttpContext.Session.GetInt32("idPessoa");

                var objUsuariosBLL = new UsuarioBLL();
                var retorno = objUsuariosBLL.InserirUsuario(model);

                if (retorno == 3) {
                    ViewBag.MensagemTitle = "Sucesso";
                    ViewBag.MensagemBody = "Usuário cadastrado com sucesso!";

                    ModelState.Clear();

                    return View();
                } else {
                    ViewBag.MensagemTitle = "Error";
                    ViewBag.MensagemBody = "Ocorreu um erro ao cadastrar um usuário!";
                    return View(model);
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: UsuarioController";
                ViewBag.MensagemBodyAction = "Action: CadastroUsuario - POST";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        //GET: /Usuario/ConsultaUsuario
        [HttpGet]
        public ActionResult ConsultarUsuario(ConsultarUsuarioModel model, string pagina) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    var objUsuariosBLL = new UsuarioBLL();
                    var viewModel = new ConsultarUsuarioModel();
                    var sort = 0;

                    if (HttpContext.Session.GetString("flagNome") == null) {
                        HttpContext.Session.SetString("flagNome", "default");
                    }

                    if (HttpContext.Session.GetString("flagCPF") == null) {
                        HttpContext.Session.SetString("flagCPF", "default");
                    }

                    if (HttpContext.Session.GetString("flagTelefoneCelular") == null) {
                        HttpContext.Session.SetString("flagTelefoneCelular", "default");
                    }

                    if (!String.IsNullOrEmpty(model.sortOrder)) {
                        switch (model.sortOrder) {
                            case "nome": {
                                if (HttpContext.Session.GetString("flagNome") == "default") {
                                    HttpContext.Session.SetString("flagNome", "ASC");
                                    sort = 1;
                                } else if (HttpContext.Session.GetString("flagNome") == "ASC") {
                                    HttpContext.Session.SetString("flagNome", "DESC");
                                    sort = 2;
                                } else if (HttpContext.Session.GetString("flagNome") == "DESC") {
                                    HttpContext.Session.SetString("flagNome", "ASC");
                                    sort = 1;
                                }
                                break;
                            }
                            case "cpf": {
                                if (HttpContext.Session.GetString("flagCPF") == "default") {
                                    HttpContext.Session.SetString("flagCPF", "ASC");
                                    sort = 3;
                                } else if (HttpContext.Session.GetString("flagCPF") == "ASC") {
                                    HttpContext.Session.SetString("flagCPF", "DESC");
                                    sort = 4;
                                } else if (HttpContext.Session.GetString("flagCPF") == "DESC") {
                                    HttpContext.Session.SetString("flagCPF", "ASC");
                                    sort = 3;
                                }
                                break;
                            }
                            case "telefoneCelular": {
                                if (HttpContext.Session.GetString("flagTelefoneCelular") == "default") {
                                    HttpContext.Session.SetString("flagTelefoneCelular", "ASC");
                                    sort = 5;
                                } else if (HttpContext.Session.GetString("flagTelefoneCelular") == "ASC") {
                                    HttpContext.Session.SetString("flagTelefoneCelular", "DESC");
                                    sort = 6;
                                } else if (HttpContext.Session.GetString("flagTelefoneCelular") == "DESC") {
                                    HttpContext.Session.SetString("flagTelefoneCelular", "ASC");
                                    sort = 5;
                                }
                                break;
                            }
                            default: {
                                sort = 0;
                                break;
                            }
                        }
                    }

                    var retornoListaUsuario = objUsuariosBLL.ConsultarUsuario((int)ViewData["idPessoa"], sort, model.psqNome, model.psqCPF, model.psqTelefoneCelular);

                    if (retornoListaUsuario != null) {
                        if (HttpContext.Session.GetString("MensagemTitle") != null && HttpContext.Session.GetString("MensagemBody") != null && HttpContext.Session.GetString("MensagemTitle") != "" && HttpContext.Session.GetString("MensagemBody") != "") {
                            ViewBag.MensagemTitle = HttpContext.Session.GetString("MensagemTitle");
                            ViewBag.MensagemBody = HttpContext.Session.GetString("MensagemBody");
                            HttpContext.Session.SetString("MensagemTitle", "");
                            HttpContext.Session.SetString("MensagemBody", "");
                        }

                        int pageNumber = 0;
                        if (pagina != null) {
                            pageNumber = Convert.ToInt32(pagina);
                        } else {
                            pageNumber = 1;
                        }

                        viewModel.ListaConsultarUsuarioModel = retornoListaUsuario.ToPagedList(pageNumber, 10);

                        return View(viewModel);
                    } else {
                        string mensagem = "";
                        mensagem = "Não existe nenhum Usuário cadastrado pelo usuário: " + ViewData["nome"];

                        if (model.psqNome != null) mensagem = mensagem + " com o parâmetro 'Nome': " + model.psqNome;
                        if (model.psqCPF != null) mensagem = mensagem + " com o parâmetro 'CPF': " + model.psqCPF;
                        if (model.psqTelefoneCelular != null) mensagem = mensagem + " com o parâmetro 'Telefone Celualr': " + model.psqTelefoneCelular;

                        ViewBag.MensagemTitle = "Informação";
                        ViewBag.MensagemBody = mensagem;

                        return View();
                    }
                } else {
                    HttpContext.Session.SetString("UserMessage", "Você não está logado no sistema! Realize o Login antes de acessar essa página!");
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: UsuarioController";
                ViewBag.MensagemBodyAction = "Action: ConsultaUsuario - GET";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        //GET: /Usuario/EditarUsuario
        [HttpGet]
        public ActionResult EditarUsuario(int id) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flUsuarioA"] != 0) {
                        ViewData["Title"] = "Editar Usuário";

                        var objUsuarioBLL = new UsuarioBLL();
                        EditarUsuarioModel viewModel = objUsuarioBLL.ConsultarUsuarioID(id);
                        viewModel.pessoa.Status = viewModel.usuario.statusDesativado.ToString();

                        return View(viewModel);
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro ao Cadastrar a Consulta");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Usuario/EditarUsuario'");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", "Home/Index");
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: UsuarioController";
                ViewBag.MensagemBodyAction = "Action: EditarUsuario/ID - GET";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        //POST: /Usuario/EditarUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarUsuario(EditarUsuarioModel model) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flUsuarioA"] != 0) {
                        var objUsuarioBLL = new UsuarioBLL();
                        var retorno = objUsuarioBLL.EditarUsuario(model);

                        if (retorno == 3) {
                            HttpContext.Session.SetString("MensagemTitle", "Sucesso");
                            HttpContext.Session.SetString("MensagemBody", "O usuário " + model.pessoa.Nome + " foi atualizado com sucesso!");
                            ConsultarUsuarioModel modelConsulta = null;
                            return RedirectToAction("ConsultarUsuario", "Usuario");
                        } else {
                            ViewBag.MensagemTitle = "Erro";
                            ViewBag.MensagemBody = "Ocorreu um erro na tentiva de editar o usuário: " + ViewData["nome"];
                            return View();
                        }
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "Você não tem premissão para acessar a tela de Edição de Usuários!");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                ViewBag.MensagemTitle = "Erro";
                ViewBag.MensagemBodyController = "Controller: UsuarioController";
                ViewBag.MensagemBodyAction = "Action: EditarUsuario/{USUÁRIO} - POST";
                ViewBag.MensagemBody = "Exceção: " + ex.Message;
                return View();
            }
        }

        //GET: /Usuario/Relatorio
        [HttpGet]
        public ActionResult Relatorio() {
            Document doc = new Document(PageSize.A4);//criando e estipulando o tipo da folha usada
            doc.SetMargins(40, 40, 40, 80);//estibulando o espaçamento das margens que queremos
            doc.AddCreationDate();//adicionando as configuracoes

            //caminho onde sera criado o pdf + nome desejado
            //OBS: o nome sempre deve ser terminado com .pdf
            string caminho = @"C:\Users\mselm\Desktop\" + "teste.pdf";

            //criando o arquivo pdf embranco, passando como parametro a variavel doc criada acima e a variavel caminho 
            //tambem criada acima.
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            doc.Open();

            //criando uma string vazia
            string dados = "";

            //criando a variavel para paragrafo
            Paragraph paragrafo = new Paragraph(dados, new Font(Font.NORMAL, 14));
            //etipulando o alinhamneto
            paragrafo.Alignment = Element.ALIGN_JUSTIFIED;
            //Alinhamento Justificado
            //adicioando texto
            paragrafo.Add("TESTE TESTE TESTE");
            //acidionado paragrafo ao documento
            doc.Add(paragrafo);
            //fechando documento para que seja salva as alteraçoes.
            doc.Close();


            return View();
        }

        [HttpPost]
        public ActionResult VerificaUF(string valorCampo)
        {
            switch (valorCampo)
            {
                case "AC":
                    break;
                case "AL":
                    break;
                case "AP":
                    break;
                case "AM":
                    break;
                case "BA":
                    break;
                case "CE":
                    break;
                case "DF":
                    break;
                case "ES":
                    break;
                case "GO":
                    break;
                case "MA":
                    break;
                case "MT":
                    break;
                case "MS":
                    break;
                case "MG":
                    break;
                case "PA":
                    break;
                case "PB":
                    break;
                case "PR":
                    break;
                case "PE":
                    break;
                case "PI":
                    break;
                case "RJ":
                    break;
                case "RN":
                    break;
                case "RS":
                    break;
                case "RO":
                    break;
                case "RR":
                    break;
                case "SC":
                    break;
                case "SP":
                    break;
                case "SE":
                    break;
                case "TO":
                    break;
                default:
                    break;
            }
            return null;
        }

        private void CarregarDadosUsuarioParaSession(EditarUsuarioModel usuarioCompletoTO) {
            HttpContext.Session.SetInt32("idUsuario", usuarioCompletoTO.usuario.IdUsuario);
            HttpContext.Session.SetString("usuario", usuarioCompletoTO.usuario.Username);
            HttpContext.Session.SetInt32("tipoUsuario", Int32.Parse(usuarioCompletoTO.usuario.TipoUsuario));

            HttpContext.Session.SetInt32("idPessoa", usuarioCompletoTO.pessoa.IdPessoa);
            HttpContext.Session.SetInt32("idMedico", usuarioCompletoTO.pessoa.IdMedico);
            HttpContext.Session.SetString("nome", usuarioCompletoTO.pessoa.Nome);
            HttpContext.Session.SetString("cpf", usuarioCompletoTO.pessoa.CPF);
            HttpContext.Session.SetString("rg", usuarioCompletoTO.pessoa.RG);
            HttpContext.Session.SetString("sexo", usuarioCompletoTO.pessoa.Sexo);
            HttpContext.Session.SetString("dataNascimento", usuarioCompletoTO.pessoa.DataNascimento.ToShortDateString());
            HttpContext.Session.SetString("logradouro", usuarioCompletoTO.pessoa.Logradouro);
            HttpContext.Session.SetInt32("numero", usuarioCompletoTO.pessoa.Numero);
            HttpContext.Session.SetString("bairro", usuarioCompletoTO.pessoa.Bairro);
            HttpContext.Session.SetString("cidade", usuarioCompletoTO.pessoa.Cidade);
            HttpContext.Session.SetString("uf", usuarioCompletoTO.pessoa.UF);
            HttpContext.Session.SetString("telefoneCelular", usuarioCompletoTO.pessoa.Telefone_Celular);
            HttpContext.Session.SetString("email", usuarioCompletoTO.pessoa.Email);

            /* USUARIO */
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flUsuarioI)) {
                HttpContext.Session.SetInt32("flUsuarioI", 1);
            } else {
                HttpContext.Session.SetInt32("flUsuarioI", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flUsuarioC)) {
                HttpContext.Session.SetInt32("flUsuarioC", 1);
            } else {
                HttpContext.Session.SetInt32("flUsuarioC", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flUsuarioA)) {
                HttpContext.Session.SetInt32("flUsuarioA", 1);
            } else {
                HttpContext.Session.SetInt32("flUsuarioA", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flUsuarioE)) {
                HttpContext.Session.SetInt32("flUsuarioE", 1);
            } else {
                HttpContext.Session.SetInt32("flUsuarioE", 0);
            }

            /* PACIENTE */
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flPacienteI)) {
                HttpContext.Session.SetInt32("flPacienteI", 1);
            } else {
                HttpContext.Session.SetInt32("flPacienteI", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flPacienteC)) {
                HttpContext.Session.SetInt32("flPacienteC", 1);
            } else {
                HttpContext.Session.SetInt32("flPacienteC", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flPacienteA)) {
                HttpContext.Session.SetInt32("flPacienteA", 1);
            } else {
                HttpContext.Session.SetInt32("flPacienteA", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flPacienteE)) {
                HttpContext.Session.SetInt32("flPacienteE", 1);
            } else {
                HttpContext.Session.SetInt32("flPacienteE", 0);
            }

            /* CONSULTA */
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flConsultaI)) {
                HttpContext.Session.SetInt32("flConsultaI", 1);
            } else {
                HttpContext.Session.SetInt32("flConsultaI", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flConsultaC)) {
                HttpContext.Session.SetInt32("flConsultaC", 1);
            } else {
                HttpContext.Session.SetInt32("flConsultaC", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flConsultaA)) {
                HttpContext.Session.SetInt32("flConsultaA", 1);
            } else {
                HttpContext.Session.SetInt32("flConsultaA", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flConsultaE)) {
                HttpContext.Session.SetInt32("flConsultaE", 1);
            } else {
                HttpContext.Session.SetInt32("flConsultaE", 0);
            }

            /* AUSENCIA */
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flAusenciaI)) {
                HttpContext.Session.SetInt32("flAusenciaI", 1);
            } else {
                HttpContext.Session.SetInt32("flAusenciaI", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flAusenciaC)) {
                HttpContext.Session.SetInt32("flAusenciaC", 1);
            } else {
                HttpContext.Session.SetInt32("flAusenciaC", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flAusenciaA)) {
                HttpContext.Session.SetInt32("flAusenciaA", 1);
            } else {
                HttpContext.Session.SetInt32("flAusenciaA", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flAusenciaE)) {
                HttpContext.Session.SetInt32("flAusenciaE", 1);
            } else {
                HttpContext.Session.SetInt32("flAusenciaE", 0);
            }

            /* MEDICAMENTO */
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flMedicamentoI)) {
                HttpContext.Session.SetInt32("FlMedicamentoI", 1);
            } else {
                HttpContext.Session.SetInt32("flMedicamentoI", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flMedicamentoC)) {
                HttpContext.Session.SetInt32("flMedicamentoC", 1);
            } else {
                HttpContext.Session.SetInt32("flMedicamentoC", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flMedicamentoA)) {
                HttpContext.Session.SetInt32("flMedicamentoA", 1);
            } else {
                HttpContext.Session.SetInt32("flMedicamentoA", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flMedicamentoE)) {
                HttpContext.Session.SetInt32("flMedicamentoE", 1);
            } else {
                HttpContext.Session.SetInt32("flMedicamentoE", 0);
            }

            /* EXAME */
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flExamesI)) {
                HttpContext.Session.SetInt32("flExamesI", 1);
            } else {
                HttpContext.Session.SetInt32("flExamesI", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flExamesC)) {
                HttpContext.Session.SetInt32("flExamesC", 1);
            } else {
                HttpContext.Session.SetInt32("flExamesC", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flExamesA)) {
                HttpContext.Session.SetInt32("flExamesA", 1);
            } else {
                HttpContext.Session.SetInt32("flExamesA", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flExamesE)) {
                HttpContext.Session.SetInt32("flExamesE", 1);
            } else {
                HttpContext.Session.SetInt32("flExamesE", 0);
            }

            /* RECEITA */
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flReceitaI)) {
                HttpContext.Session.SetInt32("flReceitaI", 1);
            } else {
                HttpContext.Session.SetInt32("flReceitaI", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flReceitaC)) {
                HttpContext.Session.SetInt32("flReceitaC", 1);
            } else {
                HttpContext.Session.SetInt32("flReceitaC", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flReceitaA)) {
                HttpContext.Session.SetInt32("flReceitaA", 1);
            } else {
                HttpContext.Session.SetInt32("flReceitaA", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flReceitaE)) {
                HttpContext.Session.SetInt32("flReceitaE", 1);
            } else {
                HttpContext.Session.SetInt32("flReceitaE", 0);
            }

            /* MOLESTIA ATUAL */
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flHistoriaMolestiaAtualI)) {
                HttpContext.Session.SetInt32("flHistoriaMolestiaAtualI", 1);
            } else {
                HttpContext.Session.SetInt32("flHistoriaMolestiaAtualI", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flHistoriaMolestiaAtualC)) {
                HttpContext.Session.SetInt32("flHistoriaMolestiaAtualC", 1);
            } else {
                HttpContext.Session.SetInt32("flHistoriaMolestiaAtualC", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flHistoriaMolestiaAtualA)) {
                HttpContext.Session.SetInt32("flHistoriaMolestiaAtualA", 1);
            } else {
                HttpContext.Session.SetInt32("flHistoriaMolestiaAtualA", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flHistoriaMolestiaAtualE)) {
                HttpContext.Session.SetInt32("flHistoriaMolestiaAtualE", 1);
            } else {
                HttpContext.Session.SetInt32("flHistoriaMolestiaAtualE", 0);
            }

            /* PATOLOGICA PREGRESSA */
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flHistoriaPatologicaPregressaI)) {
                HttpContext.Session.SetInt32("flHistoriaPatologicaPregressaI", 1);
            } else {
                HttpContext.Session.SetInt32("flHistoriaPatologicaPregressaI", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flHistoriaPatologicaPregressaC)) {
                HttpContext.Session.SetInt32("flHistoriaPatologicaPregressaC", 1);
            } else {
                HttpContext.Session.SetInt32("flHistoriaPatologicaPregressaC", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flHistoriaPatologicaPregressaA)) {
                HttpContext.Session.SetInt32("flHistoriaPatologicaPregressaA", 1);
            } else {
                HttpContext.Session.SetInt32("flHistoriaPatologicaPregressaA", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flHistoriaPatologicaPregressaE)) {
                HttpContext.Session.SetInt32("flHistoriaPatologicaPregressaE", 1);
            } else {
                HttpContext.Session.SetInt32("flHistoriaPatologicaPregressaE", 0);
            }

            /* HIPOTESE DIAGNOSTICA */
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flHipoteseDiagnosticaI)) {
                HttpContext.Session.SetInt32("flHipoteseDiagnosticaI", 1);
            } else {
                HttpContext.Session.SetInt32("flHipoteseDiagnosticaI", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flHipoteseDiagnosticaC)) {
                HttpContext.Session.SetInt32("flHipoteseDiagnosticaC", 1);
            } else {
                HttpContext.Session.SetInt32("flHipoteseDiagnosticaC", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flHipoteseDiagnosticaA)) {
                HttpContext.Session.SetInt32("flHipoteseDiagnosticaA", 1);
            } else {
                HttpContext.Session.SetInt32("flHipoteseDiagnosticaA", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flHipoteseDiagnosticaE)) {
                HttpContext.Session.SetInt32("flHipoteseDiagnosticaE", 1);
            } else {
                HttpContext.Session.SetInt32("flHipoteseDiagnosticaE", 0);
            }

            /* CONDUTA */
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flCondutaI)) {
                HttpContext.Session.SetInt32("flCondutaI", 1);
            } else {
                HttpContext.Session.SetInt32("flCondutaI", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flCondutaC)) {
                HttpContext.Session.SetInt32("flCondutaC", 1);
            } else {
                HttpContext.Session.SetInt32("flCondutaC", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flCondutaA)) {
                HttpContext.Session.SetInt32("flCondutaA", 1);
            } else {
                HttpContext.Session.SetInt32("flCondutaA", 0);
            }
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flCondutaE)) {
                HttpContext.Session.SetInt32("flCondutaE", 1);
            } else {
                HttpContext.Session.SetInt32("flCondutaE", 0);
            }

            /* INICIAR ATENDIMENTO */
            if (Convert.ToBoolean(usuarioCompletoTO.permissoes.flIniciarAtendimento)) {
                HttpContext.Session.SetInt32("flIniciarAtendimento", 1);
            } else {
                HttpContext.Session.SetInt32("flIniciarAtendimento", 0);
            }
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

            ViewData.Add("flReceitaI", HttpContext.Session.GetInt32("flReceitaI"));
            ViewData.Add("flReceitaC", HttpContext.Session.GetInt32("flReceitaC"));
            ViewData.Add("flReceitaA", HttpContext.Session.GetInt32("flReceitaA"));
            ViewData.Add("flReceitaE", HttpContext.Session.GetInt32("flReceitaE"));

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

            ViewData.Add("flIniciarAtendimento", HttpContext.Session.GetInt32("flIniciarAtendimento"));
        }
    }
}