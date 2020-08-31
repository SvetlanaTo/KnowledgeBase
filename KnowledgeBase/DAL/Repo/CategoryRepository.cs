using KnowledgeBase.Data;
using KnowledgeBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.DAL.Repo
{
    public class CategoryRepository : ICategoryRepository
    {
        private KnowledgeBaseContext _context;

        public CategoryRepository(KnowledgeBaseContext context)
        {
            _context = context;
        }

        public int Add(Category category)
        {
            //using (var db = new KnowledgeBaseContext(_config))
            //{
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category.Id;
            //}
        }

        public void Update(Category category)
        {
            //using (var db = new KnowledgeBaseContext(_config))
            //{
            var cat = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (cat != null)
            {
                cat.Name = category.Name;
                cat.IsHot = category.IsHot;
                cat.SefName = category.SefName;
                cat.AuthorId = category.AuthorId;
                cat.ParentCategoryId = category.ParentCategoryId;
                cat.Icon = category.Icon;
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }
            //}
        }

        public Category Get(int categoryId)
        {
            //using (var db = new KnowledgeBaseContext(_config))
            //{
            var category = _context.Categories.FirstOrDefault(ca => ca.Id == categoryId);
            if (category == null)
            {
                throw new ArgumentNullException("Category not found");
            }

            return category;
            //}
        }

        public IList<Category> GetAllCategories()
        {
            //using (var db = new KnowledgeBaseContext(_config))
            //{
            return _context.Categories.OrderBy(c => c.Name).ToList();
            //}
        }

        public bool HasArticleInCategory(int categoryId)
        {
            //using (var db = new KnowledgeBaseContext(_config))
            //{
            return _context.Articles.Any(a => a.CategoryId == categoryId);
            //}
        }

        //2608 //treba proveriti da li i ParentCategory ima article, da li ima ChildCategories i da li one imaju artikle
        public bool HasArticleInCategoryOrParentCategoryOrChildren(int categoryId)
        {
            //Category cat = Get(categoryId);
            Category cat = _context.Categories
               .Include(c => c.ChildCategories)
               .Include(c => c.ParentCategory)
               .FirstOrDefault(m => m.Id == categoryId);

            List<Category> children = cat.ChildCategories.ToList();

            if (children.Count > 0)
            {
                foreach (var child in children)
                {
                    if (_context.Articles.Any(a => a.CategoryId == child.Id))
                    {
                        return true;
                    }
                }
            }

            return _context.Articles.Any(a => a.CategoryId == categoryId || a.CategoryId == cat.ParentCategoryId);



        }

        public IList<Article> GetArticles(int categoryId)
        {
            //using (var db = new KnowledgeBaseContext(_config))
            //{
            return _context.Articles.Include(a => a.Author).Include(a => a.Attachments).Where(a => a.CategoryId == categoryId).OrderBy(c => c.Title).ToList();
            //}
        }

        public bool Remove(Category category)
        {
            //using (var db = new KnowledgeBaseContext(_config))
            //{
            var cat = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (cat != null)
            {
                cat.AuthorId = category.AuthorId;
                _context.Categories.Remove(cat);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            //}
        }

        public Category GetFirstCategory()
        {
            //using (var db = new KnowledgeBaseContext(_config))
            //{
            return _context.Categories.FirstOrDefault();
            //}
        }

        public IList<Category> GetHotCategories()
        {
            //using (var db = new KnowledgeBaseContext(_config))
            //{
            return _context.Categories.Include("Articles").Where(c => c.IsHot).ToList();
            //}
        }

        public IList<Category> GetFirstLevelCategories()
        {
            //using (var db = new KnowledgeBaseContext(_config))
            //{
            return _context.Categories.Include("Articles").Where(c => c.ParentCategoryId == null).OrderBy(c => c.Name).ToList();
            //}
        }
    }
}
