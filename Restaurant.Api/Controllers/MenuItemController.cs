using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.MenuItem;
using Restaurant.Application.Features.MenuItems.Requests.Commands;
using Restaurant.Application.Features.MenuItems.Requests.Queries;
using Restaurant.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuItemController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<MenuItemController>
        [HttpGet]
        public async Task<ActionResult<List<MenuItemDto>>> Get()
        {
            var items = await _mediator.Send(new GetMenuItemListRequest());
            return Ok(items);
        }

        // GET api/<MenuItemController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItemDto>> Get(int id)
        {
            var item = await _mediator.Send(new GetMenuItemDetaliRequest { Id = id });
            return Ok(item);
        }

        // POST api/<MenuItemController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateMenuItemDto itemDto)
        {
            var command = await _mediator.Send(new CreateMenuItemCommand { CreateMenuItemDto = itemDto });
            return Ok(command);
        }

        // PUT api/<MenuItemController>
        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] UpdateMenuItemDto itemDto)
        {
            var command = await _mediator.Send(new UpdateMenuItemCommand { UpdateMenuItemDto = itemDto });
            return Ok(command);
        }

        // DELETE api/<MenuItemController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteMenuItemCommand { Id = id });
            return NoContent();
        }
    }
}
