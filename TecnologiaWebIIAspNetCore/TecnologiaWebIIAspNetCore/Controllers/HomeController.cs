using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TecnologiaWebIIAspNetCore.Models;

namespace TecnologiaWebIIAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            string carousel;
            carousel = "https://picsum.photos/1200/400/?blur";
            ViewBag.Carousel1 = carousel;
            ViewBag.Carousel2 = carousel;
            ViewBag.Carousel3 = carousel;

            PageModel p = new PageModel();
            p.ProjectName = "Nome do projeto";
            p.Title = "Titulo";
            p.AuxTitle = "Aux";
            ViewBag.Page = p;
            return View();
        }

        public IActionResult About()
        {

            PageModel p = new PageModel();
            p.ProjectName = "Nome do projeto";
            p.Title = "Titulo";
            p.AuxTitle = "Aux";
            ViewBag.Page = p;


            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {

            PageModel p = new PageModel();
            p.ProjectName = "Nome do projeto";
            p.Title = "Titulo";
            p.AuxTitle = "Aux";
            ViewBag.Page = p;


            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {

            PageModel p = new PageModel();
            p.ProjectName = "Nome do projeto";
            p.Title = "Titulo";
            p.AuxTitle = "Aux";
            ViewBag.Page = p;


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
