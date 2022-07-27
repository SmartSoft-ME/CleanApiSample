using CleanApiSample.Application.DTOs;
using CleanApiSample.Application.Repositories;
using CleanApiSample.Domain.Entities;
using CleanApiSample.Shared.Abstractions.Application.Queries;

using Mapster;

namespace CleanApiSample.Application.Queries.UserQueries.Handlers
{
    public class GetAllUsersHandler : IQueryHandler<GetAllUsersQuery, List<UserDto>>
    {
        private readonly IUserRepository _users;

        public GetAllUsersHandler(IUserRepository users)
        {
            _users = users;
        }

        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _users.GetAllAsync(cancellationToken);
            return users.Adapt<IEnumerable<User>, IEnumerable<UserDto>>().ToList();
        }
    }
}
