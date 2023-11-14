using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool isActive { get; set; }
        public int? PercentOff { get; set; }
        public decimal? PriceOff { get; set; }
        public List<DiscountProduct>? DiscountProducts { get; set; }
    }
}
