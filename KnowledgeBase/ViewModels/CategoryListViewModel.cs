using KnowledgeBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;


namespace KnowledgeBase.ViewModels
{
    public class CategoryListViewModel
    {
        public string CategoryName { get; set; }
        public string Icon { get; set; }
        public int CategoryId { get; set; }
        public IPagedList<Article> Articles { get; set; }

    }
}
