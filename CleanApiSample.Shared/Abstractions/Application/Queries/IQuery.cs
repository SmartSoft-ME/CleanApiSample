using MediatR;

namespace CleanApiSample.Shared.Abstractions.Application.Queries
{
    public interface IQuery<TOut> : IRequest<TOut> { }
}
