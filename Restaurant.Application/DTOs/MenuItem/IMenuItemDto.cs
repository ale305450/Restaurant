using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.MenuItem
{
    public interface IMenuItemDto 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
