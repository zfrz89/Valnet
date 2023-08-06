using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valnet.Cart.Model
{
    public class ProductInCart: BaseModel
    {
        [Required]
        public long ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int CartId { get; set; }
    }
}
