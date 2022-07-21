using MediatR;

namespace CleanApiSample.Shared.Abstractions.Application.Commands
{
    public interface ICommand<T> : IRequest<Response<T>> { }
}
