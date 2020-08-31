using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.ViewModels.Public
{
    public class SearchFormViewModel
    {
        public int ArticleId { get; set; }

        public string SearchKeyword { get; set; }

        public int CurrentPage { get; set; }

        public List<KbSearchResultItemViewModel> Results { get; set; }
    }
}
