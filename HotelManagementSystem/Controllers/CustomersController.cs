using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;

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
            IEnumerable<Customers> customersList = _db.Customers.ToList();
            return View(customersList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customers customers)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Add(customers);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customers);
        }

        public IActionResult Edit(int Id)
        {
            var customers = _db.Customers.Find(Id);
            if (customers == null)
            {
                return NotFound();
            }
            return View(customers);
        }

        [HttpPost]
        public IActionResult Edit(Customers customers)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Update(customers);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customers);
        }

        public IActionResult Delete(int Id)
        {
            var customers = _db.Customers.Find(Id);
            if (customers == null)
            {
                return NotFound();
            }
            return View(customers);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int Id)
        {
            var customers = _db.Customers.Find(Id);
            if (customers == null)
            {
                return NotFound();
            }
            _db.Customers.Remove(customers);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
