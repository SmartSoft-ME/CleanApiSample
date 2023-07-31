using CleanApiSample.Domain.Entities;

namespace CleanApiSample.Application.Repositories
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        public Task<IEnumerable<Post>> GetWholeAsync(CancellationToken cancellationToken);
        public Task<Post> GetWholeByIdAsync(int id, CancellationToken cancellationToken);
    }
}
