using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaAB103.DAL;
using ProniaAB103.Models;
using ProniaAB103.ViewModels;

namespace ProniaAB103.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            #region AddToDataBase
            //_context.Slides.Add(slide);
            //_context.Slides.AddRange(slides);
            //_context.SaveChanges();  

            //_context.Products.AddRange(products);
            //_context.SaveChanges();
            #endregion


            List<Slide> slides=_context.Slides.OrderBy(s=>s.Order).Take(3).ToList();

            List<Product> products = _context.Products.Include(p=>p.Category).ToList();

            HomeVM homeVM = new HomeVM
            {
                Sliders = slides,
                Products=products
            };

            return View(homeVM);
        }
         

        public IActionResult Details(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Product product = _context.Products.Include(p=>p.Category).FirstOrDefault(p=>p.Id==id);

            if(product==null) return NotFound();

            return View(product);
        }
        public IActionResult About()
        {
            return View();
        }

    }
}
