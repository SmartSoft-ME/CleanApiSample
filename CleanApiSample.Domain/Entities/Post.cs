using CleanApiSample.Shared.Abstractions.Domain;

namespace CleanApiSample.Domain.Entities
{
    public class Post : BaseEntity
    {

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime PostedDate { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public List<Tag>? Tags { get; private set; }

        public Post() { }        
        public Post(string title, string description, User user, List<Tag>? tags)
        {
            Title = title;
            Description = description;
            PostedDate = DateTime.Now;
            User = user;
            Tags = tags;
        }

        public void UpdateDetails(string? title, string? description)
        {
            Title = title;
            Description = description;
        }

        public void UpdateTags(List<Tag> tags)
            => Tags = tags;

        public void AddTag(Tag tag)
            => Tags.Add(tag);
        public void RemoveTag(Tag tag)
            => Tags.Remove(tag);
    }
}
