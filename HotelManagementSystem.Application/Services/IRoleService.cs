using HotelManagementSystem.Application.Dtos;


namespace HotelManagementSystem.Application.Services
{
    public interface IRoleService
    {
        IEnumerable<RoleDto> GetAllRoles();
        void CreateRole(CreateRoleDto dto);
        void UpdateRole(UpdateRoleDto dto);
        void DeleteRole(int id);
        UserRolesVM GetUserRoles(int id);
        void ManageUserRoles(UserRolesVM model);
        void SaveRolePermissions(int roleId, List<int> selectedPermissionIds);
    }
}
