using Microsoft.EntityFrameworkCore;
using PrintShop.DAL.Context;
using PrintShop.DAL.Repositories.Interfaces;
using PrintShop.GlobalData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.DAL.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _appDbContext;

        public UserRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<User> GetByIdAsync(string id)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
