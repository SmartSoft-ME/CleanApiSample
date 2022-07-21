using CleanApiSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanApiSample.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public string connectionString { get; private set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            connectionString = "Data Source=" + Path.Join(path, "CleanAPISample.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(connectionString);


    }
}
