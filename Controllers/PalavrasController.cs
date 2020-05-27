using Microsoft.AspNetCore.Mvc;

namespace BancoDePalavras.Controllers
{
    public class PalavrasController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.PalavrasActive = "active";
            return View();
        }
    }
}