using HotelManagementSystem.Domain.Models;
using HotelManagementSystem.Application.Dtos;
using HotelManagementSystem.Infrastructure.Repositories;

namespace HotelManagementSystem.Application.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepo;

        public PermissionService(IPermissionRepository permissionRepo)
        {
            _permissionRepo = permissionRepo;
        }

        public IEnumerable<PermissionDto> GetAllPermissions()
        {
            return _permissionRepo.GetAllPermissions().Select(p => new PermissionDto
            {
                Id = p.Id,
                PermissionName = p.Name
            }).ToList();
        }

        public void CreatePermission(CreatePermissionDto dto)
        {
            var permission = new Permission
            {
                Name = dto.PermissionName
            };
            _permissionRepo.AddPermission(permission);
            _permissionRepo.Save();
        }

        public void UpdatePermission(UpdatePermissionDto dto)
        {
            var permission = _permissionRepo.GetPermissionById(dto.Id);
            if (permission != null)
            {
                permission.Name = dto.PermissionName;
                _permissionRepo.UpdatePermission(permission);
                _permissionRepo.Save();
            }
        }

        public void DeletePermission(int id)
        {
            _permissionRepo.DeletePermission(id);
            _permissionRepo.Save();
        }
    }
}
