using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaAB103.DAL;
using ProniaAB103.Models;
using ProniaAB103.Utilities.Extensions;
using ProniaAB103.ViewModels;

namespace ProniaAB103.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    [AutoValidateAntiforgeryToken]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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
                ProductTags = new List<ProductTag>(),
                ProductImages=new List<ProductImage>()

            };
            if (productVM.TagIds is null)
            {
                ViewBag.Categories = await _context.Categories.ToListAsync();
                ViewBag.Tags = await _context.Tags.ToListAsync();
                ModelState.AddModelError("TagIds", "En azi 1 tag secin");
                return View();
            }
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


            if (!productVM.MainPhoto.CheckFileType("image/"))
            {
                ViewBag.Categories = await _context.Categories.ToListAsync();
                ViewBag.Tags = await _context.Tags.ToListAsync();
                ModelState.AddModelError("MainPhoto", "File novu uygun deyil");
                return View();
            }
            if (!productVM.MainPhoto.CheckFileSize(200))
            {
                ViewBag.Categories = await _context.Categories.ToListAsync();
                ViewBag.Tags = await _context.Tags.ToListAsync();
                ModelState.AddModelError("MainPhoto", "File olcusu uygun deyil");
                return View();
            }
            if (!productVM.HoverPhoto.CheckFileType("image/"))
            {
                ViewBag.Categories = await _context.Categories.ToListAsync();
                ViewBag.Tags = await _context.Tags.ToListAsync();
                ModelState.AddModelError("HoverPhoto", "File novu uygun deyil");
                return View();
            }
            if (!productVM.HoverPhoto.CheckFileSize(200))
            {
                ViewBag.Categories = await _context.Categories.ToListAsync();
                ViewBag.Tags = await _context.Tags.ToListAsync();
                ModelState.AddModelError("HoverPhoto", "File olcusu uygun deyil");
                return View();
            }
            ProductImage mainImage = new ProductImage
            {
                Product = product,
                Image = await productVM.MainPhoto.CreateFileAsync(_env.WebRootPath, "assets/images/website-images"),
                IsPrimary=true
            };
            ProductImage hoverImage = new ProductImage
            {
                Product = product,
                Image = await productVM.HoverPhoto.CreateFileAsync(_env.WebRootPath, "assets/images/website-images"),
                IsPrimary = false
            };
            product.ProductImages.Add(mainImage);
            product.ProductImages.Add(hoverImage);

            TempData["FileWarning"] = "";
            foreach (IFormFile photo in productVM.Photos)
            {
                if (!photo.CheckFileType("image/"))
                {
                    TempData["FileWarning"] += $"{photo.FileName} adli file tipi uygun deyil\n";
                    continue;
                }
                if (!photo.CheckFileSize(200))
                {
                    TempData["FileWarning"] += $"{photo.FileName} adli file olcusu uygun deyil\n";
                    continue;
                }
                ProductImage addImage = new ProductImage
                {
                    Image = await photo.CreateFileAsync(_env.WebRootPath, "assets/images/website-images"),
                    Product = product,
                    IsPrimary = null
                };
                product.ProductImages.Add(addImage);
            }


            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));  
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id <= 0) return BadRequest();
            Product product = await _context.Products.Where(p=>p.Id==id).Include(p=>p.ProductTags).Include(p=>p.ProductImages).FirstOrDefaultAsync();
            if (product is null) return NotFound();

            UpdateProductVM productVM = new UpdateProductVM
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Sku = product.Sku,
                TagIds = product.ProductTags.Select(pt=>pt.TagId).ToList(),
                ProductImageVMs=new List<ProductImageVM>()
            };

            productVM = MapImages(productVM, product);
          
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();

            return View(productVM);   
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id,UpdateProductVM productVM)
        {
            if (id is null || id <= 0) return BadRequest();
            Product existed = await _context.Products.Where(p => p.Id == id).Include(p => p.ProductTags).Include(p=>p.ProductImages).FirstOrDefaultAsync();
            if (existed is null) return NotFound();

            if (!await _context.Categories.AnyAsync(c=>c.Id==productVM.CategoryId))
            {
                ViewBag.Categories = await _context.Categories.ToListAsync();
                ViewBag.Tags = await _context.Tags.ToListAsync();

                ModelState.AddModelError("CategoryId","Bele category movcud deyil");
                productVM = MapImages(productVM, existed);
                return View(productVM);
            }

            existed.CategoryId=productVM.CategoryId;
            existed.Name = productVM.Name;
            existed.Description = productVM.Description;
            existed.Price = productVM.Price;
            existed.Sku = productVM.Sku;

            List<int> createList = productVM.TagIds.Where(tId=>!existed.ProductTags.Exists(pt=>pt.TagId==tId)).ToList();

            foreach (int tagId in createList)
            {
                bool tagResult = await _context.Tags.AnyAsync(t=>t.Id==tagId);
                if (!tagResult)
                {
                    ViewBag.Categories = await _context.Categories.ToListAsync();
                    ViewBag.Tags = await _context.Tags.ToListAsync();

                    ModelState.AddModelError("TagIds", "Secilen tag sistemde tapilmadi");
                    productVM = MapImages(productVM, existed);
                    return View(productVM);
                }
                ProductTag productTag=new ProductTag
                {
                    TagId = tagId,
                    ProductId=existed.Id
                };
                existed.ProductTags.Add(productTag); 
            }
            if (productVM.MainPhoto!=null)
            {
                if (!productVM.MainPhoto.CheckFileType("image/"))
                {
                    ViewBag.Categories = await _context.Categories.ToListAsync();
                    ViewBag.Tags = await _context.Tags.ToListAsync();
                    ModelState.AddModelError("MainPhoto","File tipi uygun deyil");
                    productVM = MapImages(productVM, existed);
                    return View(productVM);
                }
                if (!productVM.MainPhoto.CheckFileSize(200))
                {
                    ViewBag.Categories = await _context.Categories.ToListAsync();
                    ViewBag.Tags = await _context.Tags.ToListAsync();
                    ModelState.AddModelError("MainPhoto", "File olcusu uygun deyil");
                    productVM = MapImages(productVM, existed);
                    return View(productVM);
                }
                var mainImage = existed.ProductImages.FirstOrDefault(pi => pi.IsPrimary == true);
                mainImage.Image.DeleteFile(_env.WebRootPath, "assets/images/website-images");
                existed.ProductImages.Remove(mainImage);
                ProductImage mainNewImage = new ProductImage
                {
                    Image = await productVM.MainPhoto.CreateFileAsync(_env.WebRootPath, "assets/images/website-images"),
                    ProductId = existed.Id,
                    IsPrimary = true
                };
                existed.ProductImages.Add(mainNewImage);

            }
            if (productVM.HoverPhoto != null)
            {
                if (!productVM.HoverPhoto.CheckFileType("image/"))
                {
                    ViewBag.Categories = await _context.Categories.ToListAsync();
                    ViewBag.Tags = await _context.Tags.ToListAsync();
                    ModelState.AddModelError("HoverPhoto", "File tipi uygun deyil");
                    productVM = MapImages(productVM, existed);
                    return View(productVM);
                }
                if (!productVM.HoverPhoto.CheckFileSize(200))
                {
                    ViewBag.Categories = await _context.Categories.ToListAsync();
                    ViewBag.Tags = await _context.Tags.ToListAsync();
                    ModelState.AddModelError("HoverPhoto", "File olcusu uygun deyil");
                    productVM = MapImages(productVM, existed);
                    return View(productVM);
                }
                var hoverImage = existed.ProductImages.FirstOrDefault(pi => pi.IsPrimary == false);
                hoverImage.Image.DeleteFile(_env.WebRootPath, "assets/images/website-images");
                existed.ProductImages.Remove(hoverImage);

                ProductImage hoverNewImage = new ProductImage
                {
                    Image = await productVM.HoverPhoto.CreateFileAsync(_env.WebRootPath, "assets/images/website-images"),
                    ProductId = existed.Id,
                    IsPrimary = false
                };
                existed.ProductImages.Add(hoverNewImage);
            }
            List<ProductImage> removeImageList;
            if (productVM.ImageIds==null)
            {
                removeImageList = existed.ProductImages.Where(pi => pi.IsPrimary == null).ToList();
            }
            else
            {
                removeImageList = existed.ProductImages.Where(pi => !productVM.ImageIds.Contains(pi.Id) && pi.IsPrimary == null).ToList();
            }
            foreach (ProductImage removeImage in removeImageList)
            {
                removeImage.Image.DeleteFile(_env.WebRootPath, "assets/images/website-images");
                existed.ProductImages.Remove(removeImage);
            }

            if (productVM.Photos!=null)
            {
                TempData["FileWarning"] = "";
                foreach (IFormFile photo in productVM.Photos)
                {
                    if (!photo.CheckFileType("image/"))
                    {
                        TempData["FileWarning"] += $"{photo.FileName} adli file tipi uygun deyil\n";
                        continue;
                    }
                    if (!photo.CheckFileSize(200))
                    {
                        TempData["FileWarning"] += $"{photo.FileName} adli file olcusu uygun deyil\n";
                        continue;
                    }
                    ProductImage addImage = new ProductImage
                    {
                        Image = await photo.CreateFileAsync(_env.WebRootPath, "assets/images/website-images"),
                        Product = existed,
                        IsPrimary = null
                    };
                    existed.ProductImages.Add(addImage);
                }
            }

            List<ProductTag> deleteList = existed.ProductTags.Where(pt=>!productVM.TagIds.Any(t=>t==pt.TagId)).ToList();
            _context.ProductTags.RemoveRange(deleteList);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        public UpdateProductVM MapImages(UpdateProductVM productVM,Product product)
        {
            productVM.ProductImageVMs = new List<ProductImageVM>();
            foreach (ProductImage image in product.ProductImages)
            {
                ProductImageVM imageVM = new ProductImageVM
                {
                    Id = image.Id,
                    Image = image.Image,
                    IsPrimary = image.IsPrimary
                };
                productVM.ProductImageVMs.Add(imageVM);
            }
            return productVM;

        }

    }
}
