using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBooking.Core.Models.Domain;

namespace MyBooking.Infrastructure.Database.Configs
{
    public class OfferFollowConfig : IEntityTypeConfiguration<OfferFollow>
    {
        public void Configure(EntityTypeBuilder<OfferFollow> builder)
        {
            builder.HasKey(or => new { or.OfferId, or.UserId });

            builder.HasOne(of => of.Offer)
                    .WithMany(o => o.OfferFollows)
                    .HasForeignKey(of => of.OfferId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(of => of.User)
                    .WithMany(u => u.OfferFollows)
                    .HasForeignKey(of => of.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}