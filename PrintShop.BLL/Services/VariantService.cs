using Microsoft.AspNetCore.Http;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.BLL.Validation.VariantValidations;
using PrintShop.DAL.Repositories.Interfaces;
using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;

namespace PrintShop.BLL.Services
{
    public class VariantService : IVariantService
    {
        public readonly IRepository<Variant> _variantGeneralRepo;
        public readonly IVariantRepository _variantRepo;
        public readonly IRepository<Material> _materialRepo;
        public readonly IRepository<PrintSize> _printSizeRepo;
        public VariantService(IRepository<Variant> variantGeneralRepo, 
            IRepository<Material> materialRepo, IRepository<PrintSize> printSizeRepo,
            IVariantRepository variantRepo)
        {
            _variantGeneralRepo = variantGeneralRepo;
            _materialRepo = materialRepo;
            _printSizeRepo = printSizeRepo;
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

            var material = await _materialRepo.GetByIdAsync(variantCreateDto.MaterialId);
            var printSize = await _printSizeRepo.GetByIdAsync(variantCreateDto.PrintSizeId);
            if (material == null || printSize == null)
            {
                if (material == null)
                    response.ErrorMessages.Add("MaterialId not found");
                if (printSize == null)
                    response.ErrorMessages.Add("PrintSizeId not found");
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            var all = await _variantRepo.GetAllDtoAsync();
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
                MaterialId = variantCreateDto.MaterialId,
                Size = printSize,
                Material = material,
            };
            await _variantGeneralRepo.AddAsync(variantToAdd);

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

            var variantToDelete = await _variantGeneralRepo.GetByIdAsync(id);
            if (variantToDelete == null)
            {
                response.ErrorMessages.Add("Id not found.");
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            await _variantGeneralRepo.DeleteAsync(variantToDelete);

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

            var result = await _variantRepo.GetDtoByIdAsync(id);

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
            var result = await _variantRepo.GetAllDtoAsync();

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

            var variantToUpdate = await _variantGeneralRepo.GetByIdAsync(variantUpdateDto.Id);
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

            await _variantGeneralRepo.UpdateAsync(variantToUpdate);
            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status200OK;
            response.Result = "Variant updated.";
            return response;
        }
    }
}
