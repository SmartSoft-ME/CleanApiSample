using CleanApiSample.Application.DTOs;
using CleanApiSample.Application.Repositories;
using CleanApiSample.Domain.Entities;
using CleanApiSample.Shared.Abstractions.Application.Queries;

using Mapster;

namespace CleanApiSample.Application.Queries.TagQueries.Handlers
{
    public class GetAllTagsHandler : IQueryHandler<GetAllTagsQuery, List<TagDto>>
    {
        private readonly ITagRepository _tags;

        public GetAllTagsHandler(ITagRepository tags)
        {
            _tags = tags;
        }

        public async Task<List<TagDto>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            var tags = await _tags.GetAllAsync(cancellationToken);
            return tags.Adapt<IEnumerable<Tag>, IEnumerable<TagDto>>().ToList();
        }
    }
}
