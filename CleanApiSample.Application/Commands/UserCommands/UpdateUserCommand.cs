using CleanApiSample.Application.DTOs;
using CleanApiSample.Shared.Abstractions.Application.Commands;

namespace CleanApiSample.Application.Commands.UserCommands
{
    public record UpdateUserCommand(int Id, string Name, string Email, List<int> PostIds) : ICommand<UserDto>;
}
