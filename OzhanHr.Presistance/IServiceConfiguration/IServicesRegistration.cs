using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OzhanHr.Application.Features.LeaveAllocation.Handler.Commands;
using OzhanHr.Application.Features.LeaveAllocation.Handler.Queries;
using OzhanHr.Application.Features.LeaveAllocation.Request.Commands;
using OzhanHr.Application.Features.LeaveAllocation.Request.Queries;
using OzhanHr.Application.Features.LeaveRequest.Handler.Commands;
using OzhanHr.Application.Features.LeaveRequest.Handler.Queries;
using OzhanHr.Application.Features.LeaveRequest.Request.Commands;
using OzhanHr.Application.Features.LeaveRequest.Request.Queries;
using OzhanHr.Application.Features.LeaveType.Handler.Commands;
using OzhanHr.Application.Features.LeaveType.Request.Commands;
using OzhanHr.Application.Features.LeaveType.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OzhanHr.Application.IServiceConfiguration
{
    public static class IServicesRegistration
    {
        public static IServiceCollection ApplicationLayerConfiguration(this IServiceCollection services)
        {
            //HINT :
            //to prevent any Dublication it is better to use this way to contain all mapper profile in your application
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
