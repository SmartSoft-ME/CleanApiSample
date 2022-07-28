using CleanApiSample.Application.DTOs;
using CleanApiSample.Application.Repositories;
using CleanApiSample.Domain.Entities;
using CleanApiSample.Shared;
using CleanApiSample.Shared.Abstractions.Application.Commands;

using Mapster;

namespace CleanApiSample.Application.Commands.UserCommands.Handlers
{
    internal class CreateUserHandler : ICommandHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _users;

        public CreateUserHandler(IUserRepository users)
        {
            _users = users;
        }

        public async Task<Response<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var(username, email) = request;
            User user = new(username, email);
            var newUser = await _users.AddAsync(user, cancellationToken);
            return Response.Success(newUser.Adapt<User, UserDto>(), "Created user " + newUser.Username);
        }
    }
}
