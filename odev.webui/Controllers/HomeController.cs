using Microsoft.AspNetCore.Mvc;

namespace odev.webui.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
        public IActionResult Kayit()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }



    }
}