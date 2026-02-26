using Microsoft.AspNetCore.Mvc;

namespace Assessment13.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<FilesController> _logger;

        public FilesController(IWebHostEnvironment env,
            ILogger<FilesController> logger)
        {
            _env = env;
            _logger = logger;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Invalid File");

            var path = Path.Combine(_env.ContentRootPath,
                "UploadedFiles");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var filePath = Path.Combine(path, file.FileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            _logger.LogInformation("File Uploaded: {FileName}", file.FileName);

            return Ok("File uploaded successfully");
        }

        [HttpGet("download/{fileName}")]
        public IActionResult Download(string fileName)
        {
            var path = Path.Combine(_env.ContentRootPath,
                "UploadedFiles", fileName);

            if (!System.IO.File.Exists(path))
                return NotFound("File not found");

            var bytes = System.IO.File.ReadAllBytes(path);

            _logger.LogInformation("File Downloaded: {FileName}", fileName);

            return File(bytes, "application/octet-stream", fileName);
        }
    }
}