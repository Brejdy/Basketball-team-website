using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspBlog.Data;
using AspBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AspBlog.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CommentsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> AddComment (int? newsId, int? gamesId, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return BadRequest("Komentář nesmí být prázdný");
            }

            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Unauthorized();
            }

            var comment = new Comments
            {
                UserId = user.Id,
                UserName = user.UserName,
                Content = content,
                NewsId = newsId,
                GameId = gamesId
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();

            return RedirectToAction("Details", newsId.HasValue ? "Page" : "Games", new { id = newsId ?? gamesId });
        }

        [Authorize]
        public async Task<IActionResult> EditComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            if (comment.UserId != _userManager.GetUserId(User))
            {
                return Forbid();
            }

            return View(comment);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditComment(int id, string content)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            if (comment.UserId != _userManager.GetUserId(User))
            {
                return Forbid();
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                return BadRequest("Komentář nemůže být prázdný");
            }

            comment.Content = content;
            _context.Update(comment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Game", new { id = comment.GameId ?? comment.NewsId });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            
            if (comment.UserId != _userManager.GetUserId(User) && !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Game", new { id = comment.GameId ?? comment.NewsId });
        }
    }
}
