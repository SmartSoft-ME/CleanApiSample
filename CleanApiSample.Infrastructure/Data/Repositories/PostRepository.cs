using CleanApiSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace CleanApiSample.Infrastructure.Data.Repositories
{
    public class PostRepository : BaseRepository<Post>
    {
        private readonly AppDbContext _context;
        public PostRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
