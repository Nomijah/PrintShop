using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;

namespace PrintShop.BLL.Services.Interfaces
{
    public interface IVariantService
    {
        public Task<ApiResponse> GetAll();
        public Task<ApiResponse> Get(int id);
        public Task<ApiResponse> Create(VariantCreateDto variantCreateDto);
        public Task<ApiResponse> Update(VariantUpdateDto variantUpdateDto);
        public Task<ApiResponse> Delete(int id);
    }
}
