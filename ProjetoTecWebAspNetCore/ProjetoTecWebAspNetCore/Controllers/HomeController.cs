using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoTecWebAspNetCore.Models;

namespace ProjetoTecWebAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
