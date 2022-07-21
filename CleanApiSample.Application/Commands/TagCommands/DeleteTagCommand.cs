using CleanApiSample.Shared.Abstractions.Application.Commands;

using MediatR;

namespace CleanApiSample.Application.Commands.TagCommands
{
    public record DeleteTagCommand(int Id) : ICommand<Unit>;
}
