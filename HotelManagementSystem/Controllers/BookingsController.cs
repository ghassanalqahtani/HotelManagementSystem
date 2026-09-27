using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using HotelManagementSystem.Dtos;

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
            var bookingsList = _db.Bookings.Include(b => b.Customer).Include(b => b.Room).Select(b => new BookingDto
            {
                Id = b.Id,
                CustomersId = b.CustomersId,
                RoomsId = b.RoomsId,
                NumberOfNights = b.NumberOfNights,
                TotalPrice = b.TotalPrice,
                CustomerName = b.Customer != null ? b.Customer.Name : "غير معروف",
                RoomNumber = b.Room != null ? b.Room.RoomNumber : "غير معروف",
                UID = b.UID
            }).ToList();

            return View(bookingsList);
        }

        public IActionResult Details(int Id)
        {
            var b = _db.Bookings.Include(x => x.Customer).Include(x => x.Room).FirstOrDefault(x => x.Id == Id);
            if (b == null) return NotFound();

            var dto = new BookingDto
            {
                Id = b.Id,
                CustomersId = b.CustomersId,
                RoomsId = b.RoomsId,
                NumberOfNights = b.NumberOfNights,
                TotalPrice = b.TotalPrice,
                CustomerName = b.Customer != null ? b.Customer.Name : "غير معروف",
                RoomNumber = b.Room != null ? b.Room.RoomNumber : "غير معروف",
                UID = b.UID
            };
            return View(dto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateBookingDto dto)
        {
            var booking = new Bookings
            {
                CustomersId = dto.CustomersId,
                RoomsId = dto.RoomsId,
                NumberOfNights = dto.NumberOfNights,
                TotalPrice = dto.TotalPrice
            };
            _db.Bookings.Add(booking);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var b = _db.Bookings.Find(Id);
            if (b == null) return NotFound();

            var dto = new UpdateBookingDto
            {
                Id = b.Id,
                CustomersId = b.CustomersId,
                RoomsId = b.RoomsId,
                NumberOfNights = b.NumberOfNights,
                TotalPrice = b.TotalPrice
            };
            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(UpdateBookingDto dto)
        {
            var b = _db.Bookings.Find(dto.Id);
            if (b == null) return NotFound();

            b.CustomersId = dto.CustomersId;
            b.RoomsId = dto.RoomsId;
            b.NumberOfNights = dto.NumberOfNights;
            b.TotalPrice = dto.TotalPrice;

            _db.Bookings.Update(b);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var b = _db.Bookings.Include(x => x.Customer).Include(x => x.Room).FirstOrDefault(x => x.Id == Id);
            if (b == null) return NotFound();

            var dto = new BookingDto
            {
                Id = b.Id,
                CustomersId = b.CustomersId,
                RoomsId = b.RoomsId,
                NumberOfNights = b.NumberOfNights,
                TotalPrice = b.TotalPrice,
                CustomerName = b.Customer != null ? b.Customer.Name : "غير معروف",
                RoomNumber = b.Room != null ? b.Room.RoomNumber : "غير معروف",
                UID = b.UID
            };
            return View(dto);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int Id)
        {
            var b = _db.Bookings.Find(Id);
            if (b == null) return NotFound();

            _db.Bookings.Remove(b);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
