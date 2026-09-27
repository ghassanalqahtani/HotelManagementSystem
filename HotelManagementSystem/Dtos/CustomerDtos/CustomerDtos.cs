namespace HotelManagementSystem.Dtos
{
    public class CreateCustomerDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? NationalId { get; set; }
    }

    public class UpdateCustomerDto : CreateCustomerDto
    {
        public int Id { get; set; }
    }

    public class CustomerDto : UpdateCustomerDto
    {
        public string? UID { get; set; }
    }
}
