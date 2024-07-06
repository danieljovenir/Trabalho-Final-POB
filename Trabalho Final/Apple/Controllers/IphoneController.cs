using Apple.Repositorio;
using ControleDeIphone.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeIphones.Controllers
{
    public class IphoneController : Controller
    {
        private readonly InterIphoneRepositorio _iphoneRepositorio;

        public IphoneController(InterIphoneRepositorio iphoneRepositorio)
        {
            _iphoneRepositorio = iphoneRepositorio;
        }

        public IActionResult Index()
        {
            List<IphoneModel> iphones = _iphoneRepositorio.BuscarTodos();
            return View(iphones);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            IphoneModel iphone = _iphoneRepositorio.ListarPorId(id);
            if (iphone == null)
            {
                return NotFound();
            }
            return View(iphone);
        }

        [HttpPost]
        public IActionResult Editar(IphoneModel iphone)
        {
            _iphoneRepositorio.Atualizar(iphone);
            return RedirectToAction("Index");
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            IphoneModel iphone = _iphoneRepositorio.ListarPorId(id);
            if (iphone == null)
            {
                return NotFound();
            }
            return View(iphone);
        }

        [HttpPost]
        public IActionResult Apagar(int id)
        {
            _iphoneRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(IphoneModel iphone)
        {
            _iphoneRepositorio.Adicionar(iphone);
            return RedirectToAction("Index");
        }
    }
}
    