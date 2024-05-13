using MediatR;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.BlogPosts.Requests.Commands
{
    public class DeleteBlogPostCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
