using Microsoft.AspNetCore.Mvc;
using HotelManagementSystem.Application.Dtos;
using HotelManagementSystem.Application.Services;

namespace HotelManagementSystem.Controllers
{
    public class FloorsController : Controller
    {
        private readonly IFloorService _floorService;

        public FloorsController(IFloorService floorService)
        {
            _floorService = floorService;
        }

        public IActionResult Index()
        {
            var floorsList = _floorService.GetAllFloors();
            return View(floorsList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateFloorDto dto)
        {
            if (ModelState.IsValid)
            {
                _floorService.CreateFloor(dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }

        public IActionResult Edit(int Id)
        {
            var dto = _floorService.GetFloorById(Id);
            if (dto == null) return NotFound();
            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(UpdateFloorDto dto)
        {
            if (ModelState.IsValid)
            {
                _floorService.UpdateFloor(dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }

        public IActionResult Delete(int Id)
        {
            var dto = _floorService.GetFloorDetailsById(Id);
            if (dto == null) return NotFound();
            return View(dto);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int Id)
        {
            _floorService.DeleteFloor(Id);
            return RedirectToAction("Index");
        }
    }
}
