using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using AutoMapper;
using System.Reflection;

namespace BLL.ServiceExtensions
{
    public static class BLLServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
                                               IConfiguration configuration)
        {
            services.AddDbContext<ProductsContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                    b => b.MigrationsAssembly("DAL")));
        }

        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
