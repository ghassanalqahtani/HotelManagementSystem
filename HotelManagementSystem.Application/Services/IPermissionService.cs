using HotelManagementSystem.Application.Dtos;

namespace HotelManagementSystem.Application.Services
{
    public interface IPermissionService
    {
        IEnumerable<PermissionDto> GetAllPermissions();
        void CreatePermission(CreatePermissionDto dto);
        void UpdatePermission(UpdatePermissionDto dto);
        void DeletePermission(int id);
    }
}
