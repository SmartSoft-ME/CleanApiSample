using CleanApiSample.Application.DTOs;
using CleanApiSample.Shared.Abstractions.Application.Queries;

namespace CleanApiSample.Application.Queries.UserQueries
{
    public record GetUserByIdQuery(int Id) : IQuery<UserDto>;

}
