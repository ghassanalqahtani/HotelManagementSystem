using Microsoft.AspNetCore.Mvc;
using HotelManagementSystem.Application.Dtos;
using HotelManagementSystem.Application.Services;

namespace HotelManagementSystem.Controllers
{
    public class PermissionController : Controller
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public IActionResult Index()
        {
            var permissionsList = _permissionService.GetAllPermissions();
            return View(permissionsList);
        }

        [HttpPost]
        public IActionResult Create(CreatePermissionDto dto)
        {
            if (ModelState.IsValid)
            {
                _permissionService.CreatePermission(dto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(UpdatePermissionDto dto)
        {
            if (ModelState.IsValid)
            {
                _permissionService.UpdatePermission(dto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _permissionService.DeletePermission(id);
            return RedirectToAction("Index");
        }
    }
}
