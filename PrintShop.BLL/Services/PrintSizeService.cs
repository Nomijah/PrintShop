using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.BLL.Validation.PrintSizeValidations;
using PrintShop.DAL.Repositories;
using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models;
using PrintShop.GlobalData.Models.DTOs.PrintSizeDTOs;
using PrintShop.GlobalData.Models.DTOs.ResponseDTOs;

namespace PrintShop.BLL.Services
{
    public class PrintSizeService : IPrintSizeService
    {
        private readonly GeneralRepository<PrintSize> _printSizeRepo;

        public PrintSizeService(GeneralRepository<PrintSize> printSizeRepo)
        {
            _printSizeRepo = printSizeRepo;
        }
        public async Task<ApiResponse> Create(PrintSizeCreateDto printSizeCreateDto)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var validator = new PrintSizeCreateValidator();
            var validationResult = await validator.ValidateAsync(printSizeCreateDto);
            if (!validationResult.IsValid)
            {
                response.ErrorMessages.Add("Both height and width has to be a number greater than 1.");
                return response;
            }

            var all = await _printSizeRepo.GetAllAsync();
            foreach ( var item in all )
            {
                if (printSizeCreateDto.Height == item.Height && printSizeCreateDto.Width == item.Width)
                {
                    response.ErrorMessages.Add("This size is already in the database, duplicates are not allowed.");
                    return response;
                }
            }
            
            await _printSizeRepo.AddAsync(new PrintSize(printSizeCreateDto.Height, printSizeCreateDto.Width));

            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status201Created;
            response.Result = "PrintSize created successfully.";
            return response;
        }

        public Task<ApiResponse> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> Get(int id)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var result = await _printSizeRepo.GetByIdAsync(id);

            if (result != null)
            {
                response.IsSuccess = true;
                response.StatusCode = StatusCodes.Status200OK;
                response.Result = result;
                return response;
            }
            return response;
        }

        public async Task<ApiResponse> GetAll()
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };
            var result = await _printSizeRepo.GetAllAsync();

            if (result != null)
            {
                response.IsSuccess = true;
                response.StatusCode = StatusCodes.Status200OK;
                response.Result = result;
                return response;
            }
            return response;
        }

        public Task<ApiResponse> Update(PrintSize size)
        {
            throw new NotImplementedException();
        }
    }
}
