using Microsoft.EntityFrameworkCore;
using MyBooking.Core.Models.Domain;
using MyBooking.Infrastructure.Database.Configs;

namespace MyBooking.Infrastructure.Database
{
    public class DataContext : DbContext
    {
        #region tables

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<OfferDetails> OfferDetails { get; set; }
        public virtual DbSet<BookedDate> BookedDates { get; set; }
        public virtual DbSet<Opinion> Opinions { get; set; }
        public virtual DbSet<OfferFollow> OfferFollows { get; set; }
        public virtual DbSet<OfferRate> OfferRates { get; set; }
        public virtual DbSet<OfferPhoto> OfferPhotos { get; set; }
        public virtual DbSet<BookingCartItem> BookingCartItems { get; set; }
        public virtual DbSet<BookingOrder> BookingOrders { get; set; }
        public virtual DbSet<BookingOrderDetails> BookingOrderDetails { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        #endregion

        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new UserConfig().Configure(modelBuilder.Entity<User>());

            new OfferConfig().Configure(modelBuilder.Entity<Offer>());
            new OfferRateConfig().Configure(modelBuilder.Entity<OfferRate>());
            new OfferFollowConfig().Configure(modelBuilder.Entity<OfferFollow>());

            new BookingCartItemConfig().Configure(modelBuilder.Entity<BookingCartItem>());

            new BookingOrderDetailsConfig().Configure(modelBuilder.Entity<BookingOrderDetails>());

            new UserRoleConfig().Configure(modelBuilder.Entity<UserRole>());
        }
    }
}