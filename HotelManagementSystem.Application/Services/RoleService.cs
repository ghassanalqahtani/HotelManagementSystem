using HotelManagementSystem.Application.Dtos;
using HotelManagementSystem.Infrastructure.Data;

namespace HotelManagementSystem.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _db;

        public RoleService(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<RoleDto> GetAllRoles()
        {
            return _db.Roles.Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();
        }

        public void CreateRole(CreateRoleDto dto)
        {
            var role = new HotelManagementSystem.Domain.Models.Role { Name = dto.Name };
            _db.Roles.Add(role);
            _db.SaveChanges();
        }

        public void UpdateRole(UpdateRoleDto dto)
        {
            var role = _db.Roles.FirstOrDefault();
            if (role != null)
            {
                role.Name = dto.Name;
                _db.SaveChanges();
            }
        }

        public void DeleteRole(int id)
        {
            var role = _db.Roles.FirstOrDefault();
            if (role != null)
            {
                _db.Roles.Remove(role);
                _db.SaveChanges();
            }
        }

        public UserRolesVM GetUserRoles(int id)
        {
         
            var roles = _db.Roles.ToList();

            return new UserRolesVM
            {
                UserId = id,
                UserName = "Admin User",
                Roles = roles.Select(role => new RoleCheckVM
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsSelected = false
                }).ToList()
            };
        }

        public void ManageUserRoles(UserRolesVM model)
        {
            if (model == null) return;
            _db.SaveChanges();
        }

        public void SaveRolePermissions(int roleId, List<int> selectedPermissionIds)
        {
            if (selectedPermissionIds != null)
            {
                var oldPermissions = _db.PermissionRoles.ToList().Where(pr => pr.RoleId == roleId).ToList();
                _db.PermissionRoles.RemoveRange(oldPermissions);
                _db.SaveChanges();
            }
        }
    }
}
