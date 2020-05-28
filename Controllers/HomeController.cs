using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BancoDePalavras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace BancoDePalavras.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.HomeActive = "active";
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.LoginActive = "active";
            return View();
        }


        [HttpPost]
        public IActionResult Login([FromForm] Usuario usuario)
        {
            if (usuario.Email == "guest@guest.com" && usuario.Senha == "guest123")
            {
                HttpContext.Session.SetString("Login", "true");
                return RedirectToAction("Index", "Palavras");
            }
            ViewBag.LoginActive = "active";
            ViewBag.Mensage = "Usuario Invalido";
            return View();

        }

        public IActionResult Logout() 
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }


    }
}
