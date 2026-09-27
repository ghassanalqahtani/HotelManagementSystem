namespace HotelManagementSystem.Models

{
    using HotelManagementSystem.Models;
    using HotelManagementSystem.Data;
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
