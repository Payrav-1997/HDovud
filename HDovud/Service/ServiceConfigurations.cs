using HDovud.Contract.Repositories;
using HDovud.Contract.Servises;
using HDovud.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDovud.Service
{
    public static class ServiceConfigurations
    {
        public static void ConfigurService(this IServiceCollection service)
        {
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
