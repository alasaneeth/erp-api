using ERP_API.Application.Common;
using ERP_API.Application.Services;
using ERP_API.Application.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ERP_API.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<ICustomerService, CustomerService>();
            return services;
        }
    }
}
