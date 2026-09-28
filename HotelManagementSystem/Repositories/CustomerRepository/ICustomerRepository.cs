using System.Collections.Generic;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Repositories
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
