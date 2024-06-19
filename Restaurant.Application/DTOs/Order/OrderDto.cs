using Restaurant.Application.DTOs.Common;
using Restaurant.Application.DTOs.MenuItem;
using Restaurant.Application.DTOs.User;
using Restaurant.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.Order
{
    public class OrderDto : BaseDto
    {
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public int MenuItemId { get; set; }
        public CreateMenuItemDto MenuItem { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; }

    }
}
