#pragma checksum "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c78002b9d6faf313b2d82f0465f13878e40bd2e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Session_SessionView), @"mvc.1.0.view", @"/Views/Session/SessionView.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Session/SessionView.cshtml", typeof(AspNetCore.Views_Session_SessionView))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\_ViewImports.cshtml"
using SGCM;

#line default
#line hidden
#line 2 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\_ViewImports.cshtml"
using SGCM.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c78002b9d6faf313b2d82f0465f13878e40bd2e5", @"/Views/Session/SessionView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a01b0d20c99ef0324f635b4f4cb6f1d7d1176331", @"/Views/_ViewImports.cshtml")]
    public class Views_Session_SessionView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 28, true);
            WriteLiteral("<h2>Session</h2>\r\n\r\n<h4>ID: ");
            EndContext();
            BeginContext(29, 10, false);
#line 3 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
   Write(ViewBag.ID);

#line default
#line hidden
            EndContext();
            BeginContext(39, 13, true);
            WriteLiteral(" - Username: ");
            EndContext();
            BeginContext(53, 16, false);
#line 3 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
                           Write(ViewBag.Username);

#line default
#line hidden
            EndContext();
            BeginContext(69, 13, true);
            WriteLiteral(" - Password: ");
            EndContext();
            BeginContext(83, 16, false);
#line 3 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
                                                         Write(ViewBag.Password);

#line default
#line hidden
            EndContext();
            BeginContext(99, 17, true);
            WriteLiteral(" - Tipo Usuário: ");
            EndContext();
            BeginContext(117, 19, false);
#line 3 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
                                                                                           Write(ViewBag.TipoUsuario);

#line default
#line hidden
            EndContext();
            BeginContext(136, 170, true);
            WriteLiteral("</h4>\r\n\r\n<table border=\"1\">\r\n    <tr>\r\n        <th align=\"center\">Nome da Flag</th>\r\n        <th align=\"center\">Sim</th>\r\n        <th align=\"center\">Não</th>\r\n    </tr>\r\n");
            EndContext();
            BeginContext(325, 44, true);
            WriteLiteral("    <tr>\r\n        <td>Inserir Usuário</td>\r\n");
            EndContext();
#line 14 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlUsuarioI == 1) {

#line default
#line hidden
            BeginContext(410, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(427, 18, false);
#line 15 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlUsuarioI);

#line default
#line hidden
            EndContext();
            BeginContext(445, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 17 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        } else {

#line default
#line hidden
            BeginContext(494, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(535, 18, false);
#line 19 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlUsuarioI);

#line default
#line hidden
            EndContext();
            BeginContext(553, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 20 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(571, 57, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Consultar Usuário</td>\r\n");
            EndContext();
#line 24 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlUsuarioC == 1) {

#line default
#line hidden
            BeginContext(669, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(686, 18, false);
#line 25 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlUsuarioC);

#line default
#line hidden
            EndContext();
            BeginContext(704, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 27 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        } else {

#line default
#line hidden
            BeginContext(753, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(794, 18, false);
#line 29 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlUsuarioC);

#line default
#line hidden
            EndContext();
            BeginContext(812, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 30 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(830, 55, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Alterar Usuário</td>\r\n");
            EndContext();
#line 34 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlUsuarioA == 1) {

#line default
#line hidden
            BeginContext(926, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(943, 18, false);
#line 35 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlUsuarioA);

#line default
#line hidden
            EndContext();
            BeginContext(961, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 37 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        } else {

#line default
#line hidden
            BeginContext(1010, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(1051, 18, false);
#line 39 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlUsuarioA);

#line default
#line hidden
            EndContext();
            BeginContext(1069, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 40 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(1087, 55, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Excluir Usuário</td>\r\n");
            EndContext();
#line 44 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlUsuarioE == 1) {

#line default
#line hidden
            BeginContext(1183, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(1200, 18, false);
#line 45 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlUsuarioE);

#line default
#line hidden
            EndContext();
            BeginContext(1218, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 47 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        } else {

#line default
#line hidden
            BeginContext(1267, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(1308, 18, false);
#line 49 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlUsuarioE);

#line default
#line hidden
            EndContext();
            BeginContext(1326, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 50 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(1344, 11, true);
            WriteLiteral("    </tr>\r\n");
            EndContext();
            BeginContext(1375, 45, true);
            WriteLiteral("    <tr>\r\n        <td>Inserir Paciente</td>\r\n");
            EndContext();
#line 55 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlPacienteI == 1) {

#line default
#line hidden
            BeginContext(1462, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(1479, 19, false);
#line 56 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlPacienteI);

#line default
#line hidden
            EndContext();
            BeginContext(1498, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 58 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        } else {

#line default
#line hidden
            BeginContext(1547, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(1588, 19, false);
#line 60 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlPacienteI);

#line default
#line hidden
            EndContext();
            BeginContext(1607, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 61 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(1625, 58, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Consultar Paciente</td>\r\n");
            EndContext();
#line 65 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlPacienteC == 1) {

#line default
#line hidden
            BeginContext(1725, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(1742, 19, false);
#line 66 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlPacienteC);

#line default
#line hidden
            EndContext();
            BeginContext(1761, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 68 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        } else {

#line default
#line hidden
            BeginContext(1810, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(1851, 19, false);
#line 70 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlPacienteC);

#line default
#line hidden
            EndContext();
            BeginContext(1870, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 71 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(1888, 56, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Alterar Paciente</td>\r\n");
            EndContext();
#line 75 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlPacienteA == 1) {

#line default
#line hidden
            BeginContext(1986, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(2003, 19, false);
#line 76 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlPacienteA);

#line default
#line hidden
            EndContext();
            BeginContext(2022, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 78 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        } else {

#line default
#line hidden
            BeginContext(2071, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(2112, 19, false);
#line 80 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlPacienteA);

#line default
#line hidden
            EndContext();
            BeginContext(2131, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 81 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(2149, 56, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Excluir Paciente</td>\r\n");
            EndContext();
#line 85 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlPacienteE == 1) {

#line default
#line hidden
            BeginContext(2247, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(2264, 19, false);
#line 86 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlPacienteE);

#line default
#line hidden
            EndContext();
            BeginContext(2283, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 88 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        } else {

#line default
#line hidden
            BeginContext(2332, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(2373, 19, false);
#line 90 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlPacienteE);

#line default
#line hidden
            EndContext();
            BeginContext(2392, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 91 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(2410, 11, true);
            WriteLiteral("    </tr>\r\n");
            EndContext();
            BeginContext(2441, 45, true);
            WriteLiteral("    <tr>\r\n        <td>Inserir Consulta</td>\r\n");
            EndContext();
#line 96 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlConsultaI == 1) {

#line default
#line hidden
            BeginContext(2528, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(2545, 19, false);
#line 97 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlConsultaI);

#line default
#line hidden
            EndContext();
            BeginContext(2564, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 99 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        } else {

#line default
#line hidden
            BeginContext(2613, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(2654, 19, false);
#line 101 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlConsultaI);

#line default
#line hidden
            EndContext();
            BeginContext(2673, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 102 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(2691, 58, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Consultar Consulta</td>\r\n");
            EndContext();
#line 106 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlConsultaC == 1) {

#line default
#line hidden
            BeginContext(2791, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(2808, 19, false);
#line 107 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlConsultaC);

#line default
#line hidden
            EndContext();
            BeginContext(2827, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 109 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        } else {

#line default
#line hidden
            BeginContext(2876, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(2917, 19, false);
#line 111 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlConsultaC);

#line default
#line hidden
            EndContext();
            BeginContext(2936, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 112 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(2954, 56, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Alterar Consulta</td>\r\n");
            EndContext();
#line 116 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlConsultaA == 1) {

#line default
#line hidden
            BeginContext(3052, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(3069, 19, false);
#line 117 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlConsultaA);

#line default
#line hidden
            EndContext();
            BeginContext(3088, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 119 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        } else {

#line default
#line hidden
            BeginContext(3137, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(3178, 19, false);
#line 121 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlConsultaA);

#line default
#line hidden
            EndContext();
            BeginContext(3197, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 122 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(3215, 56, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Excluir Consulta</td>\r\n");
            EndContext();
#line 126 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlConsultaE == 1) {

#line default
#line hidden
            BeginContext(3313, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(3330, 19, false);
#line 127 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlConsultaE);

#line default
#line hidden
            EndContext();
            BeginContext(3349, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 129 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        } else {

#line default
#line hidden
            BeginContext(3398, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(3439, 19, false);
#line 131 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlConsultaE);

#line default
#line hidden
            EndContext();
            BeginContext(3458, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 132 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(3476, 11, true);
            WriteLiteral("    </tr>\r\n");
            EndContext();
            BeginContext(3510, 48, true);
            WriteLiteral("    <tr>\r\n        <td>Inserir Medicamento</td>\r\n");
            EndContext();
#line 137 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlMedicamentoI == 1) {

#line default
#line hidden
            BeginContext(3603, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(3620, 22, false);
#line 138 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlMedicamentoI);

#line default
#line hidden
            EndContext();
            BeginContext(3642, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 140 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        } else {

#line default
#line hidden
            BeginContext(3691, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(3732, 22, false);
#line 142 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlMedicamentoI);

#line default
#line hidden
            EndContext();
            BeginContext(3754, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 143 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(3772, 58, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Consultar Consulta</td>\r\n");
            EndContext();
#line 147 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlMedicamentoC == 1) {

#line default
#line hidden
            BeginContext(3875, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(3892, 22, false);
#line 148 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlMedicamentoC);

#line default
#line hidden
            EndContext();
            BeginContext(3914, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 150 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        } else {

#line default
#line hidden
            BeginContext(3963, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(4004, 22, false);
#line 152 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlMedicamentoC);

#line default
#line hidden
            EndContext();
            BeginContext(4026, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 153 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(4044, 59, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Alterar Medicamento</td>\r\n");
            EndContext();
#line 157 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlMedicamentoA == 1) {

#line default
#line hidden
            BeginContext(4148, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(4165, 22, false);
#line 158 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlMedicamentoA);

#line default
#line hidden
            EndContext();
            BeginContext(4187, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 160 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        } else {

#line default
#line hidden
            BeginContext(4236, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(4277, 22, false);
#line 162 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlMedicamentoA);

#line default
#line hidden
            EndContext();
            BeginContext(4299, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 163 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(4317, 59, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Excluir Medicamento</td>\r\n");
            EndContext();
#line 167 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlMedicamentoE == 1) {

#line default
#line hidden
            BeginContext(4421, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(4438, 22, false);
#line 168 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlMedicamentoE);

#line default
#line hidden
            EndContext();
            BeginContext(4460, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 170 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        } else {

#line default
#line hidden
            BeginContext(4509, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(4550, 22, false);
#line 172 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlMedicamentoE);

#line default
#line hidden
            EndContext();
            BeginContext(4572, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 173 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(4590, 11, true);
            WriteLiteral("    </tr>\r\n");
            EndContext();
            BeginContext(4618, 43, true);
            WriteLiteral("    <tr>\r\n        <td>Inserir Exames</td>\r\n");
            EndContext();
#line 178 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlExamesI == 1) {

#line default
#line hidden
            BeginContext(4701, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(4718, 17, false);
#line 179 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlExamesI);

#line default
#line hidden
            EndContext();
            BeginContext(4735, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 181 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        } else {

#line default
#line hidden
            BeginContext(4784, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(4825, 17, false);
#line 183 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlExamesI);

#line default
#line hidden
            EndContext();
            BeginContext(4842, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 184 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(4860, 56, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Consultar Exames</td>\r\n");
            EndContext();
#line 188 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlExamesC == 1) {

#line default
#line hidden
            BeginContext(4956, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(4973, 17, false);
#line 189 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlExamesC);

#line default
#line hidden
            EndContext();
            BeginContext(4990, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 191 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        } else {

#line default
#line hidden
            BeginContext(5039, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(5080, 17, false);
#line 193 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlExamesC);

#line default
#line hidden
            EndContext();
            BeginContext(5097, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 194 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(5115, 54, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Alterar Exames</td>\r\n");
            EndContext();
#line 198 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlExamesA == 1) {

#line default
#line hidden
            BeginContext(5209, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(5226, 17, false);
#line 199 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlExamesA);

#line default
#line hidden
            EndContext();
            BeginContext(5243, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 201 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        } else {

#line default
#line hidden
            BeginContext(5292, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(5333, 17, false);
#line 203 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlExamesA);

#line default
#line hidden
            EndContext();
            BeginContext(5350, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 204 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(5368, 54, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Excluir Exames</td>\r\n");
            EndContext();
#line 208 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlExamesE == 1) {

#line default
#line hidden
            BeginContext(5462, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(5479, 17, false);
#line 209 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlExamesE);

#line default
#line hidden
            EndContext();
            BeginContext(5496, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 211 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        } else {

#line default
#line hidden
            BeginContext(5545, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(5586, 17, false);
#line 213 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlExamesE);

#line default
#line hidden
            EndContext();
            BeginContext(5603, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 214 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(5621, 43, true);
            WriteLiteral("    </tr>\r\n</table>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
