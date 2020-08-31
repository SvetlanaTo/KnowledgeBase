using KnowledgeBase.Business.ApplicationSettings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Protocols;
using NLog;
using System.Configuration;

namespace KnowledgeBase.Controllers
{
    public class KbVaultPublicController : Controller
    {
        private static Logger Log = LogManager.GetCurrentClassLogger();
        public ISettingsService _settingsService { get; set; }

        public KbVaultPublicController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        new public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var settings = _settingsService.GetSettings();
            if (settings != null)
            {
                ViewBag.CompanyName = settings.CompanyName;
                ViewBag.JumbotronText = settings.JumbotronText;
                ViewBag.TagLine = settings.TagLine;
                ViewBag.DisqusShortName = settings.DisqusShortName;
                ViewBag.ShareThisPublicKey = settings.ShareThisPublicKey;
                ViewBag.ArticleDisplayCount = settings.ArticleCountPerCategoryOnHomePage;
                ViewBag.ArticlePrefix = settings.ArticlePrefix;
                ViewBag.AnalyticsAccount = settings.AnalyticsAccount;
                //todo VRATI SE
                ViewBag.Theme = ConfigurationManager.AppSettings["Theme"];
                ViewBag.ShowTotalArticleCountOnFrontPage = settings.ShowTotalArticleCountOnFrontPage;
            }
            else
            {
                ViewBag.CompanyName = "Login as admin and set your configuration parameters";
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
