using CleanApiSample.Application.DTOs;
using CleanApiSample.Shared.Abstractions.Application.Commands;

namespace CleanApiSample.Application.Commands.TagCommands
{
    public record CreateTagCommand(string Name) : ICommand<TagDto>;
}