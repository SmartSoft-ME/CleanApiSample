using CleanApiSample.Application.DTOs;
using CleanApiSample.Application.Repositories;
using CleanApiSample.Domain.Entities;
using CleanApiSample.Shared.Abstractions.Application.Queries;

using Mapster;

namespace CleanApiSample.Application.Queries.TagQueries.Handlers
{
    public class GetTagByIdHandler : IQueryHandler<GetTagByIdQuery, TagDto>
    {
        private readonly ITagRepository _tags;

        public GetTagByIdHandler(ITagRepository tags)
        {
            _tags = tags;
        }

        public async Task<TagDto> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var tag = await _tags.GetByIdAsync(request.Id, cancellationToken);
            return tag.Adapt<Tag, TagDto>();
        }
    }
}
