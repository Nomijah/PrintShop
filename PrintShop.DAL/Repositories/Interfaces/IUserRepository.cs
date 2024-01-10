using PrintShop.GlobalData.Models.DTOs.ResponseDTOs;

namespace PrintShop.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserWithRoleResponseDto>> GetAllWithRolesAsync(); 
    }
}
