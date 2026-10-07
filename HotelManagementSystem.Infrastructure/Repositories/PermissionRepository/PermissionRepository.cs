using HotelManagementSystem.Infrastructure.Data;
using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Infrastructure.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly AppDbContext _db;

        public PermissionRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Permission> GetAllPermissions()
        {
            return _db.Permissions.ToList();
        }

        public Permission GetPermissionById(int id)
        {
            return _db.Permissions.Find(id);
        }

        public void AddPermission(Permission permission)
        {
            _db.Permissions.Add(permission);
        }

        public void UpdatePermission(Permission permission)
        {
            _db.Permissions.Update(permission);
        }

        public void DeletePermission(int id)
        {
            var permission = _db.Permissions.Find(id);
            if (permission != null)
            {
                _db.Permissions.Remove(permission);
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
