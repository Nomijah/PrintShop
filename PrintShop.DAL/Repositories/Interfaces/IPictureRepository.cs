using PrintShop.GlobalData.Models;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;

namespace PrintShop.DAL.Repositories.Interfaces
{
    public interface IPictureRepository
    {
        Task<IEnumerable<Picture>> GetAllAsync(); 
        Task<Picture> GetByIdAsync();
        Task<Picture> AddAsync(PictureUploadDto pictureUploadDto);
        Task UpdateAsync(Picture picture);
        Task DeleteAsync(int id);
        Task AddCategoryAsync(int categoryId);
        Task AddTagAsync(int tagId);
    }
}
