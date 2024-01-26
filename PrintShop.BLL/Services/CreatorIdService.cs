using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.BLL.Validation.CreatorIdValidations;
using PrintShop.DAL.Repositories.Interfaces;
using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;

namespace PrintShop.BLL.Services
{
    internal class CreatorIdService : ICreatorIdService
    {
        private readonly IRepository<CreatorId> _creatorIdRepo;
        private readonly UserManager<User> _userManager;

        public CreatorIdService(IRepository<CreatorId> creatorIdRepo, UserManager<User> userManager)
        {
            _creatorIdRepo = creatorIdRepo;
            _userManager = userManager;
        }

        public async Task<ApiResponse> Create(CreatorIdDto creatorIdDto)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var validator = new CreatorIdCreateValidator();
            var validationResult = await validator.ValidateAsync(creatorIdDto);
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors.Select(x => x.ErrorMessage))
                {
                    response.ErrorMessages.Add(item);
                };
                return response;
            }

            var user = await _userManager.FindByIdAsync(creatorIdDto.UserId.ToString());
            if (user == null)
            {
                response.ErrorMessages.Add("User with provided id does not exist.");
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Contains("Creator"))
            {
                response.ErrorMessages.Add("The user does not have a Creator role.");
                return response;
            }

            var checkIfExists = await _creatorIdRepo.GetByStringIdAsync(creatorIdDto.Id);
            if (checkIfExists != null)
            {
                response.ErrorMessages.Add($"CreatorId {creatorIdDto.Id} already exists.");
                return response;
            }

            await _creatorIdRepo.AddAsync(new CreatorId
            {
                Id = creatorIdDto.Id,
                UserId = creatorIdDto.UserId,
                Name = creatorIdDto.Name,
                Presentation = creatorIdDto.Presentation,
            });

            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status201Created;
            response.Result = "CreatorId created successfully.";
            return response;
        }

        public async Task<ApiResponse> Delete(string id)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var printSizeToDelete = await _creatorIdRepo.GetByStringIdAsync(id);
            if (printSizeToDelete == null)
            {
                response.ErrorMessages.Add("Id not found.");
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            await _creatorIdRepo.DeleteAsync(printSizeToDelete);

            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status200OK;
            response.Result = "CreatorId deleted.";
            return response;
        }

        public async Task<ApiResponse> Get(string id)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var result = await _creatorIdRepo.GetByStringIdAsync(id);

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
            var result = await _creatorIdRepo.GetAllAsync();

            if (result != null)
            {
                response.IsSuccess = true;
                response.StatusCode = StatusCodes.Status200OK;
                response.Result = result;
                return response;
            }
            return response;
        }

        public async Task<ApiResponse> Update(CreatorIdDto creatorIdDto)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var creatorIdToUpdate = await _creatorIdRepo.GetByStringIdAsync(creatorIdDto.Id);
            if (creatorIdToUpdate == null)
            {
                response.ErrorMessages.Add("Id not found.");
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            creatorIdToUpdate.UserId = creatorIdDto.UserId;
            creatorIdToUpdate.Name = creatorIdDto.Name;
            creatorIdToUpdate.Presentation = creatorIdDto.Presentation;

            await _creatorIdRepo.UpdateAsync(creatorIdToUpdate);
            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status200OK;
            response.Result = "PrintSize updated.";
            return response;
        }
    }
}
