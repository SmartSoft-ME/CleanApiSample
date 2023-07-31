using CleanApiSample.Domain.Entities;

namespace CleanApiSample.Application.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<IEnumerable<User>> GetWholeAsync(CancellationToken cancellationToken);
        public Task<User> GetWholeByIdAsync(int id, CancellationToken cancellationToken);
    }
}
