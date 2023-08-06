using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Valnet.Cart.Model;

namespace Valnet.Cart.Persistence
{
    public class ValnetContext: DbContext
    {
        public ValnetContext(DbContextOptions<ValnetContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ValnetContext).Assembly);
        }

        public DbSet<Model.Cart> Carts { get; set; }
        public DbSet<ProductInCart> ProductInCarts { get; set; }

    }
}