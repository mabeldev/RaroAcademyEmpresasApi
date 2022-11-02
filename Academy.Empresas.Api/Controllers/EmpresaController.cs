using Microsoft.AspNetCore.Mvc;

namespace Academy.Empresas.Api.Controllers
{
    [Route("[controller]")]
    public class EmpresaController : Controller
    {
        private readonly ILogger<EmpresaController> _logger;

        public EmpresaController(ILogger<EmpresaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}