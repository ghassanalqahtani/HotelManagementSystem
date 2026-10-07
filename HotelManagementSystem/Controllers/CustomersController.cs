using Microsoft.AspNetCore.Mvc;
using HotelManagementSystem.Application.Dtos;
using HotelManagementSystem.Application .Services;

namespace HotelManagementSystem.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var customersList = _customerService.GetAllCustomers();
            return View(customersList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCustomerDto dto)
        {
            if (ModelState.IsValid)
            {
                _customerService.CreateCustomer(dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }

        public IActionResult Edit(int Id)
        {
            var dto = _customerService.GetCustomerById(Id);
            if (dto == null) return NotFound();
            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(UpdateCustomerDto dto)
        {
            if (ModelState.IsValid)
            {
                _customerService.UpdateCustomer(dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }

        public IActionResult Delete(int Id)
        {
            var dto = _customerService.GetCustomerDetailsById(Id);
            if (dto == null) return NotFound();
            return View(dto);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int Id)
        {
            _customerService.DeleteCustomer(Id);
            return RedirectToAction("Index");
        }
    }
}
