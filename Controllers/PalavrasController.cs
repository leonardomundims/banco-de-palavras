using BancoDePalavras.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BancoDePalavras.Controllers
{
    public class PalavrasController : Controller
    {
        private List<Nivel> Niveis = new List<Nivel>();

        public PalavrasController()
        {
            Niveis.Add(new Nivel(1, "Fácil"));
            Niveis.Add(new Nivel(2, "Médio"));
            Niveis.Add(new Nivel(3, "Difícil"));
        }
        public IActionResult Index()
        {
            ViewBag.PalavrasActive = "active";
            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Niveis = Niveis;
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm] Palavra palavras)
        {
            if (ModelState.IsValid)
            {
                return View("Index");
            }

            return View();
        }
    }
}