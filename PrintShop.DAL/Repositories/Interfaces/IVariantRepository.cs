using PrintShop.GlobalData.Models.DTOs.GenericDtos;

namespace PrintShop.DAL.Repositories.Interfaces
{
    public interface IVariantRepository
    {
        Task<IEnumerable<VariantGetDto>> GetAllDtoAsync();
        Task<VariantGetDto?> GetDtoByIdAsync(int Id);
    }
}
