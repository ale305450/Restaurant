using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.Review;
using Restaurant.Application.Features.Reviews.Requests.Commands;
using Restaurant.Application.Features.Reviews.Requests.Queries;
using Restaurant.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<ReviewController>
        [HttpGet]
        public async Task<ActionResult<List<ReviewDto>>> Get()
        {
            var reviews = await _mediator.Send(new GetReviewListRequest());
            return Ok(reviews);
        }

        // GET api/<ReviewController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDto>> Get(int id)
        {
            var reviews = await _mediator.Send(new GetReviewDetailRequest { Id = id });
            return Ok(reviews);
        }

        // POST api/<ReviewController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateReviewDto reviewDto)
        {
            var command = await _mediator.Send(new CreateReviewCommand { CreateReviewDto = reviewDto });
            return Ok(command);
        }

        // PUT api/<ReviewController>
        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Put(int id, [FromBody] UpdateReviewDto reviewDto)
        {
            var command = await _mediator.Send(new UpdateReviewCommand { Id = id,UpdateReviewDto = reviewDto });
            return Ok(command);
        }
    }
}
