using Microsoft.AspNetCore.Http;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.BLL.Validation.MaterialValidations;
using PrintShop.DAL.Repositories.Interfaces;
using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models;
using PrintShop.GlobalData.Models.DTOs.GeneralDtos;

namespace PrintShop.BLL.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IRepository<Material> _materialRepo;
        public MaterialService(IRepository<Material> materialRepo)
        {
            _materialRepo = materialRepo;
        }
        public async Task<ApiResponse> Create(MaterialCreateDto materialCreateDto)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var validator = new MaterialValidator();
            var validationResult = await validator.ValidateAsync(materialCreateDto);
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors.Select(x => x.ErrorMessage))
                {
                    response.ErrorMessages.Add(item);
                };
                return response;
            }

            var all = await _materialRepo.GetAllAsync();
            foreach (var item in all)
            {
                if (materialCreateDto.Name == item.Name)
                {
                    response.ErrorMessages.Add("This material is already in the database, duplicates are not allowed.");
                    return response;
                }
            }

            var materialToAdd = new Material
            {
                Name = materialCreateDto.Name,
                Description = materialCreateDto.Description,
                IsActive = materialCreateDto.IsActive,
            };
            await _materialRepo.AddAsync(materialToAdd);

            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status201Created;
            response.Result = "Material created successfully.";
            return response;
        }

        public async Task<ApiResponse> Delete(int id)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var materialToDelete = await _materialRepo.GetByIdAsync(id);
            if (materialToDelete == null)
            {
                response.ErrorMessages.Add("Id not found.");
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            await _materialRepo.DeleteAsync(materialToDelete);

            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status200OK;
            response.Result = "Material deleted.";
            return response;
        }

        public async Task<ApiResponse> Get(int id)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var result = await _materialRepo.GetByIdAsync(id);

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
            var result = await _materialRepo.GetAllAsync();

            if (result != null)
            {
                response.IsSuccess = true;
                response.StatusCode = StatusCodes.Status200OK;
                response.Result = result;
                return response;
            }
            return response;
        }

        public async Task<ApiResponse> Update(Material material)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var materialToUpdate = await _materialRepo.GetByIdAsync(material.Id);
            if (materialToUpdate == null)
            {
                response.ErrorMessages.Add("Id not found.");
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            materialToUpdate = material;
            await _materialRepo.UpdateAsync(materialToUpdate);
            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status200OK;
            response.Result = "Material updated.";
            return response;
        }
    }
}
