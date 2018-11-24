using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoTecWebAspNetCore.Models;

namespace ProjetoTecWebAspNetCore.Controllers
{
    public class TesteController : Controller
    {
        public IActionResult DinamicInputTest()
        {
            List<UsuarioModel> pessoas = new List<UsuarioModel>();

            ViewData["Message"] = "Your application description page.";
            ViewBag.Var1 = "teste com string";
            ViewBag.Var2 = 12;
            ViewBag.Var3 = true;
            ViewBag.Var4 = 14.2;
            ViewBag.Pessoas = pessoas;

            return View();
        }

        public IActionResult ChartJSTest()
        {
            return View();
        }

        public IActionResult ParallaxTest()
        {
            return View();
        }

        public IActionResult DashBoard()
        {
            return View();
        }

    }
}