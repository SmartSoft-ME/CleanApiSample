using CleanApiSample.Application.Commands.UserCommands;
using CleanApiSample.Application.DTOs;
using CleanApiSample.Shared;

using MediatR;

using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public async Task<Response<UserDto>> PostUser(CreateUserCommand command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

    }
}
