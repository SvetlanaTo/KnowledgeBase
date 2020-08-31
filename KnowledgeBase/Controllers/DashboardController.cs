using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.DAL.Repo;
using KnowledgeBase.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBase.Controllers
{
    public class DashboardController : Controller  
    {
        private IArticleRepository _articleRepository;

        public DashboardController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public IActionResult Index()
        {
            var model = new DashboardViewModel();

            model.TotalArticleCount = _articleRepository.GetTotalArticleCount();
            model.MostLikedArticle = _articleRepository.GetMostLikedArticle();
            model.MostViewedArticle = _articleRepository.GetMostViewedArticle();
            
            return View(model);
        }
    }
}
