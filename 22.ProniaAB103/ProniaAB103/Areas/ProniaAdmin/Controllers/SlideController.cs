using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaAB103.DAL;
using ProniaAB103.Models;

namespace ProniaAB103.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class SlideController : Controller
    {
        private readonly AppDbContext _context;

        public SlideController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Slide> slides = await _context.Slides.ToListAsync();

            return View(slides);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Slide slide)
        {
            if (slide.Photo == null)
            {
                ModelState.AddModelError("Photo", "Shekil bosh ola bilmez");
                return View();
            }

            if (!slide.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "File tipi uygun deyil");
                return View();
            }
            if (slide.Photo.Length>200*1024)
            {
                ModelState.AddModelError("Photo", "File hecmi 200 kb den boyuk olmamalidir");
                return View();
            }

            FileStream stream = new FileStream(@"C:\Users\sabir\Desktop\AB103 git\22.ProniaAB103\ProniaAB103\wwwroot\assets\images\website-images\" + slide.Photo.FileName,FileMode.Create);
            await slide.Photo.CopyToAsync(stream);

            slide.Image = slide.Photo.FileName;


            return Content(slide.Photo.Length+" "+ slide.Photo.ContentType+" "+slide.Photo.FileName);
        }
    }
}
