using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OzhanHr.Application.Contracts.Infrastructure;
using OzhanHr.Application.Model;
using OzhanHR.Infrasturcutre.Mail;

namespace OzhanHR.Infrasturcutre.ServiceConfiguration
{
    public static class InfrastructureServiceConfiguration
    {
        public static IServiceCollection InfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSetting"));
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}
