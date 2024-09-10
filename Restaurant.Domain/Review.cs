using Restaurant.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain
{
    public class Review: BaseDomainEntity
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int Rating { get; set; }
    }
}
