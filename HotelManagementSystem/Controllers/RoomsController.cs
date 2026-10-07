using Microsoft.AspNetCore.Mvc;
using HotelManagementSystem.Models;
using HotelManagementSystem.Application.Dtos;
using HotelManagementSystem.Application.Services;
using HotelManagementSystem.Infrastructure.Data;
using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly AppDbContext _db; 

        public RoomsController(IRoomService roomService, AppDbContext db)
        {
            _roomService = roomService;
            _db = db;
        }

        public IActionResult Index()
        {
            var roomsList = _roomService.GetAllRooms();
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
            if (ModelState.IsValid)
            {
                _roomService.CreateRoom(dto);
                return RedirectToAction("Index");
            }
            ViewBag.FloorsList = _db.Floors.ToList();
            return View(dto);
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
            var room = _roomService.GetRoomEntityById(roomId);
            if (room == null) return NotFound();

            var images = _roomService.GetRoomImages(roomId);
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
                _roomService.AddRoomImage(hotelImage);
            }

            return RedirectToAction(nameof(ManageImages), new { roomId = hotelImage.FolderId });
        }

        public IActionResult Edit(int Id)
        {
            var dto = _roomService.GetRoomById(Id);
            if (dto == null) return NotFound();

            ViewBag.FloorsList = _db.Floors.ToList();
            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(UpdateRoomDto dto)
        {
            if (ModelState.IsValid)
            {
                _roomService.UpdateRoom(dto);
                return RedirectToAction("Index");
            }
            ViewBag.FloorsList = _db.Floors.ToList();
            return View(dto);
        }

        public IActionResult Delete(int Id)
        {
            var dto = _roomService.GetRoomDetailsById(Id);
            if (dto == null) return NotFound();
            return View(dto);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int Id)
        {
            _roomService.DeleteRoom(Id);
            return RedirectToAction("Index");
        }
    }
}
