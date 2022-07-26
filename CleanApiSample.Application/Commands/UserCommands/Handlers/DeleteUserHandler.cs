using CleanApiSample.Application.Repositories;
using CleanApiSample.Shared;
using CleanApiSample.Shared.Abstractions.Application.Commands;
using MediatR;

namespace CleanApiSample.Application.Commands.UserCommands.Handlers
{
    internal class DeleteUserHandler : ICommandHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _users;

        public DeleteUserHandler(IUserRepository users)
        {
            _users = users;
        }

        public async Task<Response<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _users.DeleteAsync(request.Id, cancellationToken);
            return Response.Success(Unit.Value, "Deleted user");
        }
    }
}
