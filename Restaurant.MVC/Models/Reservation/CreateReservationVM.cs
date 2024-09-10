namespace Restaurant.MVC.Models.Reservation
{
    public class CreateReservationVM
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int NumGuests { get; set; }
        public string Status { get; set; }
    }
}
