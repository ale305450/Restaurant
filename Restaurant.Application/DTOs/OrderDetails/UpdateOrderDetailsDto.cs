using Restaurant.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.DTOs.OrderDetails
{
    public class UpdateOrderDetailsDto : BaseDto, IOrderDetailsDto
    {
        public int MenuItemId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
    }
}
