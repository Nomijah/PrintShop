namespace PrintShop.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; } = String.Empty;
        public User? User { get; set; }
        public List<CartItem>? CartItems { get; set; }
    }
}