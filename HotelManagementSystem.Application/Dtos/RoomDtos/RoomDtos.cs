namespace HotelManagementSystem.Application.Dtos
{
    public class CreateRoomDto
    {
        public string? RoomNumber { get; set; }
        public string? RoomType { get; set; }
        public decimal PricePerNight { get; set; }
        public int FloorsId { get; set; }
        public string? RoomImage { get; set; }
    }

    public class UpdateRoomDto : CreateRoomDto
    {
        public int Id { get; set; }
    }

    public class RoomDto : UpdateRoomDto
    {
        public string? FloorName { get; set; }
        public bool IsAvailable { get; set; }
        public string? UID { get; set; }
    }
}
