using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBooking.Core.Models.Domain;

namespace MyBooking.Infrastructure.Database.Configs
{
    public class BookingOrderDetailsConfig : IEntityTypeConfiguration<BookingOrderDetails>
    {
        public void Configure(EntityTypeBuilder<BookingOrderDetails> builder)
        {
            builder.HasOne(b => b.Booking)
                    .WithMany(b => b.BookingOrderDetails)
                    .HasForeignKey(b => b.BookingId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Order)
                    .WithOne(o => o.OrderDetails)
                    .HasForeignKey<BookingOrderDetails>(b => b.OrderId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}