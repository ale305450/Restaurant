﻿using Restaurant.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.DTOs.Category
{
    public class UpdateCategoryDto : BaseDto,ICategoryDto
    {
        public string Name { get; set; }
    }
}