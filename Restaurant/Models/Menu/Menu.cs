using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models.Menu
{
    public class Menu
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        [Display(Name = "Количество")]
        public double Count { get; set; }
        [Display(Name = "Единицы измерения")]
        public string Unit { get{ return "гр."; } }
        public int CategoryId { get; set; }
        [Display(Name = "Категория")]
        [UIHint("Collection")]
        public CategoryMenu Category { get; set; }
    }
}
