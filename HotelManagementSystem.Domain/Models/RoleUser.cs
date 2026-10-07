namespace HotelManagementSystem.Models

{
    using HotelManagementSystem.Domain.Models;
    using System.ComponentModel.DataAnnotations.Schema;
    public class RoleUser
    {
        [ForeignKey("Roles")]
        public int? RoleId { get; set; }
        public Role? Roles { get; set; }

        [ForeignKey("Users")]
        public int? UserId { get; set; }
        public User? Users { get; set; }
    }
}
