﻿using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Valnet.Cart.Persistence
{
    public class ValnetContextFactory : IDesignTimeDbContextFactory<ValnetContext>
    {
        public ValnetContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var builder = new DbContextOptionsBuilder<ValnetContext>();
            var connectionString = configuration.GetConnectionString("ValnetConnectionString");

            builder.UseSqlServer(connectionString);

            return new ValnetContext(builder.Options); 
        }
    }

}

