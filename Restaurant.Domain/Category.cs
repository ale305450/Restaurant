using Restaurant.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain
{
    public class Category : BaseDomainEntity
    {
        public string Name { get; set; }

        public ICollection<MenuItem> MenuItem { get; set; }
    }
}
