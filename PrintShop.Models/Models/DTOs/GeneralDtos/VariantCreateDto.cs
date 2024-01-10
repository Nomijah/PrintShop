using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.GlobalData.Models.DTOs.GeneralDtos
{
    public class VariantCreateDto
    {
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int MaterialId { get; set; }
        public int PrintSizeId { get; set; }
    }
}
