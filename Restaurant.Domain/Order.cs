using Restaurant.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain
{
    public class Order: BaseDomainEntity
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string Status { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
