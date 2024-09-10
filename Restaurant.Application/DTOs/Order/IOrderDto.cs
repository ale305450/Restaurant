using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.Order
{
    public interface IOrderDto
    {
        public string UserId { get; set; }
        public string Status { get; set; }

    }
}
