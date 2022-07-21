using CleanApiSample.Application.DTOs;
using CleanApiSample.Shared.Abstractions.Application.Commands;

namespace CleanApiSample.Application.Commands.PostCommands
{
    public record CreatePostCommand(string Title, string Description, int UserId, List<int> TagIds) : ICommand<PostDto>;
}