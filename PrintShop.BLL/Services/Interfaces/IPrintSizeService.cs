using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models;
using PrintShop.GlobalData.Models.DTOs.PrintSizeDTOs;

namespace PrintShop.BLL.Services.Interfaces
{
    public interface IPrintSizeService
    {
        public Task<ApiResponse> GetAll();
        public Task<ApiResponse> Get(int id);
        public Task<ApiResponse> Create(PrintSizeCreateDto printSizeCreateDto);
        public Task<ApiResponse> Update(PrintSize size);
        public Task<ApiResponse> Delete(int id);
    }
}
