using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Models
{
    public class UserFile
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FileURL { get; set; }

        public int? UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User? User { get; set; }

        public int? CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customers? Customer { get; set; }
    }
}
