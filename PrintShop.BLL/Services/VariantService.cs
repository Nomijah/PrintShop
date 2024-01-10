using Microsoft.AspNetCore.Http;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.BLL.Validation.VariantValidations;
using PrintShop.DAL.Repositories.Interfaces;
using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models;
using PrintShop.GlobalData.Models.DTOs.GeneralDtos;

namespace PrintShop.BLL.Services
{
    public class VariantService : IVariantService
    {
        public readonly IRepository<Variant> _variantRepo;
        public VariantService(IRepository<Variant> variantRepo)
        {
            _variantRepo = variantRepo;
        }
        public async Task<ApiResponse> Create(VariantCreateDto variantCreateDto)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var validator = new VariantCreateValidator();
            var validationResult = await validator.ValidateAsync(variantCreateDto);
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors.Select(x => x.ErrorMessage))
                {
                    response.ErrorMessages.Add(item);
                };
                return response;
            }

            var all = await _variantRepo.GetAllAsync();
            foreach (var item in all)
            {
                if (variantCreateDto.MaterialId == item.MaterialId && variantCreateDto.PrintSizeId == item.PrintSizeId)
                {
                    response.ErrorMessages.Add("This variant is already in the database, duplicates are not allowed.");
                    return response;
                }
            }

            var variantToAdd = new Variant
            {
                Price = variantCreateDto.Price,
                Description = variantCreateDto.Description,
                PrintSizeId = variantCreateDto.PrintSizeId,
                MaterialId  = variantCreateDto.MaterialId,
            };
            await _variantRepo.AddAsync(variantToAdd);

            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status201Created;
            response.Result = "Variant created successfully.";
            return response;
        }

        public async Task<ApiResponse> Delete(int id)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var variantToDelete = await _variantRepo.GetByIdAsync(id);
            if (variantToDelete == null)
            {
                response.ErrorMessages.Add("Id not found.");
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            await _variantRepo.DeleteAsync(variantToDelete);

            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status200OK;
            response.Result = "variant deleted.";
            return response;
        }

        public async Task<ApiResponse> Get(int id)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var result = await _variantRepo.GetByIdAsync(id);

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
            var result = await _variantRepo.GetAllAsync();

            if (result != null)
            {
                response.IsSuccess = true;
                response.StatusCode = StatusCodes.Status200OK;
                response.Result = result;
                return response;
            }
            return response;
        }

        public async Task<ApiResponse> Update(VariantUpdateDto variantUpdateDto)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var variantToUpdate = await _variantRepo.GetByIdAsync(variantUpdateDto.Id);
            if (variantToUpdate == null)
            {
                response.ErrorMessages.Add("Id not found.");
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            variantToUpdate.Price = variantUpdateDto.Price;
            variantToUpdate.Description = variantUpdateDto.Description;
            variantToUpdate.PrintSizeId = variantUpdateDto.PrintSizeId;
            variantToUpdate.MaterialId = variantUpdateDto.MaterialId;

            await _variantRepo.UpdateAsync(variantToUpdate);
            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status200OK;
            response.Result = "Variant updated.";
            return response;
        }
    }
}
