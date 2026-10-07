using Microsoft.AspNetCore.Mvc;
using HotelManagementSystem.Application.Dtos;
using HotelManagementSystem.Application.Services;

namespace HotelManagementSystem.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountsService _accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            _accountsService = accountsService;
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

            var isLogged = _accountsService.Login(dto);

            if (isLogged)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View();
        }
    }
}
