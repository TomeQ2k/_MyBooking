using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBooking.Application.Migrations
{
    public partial class AddBookingCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingCartItems",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BookingCartId = table.Column<string>(nullable: true),
                    BookedDateId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingCartItems_BookedDates_BookedDateId",
                        column: x => x.BookedDateId,
                        principalTable: "BookedDates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingCartItems_BookedDateId",
                table: "BookingCartItems",
                column: "BookedDateId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingCartItems");
        }
    }
}
