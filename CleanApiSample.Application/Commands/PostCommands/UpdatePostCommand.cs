using CleanApiSample.Application.DTOs;
using CleanApiSample.Shared.Abstractions.Application.Commands;

namespace CleanApiSample.Application.Commands.PostCommands
{
    public record UpdateTagCommand(int Id, string Title, string Description, List<int> TagIds) : ICommand<PostDto>;
}
