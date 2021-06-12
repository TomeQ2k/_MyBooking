using System;
using MyBooking.Core.Enums;
using MyBooking.Core.Helpers;

namespace MyBooking.Core.Entities
{
    public class Token
    {
        public string Id { get; protected set; } = Utils.Id();
        public string Code { get; protected set; } = Utils.Token();
        public DateTime DateCreated { get; protected set; } = DateTime.Now;
        public TokenType TokenType { get; protected set; }
        public string UserId { get; protected set; }

        public virtual User User { get; protected set; }

        public static Token Create(TokenType tokenType)
            => new Token { TokenType = tokenType };
    }
}