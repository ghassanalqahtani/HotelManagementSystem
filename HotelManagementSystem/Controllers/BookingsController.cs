using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Controllers
{
    public class BookingsController : Controller
    {
        private readonly AppDbContext _db;

        public BookingsController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var bookingsList = _db.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Room)
                .ToList();

            return View(bookingsList);
        }

        public IActionResult Details(int Id)
        {
            var booking = _db.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Room)
                .FirstOrDefault(b => b.Id == Id);

            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Bookings bookings)
        {
            _db.Bookings.Add(bookings);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var bookings = _db.Bookings.Find(Id);
            if (bookings == null)
            {
                return NotFound();
            }
            return View(bookings);
        }

        [HttpPost]
        public IActionResult Edit(Bookings bookings)
        {
            if (ModelState.IsValid)
            {
                _db.Bookings.Update(bookings);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookings);
        }

        public IActionResult Delete(int Id)
        {
            var bookings = _db.Bookings.Find(Id);
            if (bookings == null)
            {
                return NotFound();
            }
            return View(bookings);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int Id)
        {
            var bookings = _db.Bookings.Find(Id);
            if (bookings == null)
            {
                return NotFound();
            }
            _db.Bookings.Remove(bookings);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
