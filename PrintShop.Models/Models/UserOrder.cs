using System.Reflection.Metadata;

namespace PrintShop.GlobalData.Models
{
    public class UserOrder
    {
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}