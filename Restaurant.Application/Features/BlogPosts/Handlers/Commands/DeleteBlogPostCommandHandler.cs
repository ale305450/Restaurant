using AutoMapper;
using MediatR;
using Restaurant.Application.Exceptions;
using Restaurant.Application.Features.BlogPosts.Requests.Commands;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Restaurant.Application.Responses;

namespace Restaurant.Application.Features.BlogPosts.Handlers.Commands
{
    public class DeleteBlogPostCommandHandler : IRequestHandler<DeleteBlogPostCommand, BaseCommandResponse>
    {
        private readonly IBlogPostRepository _blogPostRepository;
        public DeleteBlogPostCommandHandler(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }
        public async Task<BaseCommandResponse> Handle(DeleteBlogPostCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var blogPost = await _blogPostRepository.Get(request.Id);

            if (blogPost == null)
                throw new NotFoundException(nameof(BlogPost), request.Id);

            await _blogPostRepository.Delete(blogPost);

            response.Success = true;
            response.Message = "User Deleted successfully";
            response.Id = blogPost.Id;

            return response;
        }
    }
}
