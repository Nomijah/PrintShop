using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;

namespace PrintShop.BLL.Services.Interfaces
{
    public interface ICartItemService
    {
        public Task<ApiResponse> GetAll();
        public Task<ApiResponse> Get(int id);
        public Task<ApiResponse> Create(CartItemCreateDto cartItemCreateDto);
        public Task<ApiResponse> Update(CartItemUpdateDto cartItemUpdateDto);
        public Task<ApiResponse> Delete(int id);
    }
}
