using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBooking.Core.Models.Domain;

namespace MyBooking.Infrastructure.Database.Configs
{
    public class OfferConfig : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasOne(o => o.OfferDetails)
                    .WithOne(od => od.Offer)
                    .HasForeignKey<OfferDetails>(od => od.OfferId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.Creator)
                    .WithMany(c => c.Offers)
                    .HasForeignKey(o => o.CreatorId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.Opinions)
                    .WithOne(c => c.Offer)
                    .HasForeignKey(c => c.OfferId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.BookedDates)
                    .WithOne(b => b.Offer)
                    .HasForeignKey(b => b.OfferId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.OfferFollows)
                    .WithOne(of => of.Offer)
                    .HasForeignKey(of => of.OfferId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.OfferPhotos)
                    .WithOne(op => op.Offer)
                    .HasForeignKey(op => op.OfferId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.BookingOrderDetails)
                    .WithOne(b => b.Offer)
                    .HasForeignKey(b => b.OfferId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}