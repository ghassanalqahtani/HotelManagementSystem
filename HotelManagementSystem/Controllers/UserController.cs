using Microsoft.AspNetCore.Mvc;
using HotelManagementSystem.Application.Dtos;
using HotelManagementSystem.Application.Services;
using HotelManagementSystem.Domain.Models;


namespace HotelManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var usersList = _userService.GetAllUsers();
            return View(usersList);
        }

        [HttpPost]
        public IActionResult Create(CreateUserDto dto)
        {
            if (ModelState.IsValid)
            {
                _userService.CreateUser(dto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(UpdateUserDto dto)
        {
            if (ModelState.IsValid)
            {
                
                _userService.UpdateUser(dto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
           
            _userService.DeleteUser(id);
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
            var user = _userService.GetUserEntityById(userId);
            if (user == null) return NotFound();

            var files = _userService.GetUserFiles(userId);
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
                _userService.AddUserFile(userFile);
            }

            return RedirectToAction(nameof(ManageFiles), new { userId = userFile.UserID });
        }
    }
}
