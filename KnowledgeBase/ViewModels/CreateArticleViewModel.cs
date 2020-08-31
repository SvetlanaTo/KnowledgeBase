using KnowledgeBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.ViewModels
{
    public class CreateArticleViewModel
    {
        public CreateArticleViewModel()
        {
            Attachments = new List<AttachmentViewModel>();
            //Categories = new List<Category>();

        }

        public List<AttachmentViewModel> Attachments { get; set; }
        //public List<CategoryViewModel> Categories { get; set; }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        //public int Views { get; set; }
        //public int Likes { get; set; }
        //public DateTime Created { get; set; }
        //public DateTime Edited { get; set; }
        public bool IsDraft { get; set; }
        public string Tags { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resources.UIResources), ErrorMessageResourceName = "ArticleCreatePagePublishStartRequiredMessage")]
        public DateTime PublishStartDate { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resources.UIResources), ErrorMessageResourceName = "ArticleCreatePagePublishEndRequiredMessage")]
        public DateTime PublishEndDate { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resources.UIResources), ErrorMessageResourceName = "ArticleSefNameIsRequired")]
        public string SefName { get; set; }
        //public AppUser Author { get; set; }

        //public List<Category> Categories { get; set; }
        public int Category { get; set; }

    }
}
