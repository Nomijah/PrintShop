using Azure.Storage.Blobs.Models;
using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models;

namespace PrintShop.BLL.Services.Interfaces
{
    public interface IPictureService
    {
        public Task<ApiResponse> GetAll();
        public Task<ApiResponse> Get(int id);
        public Task<ApiResponse> Create(Picture picture);
        public Task<ApiResponse> Update(Picture picture);
        public Task<ApiResponse> Delete(int id);
    }
}
