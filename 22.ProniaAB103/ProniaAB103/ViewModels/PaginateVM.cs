﻿using ProniaAB103.Models;

namespace ProniaAB103.ViewModels
{
    public class PaginateVM<T>
    {
        public List<T> Items { get; set; }
        public decimal CurrentPage { get; set; }
        public decimal TotalPage { get; set; }
    }
}
