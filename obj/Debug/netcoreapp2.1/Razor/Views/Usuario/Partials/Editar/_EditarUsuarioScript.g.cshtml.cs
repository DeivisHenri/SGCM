#pragma checksum "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Usuario\Partials\Editar\_EditarUsuarioScript.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e287a260c119c40661ab40370c0a6c27bf42bf52"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Partials_Editar__EditarUsuarioScript), @"mvc.1.0.view", @"/Views/Usuario/Partials/Editar/_EditarUsuarioScript.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Usuario/Partials/Editar/_EditarUsuarioScript.cshtml", typeof(AspNetCore.Views_Usuario_Partials_Editar__EditarUsuarioScript))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e287a260c119c40661ab40370c0a6c27bf42bf52", @"/Views/Usuario/Partials/Editar/_EditarUsuarioScript.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a01b0d20c99ef0324f635b4f4cb6f1d7d1176331", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_Partials_Editar__EditarUsuarioScript : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 972, true);
            WriteLiteral(@"<script type='text/javascript'>
    (function ($) {
        $(function () {
            $(document).ready(function ($) {
                $('.maskTelefone').mask('(99) 99999-9999');
                $('.maskCPF').mask('999.999.999-99');

                $('#nome').focus();

            });
        });
    })(jQuery);

    $(""#tipoUsuarioMedico"").click(function () {
        console.log(""1"");
        if ($('#tipoUsuarioRecepcionista').is("":checked"")) {
            console.log(""2"");
            $(""#tipoUsuarioRecepcionista"").prop(""checked"", false);
        }
    });

    $(""#tipoUsuarioRecepcionista"").click(function () {
        console.log(""3"");
        if ($('#tipoUsuarioMedico').is("":checked"")) {
            console.log(""4"");
            $(""#tipoUsuarioMedico"").prop(""checked"", false);
        }
    });

    $('#btnSelecionarTodos').click(function () {
        $(""input[type='checkbox']"").prop(""checked"", true);
    });

</script>");
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
