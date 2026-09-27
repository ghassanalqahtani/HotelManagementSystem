using System.Collections.Generic;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByUsername(string username);
        void AddUser(User user);
        void Save();
    }
}
