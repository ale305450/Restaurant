using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.Order;
using Restaurant.Application.Features.Orders.Requests.Commands;
using Restaurant.Application.Features.Orders.Requests.Queries;
using Restaurant.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> Get()
        {
            var orders = await _mediator.Send(new GetOrderListRequest());
            return Ok(orders);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> Get(int id)
        {
            var order = await _mediator.Send(new GetOrderDetailRequest { Id = id });
            return Ok(order);
        }

        // POST api/<OrderController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateOrderDto orderDto)
        {
            var command = await _mediator.Send(new CreateOrderCommand { CreateOrderDto = orderDto });
            return Ok(command);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put(int id, [FromBody] UpdateOrderDto orderDto)
        {
            var command = await _mediator.Send(new UpdateOrderCommand { Id = id, UpdateOrderDto = orderDto });
            return Ok(command);
        }
        // PUT api/<OrderController>/changestatus/5
        [HttpPut("changestatus/{id}")]
        public async Task<ActionResult> ChangeStatus(int id, [FromBody] ChangeOrderStatusDto orderStatusDto)
        {
            var status = await _mediator.Send(new UpdateOrderCommand { Id = id, ChangeOrderStatusDto = orderStatusDto });
            return Ok(status);
        }
        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteOrderCommand { Id = id });
            return NoContent();
        }
    }
}
