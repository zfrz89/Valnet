using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valnet.Cart.Application.Contracts.Persistence;
using Valnet.Cart.Model;

namespace Valnet.Cart.Persistence.Repositories
{
    public class ProductInCartRepository :GenericRepository<ProductInCart>, IProductInCartRepository
    {
        public ProductInCartRepository(ValnetContext context) : base(context)
        {
        }

        public async Task RemoveProductInCart(string ProductId, string CartId)
        {
            var productToRemove = await _context.ProductInCarts
                .FirstOrDefaultAsync(q => q.ProductId == int.Parse(ProductId) && q.CartId == int.Parse(CartId));

            if (productToRemove == null)
                return;

            _context.ProductInCarts.Remove(productToRemove);
            await _context.SaveChangesAsync();

        }
    }
}
