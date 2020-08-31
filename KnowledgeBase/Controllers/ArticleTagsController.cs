using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KnowledgeBase.Data;
using KnowledgeBase.Models;

namespace KnowledgeBase.Controllers
{
    public class ArticleTagsController : Controller
    {
        private readonly KnowledgeBaseContext _context;

        public ArticleTagsController(KnowledgeBaseContext context)
        {
            _context = context;
        }

        // GET: ArticleTags
        public async Task<IActionResult> Index()
        {
            var knowledgeBaseContext = _context.ArticleTags.Include(a => a.Article).Include(a => a.Author).Include(a => a.Tag);
            return View(await knowledgeBaseContext.ToListAsync());
        }

        // GET: ArticleTags/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleTag = await _context.ArticleTags
                .Include(a => a.Article)
                .Include(a => a.Author)
                .Include(a => a.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articleTag == null)
            {
                return NotFound();
            }

            return View(articleTag);
        }

        // GET: ArticleTags/Create
        public IActionResult Create()
        {
            ViewData["ArticleId"] = new SelectList(_context.Articles, "Id", "SefName");
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Name");
            return View();
        }

        // POST: ArticleTags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TagId,ArticleId,AuthorId")] ArticleTag articleTag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articleTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticleId"] = new SelectList(_context.Articles, "Id", "SefName", articleTag.ArticleId);
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id", articleTag.AuthorId);
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Name", articleTag.TagId);
            return View(articleTag);
        }

        // GET: ArticleTags/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleTag = await _context.ArticleTags.FindAsync(id);
            if (articleTag == null)
            {
                return NotFound();
            }
            ViewData["ArticleId"] = new SelectList(_context.Articles, "Id", "SefName", articleTag.ArticleId);
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id", articleTag.AuthorId);
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Name", articleTag.TagId);
            return View(articleTag);
        }

        // POST: ArticleTags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,TagId,ArticleId,AuthorId")] ArticleTag articleTag)
        {
            if (id != articleTag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articleTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleTagExists(articleTag.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticleId"] = new SelectList(_context.Articles, "Id", "SefName", articleTag.ArticleId);
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id", articleTag.AuthorId);
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Name", articleTag.TagId);
            return View(articleTag);
        }

        // GET: ArticleTags/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleTag = await _context.ArticleTags
                .Include(a => a.Article)
                .Include(a => a.Author)
                .Include(a => a.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articleTag == null)
            {
                return NotFound();
            }

            return View(articleTag);
        }

        // POST: ArticleTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var articleTag = await _context.ArticleTags.FindAsync(id);
            _context.ArticleTags.Remove(articleTag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleTagExists(long id)
        {
            return _context.ArticleTags.Any(e => e.Id == id);
        }
    }
}
