using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.User;
using Restaurant.Application.Features.Users.Requests.Commands;
using Restaurant.Application.Features.Users.Requests.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Mediator _mediator;

        public UserController(Mediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            var users = await _mediator.Send(new GetUserListRequest());
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            var user = await _mediator.Send(new GetUserDetaliRequest { Id = id });
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUserDto userDto)
        {
            var command = await _mediator.Send(new CreateUserCommand { CreateUserDto = userDto });
            return Ok(command);
        }

        // PUT api/<UserController>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateUserDto userDto)
        {
            var command = await _mediator.Send(new UpdateUserCommand { UpdateUserDto = userDto });
            return Ok(command);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteUserCommand { Id = id });
            return NoContent();
        }
    }
}
