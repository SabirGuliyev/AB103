using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProniaAB103.DAL;
using ProniaAB103.Models;
using ProniaAB103.ViewModels;

namespace ProniaAB103.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _http;

        public LayoutService(AppDbContext context,IHttpContextAccessor http)
        {
            _context = context;
            _http = http;
        }
        public async Task<Dictionary<string,string>> GetSettingsAsync()
        {
            Dictionary<string,string> settings = await _context.Settings.ToDictionaryAsync(s=>s.Key,s=>s.Value);

            return settings;
        }

        public async Task<List<BasketItemVM>> GetBasket()
        {
            List<BasketItemVM> basketItemsVM = new List<BasketItemVM>();
            if (_http.HttpContext.Request.Cookies["Basket"] != null)
            {
                List<BasketCookiesItemVM> basket = JsonConvert.DeserializeObject<List<BasketCookiesItemVM>>(_http.HttpContext.Request.Cookies["Basket"]);

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
            return basketItemsVM;
        }
     }
}
