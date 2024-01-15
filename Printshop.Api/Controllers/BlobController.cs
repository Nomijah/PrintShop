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
        public async Task<IActionResult> GetByFileName(string name)
        {
            var response = await _blobService.GetBlobSASTokenAsync(name);
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

        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile(string path, string name)
        {
            var response = await _blobService.UploadFileAsync(path, name);
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
