using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBooking.Core.Entities;

namespace MyBooking.Infrastructure.Database.Configs
{
    public class OfferRateConfig : IEntityTypeConfiguration<OfferRate>
    {
        public void Configure(EntityTypeBuilder<OfferRate> builder)
        {
            builder.HasKey(or => new { or.OpinionId, or.UserId });

            builder.HasOne(or => or.Opinion)
                    .WithOne(o => o.OfferRate)
                    .HasForeignKey<OfferRate>(or => or.OpinionId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(or => or.User)
                    .WithMany(u => u.OfferRates)
                    .HasForeignKey(or => or.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}