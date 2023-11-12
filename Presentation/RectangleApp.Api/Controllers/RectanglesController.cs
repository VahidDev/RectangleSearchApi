using Microsoft.AspNetCore.Mvc;
using Project.Service.Services.Abstraction;
using Project.Service.ViewModels;

namespace RectangleApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RectanglesController : ControllerBase
    {
        private readonly IRectangleService _rectangleService;

        public RectanglesController(IRectangleService rectangleService)
        {
            _rectangleService = rectangleService;
        }

        [HttpPost]
        [ModelStateControl]
        public IActionResult Search([FromBody] IEnumerable<SearchCoordinateDto> coordinates)
        {
            var result = _rectangleService.GetAllRectangles(coordinates);
            return Ok(result);
        }
    }
}
