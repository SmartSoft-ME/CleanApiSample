using CleanApiSample.Application.DTOs;
using CleanApiSample.Shared.Abstractions.Application.Queries;

namespace CleanApiSample.Application.Queries.TagQueries
{
    public record GetAllTagsQuery() : IQuery<List<TagDto>>;
}
