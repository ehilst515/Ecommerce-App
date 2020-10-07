namespace ECommerceApp.Models.Cart
{
    public class CartItem
    {
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }

    }
}
