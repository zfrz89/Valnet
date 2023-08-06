using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valnet.Cart.Model
{
    public class Cart:BaseModel
    {
        public int UserId { get; set; }
        public string Status { get; set; }
        public List<ProductInCart> Products { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
