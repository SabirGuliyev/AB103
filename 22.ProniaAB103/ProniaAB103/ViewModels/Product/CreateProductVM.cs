﻿using System.ComponentModel.DataAnnotations;

namespace ProniaAB103.ViewModels
{
    public class CreateProductVM
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }


        public int CategoryId { get; set; }

        [Required]
        public IFormFile MainPhoto { get; set; }
        [Required]
        public IFormFile HoverPhoto { get; set; }

        public List<IFormFile> Photos { get; set; }

        public List<int> TagIds { get; set; }
    }
}
