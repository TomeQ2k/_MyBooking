using System;
using MyBooking.Core.Enums;
using MyBooking.Core.Entities;
using MyBooking.Core.Models;

namespace MyBooking.Core.Helpers
{
    public static class Constants
    {
        #region values

        public const int MinUsernameLength = 5;
        public const int MaxUserNameLength = 24;
        public const int MinPasswordLength = 5;
        public const int MaxPasswordLength = 30;

        public const int MaxTitleLength = 100;
        public const int MaxDescriptionLength = 1500;
        public const int MaxOpinionLength = 1000;
        public const int MaxLocationLength = 100;
        public const int MaxRoomsCount = 6;
        public const decimal MaxPrice = 5000;
        public const int MaxPhotosCount = 10;
        public const int MaxOffersCount = 100;
        public const int MaxPersonsCount = 12;

        public const int MaxBookingDateAdvance = 1;

        public const int DailyHostedServiceTimeInDays = 1;
        public const int BookingHostedServiceTimeInMinutes = 30;

        public const int TokenExpirationTimeInDays = 7;

        public const int Minus = -1;

        public const string LogFilesPath = "./wwwroot/logs/log-.txt";

        #endregion

        #region session

        public const string CartId = "CartId";

        #endregion

        #region roles

        public const string AdminRole = "Admin";

        public static RoleType[] RolesToSeed = { RoleType.User, RoleType.Admin };

        #endregion

        #region cookies

        public const string AuthCookiesDefaultScheme = "Cookies";
        public const string AuthCookieName = "AuthCookie";

        #endregion

        #region policies

        public const string AdminPolicy = "AdminPolicy";

        #endregion

        #region orders

        public static string BookingOrderDescription(BookingOrderDetails orderDetails, decimal totalPrice)
            => $"User {(string.IsNullOrEmpty(orderDetails.CustomerEmail) ? "ANONYMOUS" : orderDetails.CustomerEmail)}" +
               $" booked offer #{orderDetails.OfferId} from: {totalPrice} $";

        #endregion

        #region viewData

        public const string ActionName = "ActionName";
        public const string PageNumber = "PageNumber";

        #endregion

        #region emails

        public static EmailMessage ActivationAccountEmail(string email, string callbackUrl)
                => new EmailMessage(
                    email: email,
                    subject: "MyBooking - activate your account",
                    message: $"<p>Hi <strong>{email}</strong>!</p><br><br>" +
                        $"<p>In order to activate your account on MyBooking, click link below.<br><br>" +
                        $"Activation account link: <a href='{callbackUrl}'>LINK</a></p>" +
                        "<p>Best regards,<br>" +
                        "MyBooking team</p>"
        );

        public static EmailMessage ResetPasswordEmail(string email, string username, string callbackUrl)
         => new EmailMessage(
             email: email,
             subject: "MyBooking - reset password",
             message: $"<p>Hi <strong>{username}</strong>!</p>" +
                 $"<p>In order to reset your password on MyBooking, click link below.<br><br>" +
                 $"Reset password link: <a href='{callbackUrl}'>LINK</a></p>" +
                 "<p>Best regards,<br>" +
                 "MyBooking team</p>"
        );

        public static EmailMessage EmailChangeEmail(string email, string callbackUrl)
          => new EmailMessage(
              email: email,
              subject: "MyBooking - change email",
              message: $"<p>Hi <strong>{email}</strong>!</p><br><br>" +
                  $"<p>In order to change your email on MyBooking, click link below.<br><br>" +
                  $"Change email link: <a href='{callbackUrl}'>LINK</a></p>" +
                  "<p>Best regards,<br>" +
                  "MyBooking team</p>"
       );

        public static EmailMessage OrderCompletedEmail(string customerEmail, string orderId, string bookingId, string offerTitle,
            decimal totalPrice, DateTime startDate, DateTime endDate, string phone, string contactEmail, string location)
          => new EmailMessage(
              email: customerEmail,
              subject: "MyBooking - order completed",
              message: $"<p>Hi <strong>{customerEmail}</strong>!</p><br>" +
                  $"<p>Your order #{orderId} has completed. Booking #{bookingId} has been confirmed.<br>Order details:<br>" +
                  $"Offer: {offerTitle}<br>From: {startDate.ToShortDateString()}<br>To: {endDate.ToShortDateString()}<br>Total price: {totalPrice} $<br>" +
                  $"Address: {location}<br>Phone: {phone}<br>Email: {contactEmail}<br><br>" +
                  $"You can still cancel your booking in MyBookings section.</p>" +
                  "<p>Best regards,<br>" +
                  "MyBooking team</p>"
        );

        #endregion
    }
}