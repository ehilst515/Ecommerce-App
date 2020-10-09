using ECommerceApp.Models.Identity;

namespace ECommerceApp.Models.Cart
{
    public class CartItem
    {
        public string UserId { get; set; }
        public long ProductId { get; set; }

        public int Quantity { get; set; }

        // Navigation Properties
        public ApplicationUser User { get; set; }

        public Product Product { get; set; }
    }
}