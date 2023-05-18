﻿namespace ProniaAB103.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<ProductImage> ProductImages { get; set; }

        public List<ProductTag> ProductTags { get; set; }
        public List<ProductColor> ProductColors { get; set; }
    }
}
