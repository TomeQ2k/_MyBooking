using System;
using MyBooking.Core.Helpers;

namespace MyBooking.Core.Entities
{
    public abstract class BaseOrder
    {
        public string Id { get; protected set; } = Utils.Id();
        public DateTime DateCreated { get; protected set; } = DateTime.Now;
        public string Description { get; protected set; }
        public decimal TotalPrice { get; protected set; }
    }
}