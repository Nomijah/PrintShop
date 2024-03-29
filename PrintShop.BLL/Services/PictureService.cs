﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.BLL.Validation.PictureValidators;
using PrintShop.DAL.Repositories.Interfaces;
using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;
using System.Drawing;

namespace PrintShop.BLL.Services
{
    public class PictureService : IPictureService
    {
        private readonly IRepository<Picture> _genericPictureRepo;
        private readonly IPictureRepository _pictureRepo;
        private readonly IBlobService _blobService;
        private readonly IConfiguration _configuration;
        private readonly IRepository<CreatorId> _creatorIdRepo;

        public PictureService(IRepository<Picture> genericPictureRepo,
            IPictureRepository pictureRepo, IBlobService blobService,
            IConfiguration configuration, IRepository<CreatorId> creatorIdRepo)
        {
            _genericPictureRepo = genericPictureRepo;
            _pictureRepo = pictureRepo;
            _blobService = blobService;
            _configuration = configuration;
            _creatorIdRepo = creatorIdRepo;
        }
        public async Task<ApiResponse> Upload(PictureUploadDto pictureUploadDto)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var validator = new PictureUploadValidator();
            var validationResult = await validator.ValidateAsync(pictureUploadDto);
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors.Select(x => x.ErrorMessage))
                {
                    response.ErrorMessages.Add(item);
                };
                return response;
            }

            var creatorIdCheck = await _creatorIdRepo.GetByStringIdAsync(pictureUploadDto.CreatorId);
            if (creatorIdCheck == null)
            {
                response.ErrorMessages.Add("The provided CreatorId does not exist.");
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            var skuPart = await GenerateUniqueSKUPart();

            var pictureToAdd = new Picture()
            {
                Id = Guid.NewGuid(),
                SKUPart = skuPart,
                CreatorId = pictureUploadDto.CreatorId,
                Title = pictureUploadDto.Title,
                Description = pictureUploadDto.Description,
                BasePrice = pictureUploadDto.BasePrice,
                IsActive = pictureUploadDto.IsActive,
            };

            using (var image = Image.FromStream(pictureUploadDto.File.OpenReadStream()))
            {
                if (image.Height < 1500 || image.Width < 1500)
                {
                    response.ErrorMessages.Add("Image resolution too low.");
                    return response;
                }
                pictureToAdd.Height = image.Height;
                pictureToAdd.Width = image.Width;
                var scaledImageSmall = ImageProcessing.ImageToByte(ImageProcessing.ResizeImage(image, 200));
                var result1 = await _blobService.UploadImageBytesAsync(pictureToAdd.Id.ToString()
                    + _configuration.GetSection("GeneratedFileNameExtensions:Small").Value,
                    scaledImageSmall);
                //var scaledImageLarge = ImageProcessing.ImageToByte(ImageProcessing.ResizeImage(image, 1024));
                //var largeWithWatermark = ImageProcessing.Watermark(ImageProcessing.BytesToStream(scaledImageLarge));
                var scaledImageLargeWithWatermark = ImageProcessing.WaterMark(
                    ImageProcessing.ResizeImage(image, 1024),
                    _configuration.GetSection("WatermarkText").Value);
                var result2 = await _blobService.UploadImageBytesAsync(pictureToAdd.Id.ToString()
                    + _configuration.GetSection("GeneratedFileNameExtensions:Large").Value,
                    scaledImageLargeWithWatermark);

                if (result1 == null || result2 == null)
                {
                    response.ErrorMessages.Add("Failed to upload generated file to blob storage.");
                    return response;
                }
            }

            //// Get file suffix for naming blob
            //var fileType = pictureUploadDto.File.FileName.GetContentType();
            //if (fileType == "image/tiff")
            //    fileType = ".tiff";                  // Eventually remove this later, should only expect Tiff-file.
            //else
            //    fileType = ".jpg";

            var blobData = await _blobService.UploadSingleFileAsync(pictureUploadDto.File, pictureToAdd.Id.ToString());

            if (blobData == null)
            {
                response.ErrorMessages.Add("Failed to upload file to blob storage.");
                return response;
            }

            pictureToAdd.Url = _blobService.GetBlobUrl(pictureUploadDto.File.FileName); // This row might need adjusting when applying frontend.

            response.Result = await _genericPictureRepo.AddAsync(pictureToAdd);
            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status201Created;

            return response;
        }

        public async Task<ApiResponse> Delete(Guid id)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var pictureToDelete = await _pictureRepo.GetByIdAsync(id);

            if (pictureToDelete == null)
            {
                response.ErrorMessages.Add($"Picture with id: {id}, not found.");
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            var deleteBlobResult = await _blobService.DeletePictureAsync(id.ToString());
            if (deleteBlobResult.Item1 == false)
            {
                response.ErrorMessages.Add(deleteBlobResult.Item2);
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            await _genericPictureRepo.DeleteAsync(pictureToDelete);

            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status200OK;
            return response;
        }

        public async Task<ApiResponse> GetAll()
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            response.Result = await _genericPictureRepo.GetAllAsync();
            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status200OK;
            return response;
        }

        public async Task<ApiResponse> Get(Guid id)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var result = await _pictureRepo.GetByIdAsync(id);
            if (result == null)
            {
                response.ErrorMessages.Add("Picture not found.");
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status200OK;
            return response;
        }

        public async Task<ApiResponse> GetBySKU(string skuPart)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var result = await _pictureRepo.GetBySKUAsync(skuPart);
            if (result == null)
            {
                response.ErrorMessages.Add($"Picture with SKUPart {skuPart} not found.");
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status200OK;
            response.Result = result;
            return response;
        }

        public Task<ApiResponse> Update(Picture picture)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GenerateUniqueSKUPart()
        {
            var pictures = await _genericPictureRepo.GetAllAsync();
            bool unique = false;
            int result = 0;
            do
            {
                Random rnd = new Random();
                result = rnd.Next(0, 10000);
                if (!pictures.ToList().Exists(p => p.SKUPart == "PI" + result.ToString("D4")))
                {
                    unique = true;
                }
            } while (!unique);
            return "PI" + result.ToString("D4");
        }

        public async Task<ApiResponse> GetAllIDs()
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            response.Result = await _pictureRepo.GetAllIDs();
            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status200OK;
            return response;
        }
        public async Task<ApiResponse> GetAllIDs(string creatorId)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            response.Result = await _pictureRepo.GetAllIDs(creatorId);
            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status200OK;
            return response;
        }

        public async Task<ApiResponse> DeleteMultiple(ICollection<string> ids)
        {
            ApiResponse response = new ApiResponse()
            {
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            };

            var pictureList = new List<Picture>();
            foreach (string id in ids)
            {
                var pictureToDelete = await _pictureRepo.GetByIdAsync(new Guid(id));
                if (pictureToDelete == null)
                {
                    response.ErrorMessages.Add($"Picture with id: {id}, not found.");
                }
                else
                {
                    pictureList.Add(pictureToDelete);
                }

                var deleteBlobResult = await _blobService.DeletePictureAsync(id);
                if (deleteBlobResult.Item1 == false)
                {
                    response.ErrorMessages.Add(deleteBlobResult.Item2);
                }
            }

            foreach (Picture picture in pictureList)
            {
                await _genericPictureRepo.DeleteAsync(picture);
            }

            if (response.ErrorMessages.Count > 0)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            response.IsSuccess = true;
            response.StatusCode = StatusCodes.Status200OK;
            return response;

        }
    }
}
