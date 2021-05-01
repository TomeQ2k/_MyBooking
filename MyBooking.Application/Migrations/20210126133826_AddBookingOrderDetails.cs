using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBooking.Application.Migrations
{
    public partial class AddBookingOrderDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.CreateTable(
                name: "BookingOrders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingOrderDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    OrderId = table.Column<string>(nullable: false),
                    CustomerEmail = table.Column<string>(nullable: true),
                    OfferId = table.Column<string>(nullable: false),
                    BookingId = table.Column<string>(nullable: false),
                    OfferTitle = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingOrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingOrderDetails_BookedDates_BookingId",
                        column: x => x.BookingId,
                        principalTable: "BookedDates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingOrderDetails_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingOrderDetails_BookingOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "BookingOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingOrderDetails_BookingId",
                table: "BookingOrderDetails",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingOrderDetails_OfferId",
                table: "BookingOrderDetails",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingOrderDetails_OrderId",
                table: "BookingOrderDetails",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingOrderDetails");

            migrationBuilder.DropTable(
                name: "BookingOrders");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }
    }
}
