using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Microsoft.Extensions.Configuration;
using PrintShop.BLL.Services.Interfaces;

namespace PrintShop.BLL.Services
{
    internal class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IConfiguration _configuration;

        public BlobService(BlobServiceClient blobServiceClient, IConfiguration configuration)
        {
            _blobServiceClient = blobServiceClient;
            _configuration = configuration;
        }

        public async Task<string> DeleteFileAsync(string name)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_configuration.GetSection("AzureStorage:PictureContainer").Value);
            var blobClient = containerClient.GetBlobClient(name);
            return await blobClient.DeleteIfExistsAsync() ? "File deleted successfully." : "File not found.";
        }

        public async Task<IEnumerable<string>> GetBlobListAsync()
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_configuration.GetSection("AzureStorage:PictureContainer").Value);
            var items = new List<string>();

            await foreach (var item in containerClient.GetBlobsAsync())
            {
                items.Add(item.Name);
            }
            return items;
        }

        public string GetBlobSASTokenAsync(string name)
        {
            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(_configuration.GetSection("AzureStorage:PictureContainer").Value);
                var blobClient = containerClient.GetBlobClient(name);
                string url = blobClient.Uri.AbsoluteUri;

                var azureStorageAccount = _configuration.GetSection("AzureStorage:AzureAccount").Value;
                var azureStorageAccessKey = _configuration.GetSection("AzureStorage:AccessKey").Value;
                BlobSasBuilder blobSasBuilder = new BlobSasBuilder()
                {
                    BlobContainerName = "pictures",
                    BlobName = name,
                    ExpiresOn = DateTime.UtcNow.AddMinutes(2),//Let SAS token expire after 5 minutes.
                };
                blobSasBuilder.SetPermissions(BlobSasPermissions.Read);//User will only be able to read the blob and it's properties
                var sasToken = blobSasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential(azureStorageAccount,
                    azureStorageAccessKey)).ToString();
                return url + "?" + sasToken;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Azure.Response<BlobContentInfo>> UploadFileAsync(string path, string name)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_configuration.GetSection("AzureStorage:PictureContainer").Value);
            var blobClient = containerClient.GetBlobClient(name);
            return await blobClient.UploadAsync(path, new BlobHttpHeaders { ContentType = path.GetContentType()});
        }
    }
}
