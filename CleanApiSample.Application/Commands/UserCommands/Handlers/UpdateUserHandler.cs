using CleanApiSample.Application.DTOs;
using CleanApiSample.Application.Repositories;
using CleanApiSample.Domain.Entities;
using CleanApiSample.Shared;
using CleanApiSample.Shared.Abstractions.Application.Commands;
using Mapster;

namespace CleanApiSample.Application.Commands.UserCommands.Handlers
{
    internal class UpdateUserHandler : ICommandHandler<UpdateUserCommand, UserDto>
    {
        private readonly IUserRepository _users;
        private readonly IPostRepository _posts;

        public UpdateUserHandler(IUserRepository users, IPostRepository posts)
        {
            _users = users;
            _posts = posts;
        }

        public async Task<Response<UserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var(id, username, email, postIds) = request;

            var user = await _users.GetByIdAsync(id, cancellationToken);

            var newPosts = new List<Post>();

            foreach (var postId in postIds)
                newPosts.Add(await _posts.GetByIdAsync(postId, cancellationToken));

            user.UpdateUsername(username);
            user.UpdateEmail(email);
            user.UpdatePosts(newPosts);

            var updatedUser = await _users.UpdateAsync(user, cancellationToken);

            return Response.Success(updatedUser.Adapt<User, UserDto>(), "Updated user " + updatedUser.Username);
        }
    }
}
