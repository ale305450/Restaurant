using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.DTOs.Category
{
    public class CreateCategoryDto : ICategoryDto
    {
        public string Name { get; set; }
    }
}
