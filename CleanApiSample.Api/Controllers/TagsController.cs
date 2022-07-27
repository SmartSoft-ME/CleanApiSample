using CleanApiSample.Application.Commands.TagCommands;
using CleanApiSample.Application.DTOs;
using CleanApiSample.Application.Queries.TagQueries;
using CleanApiSample.Shared;

using MediatR;

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

        [HttpGet]
        public async Task<List<TagDto>> Get([FromHeader] GetAllTagsQuery query, CancellationToken cancellationToken)
            => await _mediator.Send(query, cancellationToken);

        [HttpGet("{id}")]
        public async Task<TagDto> Get([FromHeader] GetTagByIdQuery query, CancellationToken cancellationToken)
            => await _mediator.Send(query, cancellationToken);

        [HttpPost]
        public async Task<Response<TagDto>> Post(CreateTagCommand command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        [HttpPut]
        public async Task<Response<TagDto>> Put(UpdateTagCommand command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        [HttpDelete]
        public async Task Delete(DeleteTagCommand command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);
    }
}
