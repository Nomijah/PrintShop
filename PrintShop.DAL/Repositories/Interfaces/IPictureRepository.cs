using PrintShop.GlobalData.Models;

namespace PrintShop.DAL.Repositories.Interfaces
{
    public interface IPictureRepository
    {
        Task<Picture?> GetByIdAsync(Guid id);
        Task<Picture?> GetBySKUAsync(string skuPart);
        Task<ICollection<string>> GetAllIDs();
        Task<ICollection<string>> GetAllIDs(string creeatorId);
    }
}
