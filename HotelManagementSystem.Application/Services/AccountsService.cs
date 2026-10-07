using HotelManagementSystem.Application.Dtos;
using HotelManagementSystem.Infrastructure.Data;

namespace HotelManagementSystem.Application.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly AppDbContext _db;

        public AccountsService(AppDbContext db)
        {
            _db = db;
        }

        public bool Login(LoginDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Username) || string.IsNullOrEmpty(dto.Password))
            {
                return false;
            }

            var user = _db.Users.FirstOrDefault(u => u.Username == dto.Username);

            if (user != null && BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            {
                return true;
            }

            return false;
        }
    }
}
