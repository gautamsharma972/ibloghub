#pragma checksum "I:\Sujay\iBlogHub\iBlogHub\Areas\Identity\Pages\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd24e31584f4bcfe25213f94db41cfb9bf6d12dd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Error), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Error.cshtml")]
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
#line 1 "I:\Sujay\iBlogHub\iBlogHub\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "I:\Sujay\iBlogHub\iBlogHub\Areas\Identity\Pages\_ViewImports.cshtml"
using iBlogHub.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "I:\Sujay\iBlogHub\iBlogHub\Areas\Identity\Pages\_ViewImports.cshtml"
using iBlogHub.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd24e31584f4bcfe25213f94db41cfb9bf6d12dd", @"/Areas/Identity/Pages/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a080b20c73dc49b4ff7c07c3340523b30008d3b", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Error : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "I:\Sujay\iBlogHub\iBlogHub\Areas\Identity\Pages\Error.cshtml"
  
    ViewData["Title"] = "Error";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-sm-12"">
        <div class=""text-center"">
            <p>&nbsp;</p>
            <p><i class=""fa fa-exclamation-triangle text-danger fa-7x""></i><br /><b class=""text-muted"">Error</b></p>

            <p class=""lead"">
                Whoops! Some error occurred while processing your request. No worries,<br /> Click <a href=""javascript: window.history.back();"">here</a>
                to go back or head to <a");
            BeginWriteAttribute("href", " href=\"", 523, "\"", 558, 1);
#nullable restore
#line 15 "I:\Sujay\iBlogHub\iBlogHub\Areas\Identity\Pages\Error.cshtml"
WriteAttributeValue("", 530, Url.Action("Index", "Home"), 530, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Home</a>\r\n            </p>\r\n");
#nullable restore
#line 17 "I:\Sujay\iBlogHub\iBlogHub\Areas\Identity\Pages\Error.cshtml"
             if (Model.ShowRequestId)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p class=\"text-muted\">\r\n                    <strong>Request ID:</strong> <code>");
#nullable restore
#line 20 "I:\Sujay\iBlogHub\iBlogHub\Areas\Identity\Pages\Error.cshtml"
                                                  Write(Model.RequestId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code>\r\n                </p>\r\n");
#nullable restore
#line 22 "I:\Sujay\iBlogHub\iBlogHub\Areas\Identity\Pages\Error.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public iBlogHub.Helpers.ICurrentUser _user { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ErrorModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ErrorModel>)PageContext?.ViewData;
        public ErrorModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
