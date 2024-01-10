using Microsoft.AspNetCore.Mvc;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.GlobalData.Models;
using PrintShop.GlobalData.Models.DTOs.GeneralDtos;
using Serilog;

namespace PrintShop.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrintSizeController : ControllerBase
    {
        private readonly IPrintSizeService _printSizeService;
        public PrintSizeController(IPrintSizeService printSizeService)
        {
            _printSizeService = printSizeService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _printSizeService.GetAll();
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _printSizeService.Get(id);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(PrintSizeCreateDto printSizeCreateDto)
        {
            var response = await _printSizeService.Create(printSizeCreateDto);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _printSizeService.Delete(id);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(PrintSize printSize)
        {
            var response = await _printSizeService.Update(printSize);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
