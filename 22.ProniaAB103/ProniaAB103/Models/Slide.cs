﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProniaAB103.Models
{
    public class Slide:BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string SubTitle { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int Order { get; set; }


    }
}
