using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.GlobalData.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool isActive { get; set; }
        public DiscountType DiscountType { get; set; }
        public decimal MinimumSpent { get; set; } = 0;
        public decimal MinimumItems { get; set; } = 0;
        public decimal? AmountOff { get; set; }
        public List<DiscountProduct>? DiscountProducts { get; set; }
    }
}
