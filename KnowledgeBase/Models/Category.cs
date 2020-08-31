using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KnowledgeBase.Models
{
    [Table("Categories")]
    public class Category
    {
        public Category()
        {
            Articles = new HashSet<Article>();
            ChildCategories = new HashSet<Category>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public bool IsHot { get; set; }

        //public int? Parent { get; set; }

        [Required]
        [StringLength(200)]
        public string SefName { get; set; }

        public string Icon { get; set; }

        public string AuthorId { get; set; }
        public virtual AppUser Author { get; set; }

        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }

        [JsonIgnore]
        public virtual ICollection<Article> Articles { get; set; }

        [JsonIgnore]
        public virtual ICollection<Category> ChildCategories { get; set; }


    }
}
