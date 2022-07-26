using CleanApiSample.Application.Repositories;
using CleanApiSample.Infrastructure.Data.Repositories;
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
            services.AddDbContext<AppDbContext>();
            
            return services;
        }
    }
}
