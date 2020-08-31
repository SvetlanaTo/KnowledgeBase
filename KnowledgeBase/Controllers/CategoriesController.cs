using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KnowledgeBase.Models;
using KnowledgeBase.Data;
using KnowledgeBase.DAL.Repo;
using KnowledgeBase.ViewModels;
using Microsoft.AspNetCore.Http;
using Resources;
using X.PagedList;
using KnowledgeBase.Business.Categories;
using System.Security.Claims;
using NLog;
using Microsoft.AspNetCore.Mvc.Routing;

namespace KnowledgeBase.Controllers
{
    public class CategoriesController : Controller
    {
        private Logger log = LogManager.GetCurrentClassLogger();
        private readonly KnowledgeBaseContext _context;
        private ICategoryRepository _categoryRepository;
        private readonly ICategoryFactory _categoryFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoriesController(KnowledgeBaseContext context, ICategoryRepository categoryRepository, ICategoryFactory categoryFactory, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _categoryRepository = categoryRepository;
            _categoryFactory = categoryFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        //public CategoriesController(KnowledgeBaseContext context, ICategoryRepository categoryRepository)
        //{
        //    _context = context;
        //    _categoryRepository = categoryRepository;
        //}   

        public async Task<IActionResult> Index()
        {
            var knowledgeBaseContext = _context.Categories.Include(c => c.Author).Include(c => c.ParentCategory);
            return View(await knowledgeBaseContext.ToListAsync());
        }

        // [Authorize(Roles = "Admin,Manager")]
        public ActionResult Create()
        {
            ViewData["ParentCategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        //[Authorize(Roles = "Admin,Manager")]
        public ActionResult Create(CategoryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var parentId = model.ParentCategoryId > 0 ? model.ParentCategoryId : (int?)null;
                    string currentUser = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    //var category = _categoryFactory.CreateCategory(model.Name, model.IsHot, model.SefName, model.Icon, KBVaultHelperFunctions.UserAsKbUser(User).Id, parentId);

                    var category = _categoryFactory.CreateCategory(model.Name, model.IsHot, model.SefName, model.Icon, currentUser, parentId);
                    var catId = _categoryRepository.Add(category);
                    //ShowOperationMessage(@UIResources.CategoryPageCreateSuccessMessage);
                    ShowOperationMessage("CategoryPageCreateSuccessMessage");
                    //return RedirectToAction("List", new { id = catId, page = 1 });
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        //  [Authorize(Roles = "Admin,Manager")]
        public JsonResult Remove(int id)
        {
            var result = new JsonOperationResponse();
            try
            {
                if (_categoryRepository.Get(id) != null)
                {
                    if (!_categoryRepository.HasArticleInCategory(id))
                    {
                        var cat = new Category
                        {
                            AuthorId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
                            Id = id
                        };
                        if (_categoryRepository.Remove(cat))
                        {
                            result.Successful = true;
                            result.ErrorMessage = string.Format(ErrorMessages.CategoryRemovedSuccessfully, cat.Name);
                            cat = _categoryRepository.GetFirstCategory();

                            //var url = new UrlHelper(Request.RequestContext);                            
                            //result.Data = cat == null
                            //    ? url.Action("Index", "Dashboard")
                            //    : url.Action("List", "Category", new { id = cat.Id, page = 1 });

                            //testirati
                            result.Data = cat == null
                               ? RedirectToAction("Index", "Dashboard")
                               : RedirectToAction("List", "Category", new { id = cat.Id, page = 1 });
                        }
                    }
                    else
                    {
                        result.Successful = false;
                        result.ErrorMessage = ErrorMessages.CategoryIsNotEmpty;
                    }
                }
                else
                {
                    result.Successful = false;
                    result.ErrorMessage = ErrorMessages.CategoryNotFound;
                }

                return Json(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                result.Successful = false;
                result.ErrorMessage = ex.Message;
                return Json(result);
            }
        }

        // [Authorize(Roles = "Admin,Manager")]
        public ActionResult Edit(int id = -1)
        {
            try
            {
                var category = _categoryRepository.Get(id);
                if (category == null)
                {
                    return NotFound();
                }

                ViewData["ParentCategoryId"] = new SelectList(_context.Categories, "Id", "Name", category.ParentCategoryId);

                return View(_categoryFactory.CreateCategoryViewModel(category));


                //return View(_categoryFactory.CreateCategoryViewModel(_categoryRepository.Get(id)));
            }
            catch (Exception ex)
            {
                log.Error(ex);
                ShowOperationMessage(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin,Manager")]
        public ActionResult Edit(CategoryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var parentId = model.ParentCategoryId > 0 ? model.ParentCategoryId : (int?)null;
                        var author = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                        var category = _categoryFactory.CreateCategory(model.Name, model.IsHot, model.SefName, model.Icon, author, parentId);
                        category.Id = model.Id;
                        _categoryRepository.Update(category);
                        ShowOperationMessage(UIResources.CategoryPageEditSuccessMessage);
                        return RedirectToAction("List", new { id = model.Id, page = 1 });
                    }
                    catch (ArgumentNullException)
                    {
                        ModelState.AddModelError("Category Not Found", ErrorMessages.CategoryNotFound);
                    }
                }

                return View(model);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                ModelState.AddModelError("Exception", ex.Message);
                return View(model);
            }
        }

        public ActionResult List(int id, int page)
        {
            try
            {
                var cat = _categoryRepository.Get(id);
                if (cat != null)
                {
                    var model = new CategoryListViewModel
                    {
                        CategoryName = cat.Name,
                        CategoryId = cat.Id,
                        Icon = cat.Icon,
                        Articles = _categoryRepository.GetArticles(id).ToPagedList(page, 20)
                    };
                    return View(model);
                }

                ShowOperationMessage(ErrorMessages.CategoryNotFound);
                return RedirectToAction("Index", "Error");
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return RedirectToAction("Index", "Error");
            }
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
    }
}



//// GET: Categories
//public async Task<IActionResult> Index()
//{
//    var knowledgeBaseContext = _context.Categories.Include(c => c.Author).Include(c => c.ParentCategory);
//    return View(await knowledgeBaseContext.ToListAsync());
//}

//// GET: Categories/Details/5
//public async Task<IActionResult> Details(int? id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }

//    var category = await _context.Categories
//        .Include(c => c.Author)
//        .Include(c => c.ParentCategory)
//        .FirstOrDefaultAsync(m => m.Id == id);
//    if (category == null)
//    {
//        return NotFound();
//    }

//    return View(category);
//}

//// GET: Categories/Create
//public IActionResult Create()
//{
//    ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id");
//    ViewData["ParentCategoryId"] = new SelectList(_context.Categories, "Id", "Name");
//    return View();
//}

//// POST: Categories/Create
//// To protect from overposting attacks, enable the specific properties you want to bind to, for 
//// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//[HttpPost]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> Create([Bind("Id,Name,IsHot,Parent,SefName,Icon,AuthorId,ParentCategoryId")] Category category)
//{
//    if (ModelState.IsValid)
//    {
//        _context.Add(category);
//        await _context.SaveChangesAsync();
//        return RedirectToAction(nameof(Index));
//    }
//    ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id", category.AuthorId);
//    ViewData["ParentCategoryId"] = new SelectList(_context.Categories, "Id", "Name", category.ParentCategoryId);
//    return View(category);
//}

//// GET: Categories/Edit/5
//public async Task<IActionResult> Edit(int? id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }

//    var category = await _context.Categories.FindAsync(id);
//    if (category == null)
//    {
//        return NotFound();
//    }
//    ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id", category.AuthorId);
//    ViewData["ParentCategoryId"] = new SelectList(_context.Categories, "Id", "Name", category.ParentCategoryId);
//    return View(category);
//}

//// POST: Categories/Edit/5
//// To protect from overposting attacks, enable the specific properties you want to bind to, for 
//// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//[HttpPost]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IsHot,Parent,SefName,Icon,AuthorId,ParentCategoryId")] Category category)
//{
//    if (id != category.Id)
//    {
//        return NotFound();
//    }

//    if (ModelState.IsValid)
//    {
//        try
//        {
//            _context.Update(category);
//            await _context.SaveChangesAsync();
//        }
//        catch (DbUpdateConcurrencyException)
//        {
//            if (!CategoryExists(category.Id))
//            {
//                return NotFound();
//            }
//            else
//            {
//                throw;
//            }
//        }
//        return RedirectToAction(nameof(Index));
//    }
//    ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id", category.AuthorId);
//    ViewData["ParentCategoryId"] = new SelectList(_context.Categories, "Id", "Name", category.ParentCategoryId);
//    return View(category);
//}

//// GET: Categories/Delete/5
//public async Task<IActionResult> Delete(int? id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }

//    var category = await _context.Categories
//        .Include(c => c.Author)
//        .Include(c => c.ParentCategory)
//        .FirstOrDefaultAsync(m => m.Id == id);
//    if (category == null)
//    {
//        return NotFound();
//    }

//    return View(category);
//}

//// POST: Categories/Delete/5
//[HttpPost, ActionName("Delete")]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> DeleteConfirmed(int id)
//{
//    var category = await _context.Categories.FindAsync(id);
//    _context.Categories.Remove(category);
//    await _context.SaveChangesAsync();
//    return RedirectToAction(nameof(Index));
//}

//private bool CategoryExists(int id)
//{
//    return _context.Categories.Any(e => e.Id == id);
//}
