using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.GlobalData.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int? ParentCategoryId { get; set; } // Null if top level category
        public string Name { get; set; } = string.Empty;
    }
}
