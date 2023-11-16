using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Update.Internal;
using PrintShop.GlobalData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintShop.DAL.Repositories.Interfaces
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(string id);
        Task<User> GetByEmailAsync(string email);
        Task<IdentityResult> AddAsync(User user, string password);
        Task<IdentityResult> UpdateAsync(User user);
        Task<IdentityResult> DeleteAsync(User user);
        Task<IdentityResult> UpdatePasswordAsync(
            User user, string newPassword, string oldPassword);
        Task<IdentityResult> SetNewRoleAsync(User user, string role);
    }
}
