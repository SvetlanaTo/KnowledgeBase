using KnowledgeBase.Models;
using KnowledgeBase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.Business.Articles
{
    public interface IArticleFactory
    {
        Task<ArticleViewModel> CreateArticleViewModel(Article article);

        Article CreateArticleFromViewModel(ArticleViewModel articleViewModel, string userId);
        ArticleViewModel CreateArticleViewModelWithDefValues(Category cat);

        //2408
        CreateArticleViewModel CreateArticleViewModelWithDefaultValues();
        Article CreateArticleFromViewModel_Create(CreateArticleViewModel model, string currentUser);
        CreateArticleViewModel CreateArticleViewModel_Edit(Article article);
    }
}
