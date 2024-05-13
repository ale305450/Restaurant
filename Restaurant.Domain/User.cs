using Restaurant.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain
{
    public class User : BaseDomainEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
