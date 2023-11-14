using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int? ParentCategoryId { get; set; } // Null if top level category
        public string Name { get; set; } = String.Empty;
    }
}
