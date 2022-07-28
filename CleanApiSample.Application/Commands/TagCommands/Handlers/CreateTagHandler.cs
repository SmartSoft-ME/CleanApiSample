using CleanApiSample.Application.DTOs;
using CleanApiSample.Application.Repositories;
using CleanApiSample.Domain.Entities;
using CleanApiSample.Shared;
using CleanApiSample.Shared.Abstractions.Application.Commands;

using Mapster;

namespace CleanApiSample.Application.Commands.TagCommands.Handlers
{
    internal class CreateTagHandler : ICommandHandler<CreateTagCommand, TagDto>
    {
        private readonly ITagRepository _tags;

        public CreateTagHandler(ITagRepository tags)
        {
            _tags = tags;
        }

        public async Task<Response<TagDto>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var name = request.Name;
            Tag tag = new(name);
            var newTag = await _tags.AddAsync(tag, cancellationToken);
            return Response.Success(newTag.Adapt<Tag, TagDto>(), "Created tag " + newTag.Name);
        }
    }
}
