namespace HotelManagementSystem.Application.Dtos
{
    public class CreateUserDto
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
    }

    public class UpdateUserDto : CreateUserDto
    {
        public int Id { get; set; }
    }

    public class UserDto : UpdateUserDto
    {
    }
}
