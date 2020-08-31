using KnowledgeBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.ViewModels.Public
{
    public class LandingPageViewModel
    {
        public List<Category> HotCategories { get; set; }
        public List<Category> FirstLevelCategories { get; set; }
        public List<Article> LatestArticles { get; set; }
        public List<Article> PopularArticles { get; set; }
        public List<TagCloudItem> PopularTags { get; set; }
        public string TotalArticleCountMessage { get; set; }
    }
}
