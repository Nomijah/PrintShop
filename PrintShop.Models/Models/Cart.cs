namespace PrintShop.GlobalData.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public User? User { get; set; }
        public List<CartItem>? CartItems { get; set; }
    }
}