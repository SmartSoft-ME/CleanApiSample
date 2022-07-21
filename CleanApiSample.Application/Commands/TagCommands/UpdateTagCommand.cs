using CleanApiSample.Application.DTOs;
using CleanApiSample.Shared.Abstractions.Application.Commands;

namespace CleanApiSample.Application.Commands.TagCommands
{
    public record UpdateTagCommand(int Id, string Name, List<int> PostIds) : ICommand<TagDto>;
}
