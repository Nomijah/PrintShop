using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public string? PictureId { get; set; }
        public Picture? Picture { get; set; }
        public int? VariantId { get; set; }
        public Variant? Variant { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
