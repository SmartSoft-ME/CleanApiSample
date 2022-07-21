using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanApiSample.Infrastructure.Data
{
    internal static class Extentions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var connectionString = "Data Source=" + Path.Join(path, "CleanAPISample.db");
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            return services;
        }
    }
}
