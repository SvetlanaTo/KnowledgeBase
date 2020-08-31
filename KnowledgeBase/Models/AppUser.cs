using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KnowledgeBase.Models
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Activities = new List<Activity>();
            Articles = new List<Article>();
            ArticleTags = new List<ArticleTag>();
            Attachments = new List<Attachment>();
            Categories = new List<Category>();
            Settings = new List<Settings>();
            Tags = new List<Tag>();
            KbUsers1 = new List<AppUser>();

        }

        //public string Name { get; set; }

        //public string LastName { get; set; }
        
        public string AuthorId { get; set; }
        public virtual AppUser Author { get; set; }


        [JsonIgnore]
        public virtual ICollection<Activity> Activities { get; set; }

        [JsonIgnore]
        public virtual ICollection<Article> Articles { get; set; }

        [JsonIgnore]
        public virtual ICollection<ArticleTag> ArticleTags { get; set; }

        [JsonIgnore]
        public virtual ICollection<Attachment> Attachments { get; set; }

        [JsonIgnore]
        public virtual ICollection<Category> Categories { get; set; }

        [JsonIgnore]
        public virtual ICollection<Settings> Settings { get; set; }

        [JsonIgnore]
        public virtual ICollection<Tag> Tags { get; set; }

        [JsonIgnore]
        public virtual ICollection<AppUser> KbUsers1 { get; set; }

    }

}
