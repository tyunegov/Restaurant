using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models.Menu
{
    public class TypeMenu
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [UIHint("Collection")]
        public IEnumerable<CategoryMenu> Categories { get; set; }
    }
}