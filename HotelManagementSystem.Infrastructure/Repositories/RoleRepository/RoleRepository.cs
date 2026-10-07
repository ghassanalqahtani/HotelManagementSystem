using HotelManagementSystem.Infrastructure.Data;
using HotelManagementSystem.Domain.Models;

namespace HotelManagementSystem.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _db;

        public RoleRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _db.Roles.ToList();
        }

        public Role GetRoleById(int id)
        {
            return _db.Roles.Find(id);
        }

        public void AddRole(Role role)
        {
            _db.Roles.Add(role);
        }

        public void UpdateRole(Role role)
        {
            _db.Roles.Update(role);
        }

        public void DeleteRole(int id)
        {
            var role = _db.Roles.Find(id);
            if (role != null)
            {
                _db.Roles.Remove(role);
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
