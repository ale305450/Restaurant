using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.Review;
using Restaurant.Application.Features.Reviews.Requests.Commands;
using Restaurant.Application.Features.Reviews.Requests.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly Mediator _mediator;

        public ReviewController(Mediator mediator)
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
        public async Task<ActionResult> Post([FromBody] CreateReviewDto reviewDto)
        {
            var command = await _mediator.Send(new CreateReviewCommand { CreateReviewDto = reviewDto });
            return Ok(command);
        }

        // PUT api/<ReviewController>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateReviewDto reviewDto)
        {
            var command = await _mediator.Send(new UpdateReviewCommand { UpdateReviewDto = reviewDto });
            return Ok(command);
        }
    }
}
