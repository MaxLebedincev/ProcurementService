using Microsoft.EntityFrameworkCore;
using ProcurementService.API.DAL.Core.Interfaces;
using ProcurementService.API.DAL.Core;

namespace ProcurementService.API.Service.Registeration
{
    public static class UnitOfWork
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryFactory, DAL.Core.UnitOfWork>();
            services.AddScoped<IUnitOfWork, DAL.Core.UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddCustomRepository<TEntity, TRepository>(this IServiceCollection services)
                 where TEntity : class
                 where TRepository : class, IBaseRepository<TEntity>
        {
            services.AddScoped<IBaseRepository<TEntity>, TRepository>();

            return services;
        }
    }
}
