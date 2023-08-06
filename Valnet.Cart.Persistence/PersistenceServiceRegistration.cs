using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valnet.Cart.Application.Contracts.Persistence;
using Valnet.Cart.Model;
using Valnet.Cart.Persistence.Repositories;

namespace Valnet.Cart.Persistence
{
    public static class PersistenceServiceRegistration 
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ValnetContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("ValnetConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IProductInCartRepository, ProductInCartRepository>();

            return services;
        }
    }
}
