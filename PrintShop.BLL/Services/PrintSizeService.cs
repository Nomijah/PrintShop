using Microsoft.AspNetCore.Http;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.BLL.Validation.PrintSizeValidations;
using PrintShop.DAL.Repositories.Interfaces;
using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;

namespace PrintShop.BLL.Services
{
    public class PrintSizeService : IPrintSizeService
    {
        private readonly IRepository<PrintSize> _printSizeRepo;

        public PrintSizeService(IRepository<PrintSize> printSizeRepo)
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
                foreach (var item in validationResult.Errors.Select(x => x.ErrorMessage))
                {
                    response.ErrorMessages.Add(item);
                };
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
            
            await _printSizeRepo.AddAsync(new PrintSize(printSizeCreateDto.Id, printSizeCreateDto.Height, printSizeCreateDto.Width));

            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status201Created;
            response.Result = "PrintSize created successfully.";
            return response;
        }

        public async Task<ApiResponse> Delete(int id)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var printSizeToDelete = await _printSizeRepo.GetByIdAsync(id);
            if (printSizeToDelete == null)
            {
                response.ErrorMessages.Add("Id not found.");
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            await _printSizeRepo.DeleteAsync(printSizeToDelete);

            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status200OK;
            response.Result = "PrintSize deleted.";
            return response;
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

            response.StatusCode = StatusCodes.Status404NotFound;
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

        public async Task<ApiResponse> Update(PrintSize size)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var printSizeToUpdate = await _printSizeRepo.GetByIdAsync(size.Id);
            if (printSizeToUpdate == null)
            {
                response.ErrorMessages.Add("Id not found.");
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            printSizeToUpdate = size;
            await _printSizeRepo.UpdateAsync(printSizeToUpdate);
            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status200OK;
            response.Result = "PrintSize updated.";
            return response;
        }
    }
}
