using CleanApiSample.Shared.Abstractions.Application.Commands;

using MediatR;

namespace CleanApiSample.Application.Commands.PostCommands
{
    public record DeletePostCommand(int Id) : ICommand<Unit>;
}
