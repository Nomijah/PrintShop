using System.Reflection.Metadata;

namespace PrintShop.GlobalData.Models
{
    public class UserOrder
    {
        //public int Id { get; set; }
        public Guid UserId { get; set; }
        public int OrderId { get; set; }
    }
}