using AutoServiceManager.Application.Interfaces.CacheRepositories;
using AutoServiceManager.Application.Interfaces.Contexts;
using AutoServiceManager.Application.Interfaces.Repositories;
using AutoServiceManager.Infrastructure.CacheRepositories;
using AutoServiceManager.Infrastructure.DbContexts;
using AutoServiceManager.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AutoServiceManager.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            #region Repositories

            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductCacheRepository, ProductCacheRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IBrandCacheRepository, BrandCacheRepository>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<ICarCacheRepository, CarCacheRepository>(); 
            services.AddTransient<ICarOrderCacheRepository, CarOrderCacheRepository>();
            services.AddTransient<ICarOrderRepository, CarOrderRepository>();
            services.AddTransient<ICarOrdersReportViewRepository, CarOrdersReportViewRepository>();
            services.AddTransient<ICarOrdersReportViewCacheRepository, CarOrdersReportViewCacheRepository>();
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #endregion Repositories
        }
    }
}