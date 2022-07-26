using CleanApiSample.Domain.EntityProperties.UserProperties;
using CleanApiSample.Shared.Abstractions.Domain;

namespace CleanApiSample.Domain.Entities
{
    public class User : BaseEntity
    {
        public Username Username { get; private set; }
        public Email Email { get; private set; }
        public List<Post>? Posts { get; private set; }

        public User() { }

        public User(string username, string email)
        {
            Username = Username.Create(username);
            Email = Email.Create(email);
        }

        public void UpdateUsername(string username)
            => Username = Username.Create(username);
        public void UpdateEmail(string email)
            => Email = Email.Create(email);
        public void UpdatePosts(List<Post> posts) 
            => Posts = posts;
        public void AddPost(Post post)
            => Posts.Add(post);
    }
}
