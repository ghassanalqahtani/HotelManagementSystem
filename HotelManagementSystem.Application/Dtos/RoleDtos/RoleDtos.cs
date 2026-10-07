namespace HotelManagementSystem.Application.Dtos
{
    public class CreateRoleDto
    {
        public string? Name { get; set; }
    }

    public class UpdateRoleDto : CreateRoleDto
    {
        public int Id { get; set; }
    }

    public class RoleDto : UpdateRoleDto
    {
    }
}
