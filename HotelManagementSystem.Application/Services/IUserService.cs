using HotelManagementSystem.Application.Dtos;
using HotelManagementSystem.Domain.Models;


namespace HotelManagementSystem.Application.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();
        void CreateUser(CreateUserDto dto);
        void UpdateUser(UpdateUserDto dto);
        void DeleteUser(int id);
        User GetUserEntityById(int id);
        List<UserFile> GetUserFiles(int userId);
        void AddUserFile(UserFile userFile);
    }
}
