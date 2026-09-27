using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using HotelManagementSystem.Dtos;

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
            var roomsList = _db.Rooms.Include(r => r.Floor).Select(r => new RoomDto
            {
                Id = r.Id,
                RoomNumber = r.RoomNumber,
                RoomType = r.RoomType,
                PricePerNight = r.PricePerNight,
                IsAvailable = r.IsAvailable,
                FloorsId = r.FloorsId,
                FloorName = r.Floor != null ? r.Floor.FloorName : "غير محدد",
                UID = r.UID,
                RoomImage = r.RoomImage 
            }).ToList();

            return View(roomsList);
        }

        public IActionResult Create()
        {
            ViewBag.FloorsList = _db.Floors.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateRoomDto dto)
        {
            var room = new Rooms
            {
                RoomNumber = dto.RoomNumber,
                RoomType = dto.RoomType,
                PricePerNight = dto.PricePerNight,
                FloorsId = dto.FloorsId,
                IsAvailable = true
            };
            _db.Rooms.Add(room);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        private string UploadRoomImages(IFormFile file, string name)
        {
            string fileName = name + "_" + Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Rooms");
            Directory.CreateDirectory(folderPath);
            string filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/Images/Rooms/" + fileName;
        }

        public IActionResult ManageImages(int roomId)
        {
            var room = _db.Rooms.FirstOrDefault(e => e.Id == roomId);
            if (room == null) return NotFound();

            var images = _db.HotelImages.Where(e => e.FolderId == roomId).ToList();
            ViewBag.RoomNumber = room.RoomNumber;
            ViewBag.Images = images;

            var hotelImage = new HotelImage { FolderId = roomId };
            return View(hotelImage);
        }

        [HttpPost]
        public IActionResult ManageImages(HotelImage hotelImage, IFormFile fileRoom, string imageName)
        {
            if (hotelImage != null && fileRoom != null)
            {
                hotelImage.ImagePath = UploadRoomImages(fileRoom, imageName);
                _db.HotelImages.Add(hotelImage);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(ManageImages), new { roomId = hotelImage.FolderId });
        }

        public IActionResult Edit(int Id)
        {
            var r = _db.Rooms.Find(Id);
            if (r == null) return NotFound();

            var dto = new UpdateRoomDto
            {
                Id = r.Id,
                RoomNumber = r.RoomNumber,
                RoomType = r.RoomType,
                PricePerNight = r.PricePerNight,
                FloorsId = r.FloorsId
            };
            ViewBag.FloorsList = _db.Floors.ToList();
            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(UpdateRoomDto dto)
        {
            var r = _db.Rooms.Find(dto.Id);
            if (r == null) return NotFound();

            r.RoomNumber = dto.RoomNumber;
            r.RoomType = dto.RoomType;
            r.PricePerNight = dto.PricePerNight;
            r.FloorsId = dto.FloorsId;

            _db.Rooms.Update(r);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var r = _db.Rooms.Include(x => x.Floor).FirstOrDefault(x => x.Id == Id);
            if (r == null) return NotFound();

            var dto = new RoomDto
            {
                Id = r.Id,
                RoomNumber = r.RoomNumber,
                RoomType = r.RoomType,
                PricePerNight = r.PricePerNight,
                FloorName = r.Floor != null ? r.Floor.FloorName : "غير محدد",
                UID = r.UID
            };
            return View(dto);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int Id)
        {
            var r = _db.Rooms.Find(Id);
            if (r == null) return NotFound();

            _db.Rooms.Remove(r);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
