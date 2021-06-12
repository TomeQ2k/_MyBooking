using System;
using System.Linq;
using AutoMapper;
using MyBooking.Core.Helpers;
using MyBooking.Core.Entities;
using MyBooking.Core.Dtos;

namespace MyBooking.Core.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Offer, OfferDto>()
                .ForMember(dest => dest.AvailableCount, opt => opt.MapFrom(o => o.GetAvailableCount(DateTime.Now, DateTime.Now)))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(o => o.GetRating()))
                .ForMember(dest => dest.FollowsCount, opt => opt.MapFrom(o => o.OfferFollows.Count));
            CreateMap<Offer, OfferListDto>()
                .ForMember(dest => dest.AvailableCount, opt => opt.MapFrom(o => o.GetAvailableCount(DateTime.Now, DateTime.Now)))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(o => o.GetRating()))
                .ForMember(dest => dest.PersonsCount, opt => opt.MapFrom(o => o.OfferDetails.PersonsCount))
                .ForMember(dest => dest.FollowsCount, opt => opt.MapFrom(o => o.OfferFollows.Count))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(o => o.OfferDetails.PhoneNumber))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(o => o.OfferDetails.EmailAddress))
                .ForMember(dest => dest.FirstPhotoUrl, opt => opt.MapFrom(o => o.GetFirstPhotoUrl()));
            CreateMap<CreateOfferDto, Offer>()
                .ForMember(dest => dest.OfferPhotos, opt => opt.Ignore());
            CreateMap<Offer, EditOfferDto>()
                .ForMember(dest => dest.OfferPhotos, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.OfferPhotos, opt => opt.Ignore());
            CreateMap<OfferDto, OfferListDto>()
                .ForMember(dest => dest.PersonsCount, opt => opt.MapFrom(o => o.OfferDetails.PersonsCount))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(o => o.OfferDetails.PhoneNumber))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(o => o.OfferDetails.EmailAddress))
                .ForMember(dest => dest.FirstPhotoUrl, opt => opt.MapFrom(o => o.OfferPhotos.Any() ? o.OfferPhotos.FirstOrDefault().Url : null));
            CreateMap<Offer, MyOfferDto>()
                .ForMember(dest => dest.AvailableCount, opt => opt.MapFrom(o => o.GetAvailableCount(DateTime.Now, DateTime.Now)))
                .ForMember(dest => dest.BookedDatesCount, opt => opt.MapFrom(o => o.BookedDates.Count))
                .ForMember(dest => dest.FirstPhotoUrl, opt => opt.MapFrom(o => o.GetFirstPhotoUrl()));

            CreateMap<OfferDetailsDto, OfferDetails>()
                .ReverseMap();

            CreateMap<Opinion, OpinionDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(o => o.User.Username))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(o => o.OfferRate.Rating));

            CreateMap<OfferPhoto, OfferPhotoDto>()
                .ForMember(dest => dest.Url, opt => opt.MapFrom(op => StorageLocation.BuildLocation(op.Path)));

            CreateMap<BookedDate, BookedDateDto>()
                .ForMember(dest => dest.OfferTitle, opt => opt.MapFrom(bd => bd.Offer.Title))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(bd => bd.GetTotalPrice()))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(bd => bd.Offer.Location));

            CreateMap<OfferFollow, OfferFollowDto>();

            CreateMap<BookingCartItem, BookingCartItemDto>();

            CreateMap<BookingOrder, BookingOrderDto>()
                .ForMember(dest => dest.BookingId, opt => opt.MapFrom(o => o.OrderDetails.BookingId))
                .ForMember(dest => dest.OfferId, opt => opt.MapFrom(o => o.OrderDetails.OfferId));
        }
    }
}