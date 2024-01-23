using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;

namespace PrintShop.BLL.Services.Interfaces
{
    public interface IBlobService
    {
        public Task<IEnumerable<string>> GetBlobListAsync();
        public string GetBlobSASTokenAsync(string name);
        public Task<Azure.Response<BlobContentInfo>> UploadFileViaPathAsync(string path, string name);
        public Task<Azure.Response<BlobContentInfo>> UploadSingleFileAsync(IFormFile file, string name);
        public Task<ICollection<Azure.Response<BlobContentInfo>>> UploadFilesAsync(ICollection<IFormFile> files);
        public Task<string> DeleteFileAsync(string name);
        public Task<Tuple<bool, string>> DeletePictureAsync(string id);
        public Task<List<BlobItem>> GetUploadedBlobsAsync();
        public string GetBlobUrl(string name);
        public Task<Azure.Response<BlobContentInfo>> UploadImageBytesAsync(string filename, byte[] blobToSave);
    }
}
