using HotelManagementSystem.Domain.Models;
using HotelManagementSystem.Application.Dtos;
using HotelManagementSystem.Infrastructure.Repositories;
using HotelManagementSystem.Infrastructure.Data;

namespace HotelManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly AppDbContext _db;

        public UserService(IUserRepository userRepo, AppDbContext db)
        {
            _userRepo = userRepo;
            _db = db;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            return _userRepo.GetAllUsers().Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Name = u.Name
            }).ToList();
        }

        public void CreateUser(CreateUserDto dto)
        {
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                Name = dto.Name
            };
            _userRepo.AddUser(user);
            _userRepo.Save();
        }

        public void UpdateUser(UpdateUserDto dto)
        {
            var user = _userRepo.GetUserById(dto.Id);
            if (user != null)
            {
                user.Username = dto.Username;
                user.Name = dto.Name;
                user.Email = dto.Email;
                _userRepo.Save();
            }
        }

        public void DeleteUser(int id)
        {
            var user = _userRepo.GetUserById(id);
            if (user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
        }

        public User GetUserEntityById(int id)
        {
            return _userRepo.GetUserById(id);
        }

        public List<UserFile> GetUserFiles(int userId)
        {
            return _db.UserFiles.Where(e => e.UserID == userId).ToList();
        }

        public void AddUserFile(UserFile userFile)
        {
            _db.UserFiles.Add(userFile);
            _db.SaveChanges();
        }
    }
}
