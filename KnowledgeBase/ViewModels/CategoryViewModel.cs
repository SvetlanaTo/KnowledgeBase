using KnowledgeBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            Children = new List<CategoryViewModel>();
        }

        public CategoryViewModel(Category cat)
        {
            this.Id = cat.Id;
            this.Name = cat.Name;
            this.IsHot = cat.IsHot;
            this.ParentCategoryId = cat.ParentCategoryId ?? -1;
        }

        public List<CategoryViewModel> Children { get; set; }

        public int Id { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = "CategoryNameIsRequired")]
        public string Name { get; set; }

        public bool IsHot { get; set; }
        public int? ParentCategoryId { get; set; }
        public string NameForDroplist { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resources.UIResources), ErrorMessageResourceName = "CategorySefNameIsRequired")]
        public string SefName { get; set; }

        public string Icon { get; set; }
    }
}
