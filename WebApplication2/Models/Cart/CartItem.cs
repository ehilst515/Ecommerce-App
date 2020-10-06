using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models.Cart
{
    public class CartItem
    {
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }

    }
}
