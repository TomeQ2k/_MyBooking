using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBooking.Core.Models.Domain;

namespace MyBooking.Infrastructure.Database.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u => u.Username).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();

            builder.HasMany(u => u.Tokens)
                    .WithOne(t => t.User)
                    .HasForeignKey(t => t.UserId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.BookedDates)
                    .WithOne(bd => bd.User)
                    .HasForeignKey(bd => bd.UserId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(u => u.BookingCartItems)
                    .WithOne(b => b.User)
                    .HasForeignKey(b => b.UserId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.SetNull);
        }
    }
}