using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Infrastructure.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customers> GetAllCustomers();
        Customers GetCustomerById(int id);
        void AddCustomer(Customers customer);
        void UpdateCustomer(Customers customer);
        void DeleteCustomer(int id);
        void Save();
    }
}
