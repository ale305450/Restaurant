using MediatR;
using Restaurant.Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.Categories.Requests.Queries
{
    public class GetCategoryDetailRequest :IRequest<CategoryDto>
    {
        public int Id { get; set; }
    }
}
