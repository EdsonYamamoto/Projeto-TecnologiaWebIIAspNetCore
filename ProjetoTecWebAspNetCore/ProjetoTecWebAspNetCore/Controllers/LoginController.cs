using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoTecWebAspNetCore.Models;
using ProjetoTecWebAspNetCore.Controllers;
using ProjetoTecWebAspNetCore.Repository;

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
            UsuarioRepository a = new UsuarioRepository(_context);
            UsuarioModel user =  a.AutenticationUser(email, senha);
            if (user!=null){
                System.Diagnostics.Debug.WriteLine(user.ToString());

                List<ContaModel> contasUsuario = a.ContasUsuario(user.ID);
                foreach(ContaModel conta in contasUsuario)
                    System.Diagnostics.Debug.WriteLine(conta.ToString());

                return RedirectToAction(nameof(Dashboard));
            } else {
                return RedirectToAction(nameof(IndexLogin));
            }
        }
    }
}