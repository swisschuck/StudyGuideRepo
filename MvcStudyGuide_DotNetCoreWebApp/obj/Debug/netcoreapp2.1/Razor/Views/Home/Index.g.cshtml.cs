#pragma checksum "E:\Repos\StudyGuideRepo\MvcStudyGuide_DotNetCoreWebApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b4a3752de381a2a094594168d806dd398419909"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 2 "E:\Repos\StudyGuideRepo\MvcStudyGuide_DotNetCoreWebApp\Views\_ViewImports.cshtml"
using MvcStudyGuide_DotNetCoreWebApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b4a3752de381a2a094594168d806dd398419909", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb56d252c3bb48a84ff5a7e4e4ae87e8bb3eafaa", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Product>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-href-include", "~/lib/bootstrap/dist/css/bootstrap.css", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("m-1 p-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\Repos\StudyGuideRepo\MvcStudyGuide_DotNetCoreWebApp\Views\Home\Index.cshtml"
   Layout = null; 

#line default
#line hidden
            BeginContext(50, 27, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(77, 291, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "444d17586a4b4003b9af1d6ef2e622fa", async() => {
                BeginContext(83, 102, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Dependency Injection</title>\r\n");
                EndContext();
                BeginContext(272, 4, true);
                WriteLiteral("    ");
                EndContext();
                BeginContext(276, 83, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "837f3f93b4c340f59a6fa7bf21c65a44", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.HrefInclude = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(359, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(368, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(370, 934, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "856aca45e03144e7bf5292f93c412163", async() => {
                BeginContext(392, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 13 "E:\Repos\StudyGuideRepo\MvcStudyGuide_DotNetCoreWebApp\Views\Home\Index.cshtml"
     if (ViewData.Count > 0)
    {

#line default
#line hidden
                BeginContext(431, 69, true);
                WriteLiteral("        <table class=\"table table-bordered table-sm table-striped\">\r\n");
                EndContext();
#line 16 "E:\Repos\StudyGuideRepo\MvcStudyGuide_DotNetCoreWebApp\Views\Home\Index.cshtml"
             foreach (var kvp in ViewData)
            {

#line default
#line hidden
                BeginContext(559, 24, true);
                WriteLiteral("                <tr><td>");
                EndContext();
                BeginContext(584, 7, false);
#line 18 "E:\Repos\StudyGuideRepo\MvcStudyGuide_DotNetCoreWebApp\Views\Home\Index.cshtml"
                   Write(kvp.Key);

#line default
#line hidden
                EndContext();
                BeginContext(591, 9, true);
                WriteLiteral("</td><td>");
                EndContext();
                BeginContext(601, 9, false);
#line 18 "E:\Repos\StudyGuideRepo\MvcStudyGuide_DotNetCoreWebApp\Views\Home\Index.cshtml"
                                    Write(kvp.Value);

#line default
#line hidden
                EndContext();
                BeginContext(610, 12, true);
                WriteLiteral("</td></tr>\r\n");
                EndContext();
#line 19 "E:\Repos\StudyGuideRepo\MvcStudyGuide_DotNetCoreWebApp\Views\Home\Index.cshtml"
            }

#line default
#line hidden
                BeginContext(637, 18, true);
                WriteLiteral("        </table>\r\n");
                EndContext();
#line 21 "E:\Repos\StudyGuideRepo\MvcStudyGuide_DotNetCoreWebApp\Views\Home\Index.cshtml"
    }

#line default
#line hidden
                BeginContext(662, 167, true);
                WriteLiteral("    <table class=\"table table-bordered table-sm table-striped\">\r\n        <thead>\r\n            <tr><th>Name</th><th>Price</th></tr>\r\n        </thead>\r\n        <tbody>\r\n");
                EndContext();
#line 27 "E:\Repos\StudyGuideRepo\MvcStudyGuide_DotNetCoreWebApp\Views\Home\Index.cshtml"
             if (Model == null)
            {

#line default
#line hidden
                BeginContext(877, 81, true);
                WriteLiteral("                <tr><td colspan=\"3\" class=\"text-center\">No Model Data</td></tr>\r\n");
                EndContext();
#line 30 "E:\Repos\StudyGuideRepo\MvcStudyGuide_DotNetCoreWebApp\Views\Home\Index.cshtml"
            }
            else
            {
                

#line default
#line hidden
#line 33 "E:\Repos\StudyGuideRepo\MvcStudyGuide_DotNetCoreWebApp\Views\Home\Index.cshtml"
                 foreach (var p in Model)
                {

#line default
#line hidden
                BeginContext(1068, 54, true);
                WriteLiteral("                    <tr>\r\n                        <td>");
                EndContext();
                BeginContext(1123, 6, false);
#line 36 "E:\Repos\StudyGuideRepo\MvcStudyGuide_DotNetCoreWebApp\Views\Home\Index.cshtml"
                       Write(p.Name);

#line default
#line hidden
                EndContext();
                BeginContext(1129, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(1165, 32, false);
#line 37 "E:\Repos\StudyGuideRepo\MvcStudyGuide_DotNetCoreWebApp\Views\Home\Index.cshtml"
                       Write(string.Format("{0:C2}", p.Price));

#line default
#line hidden
                EndContext();
                BeginContext(1197, 34, true);
                WriteLiteral("</td>\r\n                    </tr>\r\n");
                EndContext();
#line 39 "E:\Repos\StudyGuideRepo\MvcStudyGuide_DotNetCoreWebApp\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#line 39 "E:\Repos\StudyGuideRepo\MvcStudyGuide_DotNetCoreWebApp\Views\Home\Index.cshtml"
                 
            }

#line default
#line hidden
                BeginContext(1265, 32, true);
                WriteLiteral("        </tbody>\r\n    </table>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1304, 13, true);
            WriteLiteral("\r\n</html>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
