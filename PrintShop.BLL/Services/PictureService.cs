using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.DAL.Repositories.Interfaces;
using PrintShop.GlobalData.Data;
using PrintShop.GlobalData.Models;

namespace PrintShop.BLL.Services
{
    public class PictureService : IPictureService
    {
        private readonly IRepository<Picture> _pictureRepo;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IConfiguration _configuration;

        public PictureService(IRepository<Picture> pictureRepo, BlobServiceClient blobServiceClient, IConfiguration configuration)
        {
            _pictureRepo = pictureRepo;
            _blobServiceClient = blobServiceClient;
            _configuration = configuration;
        }
        public Task<ApiResponse> Create(Picture picture)
        {
            throw new NotImplementedException();
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

            var containerClient = _blobServiceClient.GetBlobContainerClient("pictures");
            var blobClient = containerClient.GetBlobClient("LjungskileSolnedgang.jpg");
            var file = await blobClient.DownloadContentAsync();

            return response;
        }

        public Task<ApiResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Update(Picture picture)
        {
            throw new NotImplementedException();
        }
    }
}
