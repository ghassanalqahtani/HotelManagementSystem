using Microsoft.AspNetCore.Mvc;
using HotelManagementSystem.Application.Dtos;
using HotelManagementSystem.Application.Services;

namespace HotelManagementSystem.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            var rolesList = _roleService.GetAllRoles();
            return View(rolesList);
        }

        [HttpPost]
        public IActionResult Create(CreateRoleDto dto)
        {
            if (ModelState.IsValid)
            {
                _roleService.CreateRole(dto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(UpdateRoleDto dto)
        {
            if (ModelState.IsValid)
            {
                _roleService.UpdateRole(dto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _roleService.DeleteRole(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ManageRoles(int id)
        {
            var model = _roleService.GetUserRoles(id);
            if (model == null) return NotFound();
            return View(model);
        }

        [HttpPost]
        public IActionResult ManageRoles(UserRolesVM model)
        {
            if (ModelState.IsValid)
            {
                _roleService.ManageUserRoles(model);
            }
            return RedirectToAction("Index");
        }
    }
}
