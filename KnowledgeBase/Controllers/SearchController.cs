using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.Business.ApplicationSettings;
using KnowledgeBase.Data;
using KnowledgeBase.Helpers;
using KnowledgeBase.Models;
using KnowledgeBase.ViewModels;
using KnowledgeBase.ViewModels.Public;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog;

namespace KnowledgeBase.Controllers
{
    public class SearchController : Controller
    {

        //private readonly IActionContextAccessor _actionContextAccessor;
        private readonly KnowledgeBaseContext _context;
        private ISettingsService _settingService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _env;
        private static Logger Log = LogManager.GetCurrentClassLogger();
        private static KbVaultLuceneHelper _lucene;

        public SearchController(KnowledgeBaseContext context, ISettingsService settingService, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env, KbVaultLuceneHelper lucene)
        {
            _context = context;
            _settingService = settingService;
            _httpContextAccessor = httpContextAccessor;
            _env = env;
            _lucene = lucene;
        }

        [HttpPost]
        public IActionResult Do(SearchFormViewModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.SearchKeyword))
                {
                    return RedirectToAction("Index", "Home");
                }

                var articlePrefix = _settingService.GetSettings().ArticlePrefix;
                if (!string.IsNullOrEmpty(articlePrefix))
                {
                    if (model.SearchKeyword.Length > articlePrefix.Length + 1 &&
                        model.SearchKeyword.Substring(0, articlePrefix.Length + 1) == articlePrefix + "-")
                    {
                        var articleId = model.SearchKeyword.Substring(articlePrefix.Length + 1);
                        model.ArticleId = Convert.ToInt32(articleId);
                    }

                    if (model.ArticleId > 0)
                    {
                        Article article = new Article();

                        article = PublishedArticles().FirstOrDefault(a => a.Id == model.ArticleId);


                        if (article != null)
                        {
                            return RedirectToRoute("Default", new { controller = "Home", action = "Detail", id = article.SefName });
                        }
                    }
                }

                if (model.CurrentPage == 0)
                {
                    model.CurrentPage++;
                }

                //model.Results = KbVaultLuceneHelper.DoSearch(_env, model.SearchKeyword, model.CurrentPage, 10);
                model.Results = _lucene.DoSearch(model.SearchKeyword, model.CurrentPage, 10);

                return View(model);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        [HttpPost]
        public JsonResult More(SearchFormViewModel model)
        {
            var result = new JsonOperationResponse();
            try
            {
                model.CurrentPage++;
                model.Results = _lucene.DoSearch(model.SearchKeyword, model.CurrentPage, 1);
                result.Successful = true;
                result.Data = model;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                result.ErrorMessage = ex.Message;
            }

            return Json(result);
        }


        // NOVA METODA - verovatno ne radi kako treba
        [HttpPost]
        [AjaxOnly] //vrati se
        public JsonResult Ajax(string id)
        {
            var result = new JsonOperationResponse();
            try
            {
                //bool IsAjax = _actionContextAccessor.ActionContext.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";
                //bool IsAjax = _httpContextAccessor.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";
                //if (IsAjax == true)
                //{
                var items = _lucene.DoSearch(id, 1, 10);
                result.Data = items;
                result.Successful = true;
                //}
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                result.ErrorMessage = ex.Message;
            }

            return Json(result);
        }

        // STARA METODA
        //[HttpPost]
        //public JsonResult Ajax(string id)
        //{
        //    var result = new JsonOperationResponse();
        //    try
        //    {
        //        if (Request.IsAjaxRequest())
        //        //if(HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        //        {
        //            var items = _lucene.DoSearch(id, 1, 10);
        //            result.Data = items;
        //            result.Successful = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex);
        //        result.ErrorMessage = ex.Message;
        //    }

        //    return Json(result);
        //}

        public IQueryable<Article> PublishedArticles()
        {
            DateTime today = DateTime.Now.Date;
            return _context.Articles
                    .Include("Category")
                    .Include("ArticleTags.Tag")
                    .Include("Attachments")
                    .Where(a => a.PublishStartDate <= today &&
                           a.PublishEndDate >= today &&
                           a.IsDraft == 0);
        }


    }
}
