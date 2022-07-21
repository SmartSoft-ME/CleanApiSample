using MediatR;

namespace CleanApiSample.Shared.Abstractions.Application.Commands
{
    public interface ICommandHandler<TIn, TOut> : IRequestHandler<TIn, Response<TOut>>
    where TIn : ICommand<TOut> { }
}
