using Restaurant.Application.DTOs.Common;
using Restaurant.Application.DTOs.MenuItem;
using Restaurant.Application.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.DTOs.OrderDetails
{
    public class OrderDetailsDto :BaseDto
    {
        public int MenuItemId { get; set; }
        public MenuItemDto MenuItem { get; set; }
        public int OrderId { get; set; }
        public OrderDto Order { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
    }
}
