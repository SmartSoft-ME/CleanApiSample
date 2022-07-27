using CleanApiSample.Domain.Entities;

namespace CleanApiSample.Application.Repositories
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        public Task<IEnumerable<Post>> GetWithTagsAsync(CancellationToken cancellationToken);
        public Task<Post> GetWithTagsByIdAsync(int id, CancellationToken cancellationToken);
    }
}
