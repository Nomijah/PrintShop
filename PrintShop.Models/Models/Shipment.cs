using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.GlobalData.Models
{
    public class Shipment
    {
        public int Id { get; set; }
        public DateTime ShippingDate { get; set; }
        public string ShippingCompany { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public string UserId { get; set; } = string.Empty;
        public User? User { get; set; }
    }
}
