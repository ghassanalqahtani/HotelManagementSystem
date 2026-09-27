using Microsoft.AspNetCore.Mvc;
using System.Linq;
using HotelManagementSystem.Data;
using HotelManagementSystem.Dtos;

namespace HotelManagementSystem.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AppDbContext _db;

        public AccountsController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var dto = new LoginDto
            {
                Username = username,
                Password = password
            };

            if (!string.IsNullOrEmpty(dto.Username) && !string.IsNullOrEmpty(dto.Password))
            {
                var user = _db.Users.FirstOrDefault(u => u.Username == dto.Username);

                if (user != null && BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View();
        }
    }
}
