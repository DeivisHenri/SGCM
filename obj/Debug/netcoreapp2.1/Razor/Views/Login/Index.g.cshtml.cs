#pragma checksum "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Login\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "191ed2ad21c795e28f9dfc8d5024d8b86a8d5bf9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Index), @"mvc.1.0.view", @"/Views/Login/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Login/Index.cshtml", typeof(AspNetCore.Views_Login_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"191ed2ad21c795e28f9dfc8d5024d8b86a8d5bf9", @"/Views/Login/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a01b0d20c99ef0324f635b4f4cb6f1d7d1176331", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SGCM.Models.EfetuarLoginModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "/Views/Login/Partials/_IndexStyle.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("frmLogin"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return false;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Login/Partials/_IndexScript.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(55, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 6 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Login\Index.cshtml"
 if (Context.User.Identity.IsAuthenticated) {

#line default
#line hidden
            BeginContext(106, 19, true);
            WriteLiteral("    <h3>true</h3>\r\n");
            EndContext();
#line 8 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Login\Index.cshtml"
} else {

#line default
#line hidden
            BeginContext(135, 20, true);
            WriteLiteral("    <h3>false</h3>\r\n");
            EndContext();
#line 10 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Login\Index.cshtml"
}

#line default
#line hidden
            BeginContext(158, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 12 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Login\Index.cshtml"
  
    ViewData["Title"] = "Login";

#line default
#line hidden
            BeginContext(201, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(264, 59, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ecb3c4ab60aa43829d9aa444b50cd300", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(323, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(357, 40, true);
            WriteLiteral("<div class=\"login-page-container\">\r\n    ");
            EndContext();
            BeginContext(397, 2919, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "35b4fd0e9e7a43c1b1a24b9a4769c458", async() => {
                BeginContext(442, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
                BeginContext(480, 8, true);
                WriteLiteral("        ");
                EndContext();
                BeginContext(489, 23, false);
#line 25 "C:\Users\mselm\source\repos\SGCM\SGCM\Views\Login\Index.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
                EndContext();
                BeginContext(512, 2056, true);
                WriteLiteral(@"

        <div class=""login-div-middle"">
            <table class=""login-table"">
                <tbody>
                    <tr>
                        <td colspan=""2"" class=""td-button""></td>
                    </tr>
                    <tr>
                        <td class=""td-icon"">
                            <i class=""fa fa-user"" aria-hidden=""true""></i>
                        </td>
                        <td>
                            <input type=""text"" id=""inputLogin"" class=""input-no-border""
                                   placeholder=""Nome do Usuário"" autocomplete=""off"" name=""username""
                                   aria-required=""true"" aria-invalid=""false"" maxlength=""20"" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan=""2"">
                            <div class=""div-control-base""></div>
                            <span class=""span-control-invalid"" id=""tx-login-invalid""></span>
                 ");
                WriteLiteral(@"       </td>
                    </tr>
                    <tr><td colspan=""2"" class=""table-sp""></td></tr>
                    <tr>
                        <td class=""icon-td"">
                            <i class=""fa fa-lock"" aria-hidden=""true""></i>
                        </td>
                        <td>
                            <input type=""password"" id=""inputSenha"" class=""input-no-border""
                                   placeholder=""Senha"" autocomplete=""off"" name=""password""
                                   aria-required=""true"" aria-invalid=""false"" maxlength=""20"" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan=""2"">
                            <div class=""div-control-base""></div>
                            <span class=""span-control-invalid"" id=""tx-senha-invalid""></span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan=""2"" class=""td-forgot-");
                WriteLiteral("pass\">\r\n");
                EndContext();
                BeginContext(2663, 646, true);
                WriteLiteral(@"                        </td>
                    </tr>
                    <tr>
                        <td colspan=""2"" class=""login-status"">
                            <span id=""spnMsg"" class=""login-message""></span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan=""2"" class=""td-button"">
                            <button id=""btnLogin"" class=""btn btn-blue"">
                                ENTRAR
                            </button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3316, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
            EndContext();
            BeginContext(3343, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9e3d6b97a48b4284b3188e71b3b78383", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3404, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SGCM.Models.EfetuarLoginModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
