using Restaurant.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain
{
    public class Order: BaseDomainEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; }

    }
}
