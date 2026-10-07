using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToRoomsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRoles_Permissions_PermissionsId",
                table: "PermissionRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRoles_Roles_RolesId",
                table: "PermissionRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionRoles",
                table: "PermissionRoles");

            migrationBuilder.AddColumn<string>(
                name: "RoomImage",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PermissionsId",
                table: "PermissionRoles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RolesId",
                table: "PermissionRoles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionRoles",
                table: "PermissionRoles",
                columns: new[] { "RoleId", "PermissionId" });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRoles_RolesId",
                table: "PermissionRoles",
                column: "RolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRoles_Permissions_PermissionsId",
                table: "PermissionRoles",
                column: "PermissionsId",
                principalTable: "Permissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRoles_Roles_RolesId",
                table: "PermissionRoles",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRoles_Permissions_PermissionsId",
                table: "PermissionRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRoles_Roles_RolesId",
                table: "PermissionRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionRoles",
                table: "PermissionRoles");

            migrationBuilder.DropIndex(
                name: "IX_PermissionRoles_RolesId",
                table: "PermissionRoles");

            migrationBuilder.DropColumn(
                name: "RoomImage",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "RolesId",
                table: "PermissionRoles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PermissionsId",
                table: "PermissionRoles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionRoles",
                table: "PermissionRoles",
                columns: new[] { "RolesId", "PermissionsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRoles_Permissions_PermissionsId",
                table: "PermissionRoles",
                column: "PermissionsId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRoles_Roles_RolesId",
                table: "PermissionRoles",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
