using CleanApiSample.Application.Repositories;
using CleanApiSample.Domain.Entities;
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
        public async Task<IEnumerable<Post>> GetWithTagsAsync(CancellationToken cancellationToken)
            => await _posts.Include(p => p.Tags).ToListAsync(cancellationToken);

        public async Task<Post> GetWithTagsByIdAsync(int id, CancellationToken cancellationToken)
            => await _posts.Include(p => p.Tags).FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

    }
}
