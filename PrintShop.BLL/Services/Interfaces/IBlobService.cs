using Azure.Storage.Blobs.Models;

namespace PrintShop.BLL.Services.Interfaces
{
    public interface IBlobService
    {
        public Task<IEnumerable<string>> GetBlobListAsync();
        public string GetBlobSASTokenAsync(string name);
        public Task<Azure.Response<BlobContentInfo>> UploadFileAsync(string path, string name);
        public Task<string> DeleteFileAsync(string name);
    }
}
