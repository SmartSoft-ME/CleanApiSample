using CleanApiSample.Application.DTOs;
using CleanApiSample.Shared.Abstractions.Application.Queries;

namespace CleanApiSample.Application.Queries.PostQueries
{
    public record GetAllPostsQuery() : IQuery<List<PostDto>>;
}
