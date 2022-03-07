using HDovud.Contract.Repositories;
using HDovud.Contract.Servises;
using HDovud.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace HDovud.Service
{
    public static class ServiceConfigurations
    {
        public static void ConfigurService(this IServiceCollection service)
        {
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IEmailService, EmailService>();
            service.AddScoped<IJWTService, JWTService>();
        }
    }
}
