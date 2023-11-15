namespace PrintShop.GlobalData.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Head { get; set; } = string.Empty; // For storing customer info
        public List<OrderRow>? OrderRows { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime? ShippingTime { get; set; }
        public bool IsShipped { get; set; }
        public bool IsPaid { get; set; }
        public bool IsActive { get; set; }
    }
}