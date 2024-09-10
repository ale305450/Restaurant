using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.BlogPost;
using Restaurant.Application.Features.BlogPosts.Requests.Commands;
using Restaurant.Application.Features.BlogPosts.Requests.Queries;
using Restaurant.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogPostController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<BlogPostController>
        [HttpGet]
        public async Task<ActionResult<List<BlogPostDto>>> Get()
        {
            var blogPosts = await _mediator.Send(new GetBlogPostListRequest());
            return Ok(blogPosts);
        }

        // GET api/<BlogPostController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPostDto>> Get(int id)
        {
            var blogPost = await _mediator.Send(new GetBlogPostDetailRequest { Id = id });
            return Ok(blogPost);
        }

        // POST api/<BlogPostController>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBlogPostDto blogPost)
        {
            var command = await _mediator.Send(new CreateBlogPostCommand { CreateBlogPostDto = blogPost });
            return Ok(command);
        }

        // PUT api/<BlogPostController>
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<BaseCommandResponse>> Put(int id,[FromBody] UpdateBlogPostDto blogPost)
        {
            var command = await _mediator.Send(new UpdateBlogPostCommand { Id = id ,UpdateBlogPostDto = blogPost });
            return Ok(command);
        }

        // DELETE api/<BlogPostController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteBlogPostCommand { Id = id });
            return NoContent();
        }
    }
}
