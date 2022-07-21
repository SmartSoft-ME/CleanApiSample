using CleanApiSample.Shared.Abstractions.Application.Commands;

using MediatR;

namespace CleanApiSample.Application.Commands.UserCommands
{
    public record DeleteUserCommand(int Id) : ICommand<Unit>;
}
