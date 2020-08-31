using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KnowledgeBase.Models
{
    [Table("Tags")] 
    public class Tag
    {
        public Tag()
        {
            ArticleTags = new List<ArticleTag>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string AuthorId { get; set; }
        public virtual AppUser Author { get; set; }


        [JsonIgnore]
        public virtual ICollection<ArticleTag> ArticleTags { get; set; }


    }
}
