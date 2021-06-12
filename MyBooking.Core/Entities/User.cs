using System;
using System.Collections.Generic;
using MyBooking.Core.Helpers;

namespace MyBooking.Core.Entities
{
    public class User
    {
        public string Id { get; protected set; } = Utils.Id();
        public string Username { get; protected set; }
        public string Email { get; protected set; }
        public string PasswordHash { get; protected set; }
        public string PasswordSalt { get; protected set; }
        public DateTime DateRegistered { get; protected set; } = DateTime.Now;
        public bool EmailConfirmed { get; protected set; }

        public virtual ICollection<Offer> Offers { get; protected set; } = new HashSet<Offer>();
        public virtual ICollection<BookedDate> BookedDates { get; protected set; } = new HashSet<BookedDate>();
        public virtual ICollection<Opinion> Opinions { get; protected set; } = new HashSet<Opinion>();
        public virtual ICollection<OfferFollow> OfferFollows { get; protected set; } = new HashSet<OfferFollow>();
        public virtual ICollection<OfferRate> OfferRates { get; protected set; } = new HashSet<OfferRate>();
        public virtual ICollection<BookingCartItem> BookingCartItems { get; protected set; } = new HashSet<BookingCartItem>();
        public virtual ICollection<Token> Tokens { get; protected set; } = new HashSet<Token>();
        public virtual ICollection<UserRole> UserRoles { get; protected set; } = new HashSet<UserRole>();

        public void SetUsername(string username)
        {
            Username = username;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public void SetPassword(string passwordHash, string passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        public void Confirm()
        {
            EmailConfirmed = true;
        }
    }
}