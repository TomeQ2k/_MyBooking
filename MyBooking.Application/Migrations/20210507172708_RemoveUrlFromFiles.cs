using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBooking.Application.Migrations
{
    public partial class RemoveUrlFromFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "OfferPhotos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "OfferPhotos",
                type: "text",
                nullable: true);
        }
    }
}
