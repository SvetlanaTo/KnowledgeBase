#pragma checksum "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b34e9f97e33dfdc3bac2f48f00e417c8c7e70e3b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Themes_Default_Home_Index), @"mvc.1.0.view", @"/Views/Themes/Default/Home/Index.cshtml")]
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
#line 1 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
using KnowledgeBase.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b34e9f97e33dfdc3bac2f48f00e417c8c7e70e3b", @"/Views/Themes/Default/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94b3698db955241541e64384a7304ced49677a45", @"/Views/_ViewImports.cshtml")]
    public class Views_Themes_Default_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<KnowledgeBase.ViewModels.Public.LandingPageViewModel>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 4 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<!DOCTYPE html>\n<html>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b34e9f97e33dfdc3bac2f48f00e417c8c7e70e3b3947", async() => {
                WriteLiteral("\n    <title>");
#nullable restore
#line 11 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
      Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</title>\n    <meta charset=\"utf-8\" />\n    <meta name=\"viewport\" content=\"width=device-width\" />\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge;\" />\n\n");
                WriteLiteral("\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=\"", 403, "\"", 460, 1);
#nullable restore
#line 18 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
WriteAttributeValue("", 410, Url.Content("~/Assets/css/plugins/bootstrap.css"), 410, 50, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=\"", 491, "\"", 551, 1);
#nullable restore
#line 19 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
WriteAttributeValue("", 498, Url.Content("~/Assets/css/plugins/font-awesome.css"), 498, 53, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=\"", 582, "\"", 668, 1);
#nullable restore
#line 20 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
WriteAttributeValue("", 589, Url.Content("~/Assets/css/plugins/smartmenus/jquery.smartmenus.bootstrap.css"), 589, 79, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=\"", 699, "\"", 766, 1);
#nullable restore
#line 21 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
WriteAttributeValue("", 706, Url.Content("~/Assets/css/jquery-ui/jquery-ui-redmond.css"), 706, 60, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=\"", 797, "\"", 853, 1);
#nullable restore
#line 22 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
WriteAttributeValue("", 804, Url.Content("~/Assets/css/plugins/ionicons.css"), 804, 49, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=\"", 884, "\"", 953, 1);
#nullable restore
#line 23 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
WriteAttributeValue("", 891, Url.Content("~/Assets/Themes/"+ViewBag.Theme+"/css/site.css"), 891, 62, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\n\n    <script type=\"text/javascript\">\n         var KB_SearchUrl = \"");
#nullable restore
#line 26 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                        Write(Url.Action("Ajax", "Search"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\n    </script>\n");
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
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b34e9f97e33dfdc3bac2f48f00e417c8c7e70e3b8753", async() => {
                WriteLiteral("\n    <header class=\"jumbotron subhead\" id=\"overview\">\n        <div class=\"container\">\n            <h1>\n                <a href=\"/\"><span>");
#nullable restore
#line 33 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                             Write(ViewBag.CompanyName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></a>\n                <small>");
#nullable restore
#line 34 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                  Write(ViewBag.TagLine);

#line default
#line hidden
#nullable disable
                WriteLiteral("</small>\n            </h1>\n            <p id=\"htmlJumbotronText\" class=\"lead\">");
#nullable restore
#line 36 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                                              Write(ViewBag.JumbotronText);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\n        </div>\n    </header>\n    <div class=\"container\">\n        <div class=\"row\">\n");
#nullable restore
#line 41 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
             using (Html.BeginForm("Do", "Search", FormMethod.Post, new { id = "SearchForm" }))
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"input-group\">\n                    <input type=\"hidden\" name=\"ArticleId\" id=\"ArticleId\"");
                BeginWriteAttribute("value", " value=\"", 1704, "\"", 1712, 0);
                EndWriteAttribute();
                WriteLiteral(" />\n                    <input type=\"text\" class=\"form-control search-control\" placeholder=\"Enter search text\" ID=\"txtSearch\" name=\"SearchKeyword\" />\n                    <span class=\"input-group-btn\">\n");
                WriteLiteral("                        <input type=\"submit\" id=\"btnDoSearch\" class=\"btn btn-default\" value=\"ButtonSearch\" />\n                    </span>\n                </div>\n");
#nullable restore
#line 51 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\n        <div class=\"clearfix\">&nbsp;</div>\n");
#nullable restore
#line 54 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
         if (ViewBag.ShowTotalArticleCountOnFrontPage)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"row\">\n                <div class=\"container\">\n                    ");
#nullable restore
#line 58 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
               Write(Model.TotalArticleCountMessage);

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </div>\n            </div>\n            <div class=\"clearfix\">&nbsp;</div>\n");
#nullable restore
#line 62 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("        <div class=\"row\">\n            <div class=\"col-lg-9\">\n                <h4 class=\"section-title clearfix\">\n");
                WriteLiteral("                    <span class=\"line\"></span><i class=\"fa fa-folder-open-o fa-fw text-muted\"></i>LandingHotCategoryHeader\n                </h4>\n                <div class=\"row\">\n                    <div class=\"container\">\n");
#nullable restore
#line 71 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                         foreach (var category in Model.HotCategories)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <div class=\"col-lg-6\">\n                                <div class=\"row\">\n                                    <i class=\"fa fa-folder-open-o fa-fw text-muted\"></i>\n                                    ");
#nullable restore
#line 76 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                               Write(category.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                                    <span class=\"badge\">");
#nullable restore
#line 77 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                                                   Write(category.Articles.Count);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\n                                </div>\n                                <div class=\"row\">\n                                    <ul class=\"fa-ul\">\n");
#nullable restore
#line 81 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                                         foreach (var article in category.Articles.Take((int)ViewBag.ArticleDisplayCount))
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <li>\n                                                <i class=\"fa-li fa fa-list-alt fa-fw text-muted\"></i>\n                                                <a");
                BeginWriteAttribute("href", " href=\'", 3976, "\'", 4042, 1);
#nullable restore
#line 85 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
WriteAttributeValue("", 3983, Url.Action("Detail", "Home", new { id = article.SefName }), 3983, 59, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 85 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                                                                                                                 Write(article.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\n                                            </li>\n");
#nullable restore
#line 87 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    </ul>\n                                </div>\n                            </div>\n");
#nullable restore
#line 91 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    </div>
                </div>
                <div class=""clearfix"">&nbsp;</div>
                <div class=""row"">
                    <div class=""container"">
                        <div class=""col-lg-6"">
                            <h4 class=""section-title clearfix"">
");
                WriteLiteral("                                <span class=\"line\"></span>LandingLatestArticlesTitle\n                            </h4>\n                            <div class=\"row\">\n                                <ul class=\"fa-ul\">\n");
#nullable restore
#line 104 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                                     foreach (var article in Model.LatestArticles)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <li>\n                                            <i class=\"fa-li fa fa-list-alt fa-fw text-muted\"></i>\n                                            <a");
                BeginWriteAttribute("href", " href=\'", 5215, "\'", 5281, 1);
#nullable restore
#line 108 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
WriteAttributeValue("", 5222, Url.Action("Detail", "Home", new { id = article.SefName }), 5222, 59, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 108 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                                                                                                             Write(article.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\n                                        </li>\n");
#nullable restore
#line 110 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                </ul>\n                            </div>\n                        </div>\n                        <div class=\"col-lg-6\">\n                            <h4 class=\"section-title clearfix\">\n");
                WriteLiteral("                                <span class=\"line\"></span>LandingPopularArticlesTitle \n\n                            </h4>\n                            <div class=\"row\">\n                                <ul class=\"fa-ul\">\n");
#nullable restore
#line 122 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                                     foreach (var article in Model.PopularArticles)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <li>\n                                            <i class=\"fa-li fa fa-list-alt fa-fw text-muted\"></i>\n                                            <a");
                BeginWriteAttribute("href", " href=\'", 6234, "\'", 6300, 1);
#nullable restore
#line 126 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
WriteAttributeValue("", 6241, Url.Action("Detail", "Home", new { id = article.SefName }), 6241, 59, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 126 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                                                                                                             Write(article.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\n                                        </li>\n");
#nullable restore
#line 128 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                </ul>\n                            </div>\n                        </div>\n                    </div>\n                </div>\n            </div>\n            <div class=\"col-lg-3\">\n");
                WriteLiteral("                <h4 class=\"section-title\">LandingSidebarCategoryListTitle</h4>\n                <div>\n");
#nullable restore
#line 139 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                     foreach (Category category in Model.FirstLevelCategories)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"row\">\n                <i class=\"fa fa-arrow-circle-o-right text-muted\"></i>\n                <a");
                BeginWriteAttribute("href", " href=\"", 7029, "\"", 7100, 1);
#nullable restore
#line 143 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
WriteAttributeValue("", 7036, Url.Action("Categories", "Home", new { id = category.SefName }), 7036, 64, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 143 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                                                                                      Write(category.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\n");
                WriteLiteral("\n            </div>");
#nullable restore
#line 146 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                  }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </div>\n                <div class=\"col-lg-12\">&nbsp;</div>\n\n");
#nullable restore
#line 150 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                 if (Model.PopularTags.Count > 0)
                {

#line default
#line hidden
#nullable disable
#nullable restore
#line 152 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                           Write(Html.PartialAsync("TagCloud", Model.PopularTags));

#line default
#line hidden
#nullable disable
#nullable restore
#line 152 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                                                                                 }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\n        </div>\n    </div>\n\n    <script");
                BeginWriteAttribute("src", " src=\"", 7549, "\"", 7605, 1);
#nullable restore
#line 157 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
WriteAttributeValue("", 7555, Url.Content("~/Assets/js/jquery/jquery-2-0-2.js"), 7555, 50, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=\"", 7628, "\"", 7688, 1);
#nullable restore
#line 158 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
WriteAttributeValue("", 7634, Url.Content("~/Assets/js/jquery/jquery-ui-1-10-4.js"), 7634, 54, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=\"", 7711, "\"", 7767, 1);
#nullable restore
#line 159 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
WriteAttributeValue("", 7717, Url.Content("~/Assets/js/bootstrap/bootstrap.js"), 7717, 50, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=\"", 7790, "\"", 7872, 1);
#nullable restore
#line 160 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
WriteAttributeValue("", 7796, Url.Content("~/Assets/Themes/"+ViewBag.Theme+"/js/cookie/jquery.cookie.js"), 7796, 76, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=\"", 7895, "\"", 7965, 1);
#nullable restore
#line 161 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
WriteAttributeValue("", 7901, Url.Content("~/Assets/Themes/"+ViewBag.Theme+"/js/frontend.js"), 7901, 64, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=\"", 7988, "\"", 8078, 1);
#nullable restore
#line 162 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
WriteAttributeValue("", 7994, Url.Content("~/Assets/Themes/"+ViewBag.Theme+"/js/smartmenus/jquery.smartmenus.js"), 7994, 84, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=\"", 8101, "\"", 8201, 1);
#nullable restore
#line 163 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
WriteAttributeValue("", 8107, Url.Content("~/Assets/Themes/"+ViewBag.Theme+"/js/smartmenus/jquery.smartmenus.bootstrap.js"), 8107, 94, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=\"", 8224, "\"", 8323, 1);
#nullable restore
#line 164 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
WriteAttributeValue("", 8230, Url.Content("~/Assets/Themes/"+ViewBag.Theme+"/js/smartmenus/jquery.smartmenus.keyboard.js"), 8230, 93, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n\n");
#nullable restore
#line 166 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
     if (!String.IsNullOrEmpty(ViewBag.AnalyticsAccount))
    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"        <script>
            (function (i, s, o, g, r, a, m) {
                i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                    (i[r].q = i[r].q || []).push(arguments)
                }, i[r].l = 1 * new Date(); a = s.createElement(o),
                m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
            })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

            ga('create', '");
#nullable restore
#line 176 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
                     Write(ViewBag.AnalyticsAccount);

#line default
#line hidden
#nullable disable
                WriteLiteral("\', \'auto\');\n            ga(\'send\', \'pageview\');\n        </script>\n");
#nullable restore
#line 179 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 0109\KnowledgeBase\Views\Themes\Default\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</html>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KnowledgeBase.ViewModels.Public.LandingPageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
