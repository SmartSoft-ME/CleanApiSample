using CleanApiSample.Application.Commands.UserCommands;
using CleanApiSample.Application.DTOs;
using CleanApiSample.Application.Queries.UserQueries;
using CleanApiSample.Shared;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CleanApiSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator) 
            => _mediator = mediator;

        [HttpGet]
        public async Task<List<UserDto>> Get([FromQuery] GetAllUsersQuery query, CancellationToken cancellationToken)
            => await _mediator.Send(query, cancellationToken);

        [HttpGet("{id}")]
        public async Task<UserDto> Get([FromHeader] GetUserByIdQuery query, CancellationToken cancellationToken)
            => await _mediator.Send(query, cancellationToken);

        [HttpPost]
        public async Task<Response<UserDto>> Post(CreateUserCommand command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        [HttpPut]
        public async Task<Response<UserDto>> Put(UpdateUserCommand command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        [HttpDelete]
        public async Task Delete(DeleteUserCommand command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);
    }
}
