#pragma checksum "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "230b41a037003d7a5c8f388e6e543006c5b5ad44"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"230b41a037003d7a5c8f388e6e543006c5b5ad44", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4703e932db1fbaf4bc13a4abb1db540c49984d8a", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<iBlogHub.Data.Posts>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rounded"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("250"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("250"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""container"">
        <h5>All Posts</h5>
        <hr/>
        <div class=""table-responsive"">
            <table class=""table"">
                <tr>
                    <td><b>#</b></td>
                    <td>
                        Title
                    </td>
                    <td>Type</td>
                    <td>
                        Slug
                    </td>
");
            WriteLiteral(@"                    <td>Image</td>
                    <td>
                        Postedby
                    </td>
                    <td>
                        PostedOn
                    </td>
                    <td>Verification Status</td>
                    <td>
                        Action
                    </td>
                </tr>
");
#nullable restore
#line 36 "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml"
                  
                    int count = 0;
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml"
                 foreach (var item in Model)
                {
                    count++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 43 "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml"
                       Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 44 "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml"
                       Write(item.PostTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td><label class=\"bg-warning\">");
#nullable restore
#line 45 "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml"
                                                 Write(item.Category.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label></td>\r\n                        <td>");
#nullable restore
#line 46 "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml"
                       Write(item.slug);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("                        <td>\r\n");
#nullable restore
#line 49 "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml"
                               if (!string.IsNullOrEmpty(item.FeaturedImage))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "230b41a037003d7a5c8f388e6e543006c5b5ad447932", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1703, "~/Uploads/", 1703, 10, true);
#nullable restore
#line 51 "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml"
AddHtmlAttributeValue("", 1713, item.FeaturedImage, 1713, 19, false);

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
            WriteLiteral("\r\n");
#nullable restore
#line 52 "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml"

                                }
                                else
                                {
                                    Html.Raw("No Image provided");
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                        <td>");
#nullable restore
#line 60 "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml"
                       Write(item.Author.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 61 "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml"
                       Write(item.PostDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td");
            BeginWriteAttribute("class", " class=\"", 2145, "\"", 2196, 1);
#nullable restore
#line 62 "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml"
WriteAttributeValue("", 2153, item.isVerified?"bg-success":"bg-danger", 2153, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 62 "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml"
                                                                           Write(item.isVerified);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        <td>\r\n                            <a class=\"btn btn-sm btn-danger\" href=\"#\" data-id=\"");
#nullable restore
#line 64 "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml"
                                                                          Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" id=\"btnDel\" data-title=\"");
#nullable restore
#line 64 "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml"
                                                                                                            Write(item.PostTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-page=\"Details\">Delete</a>\r\n                            \r\n");
#nullable restore
#line 66 "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml"
                              
                                if (!item.isVerified)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <button");
            BeginWriteAttribute("onclick", " onclick=\"", 2609, "\"", 2637, 3);
            WriteAttributeValue("", 2619, "Verify(\'", 2619, 8, true);
#nullable restore
#line 69 "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml"
WriteAttributeValue("", 2627, item.Id, 2627, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2635, "\')", 2635, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-sm\">Verify Now</button>\r\n");
#nullable restore
#line 70 "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 74 "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </table>\r\n        </div>\r\n        \r\n    </div>\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "230b41a037003d7a5c8f388e6e543006c5b5ad4413429", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 82 "I:\Sujay\iBlogHub\iBlogHub\Views\Admin\Index.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script type=""text/javascript"">
        function Verify(id) {
            $.ajax({
                url: '/Admin/Verify',
                type: 'POST',
                data: {
                    id: id,
                    __RequestVerificationToken: token
                },
                success: function (response) {
                    Swal.fire(
                        ""Verified"",
                        """" + response.msg
                    ).then(function () { window.location.reload(); });
                },
                failure: function (response) {
                    Swal.fire(
                        ""Error"",
                        ""Oops, something went wrong! Please try again later."",
                        ""error""
                    )
                }
            });
        }
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<iBlogHub.Data.Posts>> Html { get; private set; }
    }
}
#pragma warning restore 1591
