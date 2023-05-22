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

            List<Product> products = _context.Products.Include(p=>p.Category).Include(p=>p.ProductImages).ToList();

            HomeVM homeVM = new HomeVM
            {
                Sliders = slides,
                Products=products
            };

            return View(homeVM);
        }
        
        //public IActionResult GetData()
        //{
           
        //    return Content(Request.Cookies["Name"].Length+" "+HttpContext.Session.GetString("Surname"));
        //}

        public IActionResult Details(int? id)
        {
        //    HttpContext.Session.SetString("Surname", "Quliyev");

        //    Response.Cookies.Append("Name", "Nahid", new CookieOptions
        //    {
        //        MaxAge = TimeSpan.FromMinutes(10)
        //    }); 
            if (id == null || id < 1) return BadRequest();

            Product product = _context.Products
                .Include(p=>p.Category)
                .Include(p=>p.ProductImages)
                .Include(p => p.ProductTags).ThenInclude(pt => pt.Tag)
                .FirstOrDefault(p=>p.Id==id);

            if (product == null) return NotFound();


            List<Product> products = _context.Products.Include(p=>p.ProductImages).Where(p => p.CategoryId == product.CategoryId&&p.Id!=product.Id).ToList();
          

            DetailsVM detailsVM = new DetailsVM
            {
                Product = product,
                Products = products
            };

            return View(detailsVM);
        }
        public IActionResult About()
        {
            return View();
        }

    }
}
