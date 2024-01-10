using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;

namespace PrintShop.BLL.Services.Interfaces
{
    public interface IMaterialService
    {
        public Task<ApiResponse> GetAll();
        public Task<ApiResponse> Get(int id);
        public Task<ApiResponse> Create(MaterialCreateDto materialCreateDto);
        public Task<ApiResponse> Update(Material material);
        public Task<ApiResponse> Delete(int id);
    }
}
