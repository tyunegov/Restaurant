using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models.Menu
{
    public class CategoryMenu
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        public int TypeId { get; set; }
        [Display(Name = "Категория")]
        public IEnumerable<Menu> Menu { get; set; }
        [Display(Name = "Раздел")]
        [UIHint("Collection")]
        public TypeMenu Type { get; set; }
    }
}
