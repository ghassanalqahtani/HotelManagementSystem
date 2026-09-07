using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Models
{
    public class Bookings
    {
        public int Id { get; set; }

        public int CustomersId { get; set; }
        [ForeignKey("CustomersId")]
        public virtual Customers? Customer { get; set; }

        public int RoomsId { get; set; }
        [ForeignKey("RoomsId")]
        public virtual Rooms? Room { get; set; }

        public int NumberOfNights { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
