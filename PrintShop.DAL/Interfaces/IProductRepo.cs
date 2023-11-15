using PrintShop.GlobalData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.DAL.Interface
{
    internal interface IProductRepo
    {
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
