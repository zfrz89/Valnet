using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valnet.Cart.Application.Contracts.Persistence;

namespace Valnet.Cart.Persistence.Repositories
{
    public class CartRepository : GenericRepository<Model.Cart>, ICartRepository
    {
        public CartRepository(ValnetContext context) : base(context)
        {
        }
        public async Task<Model.Cart> GetFirstCart(string userId)
        {
            return await _context.Carts
                .Include(q=>q.Products)
                .Where(q => q.UserId ==int.Parse(userId)).FirstOrDefaultAsync();
        }
    }
}
