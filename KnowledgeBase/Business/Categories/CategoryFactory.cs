using KnowledgeBase.Models;
using KnowledgeBase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.Business.Categories
{
    public class CategoryFactory : ICategoryFactory
    {
        public Category CreateCategory(string name, bool isHot, string sefName, string icon, string author, int? parent)
        {
            return new Category
            {
                Name = name,
                AuthorId = author,
                IsHot = isHot,
                SefName = sefName,
                Icon = icon,
                ParentCategoryId = parent
            };
        }

        public CategoryViewModel CreateCategoryViewModel(Category cat)
        {
            var categoryModel = new CategoryViewModel
            {
                Id = cat.Id,
                IsHot = cat.IsHot,
                ParentCategoryId = cat.ParentCategoryId ?? -1,
                Name = cat.Name,
                Icon = cat.Icon,
                SefName = cat.SefName
            };
            return categoryModel;
        }
    }
}
