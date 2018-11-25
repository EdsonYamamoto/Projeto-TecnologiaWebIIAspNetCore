using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoTecWebAspNetCore.Models;
using ProjetoTecWebAspNetCore.Controllers;
using ProjetoTecWebAspNetCore.Repository;
using System.Text;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Html;

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

            StringBuilder sb = new StringBuilder();
            foreach (ContaModel conta in userAccount)
            {
                sb.Append("var arrayValorConta_" + conta.NumeroConta+" = []; \n");
                foreach (BalancoModel balanco in conta.Balanco)
                {
                    sb.Append("arrayValorConta_" + conta.NumeroConta + ".push(" + balanco.Valor + "); \n");
                }
            }
            ViewBag.ArrayContas = new HtmlString(sb.ToString());
            return View();
        }

        public IActionResult Relatorio(string id)
        {
            UsuarioRepository a = new UsuarioRepository(_context);
            UsuarioModel user = a.GetUsuarioById(Convert.ToInt32(id));
            List<ContaModel> userAccount = a.ContasUsuario(user.ID);

            ViewBag.Usuario = user;
            ViewBag.Contas = userAccount;

            StringBuilder sb = new StringBuilder();
            foreach (ContaModel conta in userAccount)
            {
                sb.Append("var arrayValorConta_" + conta.NumeroConta + " = []; \n");
                foreach (BalancoModel balanco in conta.Balanco)
                {
                    sb.Append("arrayValorConta_" + conta.NumeroConta + ".push(" + balanco.Valor + "); \n");
                }
            }
            ViewBag.ArrayContas = new HtmlString(sb.ToString());
            return View();
        }

        public IActionResult CadastrarBalanco(string id)
        {
            UsuarioRepository a = new UsuarioRepository(_context);
            UsuarioModel user = a.GetUsuarioById(Convert.ToInt32(id));
            List<ContaModel> userAccount = a.ContasUsuario(user.ID);

            ViewBag.Usuario = user;
            ViewBag.Contas = userAccount;
            StringBuilder sb = new StringBuilder();
            foreach (ContaModel conta in userAccount)
            {
                sb.Append("var arrayValorConta_" + conta.NumeroConta + " = []; \n");
                foreach (BalancoModel balanco in conta.Balanco)
                {
                    sb.Append("arrayValorConta_" + conta.NumeroConta + ".push(" + balanco.Valor + "); \n");
                }
            }
            ViewBag.ArrayContas = new HtmlString(sb.ToString());
            return View();
        }

        // POST: Conta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NovoBalanco([Bind("ID,UsuarioID,NumeroConta")] BalancoModel balancoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(balancoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CadastrarBalanco));
            }
            return View(balancoModel);
        }
    }
}