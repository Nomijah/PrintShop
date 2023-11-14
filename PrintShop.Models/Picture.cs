using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string SKUPart { get; set; } = String.Empty;
        public string url { get; set; } = String.Empty;
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public int Height { get; set; }
        public int Width { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsActive { get; set; }
        public List<Category>? Categories { get; set; }
        public List<string>? Tags { get; set; }
        public List<Discount>? Discounts { get; set; }
        public List<Product>? Products { get; set; }
    }
}
