﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBooking.Infrastructure.Database;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MyBooking.Application.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210129182601_AddRolesEntity")]
    partial class AddRolesEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MyBooking.Core.Entities.BookedDate", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("OfferId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.HasIndex("UserId");

                    b.ToTable("BookedDates");
                });

            modelBuilder.Entity("MyBooking.Core.Entities.BookingCartItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("BookedDateId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BookingCartId")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookedDateId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("BookingCartItems");
                });

            modelBuilder.Entity("MyBooking.Core.Entities.BookingOrder", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("BookingOrders");
                });

            modelBuilder.Entity("MyBooking.Core.Entities.BookingOrderDetails", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("BookingId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("text");

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("OfferId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OfferTitle")
                        .HasColumnType("text");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("OfferId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("BookingOrderDetails");
                });

            modelBuilder.Entity("MyBooking.Core.Entities.Offer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("OfferDetailsId")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("TotalCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("MyBooking.Core.Entities.OfferDetails", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccommodationType")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("text");

                    b.Property<bool>("HasBalcony")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasBathroom")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasKitchen")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasMinibar")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasTV")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasWifi")
                        .HasColumnType("boolean");

                    b.Property<string>("OfferId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PersonsCount")
                        .HasColumnType("integer");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("RoomsCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OfferId")
                        .IsUnique();

                    b.ToTable("OfferDetails");
                });

            modelBuilder.Entity("MyBooking.Core.Entities.OfferFollow", b =>
                {
                    b.Property<string>("OfferId")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("OfferId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("OfferFollows");
                });

            modelBuilder.Entity("MyBooking.Core.Entities.OfferPhoto", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("OfferId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.ToTable("OfferPhotos");
                });

            modelBuilder.Entity("MyBooking.Core.Entities.OfferRate", b =>
                {
                    b.Property<string>("OpinionId")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision");

                    b.HasKey("OpinionId", "UserId");

                    b.HasIndex("OpinionId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("OfferRates");
                });

            modelBuilder.Entity("MyBooking.Core.Entities.Opinion", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("OfferId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.HasIndex("UserId");

                    b.ToTable("Opinions");
                });

            modelBuilder.Entity("MyBooking.Core.Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("RoleName")
                        .HasColumnType("text");

                    b.Property<int>("RoleType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MyBooking.Core.Entities.Token", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("TokenType")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("MyBooking.Core.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyBooking.Core.Entities.UserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("MyBooking.Core.Entities.BookedDate", b =>
                {
                    b.HasOne("MyBooking.Core.Entities.Offer", "Offer")
                        .WithMany("BookedDates")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBooking.Core.Entities.User", "User")
                        .WithMany("BookedDates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("MyBooking.Core.Entities.BookingCartItem", b =>
                {
                    b.HasOne("MyBooking.Core.Entities.BookedDate", "BookedDate")
                        .WithOne("BookingCartItem")
                        .HasForeignKey("MyBooking.Core.Entities.BookingCartItem", "BookedDateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBooking.Core.Entities.User", "User")
                        .WithMany("BookingCartItems")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("MyBooking.Core.Entities.BookingOrderDetails", b =>
                {
                    b.HasOne("MyBooking.Core.Entities.BookedDate", "Booking")
                        .WithMany("BookingOrderDetails")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBooking.Core.Entities.Offer", "Offer")
                        .WithMany("BookingOrderDetails")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBooking.Core.Entities.BookingOrder", "Order")
                        .WithOne("OrderDetails")
                        .HasForeignKey("MyBooking.Core.Entities.BookingOrderDetails", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBooking.Core.Entities.Offer", b =>
                {
                    b.HasOne("MyBooking.Core.Entities.User", "Creator")
                        .WithMany("Offers")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBooking.Core.Entities.OfferDetails", b =>
                {
                    b.HasOne("MyBooking.Core.Entities.Offer", "Offer")
                        .WithOne("OfferDetails")
                        .HasForeignKey("MyBooking.Core.Entities.OfferDetails", "OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBooking.Core.Entities.OfferFollow", b =>
                {
                    b.HasOne("MyBooking.Core.Entities.Offer", "Offer")
                        .WithMany("OfferFollows")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBooking.Core.Entities.User", "User")
                        .WithMany("OfferFollows")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBooking.Core.Entities.OfferPhoto", b =>
                {
                    b.HasOne("MyBooking.Core.Entities.Offer", "Offer")
                        .WithMany("OfferPhotos")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBooking.Core.Entities.OfferRate", b =>
                {
                    b.HasOne("MyBooking.Core.Entities.Opinion", "Opinion")
                        .WithOne("OfferRate")
                        .HasForeignKey("MyBooking.Core.Entities.OfferRate", "OpinionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBooking.Core.Entities.User", "User")
                        .WithMany("OfferRates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBooking.Core.Entities.Opinion", b =>
                {
                    b.HasOne("MyBooking.Core.Entities.Offer", "Offer")
                        .WithMany("Opinions")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBooking.Core.Entities.User", "User")
                        .WithMany("Opinions")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MyBooking.Core.Entities.Token", b =>
                {
                    b.HasOne("MyBooking.Core.Entities.User", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyBooking.Core.Entities.UserRole", b =>
                {
                    b.HasOne("MyBooking.Core.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBooking.Core.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
