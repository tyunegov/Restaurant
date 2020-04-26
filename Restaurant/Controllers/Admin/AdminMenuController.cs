using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Menu;
using Restaurant.ModelView;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Restaurant.Controllers.Admin
{
    [Authorize]
    public class AdminMenuController : Controller
    {
        IRepositoryMenu repository;
        public AdminMenuController(IRepositoryMenu repository)
        {
            this.repository = repository;
        }

        [Route("Admin/Index")]
        [Route("Admin/Menu")]
        public IActionResult Types()
        {
                return View(repository.Types);
        }

        [Route("Menu/Edit")]
        public IActionResult EditMenu(int? id)
        {
            if (id == null) return NotFound();
            Menu menu = repository.GetMenu(id.Value);
            ViewBag.Categories = new SelectList(repository.Categories, "Id", "Name", menu.CategoryId);
            return View(menu);
        }


        [HttpPost]
        [Route("Menu/Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditMenu(int id, [Bind("Id,Name,Description,Price,Count, Unit, CategoryId")] Menu menu)
        {
            if (id != menu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                repository.EditMenu(id, menu);
                return RedirectToAction(nameof(Menu));
            }
            return View(menu);
        }

        [HttpPost]
        [Route("Category/Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory(int id, [Bind("Id,Name, ")] CategoryMenu category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                repository.EditCategory(id, category);
                return RedirectToAction(nameof(Menu));
            }
            return View(category);
        }

        [Route("Category/Edit")]
        public ActionResult EditCategory(int? id)
        {
            if (id == null) return NotFound();
            CategoryMenu category = repository.GetCategory(id.Value);
            ViewBag.Types = new SelectList(repository.Types, "Id", "Name", category.TypeId);
            ViewBag.Menu = repository.GetMenuForCategoryId(id.Value);
            return View(category);
        }

        [Route("Type/Edit")]
        public ActionResult EditType(int? id)
        {
            if (id == null) return NotFound();
            TypeMenu type = repository.GetTypeMenu(id.Value);
            ViewBag.Categories = repository.GetCategoriesFortypeId(id.Value);
            return View(type);
        }

        [HttpPost]
        [Route("Type/Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditType(int id, [Bind("Id,Name, TypeId")] TypeMenu type)
        {
            if (id != type.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                repository.EditType(id, type);
                return RedirectToAction(nameof(Menu));
            }
            return View(type);
        }

        [Route("Type/Delete")]
        public ActionResult DeleteType(int? id)
        {
            if (id == null) return NotFound();
            return View(repository.GetTypeMenu(id.Value));
        }

        [HttpPost]
        [Route("Type/Delete")]
        public ActionResult DeleteType(int? id, string action)
        {
            if (action.Equals("cancel")) return RedirectToAction("Types");
            if (action.Equals("delete"))
            {
                if (id == null)
                {
                    return NotFound();
                }
                DeleteType(id.Value);
            }
            return RedirectToAction("Types");
        }

        [Route("Category/Delete")]
        public ActionResult DeleteCategory(int? id)
        {
            if (id == null) return NotFound();
            return View(repository.GetCategory(id.Value));
        }

        [HttpPost]
        [Route("Category/Delete")]
        public ActionResult DeleteCategory(int? id,int? typeId, string action)
        {
            if (action.Equals("cancel")) return Redirect($"~/Type/Edit?id={typeId.Value}");
            if (action.Equals("delete"))
            {
                if (id == null)
                {
                    return NotFound();
                }
                DeleteCategory(id.Value);
            }
            return RedirectToAction("Types");
        }

        [Route("Menu/Delete")]
        public ActionResult DeleteMenu(int? id)
        {
            if (id == null) return NotFound();
            return View(repository.GetMenu(id.Value));
        }

        [HttpPost]
        [Route("Menu/Delete")]
        public ActionResult DeleteMenu(int? id, int? categoryId, string action)
        {
            if (action.Equals("cancel")) return Redirect($"~/Category/Edit?id={categoryId.Value}");
            if (action.Equals("delete"))
            {
                if (id == null)
                {
                    return NotFound();
                }
                DeleteCategory(id.Value);
            }
            return RedirectToAction("Types");
        }

        public ActionResult CreateType()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateType(TypeMenu type, string action)
        {
            if (action.Equals("cancel"))
            {
                return RedirectToAction("Types");
            }
            if (action.Equals("Отправить"))
            {
                if (ModelState.IsValid)
                {
                    repository.CreateType(type);
                    return RedirectToAction("Types");
                }
            }
            return NotFound();
        }

        public ActionResult CreateMenu(int categoryId)
        {
            ViewBag.Category = repository.GetCategory(categoryId);
            return View();
        }

        [HttpPost]
        public ActionResult CreateMenu(Menu menu, string action)
        {
            if (action.Equals("cancel"))
            {
                return RedirectToAction("Types");
            }
            if (action.Equals("Отправить"))
            {
                if (ModelState.IsValid)
                {
                    repository.CreateMenu(menu);
                    return RedirectToAction("Types");
                }
            }
            return Content($"Количество ошибок: {ModelState.ErrorCount}");
        }

        public ActionResult CreateCategory(int typeId)
        {
            ViewBag.Type = repository.GetTypeMenu(typeId);
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(CategoryMenu category, string action)
        {
            if (action.Equals("cancel"))
            {
                return RedirectToAction("Types");
            }
            if (action.Equals("Отправить"))
            {
                if (ModelState.IsValid)
                {
                    repository.CreateCategory(category);
                    return RedirectToAction("Types");
                }
            }
            return NotFound();
        }
    }
}