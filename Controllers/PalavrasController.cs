using BancoDePalavras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BancoDePalavras.Database;

namespace BancoDePalavras.Controllers
{
    public class PalavrasController : Controller
    {
        private List<Nivel> Niveis = new List<Nivel>();

      private DatabaseContext _db;

        public PalavrasController(DatabaseContext db)
        {
            _db = db;

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
        public IActionResult Cadastrar([FromForm] Palavra palavra)
        {
            ViewBag.Niveis = Niveis;
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Palavras");
            }
            return View();
        }
    }
}