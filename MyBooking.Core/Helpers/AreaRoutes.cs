using System.Collections.Generic;

namespace MyBooking.Core.Helpers
{
    public static class AreaRoutes
    {
        private static Dictionary<string, string> Routes = new Dictionary<string, string>
        {
            { AuthArea, "/" }, { BookingsArea, "/" }, { OffersArea, "/" }, { ProfileArea, "/" },
            { CartArea ,"/" }, { OrdersArea, "/" }, { StatsArea, "/" }
        };

        #region keys

        public const string AuthArea = "Auth";
        public const string BookingsArea = "Bookings";
        public const string OffersArea = "Offers";
        public const string ProfileArea = "Profile";
        public const string CartArea = "Cart";
        public const string OrdersArea = "Orders";
        public const string StatsArea = "Stats";

        #endregion

        public static string Route(string key) => Routes[key];
    }
}