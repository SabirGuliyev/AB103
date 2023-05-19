using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaAB103.DAL;
using ProniaAB103.Models;

namespace ProniaAB103.ViewComponents
{
    public class ProductViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public ProductViewComponent(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IViewComponentResult>InvokeAsync(int key)
        {

            List<Product> products = await _context.Products.Include(p => p.ProductImages).ToListAsync();

            return View(products);

            //return View(Task.FromResult(products));
        }
    }
}
