using HotelManagementSystem.Application.Dtos;
using HotelManagementSystem.Infrastructure.Repositories;
using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            return _customerRepo.GetAllCustomers().Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                NationalId = c.NationalId,
                UID = c.UID
            }).ToList();
        }

        public UpdateCustomerDto GetCustomerById(int id)
        {
            var c = _customerRepo.GetCustomerById(id);
            if (c == null) return null;

            return new UpdateCustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                NationalId = c.NationalId
            };
        }

        public CustomerDto GetCustomerDetailsById(int id)
        {
            var c = _customerRepo.GetCustomerById(id);
            if (c == null) return null;

            return new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                NationalId = c.NationalId,
                UID = c.UID
            };
        }

        public void CreateCustomer(CreateCustomerDto dto)
        {
            var customer = new Customers
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                NationalId = dto.NationalId
            };
            _customerRepo.AddCustomer(customer);
            _customerRepo.Save();
        }

        public void UpdateCustomer(UpdateCustomerDto dto)
        {
            var c = _customerRepo.GetCustomerById(dto.Id);
            if (c != null)
            {
                c.Name = dto.Name;
                c.Email = dto.Email;
                c.Phone = dto.Phone;
                c.NationalId = dto.NationalId;
                _customerRepo.UpdateCustomer(c);
                _customerRepo.Save();
            }
        }

        public void DeleteCustomer(int id)
        {
            _customerRepo.DeleteCustomer(id);
            _customerRepo.Save();
        }
    }
}
