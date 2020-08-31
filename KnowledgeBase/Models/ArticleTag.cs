using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.Models
{
    [Table("ArticleTags")]
    public class ArticleTag
    {
        public long Id { get; set; }

        public long TagId { get; set; }
        public virtual Tag Tag { get; set; } 

        public long ArticleId { get; set; }
        public virtual Article Article { get; set; }

        public string AuthorId { get; set; }
        public virtual AppUser Author { get; set; }


    }
}
