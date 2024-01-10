using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PrintShop.DAL.Context;
using PrintShop.DAL.Repositories.Interfaces;
using PrintShop.GlobalData.Models;
using PrintShop.GlobalData.Models.DTOs.ResponseDTOs;

namespace PrintShop.DAL.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<User> _userManager;
        public UserRepository(AppDbContext appDbContext, UserManager<User> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        public async Task<IEnumerable<UserWithRoleResponseDto>> GetAllWithRolesAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            List<UserWithRoleResponseDto> result = new();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                result.Add(new UserWithRoleResponseDto
                {
                    email = user.Email,
                    emailConfirmed = user.EmailConfirmed,
                    id = user.Id.ToString(),
                    userName = user.UserName,
                    roles = roles
                });
            }

            return result;
        }
    }
}
