using MediatR;
using Restaurant.Application.DTOs.BlogPost;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.BlogPosts.Requests.Queries
{
    public class GetBlogPostDetailRequest : IRequest<BlogPostDto>
    {
        public int Id { get; set; }
    }
}
