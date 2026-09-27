namespace HotelManagementSystem.Dtos
{
    public class CreateBookingDto
    {
        public int CustomersId { get; set; }
        public int RoomsId { get; set; }
        public int NumberOfNights { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class UpdateBookingDto : CreateBookingDto
    {
        public int Id { get; set; }
    }

    public class BookingDto : UpdateBookingDto
    {
        public string? CustomerName { get; set; }
        public string? RoomNumber { get; set; }
        public string? UID { get; set; }
    }
}
