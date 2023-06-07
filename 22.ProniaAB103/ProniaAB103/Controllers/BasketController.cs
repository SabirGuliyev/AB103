using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProniaAB103.DAL;
using ProniaAB103.Models;
using ProniaAB103.ViewModels;

namespace ProniaAB103.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public BasketController(AppDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
           
            List<BasketItemVM> basketItemsVM = new List<BasketItemVM>();

            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user == null) return NotFound();

                List<BasketItem> basketItems = await _context.BasketItems
                    .Where(b => b.AppUserId == user.Id)
                    .Include(b=>b.Product)
                    .ThenInclude(p=>p.ProductImages.Where(pi=>pi.IsPrimary==true)).ToListAsync();

                foreach (BasketItem item in basketItems)
                {
                    basketItemsVM.Add(new BasketItemVM
                    {
                        Count = item.Count,
                        Price = item.Price,
                        Image = item.Product.ProductImages[0].Image,
                        Name = item.Product.Name
                    });
                }

            }
            else
            {
                if (Request.Cookies["Basket"] != null)
                {
                    List<BasketCookiesItemVM> basket = JsonConvert.DeserializeObject<List<BasketCookiesItemVM>>(Request.Cookies["Basket"]);

                    for (int i = 0; i < basket.Count; i++)
                    {
                        Product product = await _context.Products
                            .Include(p => p.ProductImages.Where(pi => pi.IsPrimary == true))
                            .FirstOrDefaultAsync(p => p.Id == basket[i].Id);

                        if (product != null)
                        {
                            basketItemsVM.Add(new BasketItemVM
                            {
                                Name = product.Name,
                                Price = product.Price,
                                Count = basket[i].Count,
                                Image = product.ProductImages[0].Image
                            });
                        }
                        else
                        {
                            basket.Remove(basket[i]);
                        }

                    }
                }
            }

           
            return View(basketItemsVM);
        }
        public async Task<IActionResult> AddBasket(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            if (User.Identity.IsAuthenticated)
            {
               AppUser user=await _userManager.FindByNameAsync(User.Identity.Name);
               if (user == null) return NotFound();

               BasketItem existed=await _context.BasketItems.FirstOrDefaultAsync(b=>b.ProductId==id&&b.AppUserId==user.Id);
                if (existed!=null)
                {
                    existed.Count++;
                }
                else
                {
                    existed= new BasketItem
                    {
                        AppUserId = user.Id,
                        ProductId = product.Id,
                        Price = product.Price,
                        Count = 1
                    };
                    await _context.BasketItems.AddAsync(existed);
                }
                await _context.SaveChangesAsync();
            }
            else
            {

                List<BasketCookiesItemVM> basket;

                if (Request.Cookies["Basket"] == null)
                {
                    basket = new List<BasketCookiesItemVM>();
                    basket.Add(new BasketCookiesItemVM
                    {
                        Id = product.Id,
                        Count = 1
                    });
                }
                else
                {

                    basket = JsonConvert.DeserializeObject<List<BasketCookiesItemVM>>(Request.Cookies["Basket"]);

                    BasketCookiesItemVM existed = basket.FirstOrDefault(b => b.Id == product.Id);

                    if (existed != null)
                    {
                        existed.Count++;
                    }
                    else
                    {
                        basket.Add(new BasketCookiesItemVM
                        {
                            Id = product.Id,
                            Count = 1
                        });
                    }

                }


                string json = JsonConvert.SerializeObject(basket);

                Response.Cookies.Append("Basket", json);

            }



            return RedirectToAction("Index","Home");

        }


        public IActionResult GetBasket() 
        {
            List<BasketCookiesItemVM> basket = JsonConvert.DeserializeObject<List<BasketCookiesItemVM>>(Request.Cookies["Basket"]);


            return Json(basket);
        }
    }
}
