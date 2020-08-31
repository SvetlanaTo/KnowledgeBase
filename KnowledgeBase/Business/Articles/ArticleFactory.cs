using KnowledgeBase.Business.Categories;
using KnowledgeBase.DAL.Repo;
using KnowledgeBase.Data;
using KnowledgeBase.Models;
using KnowledgeBase.ViewModels;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.Business.Articles
{
    public class ArticleFactory : IArticleFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IUserRepository _userRepository { get; set; }
        public ICategoryFactory _categoryFactory { get; set; }
        private ICategoryRepository _categoryRepository;
        private readonly KnowledgeBaseContext _context;

        public ArticleFactory(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, ICategoryFactory categoryFactory, ICategoryRepository categoryRepository, KnowledgeBaseContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _categoryFactory = categoryFactory;
            _categoryRepository = categoryRepository;
            _context = context;
        }

        ////nije kompatibilno s Identitijem
        ////using Microsoft.AspNetCore.Mvc.Infrastructure;
        //private readonly IActionContextAccessor _actionContextAccessor;

        public async Task<ArticleViewModel> CreateArticleViewModel(Article article)
        {
            var model = new ArticleViewModel();
            if (article != null)
            {
                model.Author = await _userRepository.Get(article.AuthorId);
                model.Category = new CategoryViewModel(article.Category);
                model.Content = article.Content;
                model.Created = article.Created ?? DateTime.Now;
                model.Edited = article.Edited ?? DateTime.Now;
                model.Id = article.Id;
                model.IsDraft = article.IsDraft == 1 ? true : false;
                model.Likes = article.Likes;
                model.PublishEndDate = article.PublishEndDate ?? DateTime.Now;
                model.PublishStartDate = article.PublishStartDate ?? DateTime.Now.AddYears(5);
                model.Title = article.Title;
                model.Tags = string.Join(",", article.ArticleTags.Select(at => at.Tag.Name).ToArray());
                //model.Attachments = article.Attachments.Select(t => new AttachmentViewModel(t, _actionContextAccessor)).ToList();
                model.Attachments = article.Attachments.Select(t => new AttachmentViewModel(t, _httpContextAccessor)).ToList();
                model.SefName = article.SefName;
            }

            return model;
        }

        public Article CreateArticleFromViewModel(ArticleViewModel articleViewModel, string userId)
        {
            var article = new Article
            {
                CategoryId = articleViewModel.Category.Id,
                IsDraft = articleViewModel.IsDraft ? 1 : 0,
                PublishEndDate = articleViewModel.PublishEndDate,
                PublishStartDate = articleViewModel.PublishStartDate,
                Created = DateTime.Now,
                Edited = DateTime.Now,
                Title = articleViewModel.Title,
                Content = articleViewModel.Content,
                SefName = articleViewModel.SefName,
                AuthorId = userId.ToString()
            };
            return article;
        }

        public ArticleViewModel CreateArticleViewModelWithDefValues(Category cat)
        {
            var model = new ArticleViewModel
            {
                PublishStartDate = DateTime.Now.Date,
                PublishEndDate = DateTime.Now.AddYears(5).Date,
                Category = cat != null ? _categoryFactory.CreateCategoryViewModel(cat) : new CategoryViewModel()
            };

            return model;
        }

        //2408
        public CreateArticleViewModel CreateArticleViewModelWithDefaultValues()
        {
            var model = new CreateArticleViewModel
            {
                PublishStartDate = DateTime.Now.Date,
                PublishEndDate = DateTime.Now.AddYears(5).Date,
                //Categories = _context.Categories.ToList()
            };

            return model;
        }

        public Article CreateArticleFromViewModel_Create(CreateArticleViewModel model, string currentUser)
        {
            var article = new Article
            {
                CategoryId = model.Category,
                IsDraft = model.IsDraft ? 1 : 0,
                PublishEndDate = model.PublishEndDate,
                PublishStartDate = model.PublishStartDate,
                Created = DateTime.Now,
                Edited = DateTime.Now,
                Title = model.Title,
                Content = model.Content,
                SefName = model.SefName,
                AuthorId = currentUser,
                Views = 0,
                Likes = 0
            };
            return article;
        }

        public CreateArticleViewModel CreateArticleViewModel_Edit(Article article)
        {
            var model = new CreateArticleViewModel();
            if (article != null)
            {
                //model.Author = await _userRepository.Get(article.AuthorId);
                //model.Category = new CategoryViewModel(article.Category);
                //Category c = _categoryRepository.Get(article.CategoryId);
                model.Category = article.CategoryId;
                model.Content = article.Content;
                //model.Created = article.Created ?? DateTime.Now;
                //model.Edited = article.Edited ?? DateTime.Now;
                model.Id = article.Id;
                model.IsDraft = article.IsDraft == 1 ? true : false;
                //model.Likes = article.Likes;
                model.PublishEndDate = article.PublishEndDate ?? DateTime.Now;
                model.PublishStartDate = article.PublishStartDate ?? DateTime.Now.AddYears(5);
                model.Title = article.Title;
                model.Tags = string.Join(",", article.ArticleTags.Select(at => at.Tag.Name).ToArray());
                //model.Attachments = article.Attachments.Select(t => new AttachmentViewModel(t, _actionContextAccessor)).ToList();
                model.Attachments = article.Attachments.Select(t => new AttachmentViewModel(t, _httpContextAccessor)).ToList();
                model.SefName = article.SefName;
            }

            return model;
        }
    }
}
