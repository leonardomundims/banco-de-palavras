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
            return View(new Palavra());
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

        [HttpGet]
        public IActionResult Atualizar(int Id) {
            ViewBag.Niveis = Niveis;
            Palavra palavra = _db.Palavras.Find(Id); //encontrar a palavra com o id informado
            return View("Cadastrar", palavra); //pasa a palavra encontrada
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Palavra palavra) {
           
            ViewBag.Niveis = Niveis;

            if(ModelState.IsValid){ 
                //se o formulario for valido
                _db.Palavras.Update(palavra); //altera a palavra
                _db.SaveChanges(); //salva a alteração

                TempData["Mensagem"] = "A palavra '" + palavra.Nome + " foi alterada com sucesso";
                return RedirectToAction("Index");
            } 

            return View("Cadastrar", palavra);
            
        }

        public IActionResult Excluir(int Id) {

            var palavra = _db.Palavras.Find(Id);

            _db.Palavras.Remove(palavra); //exclui a palavra no id informado
            _db.SaveChanges(); //salva as alterações

            TempData["Mensagem"] = "A palavra '" + palavra.Nome + "' foi excluida com sucesso";
            return RedirectToAction("Index");
        }
    }
}