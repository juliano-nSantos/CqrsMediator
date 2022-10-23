using Domain.Interfaces;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(
                    configuration.GetConnectionString("Connection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext)
                        .Assembly.FullName)));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;

        }
    }
}
