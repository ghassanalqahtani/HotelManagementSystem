using System;

namespace HotelManagementSystem.Models
{
    public class Floors
    {
        public int Id { get; set; }
        public string UID { get; set; } = Guid.NewGuid().ToString();
        public string? FloorName { get; set; }
        public int FloorNumber { get; set; }
    }
}
