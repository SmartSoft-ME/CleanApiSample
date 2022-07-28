using CleanApiSample.Application.Repositories;
using CleanApiSample.Shared;
using CleanApiSample.Shared.Abstractions.Application.Commands;

using MediatR;

namespace CleanApiSample.Application.Commands.TagCommands.Handlers
{
    internal class DeleteTagHandler : ICommandHandler<DeleteTagCommand, Unit>
    {
        private readonly ITagRepository _tags;

        public DeleteTagHandler(ITagRepository tags)
        {
            _tags = tags;
        }

        public async Task<Response<Unit>> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            await _tags.DeleteAsync(request.Id, cancellationToken);
            return Response.Success(Unit.Value, "Deleted tag");
        }
    }
}
