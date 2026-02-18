using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Assessment4.Models;
using Assessment4.Services;

namespace Assessment4.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMyService _service;
        private readonly ILogger<HomeController> _logger;
        private readonly AppSettings _settings;

        public HomeController(IMyService service,
                              ILogger<HomeController> logger,
                              IOptions<AppSettings> settings)
        {
            _service = service;
            _logger = logger;
            _settings = settings.Value;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Home Index Page Accessed");

            ViewBag.AppName = _settings.AppName;
            ViewBag.Version = _settings.Version;
            ViewBag.ServiceMessage = _service.GetMessage();

            return View();
        }
    }
}
