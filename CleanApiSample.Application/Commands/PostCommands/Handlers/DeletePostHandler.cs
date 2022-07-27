using CleanApiSample.Application.Commands.PostCommands;
using CleanApiSample.Application.DTOs;
using CleanApiSample.Application.Repositories;
using CleanApiSample.Shared;
using CleanApiSample.Shared.Abstractions.Application.Commands;
using MediatR;

namespace CleanApiSample.Application.Commands.PostCommands.Handlers
{
    internal class DeletePostHandler : ICommandHandler<DeletePostCommand, Unit>
    {
        private readonly IPostRepository _posts;

        public DeletePostHandler(IPostRepository posts)
        {
            _posts = posts;
        }

        public async Task<Response<Unit>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _posts.GetByIdAsync(request.Id, cancellationToken);
            if(post.Tags is not null)
                foreach (var tag in post.Tags)
                    post.RemoveTag(tag);
            await _posts.UpdateAsync(post, cancellationToken);
            await _posts.DeleteAsync(request.Id, cancellationToken);
            return Response.Success(Unit.Value, "Deleted post");
        }
    }
}
