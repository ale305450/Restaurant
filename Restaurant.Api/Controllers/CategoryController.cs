using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.Category;
using Restaurant.Application.Features.Categories.Requests.Commands;
using Restaurant.Application.Features.Categories.Requests.Queries;
using Restaurant.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> Get()
        {
            var Categories = await _mediator.Send(new GetCategoryListRequest());
            return Ok(Categories);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var Category = await _mediator.Send(new GetCategoryDetailRequest { Id = id });
            return Ok(Category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCategoryDto category)
        {
            var command = await _mediator.Send(new CreateCategoryCommand { CreateCategoryDto = category });
            return Ok(command);
        }

        // PUT api/<CategoryController>
        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Put(int id, [FromBody] UpdateCategoryDto category)
        {
            var command = await _mediator.Send(new UpdateCategoryCommand { Id = id,UpdateCategoryDto = category });
            return Ok(command);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCategoryCommand { Id = id });
            return NoContent();
        }
    }
}
