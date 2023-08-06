using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Valnet.Cart.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection ConfitureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly()); 
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
