using Restaurant.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.Order
{
    public class ChangeOrderStatusDto :BaseDto
    {
        public string Status { get; set; }
    }
}
