using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Models
{
    public class HotelImage
    {
        public int Id { get; set; }
        public string? ImagePath { get; set; }
        public int FolderId { get; set; }

        [ForeignKey("FolderId")]
        public virtual Rooms? Room { get; set; }
    }
}
