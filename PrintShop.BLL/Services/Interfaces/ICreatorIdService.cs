using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;

namespace PrintShop.BLL.Services.Interfaces
{
    public interface ICreatorIdService
    {
        public Task<ApiResponse> GetAll();
        public Task<ApiResponse> Get(string id);
        public Task<ApiResponse> Create(CreatorIdDto creatorIdDto);
        public Task<ApiResponse> Update(CreatorIdDto creatorIdDto);
        public Task<ApiResponse> Delete(string id);
    }
}
