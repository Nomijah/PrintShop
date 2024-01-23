using Microsoft.AspNetCore.Mvc;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;
using Serilog;
using System.IO;

namespace Printshop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PictureController : ControllerBase
    {
        private readonly IPictureService _pictureService;

        public PictureController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadPicture(PictureUploadDto pictureUploadDto)
        {
            var response = await _pictureService.Upload(pictureUploadDto);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePicture(Guid id)
        {
            var response = await _pictureService.Delete(id);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetPicture(string id)
        {
            var response = await _pictureService.Get(id);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
