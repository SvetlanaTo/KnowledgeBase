using KnowledgeBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.DAL.Repo
{
    public interface IActivityRepository
    {
        void ArticleActivities(Article article, string v);
    }
}
