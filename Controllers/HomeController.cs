using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BancoDePalavras.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.HomeActive = "active";
            return View();
        }

        public IActionResult Login()
        {
            ViewBag.LoginActive = "active";
            return View();
        }
    }
}
