using MediatR;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.Categories.Requests.Commands
{
    public class DeleteCategoryCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
