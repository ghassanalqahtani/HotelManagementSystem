namespace HotelManagementSystem.Domain.Models
{

    using System.ComponentModel.DataAnnotations.Schema;



    public class PermissionRole
    {

        [ForeignKey("Permissions")]
        public int? PermissionsId { get; set; }
        public Permission? Permissions { get; set; } // Navigation property


        [ForeignKey("Roles")]
        public int? RolesId { get; set; }
        public Role? Roles { get; set; } // Navigation property
        public int PermissionId { get; internal set; }
        public int RoleId { get; internal set; }
    }
}
