using CleanApiSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanApiSample.Infrastructure.Data
{
    public class AppDbContext :DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
