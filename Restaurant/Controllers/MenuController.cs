using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models.Menu;
using Restaurant.ModelView;

namespace Restaurant.Controllers
{
    public class MenuController : Controller
    {
        IRepositoryMenu repository;

        public MenuController(IRepositoryMenu repository)
        {
            this.repository = repository;
        }
        public ActionResult Index(int Type = 1)
        {
            GetCategories();
            GetTypes();
            return View();
        }

        public ActionResult GetCategories(int TypeId = 1)
        {
            IEnumerable<CategoryMenu> categories = repository.GetCategoriesFortypeId(TypeId);

            ViewBag.Categories = categories;
            return View();
        }

        public ActionResult GetMenu(int? CategoryId)
        {
            if (CategoryId == null) return View(repository.Menu);
            return View(repository.GetMenuForCategoryId(CategoryId));
        }

        public ActionResult GetTypes()
        {
            ViewBag.Types = repository.Types;
            return View();
        }
    }
}
