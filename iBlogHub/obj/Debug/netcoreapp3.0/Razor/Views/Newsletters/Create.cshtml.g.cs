#pragma checksum "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3088dad65d0bfcaf0c24eae5160e5e99fa46684e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Newsletters_Create), @"mvc.1.0.view", @"/Views/Newsletters/Create.cshtml")]
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
#line 1 "I:\Sujay\iBlogHub\iBlogHub\Views\_ViewImports.cshtml"
using iBlogHub;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "I:\Sujay\iBlogHub\iBlogHub\Views\_ViewImports.cshtml"
using iBlogHub.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3088dad65d0bfcaf0c24eae5160e5e99fa46684e", @"/Views/Newsletters/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4703e932db1fbaf4bc13a4abb1db540c49984d8a", @"/Views/_ViewImports.cshtml")]
    public class Views_Newsletters_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<iBlogHub.Models.Newsletters>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml"
  
    ViewBag.Title = "Create";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Create</h2>\r\n\r\n\r\n");
#nullable restore
#line 11 "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml"
 using (Html.BeginForm()) 
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-horizontal\">\r\n        <h4>Newsletters</h4>\r\n        <hr />\r\n        ");
#nullable restore
#line 18 "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 20 "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml"
       Write(Html.LabelFor(model => model.Email, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 22 "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml"
           Write(Html.EditorFor(model => model.Email, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 23 "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Email, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 28 "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml"
       Write(Html.LabelFor(model => model.Name, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 30 "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml"
           Write(Html.EditorFor(model => model.Name, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 31 "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 36 "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml"
       Write(Html.LabelFor(model => model.isVerified, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                <div class=\"checkbox\">\r\n                    ");
#nullable restore
#line 39 "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml"
               Write(Html.EditorFor(model => model.isVerified));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 40 "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.isVerified, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 46 "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml"
       Write(Html.LabelFor(model => model.SubscribedOn, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 48 "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml"
           Write(Html.EditorFor(model => model.SubscribedOn, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 49 "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.SubscribedOn, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 54 "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml"
       Write(Html.LabelFor(model => model.TotalSent, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 56 "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml"
           Write(Html.EditorFor(model => model.TotalSent, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 57 "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.TotalSent, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-offset-2 col-md-10\">\r\n                <input type=\"submit\" value=\"Create\" class=\"btn btn-default\" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 67 "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    ");
#nullable restore
#line 70 "I:\Sujay\iBlogHub\iBlogHub\Views\Newsletters\Create.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public iBlogHub.Models.IPostsService _postsService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public iBlogHub.Helpers.ICurrentUser _cUser { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<iBlogHub.Models.Newsletters> Html { get; private set; }
    }
}
#pragma warning restore 1591
