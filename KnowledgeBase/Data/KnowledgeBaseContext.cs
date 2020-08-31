using KnowledgeBase.DAL.Types;
using KnowledgeBase.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.Data 
{
    public class KnowledgeBaseContext : IdentityDbContext<AppUser>
    {
        public KnowledgeBaseContext(DbContextOptions<KnowledgeBaseContext> options) : base(options)
        {

        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<SimilarArticle> SimilarArticles { get; set; }
        public DbSet<TopTagItem> TopTagItems { get; set; } 

    }
}