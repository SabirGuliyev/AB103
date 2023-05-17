using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaAB103.DAL;
using ProniaAB103.Models;
using ProniaAB103.Utilities.Extensions;

namespace ProniaAB103.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class SlideController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SlideController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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

            if (!slide.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "File tipi uygun deyil");
                return View();
            }
            if (!slide.Photo.CheckFileSize(200))
            {
                ModelState.AddModelError("Photo", "File hecmi 200 kb den boyuk olmamalidir");
                return View();
            }

            slide.Image =await slide.Photo.CreateFileAsync(_env.WebRootPath,"assets/images/website-images") ;

            await _context.AddAsync(slide);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

           
        }



        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Slide existed = await _context.Slides.FirstOrDefaultAsync(s => s.Id == id);

            if (existed == null) return NotFound();

            return View(existed);

        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, Slide slide)
        {
            if (id == null || id < 1) return BadRequest();

            Slide existed = await _context.Slides.FirstOrDefaultAsync(s => s.Id == id);

            if (existed == null) return NotFound();


            if (slide.Photo != null)
            {

                if (!slide.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "File tipi uygun deyil");
                    return View();
                }
                if (!slide.Photo.CheckFileSize(200))
                {
                    ModelState.AddModelError("Photo", "File hecmi 200 kb den boyuk olmamalidir");
                    return View();
                }
                existed.Image.DeleteFile(_env.WebRootPath, "assets/images/website-images");

                existed.Image = await slide.Photo.CreateFileAsync(_env.WebRootPath, "assets/images/website-images");
            }

            existed.Title = slide.Title;
            existed.SubTitle=slide.SubTitle;
            existed.Description = slide.Description;
            existed.Order=slide.Order;

            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
            
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Slide slide=await _context.Slides.FirstOrDefaultAsync(s=>s.Id==id);

            if (slide == null) return NotFound();

            slide.Image.DeleteFile(_env.WebRootPath, "assets/images/website-images");

            _context.Slides.Remove(slide);
            await _context.SaveChangesAsync();

             return RedirectToAction(nameof(Index));    

           
        }
    }
}
