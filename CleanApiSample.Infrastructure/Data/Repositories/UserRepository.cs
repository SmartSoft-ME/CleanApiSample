using CleanApiSample.Application.Repositories;
using CleanApiSample.Domain.Entities;
using CleanApiSample.Infrastructure.Data.Exceptions;

using Microsoft.EntityFrameworkCore;

namespace CleanApiSample.Infrastructure.Data.Repositories
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<User> _users;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _users = _context.Set<User>();
        }
        
        public async Task<IEnumerable<User>> GetWholeAsync(CancellationToken cancellationToken)
            => await _users.Include(u => u.Posts).ToListAsync(cancellationToken);

        public async Task<User> GetWholeByIdAsync(int id, CancellationToken cancellationToken)
            => await _users.Include(u => u.Posts).FirstOrDefaultAsync(t => t.Id == id, cancellationToken)
                ?? throw new NotFoundException(typeof(User).Name, id);
    }
}
