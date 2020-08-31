using KnowledgeBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalArticleCount { get; set; }
        public Article MostLikedArticle { get; set; }
        public Article MostViewedArticle { get; set; }

    }
}
