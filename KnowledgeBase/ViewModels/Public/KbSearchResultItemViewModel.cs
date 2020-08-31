using KnowledgeBase.Data;
using KnowledgeBase.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.ViewModels.Public
{
    public class KbSearchResultItemViewModel
    {
        public bool IsArticle { get; set; }
        public bool IsAttachment { get; set; }
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }

        public string ArticleSefName { get; set; }

    }
}
