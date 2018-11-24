using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoTecWebAspNetCore.Models;
using ProjetoTecWebAspNetCore.Controllers;

namespace ProjetoTecWebAspNetCore.Controllers
{
    public class LoginController : Controller
    {

        private readonly AppContextModel _context;

        public LoginController(AppContextModel context)
        {
            _context = context;
        }

        // GET: Login
        public IActionResult IndexLogin()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
           return RedirectToAction("Dashboard", "Home");
        }

        // POST: login/logar
        [HttpPost, ActionName("Logar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserConfirmed(string email, string senha)
        {
            if (UsuarioModelExists(email, senha))
            {
                return RedirectToAction(nameof(Dashboard));
            }
            else
            {
                return RedirectToAction(nameof(IndexLogin));
            }
        }

        private bool UsuarioModelExists(string email, string senha)
        {
            return _context.Usuarios.Any(e => e.Email == email && e.Senha == senha);
        }


    }
}