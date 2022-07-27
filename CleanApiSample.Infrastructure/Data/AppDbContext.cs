using CleanApiSample.Domain.Entities;
using CleanApiSample.Infrastructure.Data.Configurations;

using Microsoft.EntityFrameworkCore;

namespace CleanApiSample.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
