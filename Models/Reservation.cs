namespace BookingSystem_web_api.Models
{
    public class Reservation
    {
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
