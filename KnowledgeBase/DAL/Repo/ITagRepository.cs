using KnowledgeBase.DAL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.DAL.Repo
{
    public interface ITagRepository
    {
        void RemoveTagFromArticles(int tagId);
        Task<IList<TopTagItem>> GetTopTags();
        Task<IList<TopTagItem>> GetTagCloud();
    }
}
