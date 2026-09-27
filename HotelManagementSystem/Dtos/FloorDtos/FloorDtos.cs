namespace HotelManagementSystem.Dtos
{
    public class CreateFloorDto
    {
        public string? FloorName { get; set; }
        public int FloorNumber { get; set; }
    }

    public class UpdateFloorDto : CreateFloorDto
    {
        public int Id { get; set; }
    }

    public class FloorDto : UpdateFloorDto
    {
        public string? UID { get; set; }
    }
}
