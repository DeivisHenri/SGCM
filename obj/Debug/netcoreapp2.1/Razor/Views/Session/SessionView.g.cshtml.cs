#pragma checksum "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d84f81277755423e48e21bacea405a98198e4651"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d84f81277755423e48e21bacea405a98198e4651", @"/Views/Session/SessionView.cshtml")]
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
            BeginContext(39, 21, true);
            WriteLiteral("</h4>\r\n<h4>Username: ");
            EndContext();
            BeginContext(61, 16, false);
#line 4 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         Write(ViewBag.Username);

#line default
#line hidden
            EndContext();
            BeginContext(77, 21, true);
            WriteLiteral("</h4>\r\n<h4>Password: ");
            EndContext();
            BeginContext(99, 16, false);
#line 5 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         Write(ViewBag.Password);

#line default
#line hidden
            EndContext();
            BeginContext(115, 25, true);
            WriteLiteral("</h4>\r\n<h4>Tipo Usuário: ");
            EndContext();
            BeginContext(141, 19, false);
#line 6 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
             Write(ViewBag.TipoUsuario);

#line default
#line hidden
            EndContext();
            BeginContext(160, 21, true);
            WriteLiteral("</h4>\r\n<h4>IdMedico: ");
            EndContext();
            BeginContext(182, 17, false);
#line 7 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         Write(ViewBag.Id_Medico);

#line default
#line hidden
            EndContext();
            BeginContext(199, 170, true);
            WriteLiteral("</h4>\r\n\r\n<table border=\"1\">\r\n    <tr>\r\n        <th align=\"center\">Nome da Flag</th>\r\n        <th align=\"center\">Sim</th>\r\n        <th align=\"center\">Não</th>\r\n    </tr>\r\n");
            EndContext();
            BeginContext(388, 44, true);
            WriteLiteral("    <tr>\r\n        <td>Inserir Usuário</td>\r\n");
            EndContext();
#line 18 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlUsuarioI == 1)
        {

#line default
#line hidden
            BeginContext(482, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(499, 18, false);
#line 20 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlUsuarioI);

#line default
#line hidden
            EndContext();
            BeginContext(517, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 22 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(584, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(625, 18, false);
#line 26 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlUsuarioI);

#line default
#line hidden
            EndContext();
            BeginContext(643, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 27 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(661, 57, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Consultar Usuário</td>\r\n");
            EndContext();
#line 31 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlUsuarioC == 1)
        {

#line default
#line hidden
            BeginContext(768, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(785, 18, false);
#line 33 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlUsuarioC);

#line default
#line hidden
            EndContext();
            BeginContext(803, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 35 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(870, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(911, 18, false);
#line 39 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlUsuarioC);

#line default
#line hidden
            EndContext();
            BeginContext(929, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 40 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(947, 55, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Alterar Usuário</td>\r\n");
            EndContext();
#line 44 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlUsuarioA == 1)
        {

#line default
#line hidden
            BeginContext(1052, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(1069, 18, false);
#line 46 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlUsuarioA);

#line default
#line hidden
            EndContext();
            BeginContext(1087, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 48 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(1154, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(1195, 18, false);
#line 52 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlUsuarioA);

#line default
#line hidden
            EndContext();
            BeginContext(1213, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 53 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(1231, 55, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Excluir Usuário</td>\r\n");
            EndContext();
#line 57 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlUsuarioE == 1)
        {

#line default
#line hidden
            BeginContext(1336, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(1353, 18, false);
#line 59 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlUsuarioE);

#line default
#line hidden
            EndContext();
            BeginContext(1371, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 61 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(1438, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(1479, 18, false);
#line 65 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlUsuarioE);

#line default
#line hidden
            EndContext();
            BeginContext(1497, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 66 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(1515, 11, true);
            WriteLiteral("    </tr>\r\n");
            EndContext();
            BeginContext(1546, 45, true);
            WriteLiteral("    <tr>\r\n        <td>Inserir Paciente</td>\r\n");
            EndContext();
#line 71 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlPacienteI == 1)
        {

#line default
#line hidden
            BeginContext(1642, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(1659, 19, false);
#line 73 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlPacienteI);

#line default
#line hidden
            EndContext();
            BeginContext(1678, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 75 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(1745, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(1786, 19, false);
#line 79 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlPacienteI);

#line default
#line hidden
            EndContext();
            BeginContext(1805, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 80 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(1823, 58, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Consultar Paciente</td>\r\n");
            EndContext();
#line 84 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlPacienteC == 1)
        {

#line default
#line hidden
            BeginContext(1932, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(1949, 19, false);
#line 86 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlPacienteC);

#line default
#line hidden
            EndContext();
            BeginContext(1968, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 88 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(2035, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(2076, 19, false);
#line 92 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlPacienteC);

#line default
#line hidden
            EndContext();
            BeginContext(2095, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 93 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(2113, 56, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Alterar Paciente</td>\r\n");
            EndContext();
#line 97 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlPacienteA == 1)
        {

#line default
#line hidden
            BeginContext(2220, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(2237, 19, false);
#line 99 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlPacienteA);

#line default
#line hidden
            EndContext();
            BeginContext(2256, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 101 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(2323, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(2364, 19, false);
#line 105 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlPacienteA);

#line default
#line hidden
            EndContext();
            BeginContext(2383, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 106 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(2401, 56, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Excluir Paciente</td>\r\n");
            EndContext();
#line 110 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlPacienteE == 1)
        {

#line default
#line hidden
            BeginContext(2508, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(2525, 19, false);
#line 112 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlPacienteE);

#line default
#line hidden
            EndContext();
            BeginContext(2544, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 114 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(2611, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(2652, 19, false);
#line 118 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlPacienteE);

#line default
#line hidden
            EndContext();
            BeginContext(2671, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 119 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(2689, 11, true);
            WriteLiteral("    </tr>\r\n");
            EndContext();
            BeginContext(2720, 45, true);
            WriteLiteral("    <tr>\r\n        <td>Inserir Consulta</td>\r\n");
            EndContext();
#line 124 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlConsultaI == 1)
        {

#line default
#line hidden
            BeginContext(2816, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(2833, 19, false);
#line 126 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlConsultaI);

#line default
#line hidden
            EndContext();
            BeginContext(2852, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 128 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(2919, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(2960, 19, false);
#line 132 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlConsultaI);

#line default
#line hidden
            EndContext();
            BeginContext(2979, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 133 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(2997, 58, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Consultar Consulta</td>\r\n");
            EndContext();
#line 137 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlConsultaC == 1)
        {

#line default
#line hidden
            BeginContext(3106, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(3123, 19, false);
#line 139 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlConsultaC);

#line default
#line hidden
            EndContext();
            BeginContext(3142, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 141 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(3209, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(3250, 19, false);
#line 145 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlConsultaC);

#line default
#line hidden
            EndContext();
            BeginContext(3269, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 146 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(3287, 56, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Alterar Consulta</td>\r\n");
            EndContext();
#line 150 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlConsultaA == 1)
        {

#line default
#line hidden
            BeginContext(3394, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(3411, 19, false);
#line 152 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlConsultaA);

#line default
#line hidden
            EndContext();
            BeginContext(3430, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 154 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(3497, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(3538, 19, false);
#line 158 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlConsultaA);

#line default
#line hidden
            EndContext();
            BeginContext(3557, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 159 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(3575, 56, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Excluir Consulta</td>\r\n");
            EndContext();
#line 163 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlConsultaE == 1)
        {

#line default
#line hidden
            BeginContext(3682, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(3699, 19, false);
#line 165 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlConsultaE);

#line default
#line hidden
            EndContext();
            BeginContext(3718, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 167 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(3785, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(3826, 19, false);
#line 171 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlConsultaE);

#line default
#line hidden
            EndContext();
            BeginContext(3845, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 172 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(3863, 11, true);
            WriteLiteral("    </tr>\r\n");
            EndContext();
            BeginContext(3897, 48, true);
            WriteLiteral("    <tr>\r\n        <td>Inserir Medicamento</td>\r\n");
            EndContext();
#line 177 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlMedicamentoI == 1)
        {

#line default
#line hidden
            BeginContext(3999, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(4016, 22, false);
#line 179 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlMedicamentoI);

#line default
#line hidden
            EndContext();
            BeginContext(4038, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 181 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(4105, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(4146, 22, false);
#line 185 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlMedicamentoI);

#line default
#line hidden
            EndContext();
            BeginContext(4168, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 186 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(4186, 58, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Consultar Consulta</td>\r\n");
            EndContext();
#line 190 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlMedicamentoC == 1)
        {

#line default
#line hidden
            BeginContext(4298, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(4315, 22, false);
#line 192 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlMedicamentoC);

#line default
#line hidden
            EndContext();
            BeginContext(4337, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 194 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(4404, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(4445, 22, false);
#line 198 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlMedicamentoC);

#line default
#line hidden
            EndContext();
            BeginContext(4467, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 199 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(4485, 59, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Alterar Medicamento</td>\r\n");
            EndContext();
#line 203 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlMedicamentoA == 1)
        {

#line default
#line hidden
            BeginContext(4598, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(4615, 22, false);
#line 205 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlMedicamentoA);

#line default
#line hidden
            EndContext();
            BeginContext(4637, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 207 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(4704, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(4745, 22, false);
#line 211 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlMedicamentoA);

#line default
#line hidden
            EndContext();
            BeginContext(4767, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 212 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(4785, 59, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Excluir Medicamento</td>\r\n");
            EndContext();
#line 216 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlMedicamentoE == 1)
        {

#line default
#line hidden
            BeginContext(4898, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(4915, 22, false);
#line 218 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlMedicamentoE);

#line default
#line hidden
            EndContext();
            BeginContext(4937, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 220 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(5004, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(5045, 22, false);
#line 224 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlMedicamentoE);

#line default
#line hidden
            EndContext();
            BeginContext(5067, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 225 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(5085, 11, true);
            WriteLiteral("    </tr>\r\n");
            EndContext();
            BeginContext(5113, 43, true);
            WriteLiteral("    <tr>\r\n        <td>Inserir Exames</td>\r\n");
            EndContext();
#line 230 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlExamesI == 1)
        {

#line default
#line hidden
            BeginContext(5205, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(5222, 17, false);
#line 232 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlExamesI);

#line default
#line hidden
            EndContext();
            BeginContext(5239, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 234 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(5306, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(5347, 17, false);
#line 238 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlExamesI);

#line default
#line hidden
            EndContext();
            BeginContext(5364, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 239 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(5382, 56, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Consultar Exames</td>\r\n");
            EndContext();
#line 243 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlExamesC == 1)
        {

#line default
#line hidden
            BeginContext(5487, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(5504, 17, false);
#line 245 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlExamesC);

#line default
#line hidden
            EndContext();
            BeginContext(5521, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 247 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(5588, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(5629, 17, false);
#line 251 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlExamesC);

#line default
#line hidden
            EndContext();
            BeginContext(5646, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 252 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(5664, 54, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Alterar Exames</td>\r\n");
            EndContext();
#line 256 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlExamesA == 1)
        {

#line default
#line hidden
            BeginContext(5767, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(5784, 17, false);
#line 258 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlExamesA);

#line default
#line hidden
            EndContext();
            BeginContext(5801, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 260 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(5868, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(5909, 17, false);
#line 264 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlExamesA);

#line default
#line hidden
            EndContext();
            BeginContext(5926, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 265 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(5944, 54, true);
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Excluir Exames</td>\r\n");
            EndContext();
#line 269 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
         if (ViewBag.FlExamesE == 1)
        {

#line default
#line hidden
            BeginContext(6047, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(6064, 17, false);
#line 271 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlExamesE);

#line default
#line hidden
            EndContext();
            BeginContext(6081, 31, true);
            WriteLiteral("</td>\r\n            <td>0</td>\r\n");
            EndContext();
#line 273 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(6148, 40, true);
            WriteLiteral("            <td>0</td>\r\n            <td>");
            EndContext();
            BeginContext(6189, 17, false);
#line 277 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
           Write(ViewBag.FlExamesE);

#line default
#line hidden
            EndContext();
            BeginContext(6206, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 278 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Session\SessionView.cshtml"
        }

#line default
#line hidden
            BeginContext(6224, 43, true);
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
