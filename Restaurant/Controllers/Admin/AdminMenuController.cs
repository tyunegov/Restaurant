using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.ModelView;
using System.Diagnostics;

namespace Restaurant.Controllers.Admin
{
    public class AdminMenuController : Controller
    {
        IRepositoryMenu repository;
        public AdminMenuController(IRepositoryMenu repository)
        {
            this.repository = repository;
        }

        //[Authorize(Roles = "admin")]
        // Не разобрался с перенаправлением на главную страницу
        [Route("Admin/Index")]
        [Route("Admin/Menu")]
        public IActionResult Menu()
        {
            if (User.Identity.IsAuthenticated)
            {                
                return View(repository.Categories);
            }
            return Redirect("~/Account/Login");
        }

        [Route("Admin/Types")]
        public IActionResult Types()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(repository.Types);
            }
            return Redirect("~/Account/Login");
        }

        [Route("Edit/Types")]
        public IActionResult EditTypes()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(repository.Types);
            }
            return Redirect("~/Account/Login");
        }
    }
}