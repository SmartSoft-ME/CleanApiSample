using CleanApiSample.Application.Commands.PostCommands;
using CleanApiSample.Application.DTOs;
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

        [HttpPost]
        public async Task<Response<PostDto>> PostPost(CreatePostCommand command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);
    }
}
