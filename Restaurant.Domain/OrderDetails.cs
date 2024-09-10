using Restaurant.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain
{
    public class OrderDetails : BaseDomainEntity
    {
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }

    }
}
