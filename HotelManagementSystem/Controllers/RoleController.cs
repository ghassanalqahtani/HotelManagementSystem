using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using HotelManagementSystem.Dtos;

namespace HotelManagementSystem.Controllers
{
    public class RoleController : Controller
    {
        private readonly AppDbContext _db;

        public RoleController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var rolesList = _db.Roles.Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();

            return View(rolesList);
        }

        [HttpPost]
        public IActionResult Create(CreateRoleDto dto)
        {
            var role = new Role
            {
                Name = dto.Name
            };
            _db.Roles.Add(role);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(UpdateRoleDto dto)
        {
            var role = _db.Roles.Find(dto.Id);
            if (role == null) return NotFound();

            role.Name = dto.Name;
            _db.Roles.Update(role);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var role = _db.Roles.Find(id);
            if (role != null)
            {
                _db.Roles.Remove(role);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ManageRoles(int id)
        {
            var user = _db.Users.Find(id);
            if (user == null) return NotFound();

            var roles = _db.Roles.ToList();
            var userRoleIds = _db.RoleUsers
                .Where(x => x.UserId == id)
                .Select(x => x.RoleId)
                .ToList();

            var model = new UserRolesVM
            {
                UserId = user.Id,
                UserName = user.Name,
                Roles = roles.Select(role => new RoleCheckVM
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsSelected = userRoleIds.Contains(role.Id)
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult ManageRoles(UserRolesVM model)
        {
            var user = _db.Users.Find(model.UserId);
            if (user == null) return NotFound();

            var oldRoles = _db.RoleUsers.Where(x => x.UserId == model.UserId).ToList();
            _db.RoleUsers.RemoveRange(oldRoles);

            foreach (var role in model.Roles)
            {
                if (role.IsSelected)
                {
                    var roleUser = new RoleUser
                    {
                        UserId = model.UserId,
                        RoleId = role.RoleId
                    };
                    _db.RoleUsers.Add(roleUser);
                }
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SavePermissions(int roleId, List<int> selectedPermissionIds)
        {
            var oldPermissions = _db.PermissionRoles.Where(pr => pr.RoleId == roleId).ToList();
            _db.PermissionRoles.RemoveRange(oldPermissions);

            if (selectedPermissionIds != null)
            {
                foreach (var permissionId in selectedPermissionIds)
                {
                    var permissionRole = new PermissionRole
                    {
                        RoleId = roleId,
                        PermissionId = permissionId
                    };
                    _db.PermissionRoles.Add(permissionRole);
                }
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
