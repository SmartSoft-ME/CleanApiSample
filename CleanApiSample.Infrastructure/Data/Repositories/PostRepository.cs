using CleanApiSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace CleanApiSample.Infrastructure.Data.Repositories
{
    public class PostRepository : BaseRepository<Post>
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
    }
}
