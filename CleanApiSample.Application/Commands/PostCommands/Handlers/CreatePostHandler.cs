using CleanApiSample.Application.Commands.PostCommands;
using CleanApiSample.Application.DTOs;
using CleanApiSample.Application.Repositories;
using CleanApiSample.Domain.Entities;
using CleanApiSample.Shared;
using CleanApiSample.Shared.Abstractions.Application.Commands;

using Mapster;

namespace CleanApiSample.Application.Commands.PostCommands.Handlers
{
    public class CreatePostHandler : ICommandHandler<CreatePostCommand, PostDto>
    {
        private readonly IPostRepository _posts;
        private readonly ITagRepository _tags;
        private readonly IUserRepository _users;

        public CreatePostHandler(IPostRepository posts, ITagRepository tags, IUserRepository users)
        {
            _posts = posts;
            _tags = tags;
            _users = users;
        }

        public async Task<Response<PostDto>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var (title, description, userId, tagIds) = request;

            var user = await _users.GetByIdAsync(userId, cancellationToken);
            var tags = new List<Tag>();

            foreach (var tagId in tagIds)
            {
                tags.Add(await _tags.GetByIdAsync(tagId, cancellationToken));
            }

            var post = new Post(title, description, user, tags);

            return Response.Success(post.Adapt<Post, PostDto>(), "Created post");
        }
    }
}
