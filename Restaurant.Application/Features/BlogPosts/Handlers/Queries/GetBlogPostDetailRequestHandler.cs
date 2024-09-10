using AutoMapper;
using MediatR;
using Restaurant.Application.DTOs.BlogPost;
using Restaurant.Application.Features.BlogPosts.Requests.Queries;
using Restaurant.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.BlogPosts.Handlers.Queries
{
    public class GetBlogPostDetailRequestHandler : IRequestHandler<GetBlogPostDetailRequest, BlogPostDto>
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;

        public GetBlogPostDetailRequestHandler(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
        }
        public async Task<BlogPostDto> Handle(GetBlogPostDetailRequest request, CancellationToken cancellationToken)
        {
            var blogPost = await _blogPostRepository.Get(request.Id);
            return _mapper.Map<BlogPostDto>(blogPost);
        }
    }
}
