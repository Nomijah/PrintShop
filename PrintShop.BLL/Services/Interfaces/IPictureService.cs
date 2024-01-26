using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;

namespace PrintShop.BLL.Services.Interfaces
{
    public interface IPictureService
    {
        public Task<ApiResponse> Get(Guid id);
        public Task<ApiResponse> GetAll();
        public Task<ApiResponse> GetBySKU(string skuPart);
        public Task<ApiResponse> Upload(PictureUploadDto pictureUploadDto);
        public Task<ApiResponse> Update(Picture picture);
        public Task<ApiResponse> Delete(Guid id);
        public Task<ApiResponse> DeleteMultiple(ICollection<string> ids);
        public Task<ApiResponse> GetAllIDs();
        public Task<ApiResponse> GetAllIDs(string creeatorId);
    }
}
