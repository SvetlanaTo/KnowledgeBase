#pragma checksum "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ae9280badfbcd8176651fc44e871826b24d55575"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Articles_Details), @"mvc.1.0.view", @"/Views/Articles/Details.cshtml")]
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
#line 1 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\_ViewImports.cshtml"
using KnowledgeBase;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\_ViewImports.cshtml"
using KnowledgeBase.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae9280badfbcd8176651fc44e871826b24d55575", @"/Views/Articles/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94b3698db955241541e64384a7304ced49677a45", @"/Views/_ViewImports.cshtml")]
    public class Views_Articles_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<KnowledgeBase.Models.Article>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Article</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayFor(model => model.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Views));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayFor(model => model.Views));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Likes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayFor(model => model.Likes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Created));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayFor(model => model.Created));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Edited));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayFor(model => model.Edited));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 50 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IsDraft));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 53 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayFor(model => model.IsDraft));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 56 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PublishStartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 59 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayFor(model => model.PublishStartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 62 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PublishEndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 65 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayFor(model => model.PublishEndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 68 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SefName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 71 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayFor(model => model.SefName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 74 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Author));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 77 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayFor(model => model.Author.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 80 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Category));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 83 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayFor(model => model.Category.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 86 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ArticleTags));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ae9280badfbcd8176651fc44e871826b24d5557513783", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 89 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ArticleTags);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#nullable restore
#line 89 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.Tags;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </dd>\r\n\r\n\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ae9280badfbcd8176651fc44e871826b24d5557515902", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 96 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Articles\Details.cshtml"
                           WriteLiteral(Model.Id);

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
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ae9280badfbcd8176651fc44e871826b24d5557518079", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KnowledgeBase.Models.Article> Html { get; private set; }
    }
}
#pragma warning restore 1591
