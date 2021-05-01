using System.Threading.Tasks;
using MyBooking.Core.Data;
using MyBooking.Core.Data.Repositories;
using MyBooking.Core.Models.Domain;
using MyBooking.Infrastructure.Database.Repositories;

namespace MyBooking.Infrastructure.Database
{
    public class Database : IDatabase
    {
        private readonly DataContext context;

        public Database(DataContext context)
        {
            this.context = context;
        }

        #region repositories

        private IRepository<User> userRepository;
        public IRepository<User> UserRepository => userRepository ?? new Repository<User>(context);

        private IOfferRepository offerRepository;
        public IOfferRepository OfferRepository => offerRepository ?? new OfferRepository(context);

        private IRepository<BookedDate> bookedDateRepository;
        public IRepository<BookedDate> BookedDateRepository => bookedDateRepository ?? new Repository<BookedDate>(context);

        private IRepository<Opinion> opinionRepository;
        public IRepository<Opinion> OpinionRepository => opinionRepository ?? new Repository<Opinion>(context);

        private IRepository<OfferRate> offerRateRepository;
        public IRepository<OfferRate> OfferRateRepository => offerRateRepository ?? new Repository<OfferRate>(context);

        private IRepository<OfferFollow> offerFollowRepository;
        public IRepository<OfferFollow> OfferFollowRepository => offerFollowRepository ?? new Repository<OfferFollow>(context);

        private IRepository<OfferPhoto> offerPhotoRepository;
        public IRepository<OfferPhoto> OfferPhotoRepository => offerPhotoRepository ?? new Repository<OfferPhoto>(context);

        private IRepository<BookingCartItem> bookingCartItemRepository;
        public IRepository<BookingCartItem> BookingCartItemRepository => bookingCartItemRepository ?? new Repository<BookingCartItem>(context);

        private IRepository<BookingOrder> bookingOrderRepository;
        public IRepository<BookingOrder> BookingOrderRepository => bookingOrderRepository ?? new Repository<BookingOrder>(context);

        private IRepository<BookingOrderDetails> bookingOrderDetailsRepository;
        public IRepository<BookingOrderDetails> BookingOrderDetailsRepository => bookingOrderDetailsRepository ?? new Repository<BookingOrderDetails>(context);

        private IRepository<Token> tokenRepository;
        public IRepository<Token> TokenRepository => tokenRepository ?? new Repository<Token>(context);

        private IRepository<Role> roleRepository;
        public IRepository<Role> RoleRepository => roleRepository ?? new Repository<Role>(context);

        private IRepository<UserRole> userRoleRepository;
        public IRepository<UserRole> UserRoleRepository => userRoleRepository ?? new Repository<UserRole>(context);

        #endregion

        public async Task<bool> Complete()
            => await context.SaveChangesAsync() > 0;

        public void Dispose()
        {
            context.Dispose();
        }
    }
}