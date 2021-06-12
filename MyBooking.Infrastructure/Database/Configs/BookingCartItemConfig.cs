using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBooking.Core.Entities;

namespace MyBooking.Infrastructure.Database.Configs
{
    public class BookingCartItemConfig : IEntityTypeConfiguration<BookingCartItem>
    {
        public void Configure(EntityTypeBuilder<BookingCartItem> builder)
        {
            builder.HasOne(b => b.BookedDate)
                    .WithOne(b => b.BookingCartItem)
                    .HasForeignKey<BookingCartItem>(b => b.BookedDateId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}