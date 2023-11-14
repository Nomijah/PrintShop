using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.Models
{
    public class Shipment
    {
        public int Id { get; set; }
        public DateTime ShippingDate { get; set; }
        public string ShippingCompany { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public string ZipCode { get; set; } = String.Empty;
        public string Country { get; set; } = String.Empty;
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string UserId { get; set; } = String.Empty;
        public User User { get; set; }
    }
}
