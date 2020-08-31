using KnowledgeBase.Models;
using KnowledgeBase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.Business.Categories
{
    public interface ICategoryFactory
    {
        Category CreateCategory(string name, bool isHot, string sefName, string icon, string author, int? parent);
        CategoryViewModel CreateCategoryViewModel(Category cat);
    }
}
