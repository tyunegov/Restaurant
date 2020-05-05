using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.ModelView;

namespace Restaurant.Controllers
{
    public class NewsController : Controller
    {
        IRepositoryNews repository;
        public NewsController(IRepositoryNews repository)
        {
            this.repository = repository;
        }
        public ActionResult Index()
        {            
            return View(repository.News);
        }
    }
}