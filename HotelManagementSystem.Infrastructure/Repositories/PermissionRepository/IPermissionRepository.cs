using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Infrastructure.Repositories
{
    public interface IPermissionRepository
    {
        IEnumerable<Permission> GetAllPermissions();
        Permission GetPermissionById(int id);
        void AddPermission(Permission permission);
        void UpdatePermission(Permission permission);
        void DeletePermission(int id);
        void Save();
    }
}
