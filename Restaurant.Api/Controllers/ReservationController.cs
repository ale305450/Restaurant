using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.Reservation;
using Restaurant.Application.Features.Reservations.Requests.Commands;
using Restaurant.Application.Features.Reservations.Requests.Queries;
using Restaurant.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<ReservationController>
        [HttpGet]
        public async Task<ActionResult<List<ReservationDto>>> Get()
        {
            var reservation = await _mediator.Send(new GetReservationListRequest());
            return Ok(reservation);
        }

        // GET api/<ReservationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDto>> Get(int id)
        {
            var reservation = await _mediator.Send(new GetReservationDetailRequest { Id = id });
            return Ok(reservation);
        }

        // POST api/<ReservationController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateReservationDto reservationDto)
        {
            var command = await _mediator.Send(new CreateReservationCommand { CreateReservationDto = reservationDto });
            return Ok(command);
        }

        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put(int id, [FromBody] UpdateReservationDto reservationDto)
        {
            var command = await _mediator.Send(new UpdateReservationCommand { Id = id, UpdateReservationDto = reservationDto });
            return Ok(command);
        }
        // PUT api/<ReservationController>/changestatus/5
        [HttpPut("changestatus/{id}")]
        public async Task<ActionResult> ChangeStatus(int id, [FromBody] ChangeReservationStatusDto reservationStatusDto)
        {
            var status = await _mediator.Send(new UpdateReservationCommand { Id = id, ChangeReservationStatusDto = reservationStatusDto });
            return Ok(status);
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteReservationCommand { Id = id });
            return NoContent();
        }
    }
}
