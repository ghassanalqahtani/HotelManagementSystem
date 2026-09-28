using System.Collections.Generic;
using System.Linq;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _db;

        public CustomerRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Customers> GetAllCustomers()
        {
            return _db.Customers.ToList();
        }

        public Customers GetCustomerById(int id)
        {
            return _db.Customers.FirstOrDefault(c => c.Id == id);
        }

        public void AddCustomer(Customers customer)
        {
            _db.Customers.Add(customer);
        }

        public void UpdateCustomer(Customers customer)
        {
            _db.Customers.Update(customer);
        }

        public void DeleteCustomer(int id)
        {
            var customer = _db.Customers.Find(id);
            if (customer != null)
            {
                _db.Customers.Remove(customer);
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
