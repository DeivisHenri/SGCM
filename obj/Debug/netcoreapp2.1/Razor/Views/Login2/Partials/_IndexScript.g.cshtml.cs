#pragma checksum "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Login2\Partials\_IndexScript.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f8a438af23acd582881e2cb8a434c8c51927a9f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login2_Partials__IndexScript), @"mvc.1.0.view", @"/Views/Login2/Partials/_IndexScript.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Login2/Partials/_IndexScript.cshtml", typeof(AspNetCore.Views_Login2_Partials__IndexScript))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8a438af23acd582881e2cb8a434c8c51927a9f8", @"/Views/Login2/Partials/_IndexScript.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a01b0d20c99ef0324f635b4f4cb6f1d7d1176331", @"/Views/_ViewImports.cshtml")]
    public class Views_Login2_Partials__IndexScript : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 1757, true);
            WriteLiteral(@"<script type=""text/javascript"">

    //Page Load.
    $(document).ready(function () {
        //Iniciando Página responsiva.
        pageResponsive.start();

        //Inicando Controles.
        controlStart();
    });

    $(""#btnLogin"").click(function () {
        //$('#frmLogin').submit(function () {
        $(""#spnMsg"").text(""Efetuando o Login..."");
        var token = gettoken()
        var dadosLogin = { __RequestVerificationToken: token, username: $(""#inputLogin"").val(), password: $(""#inputSenha"").val() }
        var json = JSON.stringify(dadosLogin);

        $.ajax({
            type: ""POST"",
            url: ""/Login/Post"",
            contentType: 'application/json; charset=utf-8',
            dataType: ""json"",
            data: json,
            success: function(data, textStatus, jqXHR) {
                alert(""success: "" + data);
            },
            failure: function (data, textStatus, jqXHR) {
                alert(""failure: "" + data.responseText);
          ");
            WriteLiteral(@"  }, //End of AJAX failure function  

            error: function (data, textStatus, jqXHR) {
                console.log(""data: "" + data);
                console.log(""textStatus: "" + textStatus);
                console.log(""jqXHR: "" + jqXHR);

                alert(""error: "" + data + textStatus + jqXHR);
            } //End of AJAX error function  

        });
    });

    //Login CallBack.
    var EfetuarLoginCallBack = function (data) {
        console.log(""121"");
        if (data.CODIGO != 1) {
            console.log(""122"");
            $(""#spnMsg"").text(data.MENSAGEM);
            $(""#inputLogin"").focus();
        } else {
            console.log(""123"");
            $(location).attr('href', '");
            EndContext();
            BeginContext(1758, 38, false);
#line 52 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Login2\Partials\_IndexScript.cshtml"
                                 Write(Url.Content("~/Paginas/Default/Index"));

#line default
#line hidden
            EndContext();
            BeginContext(1796, 75, true);
            WriteLiteral("\');\r\n        };\r\n    };\r\n\r\n    function gettoken() {\r\n        var token = \'");
            EndContext();
            BeginContext(1872, 23, false);
#line 57 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Login2\Partials\_IndexScript.cshtml"
                Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(1895, 2471, true);
            WriteLiteral(@"';
        token = $(token).val();
        return token;
   }

    //Função dos Controles.
    //Deivis Henrique Alves
    var controlStart = function () {
        try {
            $('#inputLogin').keyup(function () { inputsLogin.valLogin(this); });
            $('#inputLogin').blur(function () { inputsLogin.valLogin(this); });

            $('#inputSenha').keyup(function () { inputsLogin.valSenha(this); });
            $('#inputSenha').blur(function () { inputsLogin.valSenha(this); });
        } catch (ex) {
            console.log('ERRO: ' + ex.toLocaleString());
        };
    };

    //Pagina Responsiva.
    //Deivis Henrique Alves
    var pageResponsive = {
        base: function () {
            try {
                var tmoContainer = ($(window).height() - $('.container').height() - 200) + 'px';
                $('.page-content').css('height', tmoContainer);
                if ($('.page-content').height() <= 280) {
                    $('.div-copyright').fadeOut();
        ");
            WriteLiteral(@"        } else {
                    $('.div-copyright').fadeIn();
                };
            } catch (ex) {
                console.log('ERRO: ' + ex.toLocaleString());
            };
        },
        start: function () {
            try {
                pageResponsive.base();
                $(window).resize(function () { pageResponsive.base(); });
            } catch (ex) {
                console.log('ERRO: ' + ex.toLocaleString());
            };
        }
    };

    //Validador de Login.
    //Com Mensagem de Erro Customizada TGV.
    //Leon Denis Paiva e Silva. [PrimeTeam]
    var inputsLogin = {
        valForm: function () {
            try {
                $('#tx-login-invalid').text($('#tx_login-error').text());
                $('#tx-senha-invalid').text($('#tx_senha-error').text());
            } catch (ex) {
                console.log('ERRO: ' + ex.toLocaleString());
            };
        },
        valLogin: function (inputObj) {
            if ($(inputO");
            WriteLiteral(@"bj).val().length == 0) {
                inputsLogin.valForm();
            } else {
                $('#tx-login-invalid').text('');
            };
        },
        valSenha: function (inputObj) {
            if ($(inputObj).val().length == 0) {
                inputsLogin.valForm();
            } else {
                $('#tx-senha-invalid').text('');
            };
        }
    };
    //--
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
