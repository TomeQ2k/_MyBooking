using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBooking.Application.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    DateRegistered = table.Column<DateTime>(nullable: false),
                    EmailConfirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    TotalCount = table.Column<int>(nullable: false),
                    OfferDetailsId = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    TokenType = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookedDates",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsConfirmed = table.Column<bool>(nullable: false),
                    OfferId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookedDates_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookedDates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "OfferDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RoomsCount = table.Column<int>(nullable: false),
                    PersonsCount = table.Column<int>(nullable: false),
                    HasBathroom = table.Column<bool>(nullable: false),
                    HasKitchen = table.Column<bool>(nullable: false),
                    HasWifi = table.Column<bool>(nullable: false),
                    HasBalcony = table.Column<bool>(nullable: false),
                    HasTV = table.Column<bool>(nullable: false),
                    HasMinibar = table.Column<bool>(nullable: false),
                    AccommodationType = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    OfferId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferDetails_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferFollows",
                columns: table => new
                {
                    OfferId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferFollows", x => new { x.OfferId, x.UserId });
                    table.ForeignKey(
                        name: "FK_OfferFollows_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferFollows_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferPhotos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    OfferId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferPhotos_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opinions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    OfferId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opinions_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Opinions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfferRates",
                columns: table => new
                {
                    OpinionId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Rating = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferRates", x => new { x.OpinionId, x.UserId });
                    table.ForeignKey(
                        name: "FK_OfferRates_Opinions_OpinionId",
                        column: x => x.OpinionId,
                        principalTable: "Opinions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferRates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookedDates_OfferId",
                table: "BookedDates",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_BookedDates_UserId",
                table: "BookedDates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferDetails_OfferId",
                table: "OfferDetails",
                column: "OfferId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OfferFollows_UserId",
                table: "OfferFollows",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferPhotos_OfferId",
                table: "OfferPhotos",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferRates_OpinionId",
                table: "OfferRates",
                column: "OpinionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OfferRates_UserId",
                table: "OfferRates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CreatorId",
                table: "Offers",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_OfferId",
                table: "Opinions",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_UserId",
                table: "Opinions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_UserId",
                table: "Tokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookedDates");

            migrationBuilder.DropTable(
                name: "OfferDetails");

            migrationBuilder.DropTable(
                name: "OfferFollows");

            migrationBuilder.DropTable(
                name: "OfferPhotos");

            migrationBuilder.DropTable(
                name: "OfferRates");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "Opinions");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
