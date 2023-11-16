using Microsoft.AspNetCore.Mvc;
using PrintShop.BLL.Services.Interfaces;
using PrintShop.GlobalData.Models.DTOs;
using Serilog;

namespace PrintShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterDto userRegisterDto)
        {
            var response = await _userService.RegisterNewUser(userRegisterDto);
            Log.Information("Response => {@response}", response);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
