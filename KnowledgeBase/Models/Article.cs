using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KnowledgeBase.Models
{
    [Table("Articles")]
    public class Article
    {
        public Article()
        {
            //ArticleTags = new HashSet<ArticleTag>();
            //Attachments = new HashSet<Attachment>();
            ArticleTags = new List<ArticleTag>();
            Attachments = new List<Attachment>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public string Content { get; set; }

        public int Views { get; set; }

        public int Likes { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Edited { get; set; }

        public int IsDraft { get; set; }

        public DateTime? PublishStartDate { get; set; }

        public DateTime? PublishEndDate { get; set; }

        [Required]
        [StringLength(200)]
        public string SefName { get; set; }


        public string AuthorId { get; set; }
        public virtual AppUser Author { get; set; }


        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


        [JsonIgnore]
        public virtual ICollection<ArticleTag> ArticleTags { get; set; }

        [JsonIgnore]
        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}
