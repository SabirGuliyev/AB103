using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaAB103.DAL;
using ProniaAB103.Interfaces;
using ProniaAB103.Models;
using ProniaAB103.Services;
using ProniaAB103.ViewModels;

namespace ProniaAB103.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;

        public HomeController(AppDbContext context,UserManager<AppUser> userManager,IEmailService emailService)
        {
            _context = context;
            _userManager = userManager;
            _emailService = emailService;
        }
        public async Task<IActionResult> Index()
        {
           


            #region AddToDataBase
            //_context.Slides.Add(slide);
            //_context.Slides.AddRange(slides);
            //_context.SaveChanges();  

            //_context.Products.AddRange(products);
            //_context.SaveChanges();
            #endregion


            
            List<Slide> slides = _context.Slides.OrderBy(s => s.Order).Take(3).ToList();

            List<Product> products = _context.Products.Include(p => p.Category).Include(p => p.ProductImages).ToList();
            //ctrl+k+s
         
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

        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Items=await _context.BasketItems
                .Where(b=>b.AppUserId==user.Id&&b.OrderId==null)
                .Include(b=>b.Product)
                .ToListAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(OrderVM orderVM)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            List<BasketItem> items = await _context.BasketItems
               .Where(b => b.AppUserId == user.Id && b.OrderId == null)
               .Include(b => b.Product)
               .ToListAsync();

            if (!ModelState.IsValid)
            {
                ViewBag.Items = items;
                return View();
            }

            decimal total=0;
            foreach (var item in items)
            {
                total += item.Count * item.Price;
            }
            Order order = new Order
            {
                Address = orderVM.Address,
                Status = null,
                AppUserId = user.Id,
                PurchasedAt = DateTime.Now,
                TotalPrice = total,
                BasketItems = items
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            string body = @"<table>
                           <thead>
                               <tr>
                                   <th>Product</th>
                                   <th>Count</th>
                                   <th>Price</th>
                       
                               </tr>
                           </thead>
                           <tbody>";

            foreach (var item in items)
            {
                body += @$"     <tr>
                                   <td>{item.Product.Name}</td>
                                   <td>{item.Count}</td>
                                   <td>{item.Price}</td>
                               </tr>";
            }
            body += @"</tbody>
                       </table>";

           await _emailService.SendMail(user.Email, "Order Placement", body, true);

            return RedirectToAction(nameof(Index));
           
        }
    }
}
