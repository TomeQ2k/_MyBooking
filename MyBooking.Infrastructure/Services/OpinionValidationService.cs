using System;
using System.Linq;
using MyBooking.Core.Data;
using MyBooking.Core.Entities;
using MyBooking.Core.Services;

namespace MyBooking.Infrastructure.Services
{
    public class OpinionValidationService : BaseValidationService, IOpinionValidationService
    {
        public OpinionValidationService(IDatabase database) : base(database) { }

        public bool UserOpinionExists(User user, string offerId)
            => user != null ? user.Opinions.Any(o => o.OfferId == offerId) : throw new ArgumentNullException();
    }
}