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
using X.PagedList;

namespace KnowledgeBase.DAL.Repo
{
    public class TagRepository : ITagRepository
    {
        private KnowledgeBaseContext _context;

        public TagRepository(KnowledgeBaseContext context)
        {
            _context = context;
        }

        public async Task<IList<TopTagItem>> GetTagCloud()
        {
            //UREDITI ZA ASINHRONO SORTIRANJE
            //var popularTags = await GetTopTags().OrderBy(c => Guid.NewGuid()).ToList();
            var popularTags = await GetTopTags();
            var maxTagRatio = popularTags.Max(t => t.Ratio).HasValue ? Convert.ToInt32(popularTags.Max(t => t.Ratio).Value) : -1;
            var minTagRatio = popularTags.Min(t => t.Ratio).HasValue ? Convert.ToInt32(popularTags.Min(t => t.Ratio).Value) : -1;
            var ratioDiff = maxTagRatio - minTagRatio;
            var minRatio = minTagRatio;
            foreach (var item in popularTags)
            {
                if (ratioDiff > 0)
                {
                    item.FontSize = 80 + Convert.ToInt32(Math.Truncate((double)(item.Ratio - minRatio) * (100 / ratioDiff)));
                }
                else
                {
                    item.FontSize = 80;
                }
            }
            return popularTags.OrderBy(c => Guid.NewGuid()).ToList();
        }

        public async Task<IList<TopTagItem>> GetTopTags()
        {
            var toptagitems = await _context.TopTagItems.FromSqlRaw("exec GetTopTags").ToListAsync();
            return toptagitems;
        }

        //public IList<TopTagItem> GetTopTags()
        //{
        //    using (var db = new KbVaultContext(_config))
        //    {
        //        //select top 20 amount*100/(Select sum(amount) from VwArticleTagCount) Ratio,Name,Id, 0 as FontSize from VwArticleTagCount
        //        return db.Database.SqlQuery<TopTagItem>("exec GetTopTags").ToList(); 
        //    }
        //}

        //public IList<TopTagItem> GetTopTags()
        //{
        //    using (var command = _context.Database.GetDbConnection().CreateCommand())
        //    {
        //        //TODO VRATI SE - SREDI UPIT
        //        //command.CommandText = "select top 20 amount*100/(Select sum(amount) from VwArticleTagCount) Ratio,Name,Id, 0 as FontSize from VwArticleTagCount order by amount*100/(Select sum(amount) from VwArticleTagCount) desc";
        //        command.CommandText = "select * from ArticleTags";
        //        command.CommandType = CommandType.Text;

        //        _context.Database.OpenConnection();
        //        var entities = new List<TopTagItem>();
        //        using (var result = command.ExecuteReader())
        //        {
        //            while (result.Read())
        //            {
        //                TopTagItem simArt = new TopTagItem();

        //                simArt.Ratio = result.GetInt32(0);
        //                simArt.Name = result.GetString(1);
        //                simArt.Id = result.GetInt32(2);
        //                simArt.FontSize = result.GetInt32(3);

        //                entities.Add(simArt);
        //            }
        //        }
        //        return entities;
        //    }
        //}

        //public IList<TopTagItem> GetTopTags()
        //{
        //    using (var db = new KbVaultContext())
        //    {
        //        return db.Database.SqlQuery<TopTagItem>("exec GetTopTags").ToList();
        //    }
        //}

        public void RemoveTagFromArticles(int tagId)
        {
            //using (var db = new KnowledgeBaseContext(_config))
            //{
                var tagIdParam = new SqlParameter("TagId", tagId);
            //STORED PROCEDURES - PRAZNO!!1
            _context.Database.ExecuteSqlRaw("exec RemoveTagFromArticles @TagId", tagIdParam);
            //}
        }
    }

}
