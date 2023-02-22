using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace farm_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadingController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploadingController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("[action]")]
        public IActionResult UploadFiles(IFormFile file)
        {
            string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadedFiles");
            string filePath = Path.Combine(directoryPath, file.FileName);
            using(var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return Ok(filePath);
        }
    }
}
