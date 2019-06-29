using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;
using Microsoft.AspNetCore.Http;
using SGCM.AppData.PDF;
using SGCM.Models.PDF;
using System.Net.Http.Headers;

namespace SGCM.Controllers {

    public class PDFController : Controller {

        public IActionResult MostrarExamePDFTela(int id, string username) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flPacienteC"] != 0 && (int)ViewData["flExamesC"] != 0) {
                        MemoryStream workStream = new MemoryStream();
                        Document doc = CriarDocumentoPDF(true);

                        PdfWriter.GetInstance(doc, workStream).CloseStream = false;

                        if (id != 0 && username != null) {
                            PDFBLL pdfBLL = new PDFBLL();
                            PDFDadosExame dadosExame = new PDFDadosExame();
                            dadosExame = pdfBLL.ConsultarDadosExamePreencherPDF(Convert.ToInt32(id), Convert.ToInt32(username));

                            if (dadosExame != null) {
                                doc = LayoutPDFExame(doc, dadosExame);
                            } else {
                                HttpContext.Session.SetString("MensagemTitle", "Erro na consulta dos dados");
                                HttpContext.Session.SetString("MensagemBody", "Verifique os parametros passados!");
                                return RedirectToAction("Index", "Home");
                            }
                        } else {
                            HttpContext.Session.SetString("MensagemTitle", "Erro na consulta dos dados");
                            HttpContext.Session.SetString("MensagemBody", "Verifique os parametros passados na URL!");
                            return RedirectToAction("Index", "Home");
                        }

                        byte[] byteInfo = workStream.ToArray();
                        return new FileContentResult(byteInfo, "application/pdf");
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Consulta/CadastrarConsulta'");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                HttpContext.Session.SetString("MensagemTitle", "Erro");
                HttpContext.Session.SetString("MensagemBody", "Exceção: " + ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult BaixarExamePDF(int id, string username) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flPacienteC"] != 0 && (int)ViewData["flExamesC"] != 0) {

                        MemoryStream workStream = new MemoryStream();
                        DateTime dTime = DateTime.Now;

                        Document doc = CriarDocumentoPDF(true);
                        PdfWriter.GetInstance(doc, workStream).CloseStream = false;
                        string strPDFFileName;

                        if (id != 0 && username != null) {
                            PDFBLL pdfBLL = new PDFBLL();
                            PDFDadosExame dadosExame = new PDFDadosExame();
                            dadosExame = pdfBLL.ConsultarDadosExamePreencherPDF(Convert.ToInt32(id), Convert.ToInt32(username));

                            strPDFFileName = string.Format("Solicitação Exame do Paciente " + dadosExame.nome + ".pdf");

                            if (dadosExame != null) {
                                doc = LayoutPDFExame(doc, dadosExame);
                            } else {
                                HttpContext.Session.SetString("MensagemTitle", "Erro na consulta dos dados");
                                HttpContext.Session.SetString("MensagemBody", "Verifique os parametros passados!");
                                return RedirectToAction("Index", "Home");
                            }
                        } else {
                            HttpContext.Session.SetString("MensagemTitle", "Erro na consulta dos dados");
                            HttpContext.Session.SetString("MensagemBody", "Verifique os parametros passados na URL!");
                            return RedirectToAction("Index", "Home");
                        }

                        byte[] byteInfo = workStream.ToArray();
                        workStream.Write(byteInfo, 0, byteInfo.Length);
                        workStream.Position = 0;

                        return File(workStream, "application/pdf", strPDFFileName);
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Consulta/CadastrarConsulta'");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                HttpContext.Session.SetString("MensagemTitle", "Erro");
                HttpContext.Session.SetString("MensagemBody", "Exceção: " + ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        public Document CriarDocumentoPDF(Boolean exameOuMedicamento) {
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 80);
            doc.AddCreationDate();
            
            if (exameOuMedicamento) {
                doc.AddTitle("Receita Exame");
                doc.AddSubject("Receita impressa, Sistema de Gerenciamento da Clínica");
                doc.AddKeywords("receita, exame, sistema de gerenciamento da clínica");
                doc.AddCreator("Sistema de Gerenciamento da Clínica");
                doc.AddAuthor("Sistema Interno do Sistema de Gerenciamento da Clínica");
                doc.AddHeader("Teste1", "teste 2");
            } else {
                doc.AddTitle("Receita Medicamento");
                doc.AddSubject("Receita impressa, Sistema de Gerenciamento da Clínica");
                doc.AddKeywords("receita, exame, sistema de gerenciamento da clínica");
                doc.AddCreator("Sistema de Gerenciamento da Clínica");
                doc.AddAuthor("Sistema Interno do Sistema de Gerenciamento da Clínica");
                doc.AddHeader("Teste3", "teste 4");
            }

            return doc;
        }

        public Document LayoutPDFExame(Document doc, PDFDadosExame dadosExame) {
            doc.Open();

            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
            Font font = new Font(bf, 11);

            BaseFont bfTitulo = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
            Font fontTitulo = new Font(bfTitulo, 14);

            // CREANDO A TABLE
            PdfPTable table = new PdfPTable(3);
            table.HorizontalAlignment = 0;
            table.TotalWidth = 500f;
            table.LockedWidth = true;
            float[] widths = new float[] { 84f, 208f, 208f };
            table.SetWidths(widths);

            // Celula LOGO
            Image myImage = Image.GetInstance("C:\\Users\\mselm\\source\\repos\\SGCM\\wwwroot\\images\\SGCM_logo.png");
            PdfPCell cellImage = new PdfPCell(myImage);
            cellImage.PaddingTop = (float)2;
            cellImage.PaddingLeft = (float)2;
            cellImage.Rowspan = 3;
            cellImage.MinimumHeight = 40;
            table.AddCell(cellImage);

            // CELULA NOME SISTEMA
            PdfPCell cellSistemaNome = new PdfPCell(new Phrase("Sistema de Gerenciamento de Clínica Médica", fontTitulo));
            cellSistemaNome.Colspan = 3;
            cellSistemaNome.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cellSistemaNome);

            // CELULA PACIENTE: NOME
            PdfPCell cellPacienteNome = new PdfPCell(new Phrase("Paciente: " + dadosExame.nome, font));
            cellPacienteNome.PaddingBottom = (float)3;
            table.AddCell(cellPacienteNome);

            // CELULA CPF/RG: NÚMERO
            PdfPCell cellCpfRg = new PdfPCell(new Phrase("CPF/RG: " + dadosExame.rg, font));
            cellCpfRg.PaddingBottom = (float)3;
            table.AddCell(cellCpfRg);

            var dataNascimento = dadosExame.dataNascimento;
            var hoje = DateTime.Now;
            var idade = hoje.Year - dataNascimento.Year;
            if (dataNascimento > hoje.AddYears(-idade)) idade--;

            // CELULA Idade: IDADE
            PdfPCell cellIdade = new PdfPCell(new Phrase("Idade: " + idade, font));
            cellIdade.PaddingBottom = (float)3;
            table.AddCell(cellIdade);

            // CELULA Data Atendimento: DATA
            PdfPCell cellDataAtend = new PdfPCell(new Phrase("Data Atendimento: " + dadosExame.dataConsulta.ToShortDateString(), font));
            cellDataAtend.PaddingBottom = (float)3;
            table.AddCell(cellDataAtend);

            doc.Add(table);

            //criando uma string vazia
            string dados = "";
            //criando a variavel para paragrafo
            //Paragraph paragrafo = new Paragraph(dados, new Font(Font.NORMAL, 14));
            Paragraph paragrafo = new Paragraph(dados, font);
            //etipulando o alinhamneto
            paragrafo.Alignment = Element.ALIGN_JUSTIFIED;
            //Alinhamento Justificado
            //adicioando texto
            paragrafo.Add("Solicito: " + dadosExame.baseNomeExame);
            //acidionado paragrafo ao documento
            doc.Add(paragrafo);

            doc.Close();
            return doc;

        }

        public IActionResult MostrarMedicamentoPDFTela(int id, string username) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flPacienteC"] != 0 && (int)ViewData["flExamesC"] != 0) {
                        MemoryStream workStream = new MemoryStream();
                        Document doc = CriarDocumentoPDF(false);

                        PdfWriter.GetInstance(doc, workStream).CloseStream = false;

                        if (id != 0 && username != null) {
                            PDFBLL pdfBLL = new PDFBLL();
                            PDFDadosMedicamento dadosMedicamento = new PDFDadosMedicamento();
                            dadosMedicamento = pdfBLL.ConsultarDadosMedicamentoPreencherPDF(Convert.ToInt32(id), Convert.ToInt32(username));

                            if (dadosMedicamento != null) {
                                doc = LayoutPDFMedicamento(doc, dadosMedicamento);
                            } else {
                                HttpContext.Session.SetString("MensagemTitle", "Erro na consulta dos dados");
                                HttpContext.Session.SetString("MensagemBody", "Verifique os parametros passados!");
                                return RedirectToAction("Index", "Home");
                            }
                        } else {
                            HttpContext.Session.SetString("MensagemTitle", "Erro na consulta dos dados");
                            HttpContext.Session.SetString("MensagemBody", "Verifique os parametros passados na URL!");
                            return RedirectToAction("Index", "Home");
                        }

                        byte[] byteInfo = workStream.ToArray();
                        return new FileContentResult(byteInfo, "application/pdf");
                    } else {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Consulta/CadastrarConsulta'");
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            } catch (Exception ex) {
                HttpContext.Session.SetString("MensagemTitle", "Erro");
                HttpContext.Session.SetString("MensagemBody", "Exceção: " + ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult BaixarPDFMedicamento(int id, string username) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flPacienteC"] != 0 && (int)ViewData["flExamesC"] != 0) {

                        MemoryStream workStream = new MemoryStream();
                        DateTime dTime = DateTime.Now;

                        Document doc = CriarDocumentoPDF(true);
                        PdfWriter.GetInstance(doc, workStream).CloseStream = false;
                        string strPDFFileName;

                        if (id != 0 && username != null) {
                            PDFBLL pdfBLL = new PDFBLL();
                            PDFDadosMedicamento dadosMedicamento = new PDFDadosMedicamento();
                            dadosMedicamento = pdfBLL.ConsultarDadosMedicamentoPreencherPDF(Convert.ToInt32(id), Convert.ToInt32(username));

                            strPDFFileName = string.Format("Receita Medicamento do Paciente " + dadosMedicamento.nome + ".pdf");

                            if (dadosMedicamento != null) {
                                doc = LayoutPDFMedicamento(doc, dadosMedicamento);
                            } else {
                                HttpContext.Session.SetString("MensagemTitle", "Erro na consulta dos dados");
                                HttpContext.Session.SetString("MensagemBody", "Verifique os parametros passados!");
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                        {
                            HttpContext.Session.SetString("MensagemTitle", "Erro na consulta dos dados");
                            HttpContext.Session.SetString("MensagemBody", "Verifique os parametros passados na URL!");
                            return RedirectToAction("Index", "Home");
                        }

                        byte[] byteInfo = workStream.ToArray();
                        workStream.Write(byteInfo, 0, byteInfo.Length);
                        workStream.Position = 0;

                        return File(workStream, "application/pdf", strPDFFileName);
                    }
                    else
                    {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Consulta/CadastrarConsulta'");
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            }
            catch (Exception ex)
            {
                HttpContext.Session.SetString("MensagemTitle", "Erro");
                HttpContext.Session.SetString("MensagemBody", "Exceção: " + ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        public Document LayoutPDFMedicamento(Document doc, PDFDadosMedicamento dadosMedicamento) {
            doc.Open();

            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
            Font font = new Font(bf, 11);

            BaseFont bfTitulo = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
            Font fontTitulo = new Font(bfTitulo, 14);

            // CREANDO A TABLE
            PdfPTable table = new PdfPTable(3);
            table.HorizontalAlignment = 0;
            table.TotalWidth = 500f;
            table.LockedWidth = true;
            float[] widths = new float[] { 84f, 208f, 208f };
            table.SetWidths(widths);

            // Celula LOGO
            Image myImage = Image.GetInstance("C:\\Users\\mselm\\source\\repos\\SGCM\\wwwroot\\images\\SGCM_logo.png");
            PdfPCell cellImage = new PdfPCell(myImage);
            cellImage.PaddingTop = (float)2;
            cellImage.PaddingLeft = (float)2;
            cellImage.Rowspan = 3;
            cellImage.MinimumHeight = 40;
            table.AddCell(cellImage);

            // CELULA NOME SISTEMA
            PdfPCell cellSistemaNome = new PdfPCell(new Phrase("Sistema de Gerenciamento de Clínica Médica", fontTitulo));
            cellSistemaNome.Colspan = 3;
            cellSistemaNome.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cellSistemaNome);

            // CELULA PACIENTE: NOME
            PdfPCell cellPacienteNome = new PdfPCell(new Phrase("Paciente: " + dadosMedicamento.nome, font));
            cellPacienteNome.PaddingBottom = (float)3;
            table.AddCell(cellPacienteNome);

            // CELULA CPF/RG: NÚMERO
            PdfPCell cellCpfRg = new PdfPCell(new Phrase("CPF/RG: " + dadosMedicamento.rg, font));
            cellCpfRg.PaddingBottom = (float)3;
            table.AddCell(cellCpfRg);

            var dataNascimento = dadosMedicamento.dataNascimento;
            var hoje = DateTime.Now;
            var idade = hoje.Year - dataNascimento.Year;
            if (dataNascimento > hoje.AddYears(-idade)) idade--;

            // CELULA Idade: IDADE
            PdfPCell cellIdade = new PdfPCell(new Phrase("Idade: " + idade, font));
            cellIdade.PaddingBottom = (float)3;
            table.AddCell(cellIdade);

            // CELULA Data Atendimento: DATA
            PdfPCell cellDataAtend = new PdfPCell(new Phrase("Data Atendimento: " + dadosMedicamento.dataConsulta.ToShortDateString(), font));
            cellDataAtend.PaddingBottom = (float)3;
            table.AddCell(cellDataAtend);

            doc.Add(table);

            string dados = "";
            Paragraph paragrafoFixo = new Paragraph(dados, font);
            paragrafoFixo.Alignment = Element.ALIGN_JUSTIFIED;
            paragrafoFixo.Add("Uso oral: ");
            doc.Add(paragrafoFixo);

            string dadosVariavel = "";
            Paragraph paragrafoVariavel = new Paragraph(dadosVariavel, font);
            paragrafoVariavel.Alignment = Element.ALIGN_JUSTIFIED;
            paragrafoVariavel.Add("                 " + dadosMedicamento.nomeGenerico + "_______________________________________________");
            doc.Add(paragrafoVariavel);

            doc.Close();
            return doc;

        }

        public IActionResult MostrarRelatorioPaciente(int id) {
            try {
                ViewBag.MensagemBodyController = "";
                ViewBag.MensagemBodyAction = "";
                ViewBag.MensagemBody = "";
                CarregarDadosUsuarioParaTela();
                if ((ViewData["idUsuario"] != null) && ((int)ViewData["idUsuario"] != 0)) {
                    if ((int)ViewData["flPacienteC"] != 0 && (int)ViewData["flExamesC"] != 0) {
                        MemoryStream workStream = new MemoryStream();
                        Document doc = CriarDocumentoPDF(true);

                        PdfWriter.GetInstance(doc, workStream).CloseStream = false;

                        if (id != 0) {
                            PDFBLL pdfBLL = new PDFBLL();
                            DPFDadosPacienteModel dadosPaciente = new DPFDadosPacienteModel();
                            dadosPaciente = pdfBLL.ConsultarDadosPacientePreencherPDF(Convert.ToInt32(id));

                            if (dadosPaciente != null) {
                                doc = LayoutPDFPaciente(doc, dadosPaciente);
                            }
                            else
                            {
                                HttpContext.Session.SetString("MensagemTitle", "Erro na consulta dos dados");
                                HttpContext.Session.SetString("MensagemBody", "O paciente não tem consulta cadastrada!");
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                        {
                            HttpContext.Session.SetString("MensagemTitle", "Erro na consulta dos dados");
                            HttpContext.Session.SetString("MensagemBody", "Verifique os parametros passados na URL!");
                            return RedirectToAction("Index", "Home");
                        }

                        byte[] byteInfo = workStream.ToArray();
                        return new FileContentResult(byteInfo, "application/pdf");
                    }
                    else
                    {
                        HttpContext.Session.SetString("MensagemTitle", "Erro");
                        HttpContext.Session.SetString("MensagemBody", "O usuário " + ViewData["nome"] + " não tem acesso a página: 'Consulta/CadastrarConsulta'");
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewData.Add("ReturnUrl", ((object[])this.ControllerContext.RouteData.Values.Values)[0] + "/" + ((object[])this.ControllerContext.RouteData.Values.Values)[1]);
                    return RedirectToAction("Signin", "Login", new { ReturnUrl = ViewData["ReturnUrl"] });
                }
            }
            catch (Exception ex)
            {
                HttpContext.Session.SetString("MensagemTitle", "Erro");
                HttpContext.Session.SetString("MensagemBody", "Exceção: " + ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        public Document LayoutPDFPaciente(Document doc, DPFDadosPacienteModel dadosPaciente) {
            doc.Open();

            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
            Font font = new Font(bf, 11);

            BaseFont bfTitulo = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
            Font fontTitulo = new Font(bfTitulo, 14);

            // CREANDO A TABLE
            PdfPTable table = new PdfPTable(3);
            table.HorizontalAlignment = 0;
            table.TotalWidth = 500f;
            table.LockedWidth = true;
            float[] widths = new float[] { 84f, 208f, 208f };
            table.SetWidths(widths);

            // Celula LOGO
            Image myImage = Image.GetInstance("C:\\Users\\mselm\\source\\repos\\SGCM\\wwwroot\\images\\SGCM_logo.png");
            PdfPCell cellImage = new PdfPCell(myImage);
            cellImage.PaddingTop = (float)2;
            cellImage.PaddingLeft = (float)2;
            cellImage.Rowspan = 3;
            cellImage.MinimumHeight = 40;
            table.AddCell(cellImage);

            // CELULA NOME SISTEMA
            PdfPCell cellSistemaNome = new PdfPCell(new Phrase("Sistema de Gerenciamento de Clínica Médica", fontTitulo));
            cellSistemaNome.Colspan = 3;
            cellSistemaNome.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cellSistemaNome);

            // CELULA PACIENTE: NOME
            PdfPCell cellPacienteNome = new PdfPCell(new Phrase("Paciente: " + dadosPaciente.nome, font));
            cellPacienteNome.PaddingBottom = (float)3;
            table.AddCell(cellPacienteNome);

            // CELULA CPF/RG: NÚMERO
            PdfPCell cellCpfRg = new PdfPCell(new Phrase("CPF/RG: " + dadosPaciente.rg, font));
            cellCpfRg.PaddingBottom = (float)3;
            table.AddCell(cellCpfRg);

            var dataNascimento = dadosPaciente.dataNascimento;
            var hoje = DateTime.Now;
            var idade = hoje.Year - dataNascimento.Year;
            if (dataNascimento > hoje.AddYears(-idade)) idade--;

            // CELULA Idade: IDADE
            PdfPCell cellIdade = new PdfPCell(new Phrase("Idade: " + idade, font));
            cellIdade.PaddingBottom = (float)3;
            table.AddCell(cellIdade);

            // CELULA Data Atendimento: DATA
            PdfPCell cellDataAtend = new PdfPCell(new Phrase("Data Consulta: " + DateTime.Now.ToShortDateString(), font));
            cellDataAtend.PaddingBottom = (float)3;
            table.AddCell(cellDataAtend);

            doc.Add(table);

            Paragraph paragrafo = new Paragraph();
            paragrafo.Add(" ");

            doc.Add(paragrafo);

            // CREANDO A TABLE
            PdfPTable tableConsulta = new PdfPTable(3);
            tableConsulta.HorizontalAlignment = 0;
            tableConsulta.TotalWidth = 500f;
            tableConsulta.LockedWidth = true;
            float[] widthsConsulta = new float[] { 84f, 208f, 208f };
            tableConsulta.SetWidths(widthsConsulta);

            PdfPCell cellNumeracaoCabecalho = new PdfPCell(new Phrase("Numeração", font));
            cellNumeracaoCabecalho.PaddingBottom = (float)3;
            tableConsulta.AddCell(cellNumeracaoCabecalho);

            PdfPCell cellDataConsultaCabecalho = new PdfPCell(new Phrase("Data e Hora da Consulta", font));
            cellDataConsultaCabecalho.PaddingBottom = (float)3;
            tableConsulta.AddCell(cellDataConsultaCabecalho);

            PdfPCell cellStatusCabecalho = new PdfPCell(new Phrase("Status Consulta", font));
            cellStatusCabecalho.PaddingBottom = (float)3;
            tableConsulta.AddCell(cellStatusCabecalho);

            var numeracao = 1;

            foreach (var consulta in dadosPaciente.ListPaciente) {
                // CELULA PACIENTE: NUMERAÇÃO
                PdfPCell cellNumeracao = new PdfPCell(new Phrase("" + numeracao, font));
                cellNumeracao.PaddingBottom = (float)3;
                tableConsulta.AddCell(cellNumeracao);

                // CELULA PACIENTE: DATA CONSULTA
                PdfPCell cellDataConsulta = new PdfPCell(new Phrase("" + dadosPaciente.ListPaciente[1].dataConsulta, font));
                cellDataConsulta.PaddingBottom = (float)3;
                tableConsulta.AddCell(cellDataConsulta);

                // CELULA PACIENTE: STATUS

                var status = "";

                if (dadosPaciente.ListPaciente[1].status == 1) {
                    status = "Finalizada";
                } else if (dadosPaciente.ListPaciente[1].status == 0) {
                    status = "Aberta";
                }

                PdfPCell cellStatus = new PdfPCell(new Phrase("" + status, font));
                cellStatus.PaddingBottom = (float)3;
                tableConsulta.AddCell(cellStatus);

                numeracao++;
            }

            doc.Add(tableConsulta);

            doc.Close();
            return doc;

        }

        private void CarregarDadosUsuarioParaTela() {
        
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
 