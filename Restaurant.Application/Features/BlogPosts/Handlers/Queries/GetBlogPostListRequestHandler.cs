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
    internal class GetBlogPostListRequestHandler : IRequestHandler<GetBlogPostListRequest, List<BlogPostDto>>
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;

        public GetBlogPostListRequestHandler(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
        }
        public async Task<List<BlogPostDto>> Handle(GetBlogPostListRequest request, CancellationToken cancellationToken)
        {
            var blogPosts = await _blogPostRepository.GetAll();
            return _mapper.Map<List<BlogPostDto>>(blogPosts);
        }
    }
}
