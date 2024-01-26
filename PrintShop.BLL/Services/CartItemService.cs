using Microsoft.AspNetCore.Http;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.BLL.Validation.CartItemValidations;
using PrintShop.DAL.Repositories.Interfaces;
using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;

namespace PrintShop.BLL.Services
{
    internal class CartItemService : ICartItemService
    {
        private readonly IRepository<CartItem> _cartItemRepo;

        public CartItemService(IRepository<CartItem> cartItemRepo)
        {
            _cartItemRepo = cartItemRepo;
        }
        public async Task<ApiResponse> Create(CartItemCreateDto cartItemCreateDto)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var validator = new CartItemCreateValidator();
            var validationResult = await validator.ValidateAsync(cartItemCreateDto);
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors.Select(x => x.ErrorMessage))
                {
                    response.ErrorMessages.Add(item);
                };
                return response;
            }

            await _cartItemRepo.AddAsync(new CartItem
            {
                CartId = cartItemCreateDto.CartId,
                ProductId = cartItemCreateDto.ProductId,
                Quantity = cartItemCreateDto.Quantity,
            });

            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status201Created;
            response.Result = "CartItem created successfully.";
            return response;
        }

        public async Task<ApiResponse> Delete(int id)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var cartItemToDelete = await _cartItemRepo.GetByIdAsync(id);
            if (cartItemToDelete == null)
            {
                response.ErrorMessages.Add("Id not found.");
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            await _cartItemRepo.DeleteAsync(cartItemToDelete);

            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status200OK;
            response.Result = "CartItem deleted.";
            return response;
        }

        public async Task<ApiResponse> Get(int id)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var result = await _cartItemRepo.GetByIdAsync(id);

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
            var result = await _cartItemRepo.GetAllAsync();

            if (result != null)
            {
                response.IsSuccess = true;
                response.StatusCode = StatusCodes.Status200OK;
                response.Result = result;
                return response;
            }
            return response;
        }

        public async Task<ApiResponse> Update(CartItemUpdateDto cartItemUpdateDto)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var cartItemToUpdate = await _cartItemRepo.GetByIdAsync(cartItemUpdateDto.Id);
            if (cartItemToUpdate == null)
            {
                response.ErrorMessages.Add("Id not found.");
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            cartItemToUpdate.Quantity = cartItemUpdateDto.Quantity;

            await _cartItemRepo.UpdateAsync(cartItemToUpdate);
            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status200OK;
            response.Result = "CartItem updated.";
            return response;
        }
    }
}
