using KnowledgeBase.Helpers;
using KnowledgeBase.Models;
using KnowledgeBase.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KnowledgeBase.Business.ApplicationSettings
{
    public class SettingsFactory : ISettingsFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IWebHostEnvironment _env;

        public SettingsFactory(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _env = env;
            _httpContextAccessor = httpContextAccessor;
        }
        public Settings CreateModel(SettingsViewModel settings)
        {

            var set = new Settings
            {

                CompanyName = settings.CompanyName,
                ArticleCountPerCategoryOnHomePage = settings.ArticleCountPerCategoryOnHomePage,
                DisqusShortName = settings.DisqusShortName,
                JumbotronText = settings.JumbotronText,
                ShareThisPublicKey = settings.ShareThisPublicKey,
                TagLine = settings.TagLine,
                IndexFileExtensions = settings.IndexFileExtensions,
                ArticlePrefix = settings.ArticlePrefix,
                AnalyticsAccount = settings.AnalyticsAccount,
                //AuthorId = KBVaultHelperFunctions.UserAsKbUser(_httpContextAccessor.HttpContext.User).Id,
                AuthorId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
                BackupPath = settings.BackupPath,
                ShowTotalArticleCountOnFrontPage = settings.ShowTotalArticleCountOnFrontPage
            };

            if (!string.IsNullOrEmpty(set.BackupPath))
            {
                if (!set.BackupPath.EndsWith("\\") && !set.BackupPath.StartsWith("~"))
                {
                    set.BackupPath += "\\";
                }

                if (!set.BackupPath.EndsWith("/") && set.BackupPath.StartsWith("~"))
                {
                    set.BackupPath += "/";
                }
            }

            return set;
        }

        public SettingsViewModel CreateViewModel(Settings settings)
        {
            var model = new SettingsViewModel(settings)
            {
                SelectedTheme = ConfigurationManager.AppSettings["Theme"]
            };

            var a = typeof(SettingsFactory).Assembly;
            model.ApplicationVersion = a.GetName().Version.Major + "." + a.GetName().Version.Minor;
            //model.Themes.AddRange(Directory.EnumerateDirectories(HttpContext.Current.Server.MapPath("~/Views/Themes")).Select(Path.GetFileName).ToList());
            //todo vrati se
            //model.Themes.AddRange(Directory.EnumerateDirectories(Path.Combine(_env.WebRootPath, ("~/Views/Themes"))).Select(Path.GetFileName).ToList());


            return model;
        }
    }
}
