using BusinessLayer.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {

        IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("add")]
        public IActionResult add([FromForm] IFormFile image, [FromForm] Product product)
        {

            var result = _imageService.add(image, product);
            if (result == null)
            {
                return BadRequest("olmadı");

            }
            return Ok(result);
        }
    }
}
