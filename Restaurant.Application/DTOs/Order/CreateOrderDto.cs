using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.Order
{
    public class CreateOrderDto : IOrderDto
    {
        public int UserId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
    }
}
