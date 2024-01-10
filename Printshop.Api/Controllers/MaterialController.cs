using Microsoft.AspNetCore.Mvc;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.GlobalData.Models.DTOs.GeneralDtos;
using PrintShop.GlobalData.Models;
using Serilog;

namespace PrintShop.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;
        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _materialService.GetAll();
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _materialService.Get(id);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(MaterialCreateDto materialCreateDto)
        {
            var response = await _materialService.Create(materialCreateDto);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _materialService.Delete(id);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Material material)
        {
            var response = await _materialService.Update(material);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
