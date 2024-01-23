using PrintShop.GlobalData.Models;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;

namespace PrintShop.DAL.Repositories.Interfaces
{
    public interface IPictureRepository
    {
        Task<Picture?> GetByIdAsync(Guid id);
        Task<Picture?> GetBySKUAsync(string skuPart);
    }
}
