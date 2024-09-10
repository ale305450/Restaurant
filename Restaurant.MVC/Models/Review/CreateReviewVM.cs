namespace Restaurant.MVC.Models.Review
{
    public class CreateReviewVM
    {
        public int UserId { get; set; }
        public int MenuItemId { get; set; }
        public int Rating { get; set; }
    }
}
