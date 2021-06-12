using System;
using System.Threading.Tasks;
using MyBooking.Core.Data.Repositories;
using MyBooking.Core.Entities;

namespace MyBooking.Core.Data
{
    public interface IDatabase : IDisposable
    {
        IRepository<User> UserRepository { get; }
        IOfferRepository OfferRepository { get; }
        IRepository<BookedDate> BookedDateRepository { get; }
        IRepository<Opinion> OpinionRepository { get; }
        IRepository<OfferRate> OfferRateRepository { get; }
        IRepository<OfferFollow> OfferFollowRepository { get; }
        IRepository<OfferPhoto> OfferPhotoRepository { get; }
        IRepository<BookingCartItem> BookingCartItemRepository { get; }
        IRepository<BookingOrder> BookingOrderRepository { get; }
        IRepository<BookingOrderDetails> BookingOrderDetailsRepository { get; }
        IRepository<Token> TokenRepository { get; }
        IRepository<Role> RoleRepository { get; }
        IRepository<UserRole> UserRoleRepository { get; }

        Task<bool> Complete();
    }
}