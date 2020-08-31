using KnowledgeBase.Data;
using KnowledgeBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.DAL
{
    public class KbVaultDalExtensions
    {
        private KnowledgeBaseContext _context;

        public KbVaultDalExtensions(KnowledgeBaseContext context)
        {
            _context = context;
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
