#pragma checksum "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "35dbf3260b8f19d69084bb8f116f53c89c200f9b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Details), @"mvc.1.0.view", @"/Views/Home/Details.cshtml")]
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
#line 1 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\_ViewImports.cshtml"
using KnowledgeBase;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\_ViewImports.cshtml"
using KnowledgeBase.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35dbf3260b8f19d69084bb8f116f53c89c200f9b", @"/Views/Home/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94b3698db955241541e64384a7304ced49677a45", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<KnowledgeBase.Models.Article>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n\n");
#nullable restore
#line 5 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
   ViewBag.Title = Model.Title; 

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row\">\n    <h2 class=\"section-title clearfix\">\n        <span class=\"line\"></span> ");
#nullable restore
#line 8 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
                              Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        <span class=\"small pull-right\">");
#nullable restore
#line 9 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
                                  Write(ViewBag.ArticlePrefix);

#line default
#line hidden
#nullable disable
            WriteLiteral("-");
#nullable restore
#line 9 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
                                                         Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n    </h2>\n</div>\n<div class=\"col-xs-9\">\n    <div class=\"row\">\n        <span>\n            <i class=\"fa fa-folder-open-o fa-fw text-muted\"></i>\n            <a");
            BeginWriteAttribute("href", " href=\'", 450, "\'", 527, 1);
#nullable restore
#line 16 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
WriteAttributeValue("", 457, Url.Action("Categories", "Home", new { id = Model.Category.SefName }), 457, 70, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 16 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
                                                                                        Write(Model.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n        </span>\n        &nbsp;\n");
#nullable restore
#line 20 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
         if (@User.Identity.IsAuthenticated)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<a");
            BeginWriteAttribute("href", " href=\'", 692, "\'", 747, 1);
#nullable restore
#line 22 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
WriteAttributeValue("", 699, Url.Action("Edit","Articles",new {id=Model.Id}), 699, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"fa fa-edit fa-fw\"></span>Edit Article</a>");
#nullable restore
#line 22 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
                                                                                                                 }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        <div class=\"margin-10\">\n            <div runat=\"server\" id=\"articleContent\" class=\"col-lg-12\">\n                ");
#nullable restore
#line 26 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
           Write(Html.Raw(System.Web.HttpUtility.HtmlDecode(Model.Content)));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n        <div class=\"clearfix\">&nbsp;</div>\n    </div>\n    <div class=\"row\">\n");
#nullable restore
#line 32 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
         foreach (var attachment in Model.Attachments)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"pull-left\">\n    <a");
            BeginWriteAttribute("href", " href=\'", 1190, "\'", 1246, 1);
#nullable restore
#line 35 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
WriteAttributeValue("", 1197, Url.Content(attachment.Path+attachment.FileName), 1197, 49, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">\n        <span class=\"glyphicon glyphicon-paperclip\"></span>\n        ");
#nullable restore
#line 37 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
   Write(attachment.FileName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </a>\n    &nbsp;\n</div>");
#nullable restore
#line 40 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
      }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </div>\n    <div class=\"clearfix\">&nbsp;</div>\n    <!-- DISQUS -->\n    <div class=\"row\">\n        <div id=\"disqus_thread\"></div>\n");
#nullable restore
#line 47 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
         if (!string.IsNullOrEmpty(ViewBag.DisqusShortName))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<script type=\"text/javascript\">\n\n            var disqus_shortname = \'");
#nullable restore
#line 51 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
                               Write(ViewBag.DisqusShortName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\n            var disqus_title = \'");
#nullable restore
#line 52 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
                           Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\n            var disqus_identifier = \'KB-");
#nullable restore
#line 53 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
                                   Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';


            (function () {
            var dsq = document.createElement('script'); dsq.type = 'text/javascript'; dsq.async = true;
            dsq.src = 'http://' + disqus_shortname + '.disqus.com/embed.js';
            (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(dsq);
            })();

</script>
                <noscript>Please enable JavaScript to view the <a href=""http://disqus.com/?ref_noscript"">comments powered by Disqus.</a></noscript>
                                <a href=""http://disqus.com"" class=""dsq-brlink"">comments powered by <span class=""logo-disqus"">Disqus</span></a>");
#nullable restore
#line 64 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
                                                                                                                                              }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n    <!-- END OF DISQUS SECTION-->\n</div>\n<div class=\"col-xs-1\">&nbsp;</div>\n<!--\n    RIGHT SIDEBAR\n-->\n<div class=\"col-xs-2\">\n    <div class=\"row clearfix\">\n");
            WriteLiteral("\n        <a class=\"btn-xs btn btn-primary\"");
            BeginWriteAttribute("href", " href=\'", 2929, "\'", 2980, 1);
#nullable restore
#line 78 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
WriteAttributeValue("", 2936, Url.Action("Like","Home",new{id=@Model.Id}), 2936, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n            I Like This\n        </a>\n    </div>\n\n\n");
#nullable restore
#line 84 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
     if (ViewBag.SimilarArticles != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row margin-10 clearfix\">\n    <h4 class=\"section-title\"><span class=\"line\"></span>PublicSimilarArticlesTitle</h4>\n    <!-- SIMILAR ARTICLES -->\n\n");
#nullable restore
#line 90 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
     foreach (var article in ViewBag.SimilarArticles)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<a class=\"btn-similar-article\"");
            BeginWriteAttribute("href", " href=\'", 3326, "\'", 3386, 1);
#nullable restore
#line 91 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
WriteAttributeValue("", 3333, Url.Action("Details","Home",new{id=article.SefName}), 3333, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n            ");
#nullable restore
#line 92 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
       Write(article.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </a>");
#nullable restore
#line 93 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
#nullable restore
#line 94 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
      }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <!-- SHARE THIS -->\n    <div class=\"clearfix margin-10\">\n");
#nullable restore
#line 97 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
         if (!string.IsNullOrEmpty(ViewBag.ShareThisPublicKey))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script type=""text/javascript"">var switchTo5x = false;</script>
                <script type=""text/javascript"" src=""http://w.sharethis.com/button/buttons.js""></script>
                                <script type=""text/javascript"">
                stLight.options({ publisher: """);
#nullable restore
#line 102 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
                                         Write(ViewBag.ShareThisPublicKey);

#line default
#line hidden
#nullable disable
            WriteLiteral("\", doNotHash: false, doNotCopy: false, hashAddressBar: true });\n                                </script>\n                                                <div");
            BeginWriteAttribute("class", " class=\"", 4036, "\"", 4044, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                                    <h4 class=""section-title"">
                                                        <span class=""line""></span>PublicShareThisTitle

                                                    </h4>
                                                    <span class='st_sharethis_large' displayText='ShareThis'></span>
                                                    <span class='st_facebook_large' displayText='Facebook'></span>
                                                    <span class='st_twitter_large' displayText='Tweet'></span>
                                                    <span class='st_linkedin_large' displayText='LinkedIn'></span>
                                                    <span class='st_pinterest_large' displayText='Pinterest'></span>
                                                    <span class='st_email_large' displayText='Email'></span>
                                                </div>");
#nullable restore
#line 115 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
                                                      }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n    <div class=\"clearfix\">&nbsp;</div>\n    <div class=\"clearfix margin-10\">\n        <h4 class=\"section-title \"><span class=\"line\"></span>Tags</h4>\n");
#nullable restore
#line 120 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
         foreach (var tag in Model.ArticleTags)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<a class=\"btn-xs btn btn-primary\"");
            BeginWriteAttribute("href", " href=\'", 5277, "\'", 5331, 1);
#nullable restore
#line 122 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
WriteAttributeValue("", 5284, Url.Action("Tags","Home",new{id=tag.Tag.Name}), 5284, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n    ");
#nullable restore
#line 123 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
Write(tag.Tag.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</a>");
#nullable restore
#line 124 "D:\Svetlana\2-Baza Znanja\00 - new era\stari kod\KnowledgeBase - 2808\KnowledgeBase\Views\Home\Details.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n\n</div>\n\n\n\n");
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
