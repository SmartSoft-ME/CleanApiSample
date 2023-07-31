using CleanApiSample.Application.Repositories;
using CleanApiSample.Domain.Entities;
using CleanApiSample.Infrastructure.Data.Exceptions;

using Microsoft.EntityFrameworkCore;

namespace CleanApiSample.Infrastructure.Data.Repositories
{
    internal class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Tag> _tags;
        public TagRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _tags = _context.Set<Tag>();
        }

        public async Task<IEnumerable<Tag>> GetWholeAsync(CancellationToken cancellationToken)
            => await _tags.Include(t => t.Posts).ToListAsync(cancellationToken);

        public async Task<Tag> GetWholeByIdAsync(int id, CancellationToken cancellationToken)
            => await _tags.Include(t => t.Posts).FirstOrDefaultAsync(t => t.Id == id, cancellationToken) 
                ?? throw new NotFoundException(typeof(Tag).Name, id);
    }
}
