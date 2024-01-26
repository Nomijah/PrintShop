using Microsoft.AspNetCore.Mvc;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;
using Serilog;

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
        [RequestSizeLimit(300_000_000)] // Added to be able to receive large image files.
        public async Task<IActionResult> UploadPicture(PictureUploadDto pictureUploadDto)
        {
            var response = await _pictureService.Upload(pictureUploadDto);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeletePicture(Guid id)
        {
            var response = await _pictureService.Delete(id);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("DeleteMultiple")]
        public async Task<IActionResult> DeleteMultiplePictures(ICollection<string> pictureIDs)
        {
            var response = await _pictureService.DeleteMultiple(pictureIDs);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetPicture(Guid id)
        {
            var response = await _pictureService.Get(id);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetAllPictureIDs")]
        public async Task<IActionResult> GetAllPictureIDs()
        {
            var response = await _pictureService.GetAllIDs();
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetAllPictureIDsFromCreator")]
        public async Task<IActionResult> GetAllPictureIDs(string creatorId)
        {
            var response = await _pictureService.GetAllIDs(creatorId);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _pictureService.GetAll();
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
