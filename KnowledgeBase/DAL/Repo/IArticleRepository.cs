using KnowledgeBase.DAL.Types;
using KnowledgeBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.DAL.Repo
{
    public interface IArticleRepository //: IGenericRepository<Article>
    {
        Article Get(long id);
        //SimilarArticle Get(long? id);

        //2508
        List<ArticleTag> GetArticleTagsForArticleId(long id);

        long Add(Article article, string tags, string currentUser);

        void Update(Article article, string tags, string currentUser);

        //2808
        IList<SimilarArticle> GetVisibleSimilarArticles(int articleId, DateTime date);
        //IEnumerable<SimilarArticle> GetVisibleSimilarArticles(int articleId, DateTime date);

        void AssignTagsToArticle(long articleId, string tags);

        int GetTotalArticleCount();

        int GetTotalPublishedArticleCount();

        Article GetMostLikedArticle();

        Article GetMostViewedArticle();

        List<Article> GetLatestArticles(int maxItemCount);

        List<Article> GetPopularArticles(int maxItemCount);
    }
}
