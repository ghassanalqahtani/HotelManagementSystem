using HotelManagementSystem.Application.Dtos;

namespace HotelManagementSystem.Application.Services
{
    public interface IAccountsService
    {
        bool Login(LoginDto dto);
    }
}
