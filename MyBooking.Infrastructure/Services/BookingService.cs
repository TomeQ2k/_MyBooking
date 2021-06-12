using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBooking.Core.Data;
using MyBooking.Core.Enums;
using MyBooking.Core.Entities;
using MyBooking.Core.Models;
using MyBooking.Core.Services;
using MyBooking.Core.Services.ReadOnly;

namespace MyBooking.Infrastructure.Services
{
    public class BookingService : IBookingService
    {
        private readonly IDatabase database;
        private readonly IBookingValidationService bookingValidationService;
        private readonly IReadOnlyProfileService profileService;

        public BookingService(IDatabase database, IBookingValidationService bookingValidationService, IReadOnlyProfileService profileService)
        {
            this.database = database;
            this.bookingValidationService = bookingValidationService;
            this.profileService = profileService;
        }

        public async Task<BookedDate> GetBookedDate(string bookedDateId)
            => await database.BookedDateRepository.Get(bookedDateId);

        public async Task<IEnumerable<BookedDate>> GetBookedDates(string currentUserId)
            => await database.BookedDateRepository.Filter(bd => (bd.UserId == currentUserId && bd.Offer.CreatorId != currentUserId) || bd.Offer.CreatorId == currentUserId);

        public async Task<BookedDate> BookDate(DateTime startDate, DateTime endDate, string offerId)
        {
            var offer = await database.OfferRepository.Get(offerId);

            if (offer == null)
                return null;

            var currentUser = await profileService.GetCurrentUser();

            if (currentUser.Id == offer.CreatorId)
            {
                Alertify.Push("You are owner of this offer", AlertType.Warning);
                return null;
            }

            if (!bookingValidationService.IsBookingDateAvailable(startDate, endDate, offer))
            {
                Alertify.Push("This date is already booked", AlertType.Warning);
                return null;
            }

            if (currentUser != null && bookingValidationService.HasUserAnotherBookedDate(currentUser, offer.Id))
            {
                Alertify.Push("You have already booked this offer", AlertType.Warning);
                return null;
            }

            var bookedDate = BookedDate.Create(startDate, endDate);

            offer.BookedDates.Add(bookedDate);

            if (currentUser != null)
                currentUser.BookedDates.Add(bookedDate);

            return await database.Complete() ? bookedDate : null;
        }

        public async Task<bool> CancelBooking(string bookedDateId)
        {
            var bookedDate = await GetBookedDate(bookedDateId);

            if (bookedDate == null)
                return false;

            var currentUser = await profileService.GetCurrentUser();

            if (!bookingValidationService.IsPermittedToCancelBooking(bookedDate, currentUser?.Id))
                return false;

            database.BookedDateRepository.Delete(bookedDate);

            return await database.Complete();
        }

        public IEnumerable<BookedDate> ConfirmBookings(IEnumerable<BookedDate> bookedDates)
        {
            foreach (var bookedDate in bookedDates)
                bookedDate.Confirm();

            database.BookedDateRepository.UpdateRange(bookedDates);

            return bookedDates;
        }
    }
}