#pragma checksum "I:\Sujay\iBlogHub\iBlogHub\Views\Shared\_PostFooterSection.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "efa6b45b7157edb07c1b23724ccbac0783e92797"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__PostFooterSection), @"mvc.1.0.view", @"/Views/Shared/_PostFooterSection.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"efa6b45b7157edb07c1b23724ccbac0783e92797", @"/Views/Shared/_PostFooterSection.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4703e932db1fbaf4bc13a4abb1db540c49984d8a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__PostFooterSection : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<iBlogHub.Models.PostsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Stories", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToBookmark", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-begin", new global::Microsoft.AspNetCore.Html.HtmlString("onBegin"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-failure", new global::Microsoft.AspNetCore.Html.HtmlString("NotifyError"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-success", new global::Microsoft.AspNetCore.Html.HtmlString("Notify"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-method", new global::Microsoft.AspNetCore.Html.HtmlString("POST"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "efa6b45b7157edb07c1b23724ccbac0783e927975619", async() => {
                WriteLiteral("\r\n    <small class=\"d-block text-muted\">\r\n        <a");
                BeginWriteAttribute("href", " href=\"", 291, "\"", 371, 1);
#nullable restore
#line 7 "I:\Sujay\iBlogHub\iBlogHub\Views\Shared\_PostFooterSection.cshtml"
WriteAttributeValue("", 298, Url.Action("Index", "Profile", new { username = Model.Author.UserName }), 298, 73, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"text-muted\">\r\n            ");
#nullable restore
#line 8 "I:\Sujay\iBlogHub\iBlogHub\Views\Shared\_PostFooterSection.cshtml"
       Write(Model.Author.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 8 "I:\Sujay\iBlogHub\iBlogHub\Views\Shared\_PostFooterSection.cshtml"
                               Write(Model.Author.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </a>\r\n        \r\n");
                WriteLiteral("    </small>\r\n    <small class=\"text-muted\">\r\n");
#nullable restore
#line 17 "I:\Sujay\iBlogHub\iBlogHub\Views\Shared\_PostFooterSection.cshtml"
           iBlogHub.Helpers.TimesAgo postedOn = new iBlogHub.Helpers.TimesAgo();
            var time = postedOn.Time(Model.PostDate);
            iBlogHub.Helpers.MinReads minReads = new iBlogHub.Helpers.MinReads(Model.PostContent);
        

#line default
#line hidden
#nullable disable
                WriteLiteral("        ");
#nullable restore
#line 21 "I:\Sujay\iBlogHub\iBlogHub\Views\Shared\_PostFooterSection.cshtml"
   Write(Model.PostDate.ToString("dd MMM, yy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        &nbsp;·&nbsp;\r\n        ");
#nullable restore
#line 23 "I:\Sujay\iBlogHub\iBlogHub\Views\Shared\_PostFooterSection.cshtml"
   Write(minReads.TotalMinReads());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
                WriteLiteral("    </small>\r\n    <input type=\"hidden\" name=\"slug\"");
                BeginWriteAttribute("value", " value=\"", 1188, "\"", 1207, 1);
#nullable restore
#line 26 "I:\Sujay\iBlogHub\iBlogHub\Views\Shared\_PostFooterSection.cshtml"
WriteAttributeValue("", 1196, Model.slug, 1196, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
                WriteLiteral("    <button style=\"padding:0px;\" class=\"btn-link btn btn-xs text-muted float-right btnAddtoStory\"");
                BeginWriteAttribute("title", "\r\n            title=\"", 1365, "\"", 1485, 1);
#nullable restore
#line 29 "I:\Sujay\iBlogHub\iBlogHub\Views\Shared\_PostFooterSection.cshtml"
WriteAttributeValue("", 1386, User.Identity.IsAuthenticated ? "Add to Bookmarks" : "Login to add this story to your Bookmarks", 1386, 99, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("\r\n            type=\"submit\" data-toggle=\"tooltip\">\r\n        <i class=\"far fa-bookmark text-muted\"></i>\r\n    </button>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
