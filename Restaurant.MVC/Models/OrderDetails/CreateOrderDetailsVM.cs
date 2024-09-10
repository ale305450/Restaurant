namespace Restaurant.MVC.Models.OrderDetails
{
    public class CreateOrderDetailsVM
    {
        public int MenuItemId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
    }
}
