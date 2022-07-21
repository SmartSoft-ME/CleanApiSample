using CleanApiSample.Application.DTOs;
using CleanApiSample.Shared.Abstractions.Application.Queries;

namespace CleanApiSample.Application.Queries.PostQueries
{
    public record GetPostByIdQuery(int Id) : IQuery<PostDto>;
}
