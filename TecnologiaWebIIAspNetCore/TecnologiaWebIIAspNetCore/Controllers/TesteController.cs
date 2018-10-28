using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoAspNetCore.Controllers
{
    public class TesteController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        // GET: /<controller>/
        public IActionResult Repository()
        {
            return View();
        }
        // GET: /<controller>/
        public IActionResult DinamicVariable()
        {
            ViewBag.String = "Eu sou uma string";
            ViewBag.Int = 123;
            ViewBag.Float = 12.456;
            ViewBag.Boolean = true;

            return View();
        }
        // GET: /<controller>/
        public IActionResult ChartJS()
        {
            return View();
        }
        // GET: /<controller>/
        public IActionResult Parallax()
        {
            return View();
        }
    }
}
