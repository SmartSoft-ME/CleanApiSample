using CleanApiSample.Application.DTOs;
using CleanApiSample.Shared.Abstractions.Application.Commands;

namespace CleanApiSample.Application.Commands.UserCommands
{
    public record CreateUserCommand(string Name, string Email) : ICommand<UserDto>;
}