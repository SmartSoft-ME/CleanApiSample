using CleanApiSample.Shared.Abstractions.Domain;

namespace CleanApiSample.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; private set; }
        public List<Post> Posts { get; private set; }

        public Tag() { }
        public Tag(string name)
        {
            Name = name;
        }

        public void UpdateName(string name) 
            => Name = name;

        public void UpdatePosts(List<Post> posts)
            => Posts = posts;
        public void AddPost(Post post)
            => Posts.Add(post);
        public void AddPosts(List<Post> posts)
            => Posts.AddRange(posts);
        public void RemovePost(Post post)
            => Posts.Remove(post);
        public void RemovePosts(List<Post> posts)
            => Posts.RemoveAll(p => posts.Contains(p));
    }
}
