using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanApiSample.Infrastructure.Data
{
    internal static class Extentions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));
            return services;
        }
    }
}
