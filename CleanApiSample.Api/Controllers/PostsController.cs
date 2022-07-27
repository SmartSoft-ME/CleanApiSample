using CleanApiSample.Application.Commands.PostCommands;
using CleanApiSample.Application.DTOs;
using CleanApiSample.Application.Queries.PostQueries;
using CleanApiSample.Shared;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CleanApiSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator) 
            => _mediator = mediator;

        [HttpGet]
        public async Task<List<PostDto>> Get([FromHeader] GetAllPostsQuery query, CancellationToken cancellationToken)
            => await _mediator.Send(query, cancellationToken);

        [HttpGet("{id}")]
        public async Task<PostDto> Get([FromHeader] GetPostByIdQuery query, CancellationToken cancellationToken)
            => await _mediator.Send(query, cancellationToken);

        [HttpPost]
        public async Task<Response<PostDto>> Post(CreatePostCommand command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        [HttpPut]
        public async Task<Response<PostDto>> Put(UpdatePostCommand command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        [HttpDelete]
        public async Task Delete(DeletePostCommand command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);
    }
}
