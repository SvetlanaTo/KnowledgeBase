using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KnowledgeBase.Data;
using KnowledgeBase.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using KnowledgeBase.ViewModels;
using KnowledgeBase.Business.Articles;
using KnowledgeBase.DAL.Repo;
using KnowledgeBase.Helpers;
using NLog;
using Resources;

namespace KnowledgeBase.Controllers
{
    public class ArticlesController : Controller
    {
        private Logger log = LogManager.GetCurrentClassLogger();
        private readonly KnowledgeBaseContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IArticleFactory _articleFactory;
        private IArticleRepository _articleRepository;
        private IUserRepository _userRepository;
        private KbVaultLuceneHelper _lucene;
        private KbVaultAttachmentHelper attachmentHelper;

        public ArticlesController(KnowledgeBaseContext context, IHttpContextAccessor httpContextAccessor, IArticleFactory articleFactory, IArticleRepository articleRepository, IUserRepository userRepository, KbVaultLuceneHelper lucene, KbVaultAttachmentHelper attachmentHelper)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _articleFactory = articleFactory;
            _articleRepository = articleRepository;
            _userRepository = userRepository;
            _lucene = lucene;
            this.attachmentHelper = attachmentHelper;
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



        // GET: Articles
        public async Task<IActionResult> Index()
        {
            var knowledgeBaseContext = _context.Articles.Include(a => a.Author).Include(a => a.Category);
            return View(await knowledgeBaseContext.ToListAsync());
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.Author)
                .Include(a => a.Category)
                .Include(a => a.ArticleTags)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            //ovde je TagId ocitan a Tag je null
            //var tags = article.ArticleTags.Select(at => at.Tag.Name).ToList();

            //ovde je Tag objekat ocitan
            var articleTags = _articleRepository.GetArticleTagsForArticleId((long)id);
            var tags = articleTags.Select(at => at.Tag.Name).ToList();


            ViewData["Tags"] = new SelectList(tags, "Id");

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            var model = _articleFactory.CreateArticleViewModelWithDefaultValues();
            ViewData["Category"] = new SelectList(_context.Categories, "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public ActionResult Create([Bind("Id,Title,Content,IsDraft,PublishStartDate,PublishEndDate,SefName,Category,Tags")] CreateArticleViewModel model)
        {
            try
            {
                //ModelState.Remove("Category.Name");
                //ModelState.Remove("Category.SefName");
                if (ModelState.IsValid)
                {
                    string currentUser = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var article = _articleFactory.CreateArticleFromViewModel_Create(model, currentUser);

                    var id = _articleRepository.Add(article, model.Tags, currentUser);
                    if (article.IsDraft == 0)
                    {
                        //KbVaultLuceneHelper.AddArticleToIndex(article);
                        _lucene.AddArticleToIndex(article);
                    }

                    //vrati se
                    //ShowOperationMessage(UIResources.ArticleCreatePageCreateSuccessMessage);
                }

            }
            catch (Exception ex)
            {
                log.Error(ex);
                ModelState.AddModelError("Exception", ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var article = await _context.Articles
                .Include(a => a.Author)
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

                if (article == null)
                {
                    return NotFound();
                }

                //ovde je Tag objekat ocitan
                var articleTags = _articleRepository.GetArticleTagsForArticleId((long)id);
                var tags = articleTags.Select(at => at.Tag.Name).ToList();

                CreateArticleViewModel model = _articleFactory.CreateArticleViewModel_Edit(article);

                ViewData["Tags"] = new SelectList(model.Tags, "Name");
                //selected value je ok
                ViewData["Category"] = new SelectList(_context.Categories, "Id", "Name");

                return View("Edit", model);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return RedirectToAction("Index", "Error");
            }
        }



        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Title,Content,IsDraft,PublishStartDate,PublishEndDate,SefName,Category,Tags")] CreateArticleViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            try
            {
                //  ModelState.Remove("Category.Name");
                // ModelState.Remove("Category.SefName");
                if (ModelState.IsValid)
                {
                    string currentUser = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (model.PublishEndDate < model.PublishStartDate)
                    {
                        //vrati se
                        ModelState.AddModelError("PublishDate", ErrorMessages.PublishEndDateMustBeGreater);
                    }
                    else
                    {
                        var article = _articleRepository.Get(model.Id);

                        article.Category = _context.Categories.Find(model.Category);
                        article.IsDraft = model.IsDraft ? 1 : 0;
                        article.PublishEndDate = model.PublishEndDate;
                        article.PublishStartDate = model.PublishStartDate;
                        article.Edited = DateTime.Now;
                        article.Title = model.Title;
                        article.Content = model.Content;
                        article.Author = await _userRepository.Get(currentUser);
                        article.SefName = model.SefName;

                        //_articleRepository.Update(article, model.Tags);
                        _articleRepository.Update(article, model.Tags, currentUser);

                        if (article.IsDraft == 0)
                        {
                            _lucene.AddArticleToIndex(article);
                        }
                        else
                        {
                            _lucene.RemoveArticleFromIndex(article);
                        }

                        //vrati se
                        //ShowOperationMessage(UIResources.ArticleCreatePageEditSuccessMessage);

                        var articleTags = _articleRepository.GetArticleTagsForArticleId((long)id);
                        var tags = articleTags.Select(at => at.Tag.Name).ToList();
                        ViewData["Tags"] = new SelectList(tags, "Id");
                        return View("Details", article);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                ModelState.AddModelError("Exception", ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }


        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.Author)
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var article = await _context.Articles.FindAsync(id);

            //*************************************************************
            //stari kod - vrati se

            while (article.Attachments.Count > 0)
            {
                var a = article.Attachments.First();
                attachmentHelper.RemoveLocalAttachmentFile(a);
                _lucene.RemoveAttachmentFromIndex(a);
                article.Attachments.Remove(a);
                /*
                 * Also remove the attachment from db.attachments collection
                 *
                 * http://stackoverflow.com/questions/17723626/entity-framework-remove-vs-deleteobject
                 *
                 * If the relationship is required (the FK doesn't allow NULL values) and the relationship is not
                 * identifying (which means that the foreign key is not part of the child's (composite) primary key)
                 * you have to either add the child to another parent or you have to explicitly delete the child
                 * (with DeleteObject then). If you don't do any of these a referential constraint is
                 * violated and EF will throw an exception when you call SaveChanges -
                 * the infamous "The relationship could not be changed because one or more of the foreign-key properties
                 * is non-nullable" exception or similar.
                 */
                _context.Attachments.Remove(a);
            }

            string currentUser = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            article.AuthorId = currentUser;
            //KbVaultLuceneHelper.RemoveArticleFromIndex(article);
            //*************************************************************




            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(long id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }

    }
}
