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
    public class ClienteController : Controller
    {

        private readonly AppContextModel _context;

        public ClienteController(AppContextModel context)
        {
            _context = context;
        }

        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: login/logar
        [HttpPost, ActionName("Logar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserConfirmed(string email, string senha)
        {
            UsuarioRepository a = new UsuarioRepository(_context);
            UsuarioModel user =  a.AutenticationUser(email, senha);
            if (user!=null){
                return RedirectToAction("Dashboard", "Cliente", new { id = user.ID });
            } else {
                return RedirectToAction(nameof(Login));
            }
        }
        
        public IActionResult Dashboard(string id)
        {
            UsuarioRepository a = new UsuarioRepository(_context);
            UsuarioModel user = a.GetUsuarioById(Convert.ToInt32(id));
            List<ContaModel> userAccount = a.ContasUsuario(user.ID);

            ViewBag.Usuario = user;
            ViewBag.Contas = userAccount;

            return View();
        }
    }
}