using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;

        public LayoutService(AppDbContext context,IHttpContextAccessor http,UserManager<AppUser> userManager)
        {
            _context = context;
            _http = http;
            _userManager = userManager;
        }
        public async Task<Dictionary<string,string>> GetSettingsAsync()
        {
            Dictionary<string,string> settings = await _context.Settings.ToDictionaryAsync(s=>s.Key,s=>s.Value);

            return settings;
        }

        public async Task<List<BasketItemVM>> GetBasket()
        {
            List<BasketItemVM> basketItemsVM = new List<BasketItemVM>();


            if (_http.HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(_http.HttpContext.User.Identity.Name);
                if (user == null) throw new Exception("nese o deyile");

                List<BasketItem> basketItems = await _context.BasketItems
                    .Where(b => b.AppUserId == user.Id)
                    .Include(b => b.Product)
                    .ThenInclude(p => p.ProductImages.Where(pi => pi.IsPrimary == true)).ToListAsync();

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
            }
           
            return basketItemsVM;
        }
     }
}
