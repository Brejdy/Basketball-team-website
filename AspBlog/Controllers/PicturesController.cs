using AspBlog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspBlog.Controllers
{
    public class PicturesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public PicturesController (ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(int? pageContentId, int? gameId, List<IFormFile> files)
        {
            // DEBUG: Ověříme, kolik souborů se odeslalo
            if (files == null)
                return BadRequest("Seznam souborů je null!");

            if (files.Count == 0)
                return BadRequest("Žádné soubory nebyly vybrány!");

            string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            List<Models.Pictures> pictures = new List<Models.Pictures>();
            foreach (var file in files)
            {
                if(file.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    pictures.Add(new Models.Pictures
                    {
                        FilePath = "/uploads/" + uniqueFileName,
                        PageContentId = pageContentId,
                        GameId = gameId
                    });
                }
            }

            _context.Pictures.AddRange(pictures);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", pageContentId.HasValue ? "Page" : "Games", new { id = pageContentId ?? gameId });
        }

        [HttpGet]
        public async Task<IActionResult> GetPictureForPage(int id)
        {
            var pictures = await _context.Pictures.Where(p => p.PageContentId == id).ToListAsync();

            return View(pictures);
        }

        [HttpGet]
        public async Task<IActionResult> GetPictureForGame(int id)
        {
            var pictures = await _context.Pictures.Where(p => p.GameId == id).ToListAsync();

            return View(pictures);
        }
    }
}
