using Microsoft.AspNetCore.Mvc;
using PrintShop.BLL.Services.Interfaces;
using Serilog;

namespace Printshop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlobController : ControllerBase
    {
        private readonly IBlobService _blobService;

        public BlobController(IBlobService blobService)
        {
           _blobService = blobService;
        }

        [HttpGet("GetByFileName")]
        public IActionResult GetByFileName(string name)
        {
            var response = _blobService.GetBlobSASTokenAsync(name);
            Log.Information("Response => {@response}", response);
            return response != null ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetListOfFileNames")]
        public async Task<IActionResult> GetListOfFileNames()
        {
            var response = await _blobService.GetBlobListAsync();
            Log.Information("Response => {@response}", response);
            return response != null ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetAllBlobs")]
        public async Task<IActionResult> GetAllBlobs()
        {
            var response = await _blobService.GetUploadedBlobsAsync();
            Log.Information("Response => {@response}", response);
            return response != null ? Ok(response) : BadRequest(response);
        }

        [HttpPost("UploadFileViaPath")]
        public async Task<IActionResult> UploadFileViaPath(string path, string name)
        {
            var response = await _blobService.UploadFileViaPathAsync(path, name);
            Log.Information("Response => {@response}", response);
            return response != null ? Ok(response) : BadRequest(response);
        }

        [HttpPost("UploadSingleFile")]
        public async Task<IActionResult> UploadSingleFile(IFormFile file, string name)
        {
            var response = await _blobService.UploadSingleFileAsync(file, name);
            Log.Information("Response => {@response}", response);
            return response != null ? Ok(response) : BadRequest(response);
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> UploadFiles(ICollection<IFormFile> files)
        {
            var response = await _blobService.UploadFilesAsync(files);
            Log.Information("Response => {@response}", response);
            return response != null ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("DeleteFile")]
        public async Task<IActionResult> DeleteFile(string name)
        {
            var response = await _blobService.DeleteFileAsync(name);
            Log.Information("Response => {@response}", response);
            return response != null ? Ok(response) : BadRequest(response);
        }
    }
}
