using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valnet.Cart.Application.Contracts.Infrastructure;

namespace Valnet.Cart.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            return services;
        }
    }
}
