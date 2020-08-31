using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.Business.ApplicationSettings;
using KnowledgeBase.DAL.Repo;
using KnowledgeBase.Data;
using KnowledgeBase.Helpers;
using KnowledgeBase.Models;
using KnowledgeBase.ViewModels;
using KnowledgeBase.ViewModels.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog;
using X.PagedList;

namespace KnowledgeBase.Controllers
{
    public class HomeController : Controller
    {
        //[Authorize(Policy = "UserAccess")] 
        //public IActionResult Index()
        //{
        //    return View((object)"Hello");
        //}

        private const int ArticleCountPerPage = 20;
        public ITagRepository _tagRepository { get; set; }
        public IArticleRepository _articleRepository { get; set; }
        public ICategoryRepository _categoryRepository { get; set; }


        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly KnowledgeBaseContext _context;

        private Logger log = LogManager.GetCurrentClassLogger();

        private ISettingsService _settingservice;

        public HomeController(ITagRepository tagRepository, IArticleRepository articleRepository, ICategoryRepository categoryRepository, IHttpContextAccessor httpContextAccessor, KnowledgeBaseContext context, ISettingsService settingservice)
        {
            _tagRepository = tagRepository;
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _settingservice = settingservice;
        }

        //private readonly IActionContextAccessor _actionContextAccessor;
        //public HomeController(IActionContextAccessor actionContextAccessor, KnowledgeBaseContext context, ISettingsService settingservice)
        //{
        //    _actionContextAccessor = actionContextAccessor;
        //    _context = context;
        //    _settingservice = settingservice;
        //}





        [HttpPost]
        //2808
        //Status Code: 405; Method Not Allowed vrati seee
        [AjaxOnly]
        public JsonResult Like(int articleId)
        {
            //bool isAjaxCall = _actionContextAccessor.ActionContext.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";
            //bool isAjaxCall = _httpContextAccessor.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";
            var result = new JsonOperationResponse();
            //if (isAjaxCall == true)
            //{
            //using (var db = new KbVaultContext(_config))
            //{
            var article = _context.Articles.FirstOrDefault(a => a.Id == articleId);
            if (article == null)
            {
                //result.ErrorMessage = Resources.ErrorMessages.ArticleNotFound;
                result.ErrorMessage = "ArticleNotFound";
            }
            else
            {
                article.Likes++;
                _context.SaveChanges();
                result.Successful = true;
                result.ErrorMessage = "ArticleLikeSuccess"; //Resources.UIResources.ArticleLikeSuccess;
            }
            //}
            //}

            return Json(result);
        }

        public IActionResult Tags(string id, int page = 1)
        {
            try
            {
                //using (var db = new KbVaultContext(_config))
                //{
                var tag = _context.Tags.First(c => c.Name == id);
                if (tag == null)
                {
                    return View("TagNotFound");
                }

                ViewBag.Tag = tag;
                //IPagedList<Article> articles = PublishedArticles().Where(a => a.ArticleTags.Any(t => t.Tag.Name == id)).OrderBy(a => a.Title).ToPagedList(page, ArticleCountPerPage);
                IList<Article> articles = PublishedArticles().Where(a => a.ArticleTags.Any(t => t.Tag.Name == id)).OrderBy(a => a.Title).ToList(); //.ToPagedList(page, ArticleCountPerPage);

                return View(articles);
                //}
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return RedirectToAction("PublicError", "Error");
            }
        }

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

        public IActionResult Categories(string id, int page = 1)
        {
            try
            {

                var cat = _context.Categories.Include("ChildCategories").Include("ParentCategory").First(c => c.SefName == id);
                if (cat == null)
                {
                    return View("CategoryNotFound");
                }

                ViewBag.Category = cat;
                IList<Article> articles = PublishedArticles().Where(a => a.Category.SefName == id).OrderBy(a => a.Title).ToList(); //.ToPagedList(page, ArticleCountPerPage);
                return View(articles);

            }
            catch (Exception ex)
            {
                log.Error(ex);
                return RedirectToAction("PublicError", "Error");
            }
        }

        public IActionResult Details(string id)
        {
            try
            {
                var article = PublishedArticles().FirstOrDefault(a => a.SefName == id);
                if (article != null)
                {
                    article.Views++;
                    _context.SaveChanges();

                    ViewBag.SimilarArticles = _articleRepository.GetVisibleSimilarArticles((int)article.Id, DateTime.Today.Date);

                    return View(article);
                }

                return View("ArticleNotFound");

            }
            catch (Exception ex)
            {
                log.Error(ex);
                return RedirectToAction("PublicError", "Error");
            }
        }

        public async Task<IActionResult> Index()
        {
            var settings = _settingservice.GetSettings();
            var model = new LandingPageViewModel();
            if (settings.ShowTotalArticleCountOnFrontPage)
            {
                //model.TotalArticleCountMessage = string.Format(Resources.UIResources.PublicTotalArticleCountMessage, ArticleRepository.GetTotalArticleCount());
                model.TotalArticleCountMessage = string.Format("PublicTotalArticleCountMessage", _articleRepository.GetTotalArticleCount());
            }
            else
                //kada je null - tokom dev
                ViewBag.ShowTotalArticleCountOnFrontPage = false;


            model.HotCategories = _categoryRepository.GetHotCategories().ToList();
            ViewBag.Title = settings.CompanyName;
            model.FirstLevelCategories = _categoryRepository.GetFirstLevelCategories().ToList();
            model.LatestArticles = _articleRepository.GetLatestArticles(settings.ArticleCountPerCategoryOnHomePage);
            model.PopularArticles = _articleRepository.GetPopularArticles(settings.ArticleCountPerCategoryOnHomePage);
            //model.PopularTags = await _tagRepository.GetTagCloud().Select(tag => new TagCloudItem(tag)).ToListAsync(); 
            var pt = await _tagRepository.GetTagCloud();
            model.PopularTags = pt.Select(tag => new TagCloudItem(tag)).ToList();
            return View(model);
        }

    }
}