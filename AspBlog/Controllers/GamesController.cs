using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspBlog.Data;
using AspBlog.Models;
using Microsoft.AspNetCore.Authorization;

namespace AspBlog.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }


        [AllowAnonymous]
        public IActionResult Index(string category)
        {
            var games = _context.Games.AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                games = games.Where(g => g.Cathegory == category);
            }

            games = games.OrderBy(g => g.DateOfGame);

            return View(games.ToList());
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Games
                .Include(g => g.Commentars)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Games article)
        {
            if (ModelState.IsValid)
            {
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Games.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Games article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
       
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Games
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
            var article = await _context.Games.FindAsync(id);
            if (article != null)
            {
                _context.Games.Remove(article);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
