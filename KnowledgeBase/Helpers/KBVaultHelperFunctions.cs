using KnowledgeBase.Data;
using KnowledgeBase.Models;
using KnowledgeBase.ViewModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeBase.Helpers
{

    public class KBVaultHelperFunctions
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private static IActionContextAccessor _actionContextAccessor;
        private UserManager<AppUser> userManager;
        private KnowledgeBaseContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LinkGenerator _linkGenerator;

        public KBVaultHelperFunctions(UserManager<AppUser> userManager, KnowledgeBaseContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AppUser> UserAsKbUser(IPrincipal user)
        {
            try
            {
                if (user.Identity.IsAuthenticated)
                {
                    //return KbVaultAuthHelper.GetKbUser(user.Identity.Name);
                    AppUser u = await userManager.FindByNameAsync(user.Identity.Name);
                    if (u != null)
                        return u;
                    else
                        return null;
                            //RedirectToAction("UserNotFound");
                }

                throw new ArgumentNullException("Identity is null");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        //Svetlana
        //Microsoft.AspNet.Mvc.Rendering.HtmlString
        //Microsoft.AspNetCore.Html
        //public System.Web.Mvc.MvcHtmlString CreateCategoryMenu()
        //{
        //    return new System.Web.Mvc.MvcHtmlString(GetCategoryMenu(-1));
        //}
        public HtmlString CreateCategoryMenu()
        {
            return new HtmlString(GetCategoryMenu(-1));
        }


        internal static object UserAsKbUser(object user)
        {
            throw new NotImplementedException();
        }

        //Svetlana
        //public System.Web.Mvc.MvcHtmlString CreateBootstrapCategoryMenu()
        //{
        //    return new System.Web.Mvc.MvcHtmlString(GetBootstrapCategoryMenu(-1));
        //}
        public HtmlString CreateBootstrapCategoryMenu()
        {
            return new HtmlString(GetBootstrapCategoryMenu(-1));
        }

        public SelectList CategoryTreeForSelectList(long selectedCategoryId, bool displayRoot = true)
        {
            try
            {
                var cats = new List<CategoryViewModel>();
                var root = new CategoryViewModel();
                if (displayRoot)
                {
                    root.Id = -1;
                    root.NameForDroplist = " ";
                    cats.Add(root);
                }

                cats.AddRange(GetCategories(-1));
                return new SelectList(cats, "Id", "NameForDroplist", selectedCategoryId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        //vise nam ne treba
        //public static SelectList CreateRolesDropdown(string selectedRole)
        //{
        //    try
        //    {
        //        var objs = new List<object>
        //        {
        //            new { Value = KbVaultAuthHelper.RoleAdmin, Text = KbVaultAuthHelper.RoleAdmin },
        //            new { Value = KbVaultAuthHelper.RoleManager, Text = KbVaultAuthHelper.RoleManager },
        //            new { Value = KbVaultAuthHelper.RoleEditor, Text = KbVaultAuthHelper.RoleEditor }
        //        };

        //        return new SelectList(objs, "Value", "Text", selectedRole);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex);
        //        throw;
        //    }
        //}

        //vise nam ne treba
        //public static bool IsAdmin(IPrincipal user)
        //{
        //    try
        //    {
        //        var usr = UserAsKbUser(user);
        //        return usr.Role == KbVaultAuthHelper.RoleAdmin;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex);
        //        throw;
        //    }
        //}


        //vise nam ne treba
        //public static bool IsManager(IPrincipal user)
        //{
        //    try
        //    {
        //        var usr = UserAsKbUser(user);
        //        return usr.Role == KbVaultAuthHelper.RoleManager;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex);
        //        throw;
        //    }
        //}

        private string GetCategoryMenu(long parentCategoryId = -1)
        {
            try
            {
                //var linkHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                //var linkHelper = new UrlHelper(_actionContextAccessor.ActionContext);
                //testirati - vrati se
                HttpContext httpContext = _httpContextAccessor.HttpContext;
                //string uri = _linkGenerator.GetUriByAction(httpContext, "Remove", "File", new { id = $"{this.Hash}|{this.Id}" });



                var categoryTree = GetCategories(parentCategoryId, 0, false);
                var activeClass = "active";
                var html = new StringBuilder();
                html.Append($"<ul class='treeview-menu {activeClass}'>");

                foreach (var model in categoryTree)
                {
                    //todo vrati se!
                    //var categoryArticleListLink = linkHelper.Action("List", "Category", new { id = model.Id, page = 1 });
                    var categoryArticleListLink = _linkGenerator.GetUriByAction(httpContext, "List", "Category", new { id = model.Id, page = 1 });
                    html.Append("<li class='treeview'>" + Environment.NewLine);
                    html.Append("<div>" + Environment.NewLine);
                    html.Append($"<a href='{categoryArticleListLink}'>");
                    html.Append("<i class='fa fa-angle-double-right'></i> " + model.Name);
                    html.Append("</a>" + Environment.NewLine);
                    html.Append("</div>" + Environment.NewLine);
                    if (model.Children.Count > 0)
                    {
                        html.Append(GetCategoryMenu(model.Id));
                    }

                    html.Append("</li>" + Environment.NewLine);
                }

                html.Append("</ul>");

                return html.ToString();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        private string GetBootstrapCategoryMenu(long parentCategoryId = -1)
        {
            try
            {
                var html = new StringBuilder();

                //todo vrati se - testirati obe varijante
                var linkHelper = new UrlHelper(_actionContextAccessor.ActionContext);
                var categoryTree = GetCategories(parentCategoryId, 0, false);

                foreach (CategoryViewModel model in categoryTree)
                {
                    if (model.Children.Count > 0)
                    {
                        html.Append("<li class=\"dropdown-submenu pull-left\">" + Environment.NewLine);
                    }
                    else
                    {
                        html.Append("<li>" + Environment.NewLine);
                    }

                    var categoryListLink = linkHelper.Action("Categories", "Home", new { id = model.SefName });
                    html.Append($"<a href='{categoryListLink}'>{model.Name}</a>");
                    html.Append(Environment.NewLine);
                    if (model.Children.Count > 0)
                    {
                        html.Append("<ul class=\"dropdown-menu\">");
                        html.Append(GetBootstrapCategoryMenu(model.Id));
                        html.Append("</ul>");
                    }

                    html.AppendLine("</li>");
                }

                return html.ToString();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        private List<CategoryViewModel> GetCategories(long parentCategoryId = -1, int depth = 0, bool createSingleListForDropdown = true) 
        {
            try
            {
                var categoryList = new List<CategoryViewModel>();
                //using (var db = new KnowledgeBaseContext())
                //{
                    var categories = _context.Categories.Where(c => c.ParentCategoryId == parentCategoryId || (parentCategoryId == -1 && c.ParentCategoryId == null)).ToList();
                    foreach (var cat in categories)
                    {
                        var categoryItem = new CategoryViewModel
                        {
                            Id = cat.Id,
                            Name = cat.Name,
                            SefName = cat.SefName,
                            Icon = string.IsNullOrEmpty(cat.Icon) ? "angle-double-right" : cat.Icon,
                            NameForDroplist = cat.Name.PadLeft(cat.Name.Length + depth, '-'),
                            Children = GetCategories(cat.Id, depth + 2)
                        };
                        categoryList.Add(categoryItem);
                        if (createSingleListForDropdown)
                        {
                            categoryList.AddRange(categoryItem.Children);
                        }
                    }
                //}

                return categoryList;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}
