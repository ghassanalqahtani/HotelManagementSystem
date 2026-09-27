using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Models
{
    public class Rooms
    {
        public int Id { get; set; }
        public string UID { get; set; } = Guid.NewGuid().ToString();
        public string? RoomNumber { get; set; }
        public string? RoomType { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }

        public int FloorsId { get; set; }
        [ForeignKey("FloorsId")]
        public virtual Floors? Floor { get; set; }

        public string? RoomImage { get; set; }
    }
}
