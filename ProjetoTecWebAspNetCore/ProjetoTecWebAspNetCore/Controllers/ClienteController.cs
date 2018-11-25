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
                //return RedirectToAction("Dashboard", "Cliente", new { id = user.ID });
                return RedirectToAction(nameof(Dashboard), new { id = user.ID });
            } else {
                return RedirectToAction(nameof(Login));
            }
        }

        // GET: Login
        public IActionResult SignUp()
        {
            return View();
        }
        // POST: login/logar
        [HttpPost, ActionName("SignUpPOST")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUpPOST(UsuarioModel usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Login));
        }

        public IActionResult Dashboard(string id)
        {
            UsuarioRepository a = new UsuarioRepository(_context);
            UsuarioModel user = a.GetUsuarioById(Convert.ToInt32(id));
            List<ContaModel> userAccount = a.ContasUsuario(user.ID);

            ContaModel contaAux = new ContaModel(); 
            foreach (ContaModel conta in userAccount)
            {
                
                foreach (BalancoModel balanco in conta.Balanco)
                {
                    contaAux.Balanco.Add(balanco);
                }

            }

            ViewBag.Usuario = user;
            ViewBag.Contas = userAccount;
            Random rnd = new Random();

            StringBuilder sb = new StringBuilder();
            foreach (ContaModel conta in userAccount)
            {
                sb.Append("var arrayValorConta_" + conta.NumeroConta+" = []; \n");
                sb.Append("var arrayLabel_" + conta.NumeroConta + " = []; \n");
                sb.Append("var arrayColor_" + conta.NumeroConta+" = []; \n");
                sb.Append("var arrayBorderColor_" + conta.NumeroConta + " = []; \n");
                foreach (BalancoModel balanco in conta.Balanco)
                {
                    sb.Append("arrayValorConta_" + conta.NumeroConta + ".push(" + balanco.Valor + "); \n");
                    sb.Append("arrayLabel_" + conta.NumeroConta + ".push('" + balanco.TipoGasto + "'); \n");
                    sb.Append("arrayColor_" + conta.NumeroConta + ".push('rgba(" + rnd.Next(0, 255) + "," + rnd.Next(0, 255) + "," + rnd.Next(0, 255) + ",0.5)'); \n");
                    sb.Append("arrayBorderColor_" + conta.NumeroConta + ".push('rgba(" + rnd.Next(0, 255) + "," + rnd.Next(0, 255) + "," + rnd.Next(0, 255) + ",1)'); \n");
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
            Random rnd = new Random();

            StringBuilder sb = new StringBuilder();
            foreach (ContaModel conta in userAccount)
            {
                sb.Append("var arrayValorConta_" + conta.NumeroConta + " = []; \n");
                sb.Append("var arrayLabel_" + conta.NumeroConta + " = []; \n");
                sb.Append("var arrayColor_" + conta.NumeroConta + " = []; \n");
                sb.Append("var arrayBorderColor_" + conta.NumeroConta + " = []; \n");
                foreach (BalancoModel balanco in conta.Balanco)
                {
                    sb.Append("arrayLabel_" + conta.NumeroConta + ".push('" + balanco.TipoGasto + "'); \n");
                    sb.Append("arrayValorConta_" + conta.NumeroConta + ".push(" + balanco.Valor + "); \n");

                    sb.Append("arrayColor_" + conta.NumeroConta + ".push('rgba(" + rnd.Next(0, 255) + "," + rnd.Next(0, 255) + "," + rnd.Next(0, 255) + ",0.5)'); \n");
                    sb.Append("arrayBorderColor_" + conta.NumeroConta + ".push('rgba(" + rnd.Next(0, 255) + "," + rnd.Next(0, 255) + "," + rnd.Next(0, 255) + ",1)'); \n");
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
        public IActionResult CadastrarConta(string id)
        {
            UsuarioRepository a = new UsuarioRepository(_context);
            UsuarioModel user = a.GetUsuarioById(Convert.ToInt32(id));
            List<ContaModel> userAccount = a.ContasUsuario(user.ID);
            
            ViewBag.Usuario = user;
            ViewBag.Contas = userAccount;
            StringBuilder sb = new StringBuilder();

            return View();
        }

        // POST: login/cadastrarBalanco
        [HttpPost, ActionName("CadastrarBalanco")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NovoBalanco(string contaID, string valor, string tipoGasto)
        {
            if (ModelState.IsValid)
            {
                BalancoModel balancoModel = new BalancoModel();
                balancoModel.ContaID = Convert.ToInt32(contaID);
                balancoModel.TipoGasto = tipoGasto;
                balancoModel.Valor = Convert.ToDouble(valor);

                _context.Balancos.Add(balancoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CadastrarBalanco));
            }
            return View(nameof(CadastrarBalanco));
        }

        // POST: Cadastrar/cadastrarBalanco
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NovoContaPOST(string idUser, string numeroConta)
        {
            if (ModelState.IsValid)
            {
                UsuarioRepository userRep = new UsuarioRepository(_context);
                UsuarioModel user = userRep.GetUsuarioById(Convert.ToInt32(idUser));
                ContaModel contaModel = new ContaModel();
                contaModel.NumeroConta = Convert.ToInt32(numeroConta);
                contaModel.Usuario = user;
                contaModel.UsuarioID = Convert.ToInt32(numeroConta);
                contaModel.Balanco = new List<BalancoModel>();

                _context.Contas.Add(contaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CadastrarConta), new { id = idUser });
            }
            return View(nameof(CadastrarConta), new { id = idUser });
        }
    }
}