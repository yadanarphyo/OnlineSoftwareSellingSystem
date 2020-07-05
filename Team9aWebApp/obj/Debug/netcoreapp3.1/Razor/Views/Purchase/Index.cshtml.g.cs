#pragma checksum "D:\ca\Team9A\Team9aWebApp\Views\Purchase\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ceb2e341d327fe70e334a04b7c6801d58b6d27d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Purchase_Index), @"mvc.1.0.view", @"/Views/Purchase/Index.cshtml")]
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
#nullable restore
#line 1 "D:\ca\Team9A\Team9aWebApp\Views\_ViewImports.cshtml"
using Team9aWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ca\Team9A\Team9aWebApp\Views\_ViewImports.cshtml"
using Team9aWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ceb2e341d327fe70e334a04b7c6801d58b6d27d8", @"/Views/Purchase/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0160ddcf885b4b275ec88aeb16c9055a04c5c2a1", @"/Views/_ViewImports.cshtml")]
    public class Views_Purchase_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\ca\Team9A\Team9aWebApp\Views\Purchase\Index.cshtml"
  
    ViewData["Title"] = "My Purchases";
    Layout = "_Layout";
    string cartQty = (string)ViewData["CartQty"];



    List<string> prodNameList = ViewBag.prodName;
    List<string> actCodeList = ViewBag.actCode;
    List<DateTime> dateList = ViewBag.date;
    List<string> imageList = ViewBag.image;
    List<string> descList = ViewBag.desc;


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style type=""text/css"">
    .row {
        width: 100%;
        height: 370px;
        margin-top: 10px;
    }

    .productinfo {
        width: 250px;
        height: 360px;
        margin-left: 250px;
        background-color: aliceblue;
    }

    .purchase {
        width: 500px;
        height: 200px;
        margin-top: 80px;
        margin-left: 30px;
        float: left;
    }

    .img {
        width: 250px;
        height: 200px;
        float: left;
    }

    .name {
        width: 250px;
        height: 50px;
        float: left;
        margin-top: 10px;
    }

    .desc {
        width: 240px;
        height: 80px;
        float: left;
        margin-left: 5px;
        margin-top: 10px;
        overflow: auto;
        background-color: white;
    }

    p {
        margin-bottom: 0;
    }

    tr {
        height: 45px;
    }

    #actcode {
        width: 250px;
    }

    #combobox {
        width: 330px;
    }
</style>

<div c");
            WriteLiteral("lass=\"text-center\">\r\n    <h1 class=\"display-4\">");
#nullable restore
#line 79 "D:\ca\Team9A\Team9aWebApp\Views\Purchase\Index.cshtml"
                     Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ceb2e341d327fe70e334a04b7c6801d58b6d27d85624", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 83 "D:\ca\Team9A\Team9aWebApp\Views\Purchase\Index.cshtml"
      
        for (int i = 0; i < prodNameList.Count(); i++)
        {
        string[] codes = actCodeList[i].Split(",");


#line default
#line hidden
#nullable disable
                WriteLiteral("        <div class=\"row\">\r\n            <div class=\"productinfo\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ceb2e341d327fe70e334a04b7c6801d58b6d27d86272", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 1713, "~/images/", 1713, 9, true);
#nullable restore
#line 90 "D:\ca\Team9A\Team9aWebApp\Views\Purchase\Index.cshtml"
AddHtmlAttributeValue("", 1722, imageList[i], 1722, 13, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                <div class=\"name\"><p align=\"center\"><b>");
#nullable restore
#line 91 "D:\ca\Team9A\Team9aWebApp\Views\Purchase\Index.cshtml"
                                                  Write(prodNameList[i]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></p></div>\r\n                <div class=\"desc\"><p align=\"center\">");
#nullable restore
#line 92 "D:\ca\Team9A\Team9aWebApp\Views\Purchase\Index.cshtml"
                                               Write(descList[i]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p></div>
            </div>
            <div class=""purchase"">
                <table>
                    <tr>
                        <td style=""vertical-align:middle""><p align=""center"">Date:</p></td>
                        <td style=""vertical-align:middle"">");
#nullable restore
#line 98 "D:\ca\Team9A\Team9aWebApp\Views\Purchase\Index.cshtml"
                                                     Write(dateList[i].Date.ToString("dd/MM/yyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td style=\"vertical-align:middle\"><p align=\"center\">Qty:</p></td>\r\n                        <td style=\"vertical-align:middle\"><p>");
#nullable restore
#line 102 "D:\ca\Team9A\Team9aWebApp\Views\Purchase\Index.cshtml"
                                                        Write(codes.Length);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p></td>
                    </tr>
                    <tr>


                        <td style=""vertical-align:middle""><p align=""center"">Activation Code:</p></td>
                        <td style=""vertical-align:middle"">
                            <select id=""combobox"">
");
#nullable restore
#line 110 "D:\ca\Team9A\Team9aWebApp\Views\Purchase\Index.cshtml"
                                 for (int j = 0; j < codes.Length; j++)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ceb2e341d327fe70e334a04b7c6801d58b6d27d810121", async() => {
#nullable restore
#line 112 "D:\ca\Team9A\Team9aWebApp\Views\Purchase\Index.cshtml"
                                   Write(codes[j]);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 113 "D:\ca\Team9A\Team9aWebApp\Views\Purchase\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td colspan=""2"" align=""center""><input type=""button"" value=""Download"" /></td>
                    </tr>
                </table>
            </div>
        </div>
        <hr>
");
#nullable restore
#line 124 "D:\ca\Team9A\Team9aWebApp\Views\Purchase\Index.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
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
