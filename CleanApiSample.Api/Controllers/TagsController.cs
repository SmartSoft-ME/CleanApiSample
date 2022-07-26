using CleanApiSample.Application.Commands.TagCommands;
using CleanApiSample.Application.DTOs;
using CleanApiSample.Shared;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanApiSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<Response<TagDto>> PostTag(CreateTagCommand command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

    }
}
