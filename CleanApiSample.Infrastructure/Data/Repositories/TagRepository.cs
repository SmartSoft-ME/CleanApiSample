using CleanApiSample.Domain.Entities;

namespace CleanApiSample.Infrastructure.Data.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        private readonly AppDbContext _context;
        public TagRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
