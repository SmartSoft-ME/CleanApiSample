using CleanApiSample.Application.Repositories;
using CleanApiSample.Infrastructure.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanApiSample.Infrastructure.Data
{
    public static class Extentions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var connectionString = "Data Source=" + Path.Join(path, "CleanAPISample.db");

            services.AddDbContext<AppDbContext>(options
                => options.UseSqlite(connectionString));

            services.AddHostedService<AppInitializer>();

            return services;
        }
    }
}
