using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBooking.Application.Migrations
{
    public partial class EditBookingCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BookingCartItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingCartItems_UserId",
                table: "BookingCartItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingCartItems_Users_UserId",
                table: "BookingCartItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingCartItems_Users_UserId",
                table: "BookingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_BookingCartItems_UserId",
                table: "BookingCartItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BookingCartItems");
        }
    }
}
