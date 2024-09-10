using Restaurant.Application.DTOs.Category;
using Restaurant.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.MenuItem
{
    public class MenuItemDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
