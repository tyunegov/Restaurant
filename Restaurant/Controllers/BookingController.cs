using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models.Book;
using Restaurant.ModelView;

namespace Restaurant.Controllers
{
    public class BookingController : Controller
    {
        IRepositoryBooking repository;

        public BookingController(IRepositoryBooking repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View(repository.Bookings);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking booking = repository.GetBooking(id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        public IActionResult Responce()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Client,DateTime,Email,Amount,Number,Message,IsConfirm")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                repository.CreateBooking(booking);
                return RedirectToAction(nameof(Responce));
            }
            return View(booking);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking booking = repository.GetBooking(id.Value);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Client,DateTime,Email,Amount,Number,Message,IsConfirm")] Booking booking)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                repository.EditBooking(id, booking);
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

    }
}
