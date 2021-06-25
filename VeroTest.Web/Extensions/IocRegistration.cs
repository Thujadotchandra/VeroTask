using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VeroTest.Core.Interfaces;
using VeroTest.Core.Services;
using VeroTest.Infrastructure.Repositories;

namespace VeroTest.Web.Extensions
{
    public static class IocRegistrations
    {
        public static IServiceCollection RegisterIocServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddDbContext<VeroTest.Infrastructure.VeroTestDbContext>();


            services.AddOptions();

            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));

            services.AddTransient<ISongService, SongService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISongRepository, SongRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();


            return services;
        }
    }
}