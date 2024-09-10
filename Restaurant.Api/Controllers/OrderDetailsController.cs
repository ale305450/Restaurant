using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.OrderDetails;
using Restaurant.Application.Features.OrdersDetails.Requests.Commands;
using Restaurant.Application.Features.OrdersDetails.Requests.Queries;
using Restaurant.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailsController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<ActionResult<List<OrderDetailsDto>>> GetAll(int id)
        {
            var OrdersDetails = await _mediator.Send(new GetOrderDetailsListRequest { Id = id});
            return Ok(OrdersDetails);
        }

        // GET api/<OrderDetailsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailsDto>> Get(int id)
        {
            var OrderDetails = await _mediator.Send(new GetOrderDetailsDetailRequest { Id = id });
            return Ok(OrderDetails);
        }

        // POST api/<OrderDetailsController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateOrderDetailsDto orderDetailsDto)
        {
            var command = await _mediator.Send(new CreateOrderDetailsCommand { CreateOrderDetailsDto = orderDetailsDto });
            return Ok(command);
        }

        // PUT api/<OrderDetailsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put(int id, [FromBody] UpdateOrderDetailsDto orderDetailsDto)
        {
            var command = await _mediator.Send(new UpdateOrderDetailsCommand { Id = id, UpdateOrderDetailsDto = orderDetailsDto });
            return Ok(command);
        }

        // DELETE api/<OrderDetailsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteOrderDetailsCommand { Id = id });
            return NoContent();
        }
    }
}
