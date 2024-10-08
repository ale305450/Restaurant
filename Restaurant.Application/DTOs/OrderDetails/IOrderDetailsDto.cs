﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.DTOs.OrderDetails
{
    public interface IOrderDetailsDto
    {
        public int MenuItemId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
    }
}
