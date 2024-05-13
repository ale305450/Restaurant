using MediatR;
using Restaurant.Application.DTOs.BlogPost;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.BlogPosts.Requests.Queries
{
    public class GetBlogPostListRequest : IRequest<List<BlogPostDto>>
    {
    }
}
