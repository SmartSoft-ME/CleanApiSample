using CleanApiSample.Application.Repositories;
using CleanApiSample.Domain.Entities;

namespace CleanApiSample.Infrastructure.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
