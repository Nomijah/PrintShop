using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.GlobalData.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string SKU { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? PictureId { get; set; }
        public Picture? Picture { get; set; }
        public int? VariantId { get; set; }
        public Variant? Variant { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public List<DiscountProduct>? Discounts { get; set; }
    }
}
