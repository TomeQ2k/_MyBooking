namespace MyBooking.Core.Models.Dtos
{
    public class BookingCartItemDto
    {
        public string Id { get; set; }
        public string BookingCartId { get; set; }
        public string BookedDateId { get; set; }
        public string UserId { get; set; }

        public BookedDateDto BookedDate { get; set; }
    }
}