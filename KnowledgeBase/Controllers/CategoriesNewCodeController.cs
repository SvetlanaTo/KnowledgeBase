using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using KnowledgeBase.Business.Categories;
using KnowledgeBase.DAL.Repo;
using KnowledgeBase.Data;
using KnowledgeBase.Models;
using KnowledgeBase.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NLog;
using Resources;

namespace KnowledgeBase.Controllers
{
    public class CategoriesNewCodeController : Controller
    {

        private Logger log = LogManager.GetCurrentClassLogger();
        private readonly KnowledgeBaseContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ICategoryFactory _categoryFactory;
        private ICategoryRepository _categoryRepository;
        public IActivityRepository _activityRepository;

        public CategoriesNewCodeController(KnowledgeBaseContext context, IHttpContextAccessor httpContextAccessor, ICategoryFactory categoryFactory, ICategoryRepository categoryRepository, IActivityRepository activityRepository)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _categoryFactory = categoryFactory;
            _categoryRepository = categoryRepository;
            _activityRepository = activityRepository;
        }

        protected void ShowErrorMessage(string msg)
        {
            //ControllerContext.HttpContext.Session[ErrorMessageKey] += msg;
            var session1 = ControllerContext.HttpContext.Session.GetString("ErrorMessageKey");
            session1 += msg;
        }

        protected void ShowOperationMessage(string msg)
        {
            //ControllerContext.HttpContext.Session[OperationMessageKey] += msg;
            var session1 = ControllerContext.HttpContext.Session.GetString("OperationMessageKey");
            session1 += msg;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var knowledgeBaseContext = _context.Categories.Include(c => c.Author).Include(c => c.ParentCategory);
            return View(await knowledgeBaseContext.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .Include(c => c.Author)
                .Include(c => c.ParentCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {

            ViewData["ParentCategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Name,IsHot,SefName,Icon,ParentCategoryId")] CategoryViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    string currentUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var parentId = model.ParentCategoryId > 0 ? model.ParentCategoryId : (int?)null;
                    var category = _categoryFactory.CreateCategory(model.Name, model.IsHot, model.SefName, model.Icon, currentUserId, parentId);
                    var catId = _categoryRepository.Add(category);

                    //vrati se
                    //ShowOperationMessage(@UIResources.CategoryPageCreateSuccessMessage); 
                    //return RedirectToAction("List", new { id = catId, page = 1 });

                    return RedirectToAction(nameof(Index));
                }

                return View(model);

            }
            catch (Exception ex)
            {
                log.Error(ex);
                return RedirectToAction("Index", "Error");
            }

        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null)
                {
                    return NotFound();
                }

                var categoryView = _categoryFactory.CreateCategoryViewModel(category);

                ViewData["ParentCategoryId"] = new SelectList(_context.Categories, "Id", "Name", category.ParentCategoryId);
                return View(categoryView);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                ShowOperationMessage(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Name,IsHot,SefName,Icon,ParentCategoryId")] CategoryViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var parentCategoryId = model.ParentCategoryId > 0 ? model.ParentCategoryId : (int?)null;
                        var author = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                        var category = _categoryFactory.CreateCategory(model.Name, model.IsHot, model.SefName, model.Icon, author, parentCategoryId);
                        category.Id = model.Id;
                        _categoryRepository.Update(category);
                        //vrati se
                        //ShowOperationMessage(UIResources.CategoryPageEditSuccessMessage);
                        //return RedirectToAction("List", new { id = model.Id, page = 1 });
                        return RedirectToAction(nameof(Index));
                    }
                    catch (ArgumentNullException)
                    {
                        ModelState.AddModelError("Category Not Found", ErrorMessages.CategoryNotFound);
                    }
                }

                return View(model);
                //return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                log.Error(ex);
                ModelState.AddModelError("Exception", ex.Message);
                return View(model);
            }

        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .Include(c => c.Author)
                .Include(c => c.ParentCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }
            try
            {
                //if (!_categoryRepository.HasArticleInCategory(id))
                if (!_categoryRepository.HasArticleInCategoryOrParentCategoryOrChildren(id))
                {
                    _context.Categories.Remove(category);
                    await _context.SaveChangesAsync();

                    //0109
                    _activityRepository.CategoryActivities(category, "deleted");

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    log.Info("Category Has Articles!");
                    //vrati se
                    return BadRequest("Category Has Articles!");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                ModelState.AddModelError("Exception", ex.Message);
                return View(category);
            }





        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
