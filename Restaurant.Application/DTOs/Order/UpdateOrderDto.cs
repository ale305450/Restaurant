using Restaurant.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.Order
{
    public class UpdateOrderDto : BaseDto, IOrderDto
    {
        public int UserId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
    }
}
