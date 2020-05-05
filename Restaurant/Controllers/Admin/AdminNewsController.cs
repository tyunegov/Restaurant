using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.News;
using Restaurant.ModelView;

namespace Restaurant.Controllers.Admin
{
    public class AdminNewsController : Controller
    {
        IRepositoryNews repository;
        public AdminNewsController(IRepositoryNews repository)
        {
            this.repository = repository;
        }

        [Route("Admin/News")]
        public IActionResult Index()
        {
            return View(repository.News);
        }

        [Route("News/Edit")]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            return View(repository.Get(id.Value));
        }

        [Route("News/Edit")]
        [HttpPost]
        public IActionResult Edit(NewsModel model)
        {
            if (ModelState.IsValid)
            {
                repository.Edit(model);
            }
            return RedirectToAction("Index");
        }

        [Route("News/Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            return View(repository.Get(id.Value));
        }

        [HttpPost]
        [Route("News/Delete")]
        public ActionResult Delete(int? id, string action)
        {
            if (action.Equals("cancel")) return RedirectToAction("Index");
            if (action.Equals("delete"))
            {
                if (id == null)
                {
                    return NotFound();
                }
                Delete(id.Value);
            }
            return RedirectToAction("Index");
        }

        [Route("News/Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewsModel model)
        {
            if(ModelState.IsValid)
            {
                repository.Create(model);
            }
            return RedirectToAction("Index");
        }
    }
}