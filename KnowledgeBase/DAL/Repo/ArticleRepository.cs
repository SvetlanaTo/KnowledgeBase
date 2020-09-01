using KnowledgeBase.DAL.Types;
using KnowledgeBase.Data;
using KnowledgeBase.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.DAL.Repo
{
    public class ArticleRepository : IArticleRepository //GenericRepository<Article>, IArticleRepository
    {
        private KnowledgeBaseContext _context;
        public IActivityRepository _activityRepository;

        public ArticleRepository(KnowledgeBaseContext context, IActivityRepository activityRepository)
        {
            _context = context;
            _activityRepository = activityRepository;
        }

        //private KbVaultDalExtensions ext;




        public Article Get(long id)
        {
            var model = _context.Articles
                .Include(c => c.Category)
                .Include(t => t.ArticleTags)
                //.Include(t => t.ArticleTags.Select(a => a.Tag))
                .Include(a => a.Attachments)
                .FirstOrDefault(a => a.Id == id);
            return model;

        }

        //2508
        public List<ArticleTag> GetArticleTagsForArticleId(long id)
        {
            var articleTag = _context.ArticleTags
               .Include(a => a.Article)
               .Include(a => a.Author)
               .Include(a => a.Tag)
               //.FirstOrDefaultAsync(m => m.ArticleId == id);
               .Where(m => m.ArticleId == id)
               .ToList();

            return articleTag;
        }



        public long Add(Article article, string tags, string currentUser)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
            if (!string.IsNullOrEmpty(tags))
            {
                //AssignTagsToArticle(article.Id, tags);
                AssignTagsToArticleWithAuthor(article.Id, tags, currentUser);

            }

            _context.SaveChanges();
            //0109 - activity
            _activityRepository.ArticleActivities(article, "added");
            return article.Id;

        }

        public void Update(Article article, string tags, string currentUser)
        {
            //using (var db = new KnowledgeBaseContext(_config))
            //{
            //0308-s
            //AddOrUpdate(article);

            _context.Articles.Update(article);

            _context.SaveChanges();
            if (!string.IsNullOrEmpty(tags))
            {
                //AssignTagsToArticle(article.Id, tags);
                AssignTagsToArticleWithAuthor(article.Id, tags, currentUser);
            }

            _context.SaveChanges();

            //0109 - activity
            _activityRepository.ArticleActivities(article, "updated");
        }




        //public IEnumerable<SimilarArticle> GetVisibleSimilarArticles(int articleId, DateTime date)
        public IList<SimilarArticle> GetVisibleSimilarArticles(int articleId, DateTime date)
        {
            var articleIdParam = new SqlParameter("ArticleId", articleId);

            //AsEnumerable
            //ToList()
            //.IgnoreQueryFilters();
            //AsNoTracking
            //FromSqlRaw
            //return _context.SimilarArticles.FromSqlRaw("exec GetSimilarArticles @ArticleId", articleIdParam)
            //    .Where(a => a.PublishStartDate <= date && a.PublishEndDate >= date && a.IsDraft == 0)
            //    .AsNoTracking()
            //    .ToList();

            var articles = _context.SimilarArticles.FromSqlRaw("exec GetSimilarArticles @ArticleId", articleIdParam).ToList();


            var similarArticles = articles.Where(a => a.PublishStartDate <= date && a.PublishEndDate >= date && a.IsDraft == 0).ToList();

            return similarArticles;
        }

        public void AssignTagsToArticle(long articleId, string tags)
        {
            var articleIdParameter = new SqlParameter("ArticleId", articleId);
            var tagsParameter = new SqlParameter("Tags", tags);
            _context.Database.ExecuteSqlRaw("exec AssignTagsToArticle @ArticleId, @Tags", articleIdParameter, tagsParameter);
        }

        public void AssignTagsToArticleWithAuthor(long articleId, string tags, string currentUser)
        {
            var articleIdParameter = new SqlParameter("ArticleId", articleId);
            var tagsParameter = new SqlParameter("Tags", tags);
            var currentUserId = new SqlParameter("AuthorId", currentUser);

            _context.Database.ExecuteSqlRaw("exec AssignTagsToArticleWithAuthor @ArticleId, @Tags, @AuthorId", articleIdParameter, tagsParameter, currentUserId);
        }

        public int GetTotalArticleCount()
        {

            return _context.Articles.Count();
        }

        public int GetTotalPublishedArticleCount()
        {
            List<Article> lista = new List<Article>();
            lista = PublishedArticles().ToList();
            //todo
            return lista.Count();

        }

        public Article GetMostLikedArticle()
        {

            return _context.Articles.OrderByDescending(a => a.Likes).FirstOrDefault();
        }

        public Article GetMostViewedArticle()
        {

            return _context.Articles.OrderByDescending(a => a.Views).FirstOrDefault();
        }

        public List<Article> GetLatestArticles(int maxItemCount)
        {
            List<Article> lista = new List<Article>();
            lista = PublishedArticles().ToList();
            return lista
                    .OrderByDescending(a => a.Edited)
                    .Take(maxItemCount)
                    .ToList();
        }

        public List<Article> GetPopularArticles(int maxItemCount)
        {
            List<Article> lista = new List<Article>();
            lista = PublishedArticles().ToList();
            return lista
                    .OrderByDescending(a => a.Likes)
                    .Take(maxItemCount)
                    .ToList();
        }

        public IQueryable<Article> PublishedArticles()
        {
            DateTime today = DateTime.Now.Date;
            return _context.Articles
                    .Include("Category")
                    .Include("ArticleTags.Tag")
                    .Include("Attachments")
                    .Where(a => a.PublishStartDate <= today &&
                           a.PublishEndDate >= today &&
                           a.IsDraft == 0);
        }


    }
}
