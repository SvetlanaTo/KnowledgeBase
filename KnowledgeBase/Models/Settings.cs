using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.Models
{
    [Table("Settings")]
    public class Settings
    {
        [Key] 
        [StringLength(100)]
        public string CompanyName { get; set; }

        [StringLength(500)]
        public string TagLine { get; set; }

        [StringLength(100)]
        public string JumbotronText { get; set; }

        public short ArticleCountPerCategoryOnHomePage { get; set; }

        [StringLength(50)]
        public string ShareThisPublicKey { get; set; }

        [StringLength(150)]
        public string DisqusShortName { get; set; }

        [StringLength(2000)]
        public string IndexFileExtensions { get; set; }

        [StringLength(50)]
        public string ArticlePrefix { get; set; }

        [StringLength(50)]
        public string AnalyticsAccount { get; set; }

        [StringLength(2000)]
        public string BackupPath { get; set; }

        public bool ShowTotalArticleCountOnFrontPage { get; set; }

        public string AuthorId { get; set; }
        public virtual AppUser Author { get; set; }
    }
}
