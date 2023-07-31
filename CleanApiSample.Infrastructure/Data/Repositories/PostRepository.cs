using CleanApiSample.Application.Repositories;
using CleanApiSample.Domain.Entities;
using CleanApiSample.Infrastructure.Data.Exceptions;

using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace CleanApiSample.Infrastructure.Data.Repositories
{
    internal class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Post> _posts;
        public PostRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _posts = _context.Set<Post>();
        }
        public async Task<IEnumerable<Post>> GetWholeAsync(CancellationToken cancellationToken)
            => await _posts.Include(p => p.Tags).Include(p => p.User).ToListAsync(cancellationToken);

        public async Task<Post> GetWholeByIdAsync(int id, CancellationToken cancellationToken)
            => await _posts.Include(p => p.Tags)
                           .Include(p => p.User)
                           .FirstOrDefaultAsync(p => p.Id == id, cancellationToken)
                ?? throw new NotFoundException(typeof(Post).Name, id);

    }
}
