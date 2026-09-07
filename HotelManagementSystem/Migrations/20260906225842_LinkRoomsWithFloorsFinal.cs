using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class LinkRoomsWithFloorsFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FloorsId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FloorsId",
                table: "Rooms",
                column: "FloorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Floors_FloorsId",
                table: "Rooms",
                column: "FloorsId",
                principalTable: "Floors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Floors_FloorsId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_FloorsId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "FloorsId",
                table: "Rooms");
        }
    }
}
