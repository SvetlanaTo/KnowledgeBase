using KnowledgeBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.DAL.Repo
{
    public interface ICategoryRepository
    {
        int Add(Category category);
        void Update(Category category);
        Category Get(int categoryId);
        bool Remove(Category category);

        Category GetFirstCategory();
        IList<Category> GetAllCategories();
        IList<Category> GetHotCategories();
        IList<Category> GetFirstLevelCategories();
        bool HasArticleInCategory(int categoryId);

        //2608
        bool HasArticleInCategoryOrParentCategoryOrChildren(int categoryId);
        IList<Article> GetArticles(int categoryId);
    }
}
