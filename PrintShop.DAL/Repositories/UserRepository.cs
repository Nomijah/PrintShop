using PrintShop.DAL.Repositories.Interfaces;
using PrintShop.GlobalData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.DAL.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public Task<IEnumerable<User>> GetAllWithRolesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
