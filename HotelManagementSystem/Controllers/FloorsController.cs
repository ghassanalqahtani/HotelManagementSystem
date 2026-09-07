using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Controllers
{
    public class FloorsController : Controller
    {
        private readonly AppDbContext _db;

        public FloorsController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Floors> floorsList = _db.Floors.ToList();
            return View(floorsList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Floors floors)
        {
            _db.Floors.Add(floors);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var floors = _db.Floors.Find(Id);
            if (floors == null)
            {
                return NotFound();
            }
            return View(floors);
        }

        [HttpPost]
        public IActionResult Edit(Floors floors)
        {
            if (ModelState.IsValid)
            {
                _db.Floors.Update(floors);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(floors);
        }

        public IActionResult Delete(int Id)
        {
            var floors = _db.Floors.Find(Id);
            if (floors == null)
            {
                return NotFound();
            }
            return View(floors);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int Id)
        {
            var floors = _db.Floors.Find(Id);
            if (floors == null)
            {
                return NotFound();
            }
            _db.Floors.Remove(floors);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
