using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaAB103.DAL;
using ProniaAB103.Models;
using ProniaAB103.ViewModels;

namespace ProniaAB103.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    [AutoValidateAntiforgeryToken]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Include(p => p.ProductImages
                .Where(pi => pi.IsPrimary == true))
                .Include(p => p.Category)
                .Include(p => p.ProductTags)
                .ThenInclude(pt=>pt.Tag)
                .ToListAsync();

            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Tags=await _context.Tags.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM productVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _context.Categories.ToListAsync();
                ViewBag.Tags = await _context.Tags.ToListAsync();
                return View();
            }

            bool result = await _context.Categories.AnyAsync(c => c.Id == productVM.CategoryId);
            if (!result)
            {
                ViewBag.Categories = await _context.Categories.ToListAsync();
                ViewBag.Tags = await _context.Tags.ToListAsync();
                ModelState.AddModelError("CategoryId", $"Bele Category movcud deyil");
                return View();
            }

            Product product = new Product
            {
                Name = productVM.Name,
                Price = productVM.Price,
                Description = productVM.Description,
                Sku = productVM.Sku,
                CategoryId = productVM.CategoryId,
                ProductTags=new List<ProductTag>()

            };

            foreach (int tagId in productVM.TagIds)
            {
                bool tagResult = await _context.Tags.AnyAsync(t => t.Id == tagId);
                if (!result)
                {
                    ViewBag.Categories = await _context.Categories.ToListAsync();
                    ViewBag.Tags = await _context.Tags.ToListAsync();
                    ModelState.AddModelError("TagIds", $"Bele Tag movcud deyil");
                    return View();
                }
                ProductTag productTag = new ProductTag
                {
                    TagId = tagId,
                    Product = product
                };

              product.ProductTags.Add(productTag);
            }

        
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));  
        }
    }
}
