using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TecnologiaWebIIAspNetCore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TecnologiaWebIIAspNetCore.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            PageModel p = new PageModel();
            p.ProjectName = "Nome do projeto";
            p.Title = "Titulo";
            p.AuxTitle = "Aux";
            ViewBag.Page = p;


            return View();
        }
    }
}
