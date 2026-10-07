using HotelManagementSystem.Application.Dtos;

namespace HotelManagementSystem.Application.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAllCustomers();
        UpdateCustomerDto GetCustomerById(int id);
        CustomerDto GetCustomerDetailsById(int id);
        void CreateCustomer(CreateCustomerDto dto);
        void UpdateCustomer(UpdateCustomerDto dto);
        void DeleteCustomer(int id);
    }
}
