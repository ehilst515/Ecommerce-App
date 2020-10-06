using ECommerceApp.Models.Cart;
using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public CartItem Cart { get; set; }
    }
}
