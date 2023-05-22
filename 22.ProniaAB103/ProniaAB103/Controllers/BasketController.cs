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

        public BasketController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
           
            List<BasketItemVM> basketItemsVM = new List<BasketItemVM>();

            if (Request.Cookies["Basket"]!=null)
            {
                List<BasketCookiesItemVM> basket = JsonConvert.DeserializeObject<List<BasketCookiesItemVM>>(Request.Cookies["Basket"]);

                for (int i = 0; i < basket.Count; i++)
                {
                    Product product = await _context.Products
                        .Include(p=>p.ProductImages.Where(pi=>pi.IsPrimary==true))
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
            return View(basketItemsVM);
        }
        public async Task<IActionResult> AddBasket(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();


            List<BasketCookiesItemVM> basket;

            if (Request.Cookies["Basket"]==null)
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

                basket= JsonConvert.DeserializeObject<List<BasketCookiesItemVM>>(Request.Cookies["Basket"]);

                BasketCookiesItemVM existed=basket.FirstOrDefault(b=>b.Id==product.Id);

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

            Response.Cookies.Append("Basket",json);

            return RedirectToAction("Index","Home");

        }


        public IActionResult GetBasket() 
        {
            List<BasketCookiesItemVM> basket = JsonConvert.DeserializeObject<List<BasketCookiesItemVM>>(Request.Cookies["Basket"]);


            return Json(basket);
        }
    }
}
