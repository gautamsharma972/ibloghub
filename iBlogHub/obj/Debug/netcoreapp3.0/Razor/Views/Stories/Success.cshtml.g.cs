#pragma checksum "I:\Sujay\iBlogHub\iBlogHub\Views\Stories\Success.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4939d55f73fb8845740d01ca759c9f5181ff9f94"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Stories_Success), @"mvc.1.0.view", @"/Views/Stories/Success.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4939d55f73fb8845740d01ca759c9f5181ff9f94", @"/Views/Stories/Success.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4703e932db1fbaf4bc13a4abb1db540c49984d8a", @"/Views/_ViewImports.cshtml")]
    public class Views_Stories_Success : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<iBlogHub.Models.PostsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "I:\Sujay\iBlogHub\iBlogHub\Views\Stories\Success.cshtml"
  
    ViewData["Title"] = "Success";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <style type=\"text/css\">\r\n        .center {\r\n            margin: auto;\r\n            padding: 70px 0;\r\n        }\r\n    </style>\r\n");
            }
            );
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"page-content\" id=\"wrapper\">\r\n        <div class=\"row d-flex h-100\">\r\n            <div class=\"col-sm-12\">\r\n                <div class=\"center\">\r\n                    <div");
            BeginWriteAttribute("class", " class=\"", 489, "\"", 497, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <h2>");
#nullable restore
#line 20 "I:\Sujay\iBlogHub\iBlogHub\Views\Stories\Success.cshtml"
                       Write(Model.PostTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 21 "I:\Sujay\iBlogHub\iBlogHub\Views\Stories\Success.cshtml"
                         if (Model.HasMessage)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p class=\"text-muted\">\r\n                                ");
#nullable restore
#line 24 "I:\Sujay\iBlogHub\iBlogHub\Views\Stories\Success.cshtml"
                           Write(Model.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Click <a");
            BeginWriteAttribute("href", " href=\"", 734, "\"", 786, 1);
#nullable restore
#line 24 "I:\Sujay\iBlogHub\iBlogHub\Views\Stories\Success.cshtml"
WriteAttributeValue("", 741, Href($"~/{Model.ViewCategory}/{Model.slug}"), 741, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">here</a> to preview.\r\n                            </p>\r\n");
#nullable restore
#line 26 "I:\Sujay\iBlogHub\iBlogHub\Views\Stories\Success.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <p class=\"text-muted\">To edit your post again, click <a");
            BeginWriteAttribute("href", " href=\"", 950, "\"", 1013, 1);
#nullable restore
#line 27 "I:\Sujay\iBlogHub\iBlogHub\Views\Stories\Success.cshtml"
WriteAttributeValue("", 957, Url.Action("Edit", "Stories", new { slug = Model.slug}), 957, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">here</a>.</p>\r\n                        <p>\r\n                            Meanwhile,<br />\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1135, "\"", 1186, 1);
#nullable restore
#line 30 "I:\Sujay\iBlogHub\iBlogHub\Views\Stories\Success.cshtml"
WriteAttributeValue("", 1142, Href("~/Identity/Account/Manage/MyStories"), 1142, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-default\"><i class=\"fa fa-th-list\"></i> Check all your Stories</a><br />\r\n                            <a class=\"btn btn-default\"");
            BeginWriteAttribute("href", " href=\"", 1330, "\"", 1372, 1);
#nullable restore
#line 31 "I:\Sujay\iBlogHub\iBlogHub\Views\Stories\Success.cshtml"
WriteAttributeValue("", 1337, Href("~/Identity/Account/Manage/"), 1337, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <i class=\"fa fa-user\"></i> Visit your Profile\r\n                            </a>   <br />\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1528, "\"", 1563, 1);
#nullable restore
#line 34 "I:\Sujay\iBlogHub\iBlogHub\Views\Stories\Success.cshtml"
WriteAttributeValue("", 1535, Url.Action("Index", "Home"), 1535, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-default\"><i class=\"fa fa-home\"></i> Back to Home Page</a>\r\n                        </p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<iBlogHub.Models.PostsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
