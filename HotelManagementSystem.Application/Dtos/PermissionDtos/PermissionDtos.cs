namespace HotelManagementSystem.Application.Dtos
{
    public class CreatePermissionDto
    {
        public string? PermissionName { get; set; }
    }

    public class UpdatePermissionDto : CreatePermissionDto
    {
        public int Id { get; set; }
    }

    public class PermissionDto : UpdatePermissionDto
    {
    }
}
