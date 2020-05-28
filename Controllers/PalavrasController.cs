using BancoDePalavras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BancoDePalavras.Database;
using System.Linq;
using BancoDePalavras.Library;
using BancoDePalavras.Library.Filters;

namespace BancoDePalavras.Controllers
{
    [Login]
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
            var palavras = _db.Palavras.ToList();
            ViewBag.PalavrasActive = "active";
            return View(palavras);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Niveis = Niveis;
            ViewBag.PalavrasActive = "active";
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm] Palavra palavra)
        {
            ViewBag.Niveis = Niveis;

            if (ModelState.IsValid)
            {
                _db.Add(palavra);
                _db.SaveChanges();
                return RedirectToAction("Index", "Palavras");
            }

            return View();
        }
    }
}