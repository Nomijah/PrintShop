using Microsoft.AspNetCore.Mvc;
using PrintShop.BLL.Services;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;
using PrintShop.GlobalData.Models;
using Serilog;

namespace Printshop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreatorIdController : ControllerBase
    {
        private readonly ICreatorIdService _creatorIdService;
        public CreatorIdController(ICreatorIdService creatorIdService)
        {
            _creatorIdService = creatorIdService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _creatorIdService.GetAll();
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _creatorIdService.Get(id);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreatorIdDto creatorIdDto)
        {
            var response = await _creatorIdService.Create(creatorIdDto);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _creatorIdService.Delete(id);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CreatorIdDto creatorIdDto)
        {
            var response = await _creatorIdService.Update(creatorIdDto);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
