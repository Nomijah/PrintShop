using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.GlobalData.Models.DTOs.GeneralDtos
{
    public class MaterialCreateDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
