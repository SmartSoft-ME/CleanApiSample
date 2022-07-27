using CleanApiSample.Application.DTOs;
using CleanApiSample.Application.Repositories;
using CleanApiSample.Domain.Entities;
using CleanApiSample.Shared;
using CleanApiSample.Shared.Abstractions.Application.Commands;

using Mapster;

namespace CleanApiSample.Application.Commands.PostCommands.Handlers
{
    internal class UpdatePostHandler : ICommandHandler<UpdatePostCommand, PostDto>
    {
        private readonly IPostRepository _posts;
        private readonly ITagRepository _tags;

        public UpdatePostHandler(IPostRepository posts, ITagRepository tags)
        {
            _posts = posts;
            _tags = tags;
        }

        public async Task<Response<PostDto>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var (id, title, description, tagIds) = request;

            var post = await _posts.GetWithTagsByIdAsync(id, cancellationToken);

            if (tagIds is not null)
            {
                var newTags = new List<Tag>();
                foreach (var tagId in tagIds)
                    newTags.Add(await _tags.GetByIdAsync(tagId, cancellationToken));
                post.UpdateTags(newTags);
            }

            post.UpdateDetails(title, description);

            var updatedPost = await _posts.UpdateAsync(post, cancellationToken);

            var setter = TypeAdapterConfig<Post, PostDto>.NewConfig()
                .Map(dest => dest.Tags, src => src.Tags).MaxDepth(2);
            return Response.Success(updatedPost.Adapt<Post, PostDto>(setter.Config), "Updated post " + updatedPost.Title);
        }
    }
}
