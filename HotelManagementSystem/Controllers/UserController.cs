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
    public class UserController : Controller
    {
        private readonly AppDbContext _db;

        public UserController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var usersList = _db.Users.Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Name = u.Name
            }).ToList();

            return View(usersList);
        }

        [HttpPost]
        public IActionResult Create(CreateUserDto dto)
        {
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                Name = dto.Name
            };
            _db.Users.Add(user);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        private string UploadFiles(IFormFile file, string name)
        {
            string fileName = name + "_" + Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "Users");
            Directory.CreateDirectory(folderPath);
            string filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/Files/Users/" + fileName;
        }

        public IActionResult ManageFiles(int userId)
        {
            var user = _db.Users.FirstOrDefault(e => e.Id == userId);
            if (user == null) return NotFound();

            var files = _db.UserFiles.Where(e => e.UserID == userId).ToList();
            ViewBag.UserName = user.Username;
            ViewBag.Files = files;

            var userFile = new UserFile { UserID = userId };
            return View(userFile);
        }

        [HttpPost]
        public IActionResult ManageFiles(UserFile userFile, IFormFile fileUser)
        {
            if (userFile != null && fileUser != null)
            {
                userFile.FileURL = UploadFiles(fileUser, userFile.Name ?? "UserFile");
                _db.UserFiles.Add(userFile);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(ManageFiles), new { userId = userFile.UserID });
        }
    }
}
