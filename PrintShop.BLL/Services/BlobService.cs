using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PrintShop.BLL.Services.Interfaces;

namespace PrintShop.BLL.Services
{
    internal class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly BlobContainerClient _containerClient;
        private readonly IConfiguration _configuration;

        public BlobService(BlobServiceClient blobServiceClient, IConfiguration configuration)
        {
            _blobServiceClient = blobServiceClient;
            _configuration = configuration;
            _containerClient = _blobServiceClient.GetBlobContainerClient(_configuration.GetSection("AzureStorage:PictureContainer").Value);
        }

        public async Task<string> DeleteFileAsync(string name)
        {
            var blobClient = _containerClient.GetBlobClient(name);
            return await blobClient.DeleteIfExistsAsync() ? "File deleted successfully." : "File not found.";
        }

        public async Task<IEnumerable<string>> GetBlobListAsync()
        {
            var items = new List<string>();

            await foreach (var item in _containerClient.GetBlobsAsync())
            {
                items.Add(item.Name);
            }
            return items;
        }

        public string GetBlobSASTokenAsync(string name)
        {
            try
            {
                var blobClient = _containerClient.GetBlobClient(name);
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

        public async Task<Azure.Response<BlobContentInfo>> UploadFileViaPathAsync(string path, string name)
        {
            var blobClient = _containerClient.GetBlobClient(name);
            return await blobClient.UploadAsync(path, new BlobHttpHeaders { ContentType = path.GetContentType()});
        }

        public async Task<Azure.Response<BlobContentInfo>> UploadSingleFileAsync(IFormFile file, string name)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                memoryStream.Position = 0;
                return await _containerClient.UploadBlobAsync(name.ToString(), memoryStream);
            }
        }

        public async Task<ICollection<Azure.Response<BlobContentInfo>>> UploadFilesAsync(ICollection<IFormFile> files)
        {
            var response = new List<Azure.Response<BlobContentInfo>>();
            foreach (var file in files)
            {
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    memoryStream.Position = 0;
                    var client = await _containerClient.UploadBlobAsync(file.FileName, memoryStream);
                    response.Add(client);
                }
            }
            return response;
        }

        public async Task<List<BlobItem>> GetUploadedBlobsAsync()
        {
            var items = new List<BlobItem>();
            var uploadedFiles = _containerClient.GetBlobsAsync();
            await foreach (BlobItem file in uploadedFiles)
            {
                items.Add(file);
            }

            return items;
        }

        public string GetBlobUrl(string blobName)
        {
            return _containerClient.GetBlobClient(blobName).Uri.ToString();

        }

        public async Task<Azure.Response<BlobContentInfo>> UploadImageBytesAsync(string filename, byte[] blobToSave)
        {
            var blobContainer = _blobServiceClient.GetBlobContainerClient(_configuration.GetSection("AzureStorage:WebPicContainer").Value);
            var blobClient = blobContainer.GetBlobClient(filename);
            return await blobClient.UploadAsync(new MemoryStream(blobToSave));
        }

        public async Task<Tuple<bool,string>> DeletePictureAsync(string id)
        {
            var blobClient1 = _containerClient.GetBlobClient(id + ".tiff");
            var blobContainer = _blobServiceClient.GetBlobContainerClient(_configuration.GetSection("AzureStorage:WebPicContainer").Value);
            var blobClient2 = blobContainer.GetBlobClient(id + _configuration.GetSection("GeneratedFileNameExtensions:Large").Value);
            var blobClient3 = blobContainer.GetBlobClient(id + _configuration.GetSection("GeneratedFileNameExtensions:Small").Value);
            // Check that all blobs are present in storage
            if (await blobClient1.ExistsAsync() && await blobClient2.ExistsAsync() && await blobClient3.ExistsAsync())
            {
                await blobClient1.DeleteAsync();
                await blobClient2.DeleteAsync();
                await blobClient3.DeleteAsync();
                return new Tuple<bool, string>( true, "All versions of picture deleted." );
            }
            return new Tuple<bool, string>(true, "One or more files not found in blob storage.");
        }
    }
}
