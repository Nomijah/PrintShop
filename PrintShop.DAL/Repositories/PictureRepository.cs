using PrintShop.DAL.Repositories.Interfaces;
using PrintShop.GlobalData.Models;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;

namespace PrintShop.DAL.Repositories
{
    internal class PictureRepository : IPictureRepository
    {
        public Task<Picture> AddAsync(PictureUploadDto pictureUploadDto)
        {
            throw new NotImplementedException();
        }

        public Task AddCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task AddTagAsync(int tagId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Picture>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Picture> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Picture picture)
        {
            throw new NotImplementedException();
        }
    }
}
