using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using HotelManagementSystem.Dtos;

namespace HotelManagementSystem.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppDbContext _db;

        public CustomersController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var customersList = _db.Customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                NationalId = c.NationalId,
                UID = c.UID
            }).ToList();

            return View(customersList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCustomerDto dto)
        {
            var customer = new Customers
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                NationalId = dto.NationalId
            };
            _db.Customers.Add(customer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var c = _db.Customers.Find(Id);
            if (c == null) return NotFound();

            var dto = new UpdateCustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                NationalId = c.NationalId
            };
            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(UpdateCustomerDto dto)
        {
            var c = _db.Customers.Find(dto.Id);
            if (c == null) return NotFound();

            c.Name = dto.Name;
            c.Email = dto.Email;
            c.Phone = dto.Phone;
            c.NationalId = dto.NationalId;

            _db.Customers.Update(c);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var c = _db.Customers.Find(Id);
            if (c == null) return NotFound();

            var dto = new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                NationalId = c.NationalId,
                UID = c.UID
            };
            return View(dto);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int Id)
        {
            var c = _db.Customers.Find(Id);
            if (c == null) return NotFound();

            _db.Customers.Remove(c);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
