#pragma checksum "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Home\Categories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d796c530b96e80c6af05fb64bfb06e97f9df5d12"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Categories), @"mvc.1.0.view", @"/Views/Home/Categories.cshtml")]
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
#line 3 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Home\Categories.cshtml"
using KnowledgeBase.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d796c530b96e80c6af05fb64bfb06e97f9df5d12", @"/Views/Home/Categories.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94b3698db955241541e64384a7304ced49677a45", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Categories : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<KnowledgeBase.Models.Article>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("\n");
#nullable restore
#line 6 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Home\Categories.cshtml"
   ViewBag.Title = String.Format("CategoryList PageTitle", ViewBag.Category.Name); 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"row\">\n    <div class=\"col-xs-10\">\n        <h2 class=\"section-title clearfix\">\n            <span class=\"line\"></span> CategoryListSubCategoryTitle\n            <small class=\"pull-right\">\n");
#nullable restore
#line 13 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Home\Categories.cshtml"
                 if (ViewBag.Category.ParentCategory != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <a class=\"text-muted\"");
            BeginWriteAttribute("href", " href=\"", 482, "\"", 573, 1);
#nullable restore
#line 15 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Home\Categories.cshtml"
WriteAttributeValue("", 489, Url.Action("Categories","Home",new { id = ViewBag.Category.ParentCategory.SefName}), 489, 84, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 15 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Home\Categories.cshtml"
                                                                                                                 Write(ViewBag.Category.ParentCategory.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n                    <i class=\"fa fa-angle-double-up\"></i>");
#nullable restore
#line 16 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Home\Categories.cshtml"
                                                         }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </small>\n        </h2>\n    </div>\n    <div class=\"col-xs-12\">\n\n");
#nullable restore
#line 22 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Home\Categories.cshtml"
         foreach (Category subCategory in ViewBag.Category.ChildCategories)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"col-xs-4\">\n    <i class=\"fa fa-folder-open-o fa-fw text-muted\"></i><a");
            BeginWriteAttribute("href", " href=\"", 918, "\"", 992, 1);
#nullable restore
#line 25 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Home\Categories.cshtml"
WriteAttributeValue("", 925, Url.Action("Categories", "Home", new { id = subCategory.SefName }), 925, 67, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 25 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Home\Categories.cshtml"
                                                                                                                                 Write(subCategory.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n</div>");
#nullable restore
#line 26 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Home\Categories.cshtml"
      }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n</div>\n<br />\n<div class=\"row\">\n    <div class=\"col-xs-10\">\n        <h2 class=\"section-title clearfix\">\n            <span class=\"line\"></span> ");
#nullable restore
#line 33 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Home\Categories.cshtml"
                                  Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </h2>\n    </div>\n    <div class=\"col-xs-10\">\n        <ul class=\"fa-ul\">\n");
#nullable restore
#line 38 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Home\Categories.cshtml"
             foreach (var article in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<li>\n    <i class=\"fa-li fa fa-list-alt fa-fw text-muted\"></i>\n    <a");
            BeginWriteAttribute("href", " href=\'", 1400, "\'", 1461, 1);
#nullable restore
#line 42 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Home\Categories.cshtml"
WriteAttributeValue("", 1407, Url.Action("Details","Home",new {id=article.SefName}), 1407, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 42 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Home\Categories.cshtml"
                                                                Write(article.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n</li>\n");
#nullable restore
#line 44 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Home\Categories.cshtml"
       }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\n\n    </div>\n</div>\n<div class=\"pager\">\n");
            WriteLiteral("\n\n");
            WriteLiteral("<!-- VRATI SE - PRIMENI Razor Pages-->\n");
            WriteLiteral("\n");
            WriteLiteral("\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<KnowledgeBase.Models.Article>> Html { get; private set; }
    }
}
#pragma warning restore 1591
