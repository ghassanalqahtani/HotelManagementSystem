using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelManagementSystem.Application.Dtos;
using HotelManagementSystem.Application.Services;

namespace HotelManagementSystem.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ICustomerService _customerService;
        private readonly IRoomService _roomService;

        public BookingsController(IBookingService bookingService, ICustomerService customerService, IRoomService roomService)
        {
            _bookingService = bookingService;
            _customerService = customerService;
            _roomService = roomService;
        }

        public IActionResult Index()
        {
            var bookingsList = _bookingService.GetAllBookings();
            return View(bookingsList);
        }

        public IActionResult Details(int Id)
        {
            var dto = _bookingService.GetBookingById(Id);
            if (dto == null) return NotFound();
            return View(dto);
        }

        public IActionResult Create()
        {
            ViewBag.CustomersList = new SelectList(_customerService.GetAllCustomers(), "Id", "Name");
            ViewBag.RoomsList = new SelectList(_roomService.GetAllRooms().Where(r => r.IsAvailable), "Id", "RoomNumber");
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateBookingDto dto)
        {
            if (ModelState.IsValid)
            {
                _bookingService.CreateBooking(dto);
                return RedirectToAction("Index");
            }
            ViewBag.CustomersList = new SelectList(_customerService.GetAllCustomers(), "Id", "Name");
            ViewBag.RoomsList = new SelectList(_roomService.GetAllRooms().Where(r => r.IsAvailable), "Id", "RoomNumber");
            return View(dto);
        }

        public IActionResult Edit(int Id)
        {
            var dto = _bookingService.GetBookingForEditById(Id);
            if (dto == null) return NotFound();

            ViewBag.CustomersList = new SelectList(_customerService.GetAllCustomers(), "Id", "Name");
            ViewBag.RoomsList = new SelectList(_roomService.GetAllRooms(), "Id", "RoomNumber");
            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(UpdateBookingDto dto)
        {
            if (ModelState.IsValid)
            {
                _bookingService.UpdateBooking(dto);
                return RedirectToAction("Index");
            }
            ViewBag.CustomersList = new SelectList(_customerService.GetAllCustomers(), "Id", "Name");
            ViewBag.RoomsList = new SelectList(_roomService.GetAllRooms(), "Id", "RoomNumber");
            return View(dto);
        }

        public IActionResult Delete(int Id)
        {
            var dto = _bookingService.GetBookingById(Id);
            if (dto == null) return NotFound();
            return View(dto);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int Id)
        {
            _bookingService.DeleteBooking(Id);
            return RedirectToAction("Index");
        }
    }
}
