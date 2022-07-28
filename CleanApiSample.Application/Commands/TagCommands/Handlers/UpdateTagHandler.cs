using System.Runtime.CompilerServices;

using CleanApiSample.Application.Commands.TagCommands;
using CleanApiSample.Application.DTOs;
using CleanApiSample.Application.Repositories;
using CleanApiSample.Domain.Entities;
using CleanApiSample.Shared;
using CleanApiSample.Shared.Abstractions.Application.Commands;

using Mapster;

namespace CleanApiSample.Application.Commands.TagCommands.Handlers
{
    internal class UpdateTagHandler : ICommandHandler<UpdateTagCommand, TagDto>
    {
        private readonly ITagRepository _tags;
        private readonly IPostRepository _posts;

        public UpdateTagHandler(ITagRepository tags, IPostRepository posts)
        {
            _tags = tags;
            _posts = posts;
        }

        public async Task<Response<TagDto>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var (id, name, postIds) = request;

            var tag = await _tags.GetByIdAsync(id, cancellationToken);

            var newPosts = new List<Post>();
            foreach (var postId in postIds)
                newPosts.Add(await _posts.GetByIdAsync(postId, cancellationToken));

            tag.UpdateName(name);
            tag.UpdatePosts(newPosts);
            var updatedTag = await _tags.UpdateAsync(tag, cancellationToken);

            return Response.Success(updatedTag.Adapt<Tag, TagDto>(), "Updated tag " + updatedTag.Name);
        }
    }
}
