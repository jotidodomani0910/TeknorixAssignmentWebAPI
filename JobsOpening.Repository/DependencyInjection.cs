using JobsOpening.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace JobsOpening.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {

            services.AddTransient<IJobRepository, JobRespository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
           
            return services;
        }
    }
}
