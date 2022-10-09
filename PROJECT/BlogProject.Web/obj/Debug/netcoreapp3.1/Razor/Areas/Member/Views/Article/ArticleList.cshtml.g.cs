#pragma checksum "C:\PROJECT\BlogProject.Web\Areas\Member\Views\Article\ArticleList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f7eb5916ecb3777fad85d9916a7680c2bc29d07a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Member_Views_Article_ArticleList), @"mvc.1.0.view", @"/Areas/Member/Views/Article/ArticleList.cshtml")]
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
#line 1 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\_ViewImports.cshtml"
using BlogProject.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\_ViewImports.cshtml"
using BlogProject.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\_ViewImports.cshtml"
using BlogProject.Web.Models.DTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\_ViewImports.cshtml"
using BlogProject.Model.Entities.Concrete;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\_ViewImports.cshtml"
using BlogProject.Web.Areas.Member.Models.DTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\_ViewImports.cshtml"
using BlogProject.Web.Areas.Member.Models.VMs;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7eb5916ecb3777fad85d9916a7680c2bc29d07a", @"/Areas/Member/Views/Article/ArticleList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b63b9cd1b39ee6526acd2223b92fc69eff7e9661", @"/Areas/Member/Views/_ViewImports.cshtml")]
    public class Areas_Member_Views_Article_ArticleList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List< ArticleListVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Comment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 5 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\Article\ArticleList.cshtml"
 foreach (var item in Model)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card card-widget col-md-10\">\r\n\r\n    <div class=\"user-block\">\r\n        <img class=\"img-circle\" style=\"border-radius:50%;\"");
            BeginWriteAttribute("src", " src=\"", 202, "\"", 223, 1);
#nullable restore
#line 11 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\Article\ArticleList.cshtml"
WriteAttributeValue("", 208, item.ImagePath, 208, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"User Image\">\r\n        <span class=\"username\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7eb5916ecb3777fad85d9916a7680c2bc29d07a5907", async() => {
#nullable restore
#line 12 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\Article\ArticleList.cshtml"
                                                                                                   Write(item.UserFullName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 12 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\Article\ArticleList.cshtml"
                                                                              WriteLiteral(item.UserId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</span>\r\n        <span class=\"description\">Tarafından Paylaşıldı - ");
#nullable restore
#line 13 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\Article\ArticleList.cshtml"
                                                     Write(item.CreatedDate.ToString("dd MMMM dddd yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
    </div>


    <div class=""card-header"">
        <div class=""user-block"">


        </div>
        <!-- /.user-block -->
        <div class=""card-tools"">
            <button type=""button"" class=""btn btn-tool"" title=""Mark as read"">
                <i class=""far fa-circle""></i>
            </button>
            <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"">
                <i class=""fas fa-minus""></i>
            </button>
            <button type=""button"" class=""btn btn-tool"" data-card-widget=""remove"">
                <i class=""fas fa-times""></i>
            </button>
        </div>
        <!-- /.card-tools -->
    </div>
    <!-- /.card-header -->
    <div class=""card-body"">
        <img class=""img-fluid pad""");
            BeginWriteAttribute("src", " src=\"", 1263, "\"", 1284, 1);
#nullable restore
#line 38 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\Article\ArticleList.cshtml"
WriteAttributeValue("", 1269, item.ImagePath, 1269, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Photo\">\r\n\r\n        <p><b>");
#nullable restore
#line 40 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\Article\ArticleList.cshtml"
         Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n        <p>");
#nullable restore
#line 41 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\Article\ArticleList.cshtml"
      Write(item.Content.Substring(0, 40));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7eb5916ecb3777fad85d9916a7680c2bc29d07a10574", async() => {
                WriteLiteral("  devamını okumak için tıklayınız...");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 41 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\Article\ArticleList.cshtml"
                                                                                            WriteLiteral(item.ArticleID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</p>\r\n        <p>kategoriler:</p>\r\n");
#nullable restore
#line 43 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\Article\ArticleList.cshtml"
         for (int i = 0; i < item.CategoryName.Count; i++)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <p class=\"text-center\"> <span class=\"badge badge-gradient-primary float-left\"> ");
#nullable restore
#line 46 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\Article\ArticleList.cshtml"
                                                                                      Write(item.CategoryName[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral(",</span></p>\r\n");
#nullable restore
#line 47 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\Article\ArticleList.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <p class=\"text-center\"> <span class=\"badge badge-gradient-secondary float-right\">Like Sayı :");
#nullable restore
#line 49 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\Article\ArticleList.cshtml"
                                                                                               Write(item.Likes.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - Yorum Sayı :");
#nullable restore
#line 49 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\Article\ArticleList.cshtml"
                                                                                                                               Write(item.Comments.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></p>\r\n    </div>\r\n\r\n    <div class=\"card-footer card-comments\">\r\n\r\n\r\n");
#nullable restore
#line 55 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\Article\ArticleList.cshtml"
         foreach (var item1 in item.Comments)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <img class=\"img-circle\" style=\"width:40px; \"");
            BeginWriteAttribute("src", " src=\"", 2087, "\"", 2117, 1);
#nullable restore
#line 57 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\Article\ArticleList.cshtml"
WriteAttributeValue("", 2093, item1.AppUser.ImagePath, 2093, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"User Image\">\r\n            <b>");
#nullable restore
#line 58 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\Article\ArticleList.cshtml"
          Write(item1.AppUser.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n            <div class=\"comment-text\">\r\n\r\n\r\n                <p><b>");
#nullable restore
#line 62 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\Article\ArticleList.cshtml"
                 Write(item1.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n            </div>\r\n");
#nullable restore
#line 64 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\Article\ArticleList.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n    <!-- /.card-body -->\r\n    <div class=\"card-footer card-comments\">\r\n\r\n        <!-- /.card-comment -->\r\n        <div class=\"card-comment\">\r\n\r\n        </div>\r\n        <!-- /.card-comment -->\r\n    </div>\r\n");
            WriteLiteral("    <!-- /.card-footer -->\r\n    <!-- /.card-footer -->\r\n");
#nullable restore
#line 83 "C:\PROJECT\BlogProject.Web\Areas\Member\Views\Article\ArticleList.cshtml"

}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List< ArticleListVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
