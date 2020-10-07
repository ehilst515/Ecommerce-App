using System.Collections.Generic;
using ECommerceApp.Models.Cart;
using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        // Reverse navigation property
        public List<CartItem> Cart { get; set; }
    }
}