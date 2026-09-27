using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using HotelManagementSystem.Dtos;

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
            var floorsList = _db.Floors.Select(f => new FloorDto
            {
                Id = f.Id,
                FloorName = f.FloorName,
                FloorNumber = f.FloorNumber,
                UID = f.UID
            }).ToList();

            return View(floorsList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateFloorDto dto)
        {
            var floor = new Floors
            {
                FloorName = dto.FloorName,
                FloorNumber = dto.FloorNumber
            };
            _db.Floors.Add(floor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var f = _db.Floors.Find(Id);
            if (f == null) return NotFound();

            var dto = new UpdateFloorDto
            {
                Id = f.Id,
                FloorName = f.FloorName,
                FloorNumber = f.FloorNumber
            };
            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(UpdateFloorDto dto)
        {
            var f = _db.Floors.Find(dto.Id);
            if (f == null) return NotFound();

            f.FloorName = dto.FloorName;
            f.FloorNumber = dto.FloorNumber;

            _db.Floors.Update(f);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var f = _db.Floors.Find(Id);
            if (f == null) return NotFound();

            var dto = new FloorDto
            {
                Id = f.Id,
                FloorName = f.FloorName,
                FloorNumber = f.FloorNumber,
                UID = f.UID
            };
            return View(dto);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int Id)
        {
            var f = _db.Floors.Find(Id);
            if (f == null) return NotFound();

            _db.Floors.Remove(f);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
