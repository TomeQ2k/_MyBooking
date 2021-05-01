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
    [Migration("20210118151953_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MyBooking.Core.Models.Domain.BookedDate", b =>
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

            modelBuilder.Entity("MyBooking.Core.Models.Domain.Offer", b =>
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

            modelBuilder.Entity("MyBooking.Core.Models.Domain.OfferDetails", b =>
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

            modelBuilder.Entity("MyBooking.Core.Models.Domain.OfferFollow", b =>
                {
                    b.Property<string>("OfferId")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("OfferId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("OfferFollows");
                });

            modelBuilder.Entity("MyBooking.Core.Models.Domain.OfferPhoto", b =>
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

            modelBuilder.Entity("MyBooking.Core.Models.Domain.OfferRate", b =>
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

            modelBuilder.Entity("MyBooking.Core.Models.Domain.Opinion", b =>
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

            modelBuilder.Entity("MyBooking.Core.Models.Domain.Token", b =>
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

            modelBuilder.Entity("MyBooking.Core.Models.Domain.User", b =>
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

            modelBuilder.Entity("MyBooking.Core.Models.Domain.BookedDate", b =>
                {
                    b.HasOne("MyBooking.Core.Models.Domain.Offer", "Offer")
                        .WithMany("BookedDates")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBooking.Core.Models.Domain.User", "User")
                        .WithMany("BookedDates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("MyBooking.Core.Models.Domain.Offer", b =>
                {
                    b.HasOne("MyBooking.Core.Models.Domain.User", "Creator")
                        .WithMany("Offers")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBooking.Core.Models.Domain.OfferDetails", b =>
                {
                    b.HasOne("MyBooking.Core.Models.Domain.Offer", "Offer")
                        .WithOne("OfferDetails")
                        .HasForeignKey("MyBooking.Core.Models.Domain.OfferDetails", "OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBooking.Core.Models.Domain.OfferFollow", b =>
                {
                    b.HasOne("MyBooking.Core.Models.Domain.Offer", "Offer")
                        .WithMany("OfferFollows")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBooking.Core.Models.Domain.User", "User")
                        .WithMany("OfferFollows")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBooking.Core.Models.Domain.OfferPhoto", b =>
                {
                    b.HasOne("MyBooking.Core.Models.Domain.Offer", "Offer")
                        .WithMany("OfferPhotos")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBooking.Core.Models.Domain.OfferRate", b =>
                {
                    b.HasOne("MyBooking.Core.Models.Domain.Opinion", "Opinion")
                        .WithOne("OfferRate")
                        .HasForeignKey("MyBooking.Core.Models.Domain.OfferRate", "OpinionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBooking.Core.Models.Domain.User", "User")
                        .WithMany("OfferRates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBooking.Core.Models.Domain.Opinion", b =>
                {
                    b.HasOne("MyBooking.Core.Models.Domain.Offer", "Offer")
                        .WithMany("Opinions")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBooking.Core.Models.Domain.User", "User")
                        .WithMany("Opinions")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MyBooking.Core.Models.Domain.Token", b =>
                {
                    b.HasOne("MyBooking.Core.Models.Domain.User", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
