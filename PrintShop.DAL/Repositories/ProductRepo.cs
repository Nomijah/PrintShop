using PrintShop.DAL.Interfaces;
using PrintShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.DAL.Repositories
{
    public class ProductRepo : IRepository<Product>
    {
        public Task AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
