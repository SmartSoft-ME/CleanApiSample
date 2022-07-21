using CleanApiSample.Application.DTOs;
using CleanApiSample.Shared.Abstractions.Application.Queries;

namespace CleanApiSample.Application.Queries.UserQueries
{
    public record GetAllUsersQuery() : IQuery<List<UserDto>>;
}
