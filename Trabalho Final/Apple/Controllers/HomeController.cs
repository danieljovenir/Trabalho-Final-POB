using ControleDeIphones.Data; // Certifique-se de que este namespace está correto
using ControleDeIphone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using Apple.Models;

namespace Apple.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BancoContext _context; // Usando BancoContext

        public HomeController(ILogger<HomeController> logger, BancoContext context)
        {
            _logger = logger;
            _context = context; // Inicializando o contexto
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search(string query)
        {
            var produtos = _context.Iphones
                .Where(p => p.Nome.Contains(query))
                .ToList();

            return View("SearchResults", produtos); // Retornando a view com os resultados da pesquisa
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
