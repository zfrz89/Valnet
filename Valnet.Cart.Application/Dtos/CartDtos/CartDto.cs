using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valnet.Cart.Model;

namespace Valnet.Cart.Application.Dtos.CartDtos
{
    public class CartDto
    {
        public int UserId { get; set; }
        public string Status { get; set; }
        public ICollection<ProductInCart> Products { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public float Total { get; set; }
    }
}
