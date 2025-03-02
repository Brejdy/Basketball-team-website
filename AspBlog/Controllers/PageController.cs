using AspBlog.Data;
using AspBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspBlog.Controllers
{
    public class PageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PageController (ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult About()
        {
            var contentList = _context.PageContent.ToList();
            return View(contentList);
        }
        public IActionResult News()
        {
            var contentList = _context.PageContent.AsQueryable();
            contentList = contentList.OrderByDescending(x => x.Date);
            return View(contentList);
        }
        public IActionResult Recruit()
        {
            var contentList = _context.PageContent.ToList();
            return View(contentList);
        }
        public IActionResult Matches()
        {
            var contentList = _context.PageContent.ToList();
            return View(contentList);
        }
        public IActionResult Practices()
        {
            var contentList = _context.PageContent.ToList();
            return View(contentList);
        }
        public IActionResult Contact()
        {
            var contentList = _context.PageContent.ToList();
            return View(contentList);
        }

        public IActionResult Edit(int id)
        {
            var content = _context.PageContent.Find(id);
            return View(content);
        }

        [HttpPost]
        public IActionResult Edit(PageContent pageContent, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            _context.Update(pageContent);
            _context.SaveChanges();
            return RedirectToAction(returnUrl);
        }

        public IActionResult Create()
        {
            return View(new PageContent());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PageContent model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                _context.PageContent.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(returnUrl);
            }
            return View(model);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.PageContent
                .Include(p => p.Commentars)
                .Include(p => p.Pictures).AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.PageContent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.PageContent.FindAsync(id);
            if (article != null)
            {
                _context.PageContent.Remove(article);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("News", "Page");
        }
    }
}
