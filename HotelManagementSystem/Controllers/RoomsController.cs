using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Controllers
{
    public class RoomsController : Controller
    {
        private readonly AppDbContext _db;

        public RoomsController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var roomsList = _db.Rooms.Include(r => r.Floor).ToList();
            return View(roomsList);
        }

        public IActionResult Create()
        {
            ViewBag.FloorsList = _db.Floors.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Rooms rooms)
        {
            rooms.IsAvailable = true;
            _db.Rooms.Add(rooms);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var rooms = _db.Rooms.Find(Id);
            if (rooms == null)
            {
                return NotFound();
            }
            return View(rooms);
        }

        [HttpPost]
        public IActionResult Edit(Rooms rooms)
        {
            if (ModelState.IsValid)
            {
                _db.Rooms.Update(rooms);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rooms);
        }

        public IActionResult Delete(int Id)
        {
            var rooms = _db.Rooms.Find(Id);
            if (rooms == null)
            {
                return NotFound();
            }
            return View(rooms);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int Id)
        {
            var rooms = _db.Rooms.Find(Id);
            if (rooms == null)
            {
                return NotFound();
            }
            _db.Rooms.Remove(rooms);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
