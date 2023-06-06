namespace ProniaAB103.ViewModels
{
    public class UpdateProductVM
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }

        public int CategoryId { get; set; }
        public List<int> TagIds { get; set; }
        public List<int> ImageIds { get; set; }
        public IFormFile MainPhoto { get; set; }
        public IFormFile HoverPhoto { get; set; }

        public List<IFormFile> Photos { get; set; }
        public List<ProductImageVM> ProductImageVMs { get; set; }

    }

    public class ProductImageVM
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public bool? IsPrimary { get; set; }

    }
}
