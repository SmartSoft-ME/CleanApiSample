using CleanApiSample.Application.DTOs;
using CleanApiSample.Application.Repositories;
using CleanApiSample.Domain.Entities;
using CleanApiSample.Shared;
using CleanApiSample.Shared.Abstractions.Application.Queries;

using Mapster;

namespace CleanApiSample.Application.Queries.UserQueries.Handlers
{
    public class GetUserByIdHandler : IQueryHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _users;

        public GetUserByIdHandler(IUserRepository users)
        {
            _users = users;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _users.GetByIdAsync(request.Id, cancellationToken);
            return user.Adapt<User, UserDto>();
        }
    }
}
