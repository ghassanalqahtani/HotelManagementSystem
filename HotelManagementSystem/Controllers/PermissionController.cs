using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using HotelManagementSystem.Dtos;

namespace HotelManagementSystem.Controllers
{
    public class PermissionController : Controller
    {
        private readonly AppDbContext _db;

        public PermissionController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var permissionsList = _db.Permissions.Select(p => new PermissionDto
            {
                Id = p.Id,
                PermissionName = p.Name
            }).ToList();

            return View(permissionsList);
        }

        [HttpPost]
        public IActionResult Create(CreatePermissionDto dto)
        {
            var permission = new Permission
            {
                Name = dto.PermissionName
            };
            _db.Permissions.Add(permission);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(UpdatePermissionDto dto)
        {
            var permission = _db.Permissions.Find(dto.Id);
            if (permission == null) return NotFound();

            permission.Name = dto.PermissionName;
            _db.Permissions.Update(permission);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var permission = _db.Permissions.Find(id);
            if (permission != null)
            {
                _db.Permissions.Remove(permission);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
