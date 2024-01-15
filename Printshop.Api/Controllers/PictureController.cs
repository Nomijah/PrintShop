using Microsoft.AspNetCore.Mvc;
using PrintShop.BLL.Services.Interfaces;
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

    }
}
