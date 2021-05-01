using MyBooking.Core.Enums;

namespace MyBooking.Core.Models.Helpers
{
    public class Alert
    {
        public AlertType Type { get; }
        public string Message { get; }

        public Alert(AlertType type, string message)
        {
            Type = type;
            Message = message;
        }
    }
}