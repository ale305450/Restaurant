﻿using MediatR;
using Restaurant.Application.DTOs.Category;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.Categories.Requests.Commands
{
    public class UpdateCategoryCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
        public UpdateCategoryDto UpdateCategoryDto { get; set; }
    }
}