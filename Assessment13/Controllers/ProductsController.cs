using Microsoft.AspNetCore.Mvc;
using Assessment13.Services;

namespace Assessment13.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ProductService service,
            ILogger<ProductsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Products requested");
            return Ok(_service.GetProducts());
        }

        [HttpGet("error")]
        public IActionResult GenerateError()
        {
            throw new Exception("Manual Exception Triggered!");
        }
    }
}