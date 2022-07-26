using CleanApiSample.Application.DTOs;
using CleanApiSample.Shared.Abstractions.Application.Commands;

namespace CleanApiSample.Application.Commands.PostCommands
{
    public record UpdatePostCommand(int Id, string Title, string Description, List<int> TagIds) : ICommand<PostDto>;
}
