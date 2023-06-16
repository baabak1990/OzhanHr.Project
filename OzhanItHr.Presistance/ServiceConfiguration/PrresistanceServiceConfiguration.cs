using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OzhanHr.Application.Contracts.Presistance.Repository;
using OzhanItHr.Persistence.Context;
using OzhanItHr.Persistence.Repositories;

namespace OzhanItHr.Persistence.ServiceConfiguration
{
    public static class PersistenceServiceConfiguration
    {
        public static IServiceCollection PersistenceService(this IServiceCollection services,
            IConfiguration configuration)
        {
            //TODO: Add ConnectionString Here
            services.AddDbContext<DefaultDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LeaveManagementConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(IGenericRepository<>));

            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            services.AddScoped<IleaveRequestRepository, leaveRequestRepository>();
            services.AddScoped<IleaveTypeRepository, leaveTypeRepository>();

            return services;
        }
    }
}
