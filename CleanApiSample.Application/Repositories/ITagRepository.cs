using CleanApiSample.Domain.Entities;

namespace CleanApiSample.Application.Repositories
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
        public Task<IEnumerable<Tag>> GetWholeAsync(CancellationToken cancellationToken);
        public Task<Tag> GetWholeByIdAsync(int id, CancellationToken cancellationToken);
    }
}
