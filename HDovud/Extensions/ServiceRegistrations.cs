using HDovud.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HDovud.Extensions
{
    public static class ServiceRegistrations
    {
        public static void ConfigureDataContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<DataContext>(builder => builder.UseSqlite(configuration.GetConnectionString("Default")).UseLazyLoadingProxies());



        public static void ConfigureRouting(this IServiceCollection services) =>
            services.AddRouting(x => x.LowercaseUrls = true);
    }
}
