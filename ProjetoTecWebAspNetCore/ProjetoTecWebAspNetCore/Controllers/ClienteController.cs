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
using Microsoft.AspNetCore.Session;

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
        public IActionResult UserConfirmed(string email, string senha)
        {
            UsuarioRepository a = new UsuarioRepository(_context);
            UsuarioModel user = a.AutenticationUser(email, senha);
            if (user != null)
            {
                TempData["user"] = user.ID;
                return RedirectToAction(nameof(Dashboard), new { id = user.ID });
            }
            else
            {
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

            if (TempData["user"] != null)
            {
                foreach (ContaModel conta in userAccount)
                    foreach (BalancoModel balanco in conta.Balanco)
                        contaAux.Balanco.Add(balanco);

                int qtdRegistrados = 0;
                int sociosRegistrados = 0;
                double GastoTotais = 0;
                double GanhosTotais = 0;
                foreach (BalancoModel balanco in contaAux.Balanco)
                {
                    if (balanco.Valor < 0)
                        GastoTotais += balanco.Valor;
                    if (balanco.Valor > 0)
                        GanhosTotais += balanco.Valor;
                    qtdRegistrados++;
                }
                ViewBag.Usuario = user;
                ViewBag.Contas = userAccount;
                ViewBag.GastoTotais = GastoTotais;
                ViewBag.GanhosTotais = GanhosTotais;
                ViewBag.qtdRegistro = qtdRegistrados;
                ViewBag.qtdSocios = sociosRegistrados;
                ViewBag.Conta = contaAux;
                Random rnd = new Random();

                StringBuilder sb = new StringBuilder();
                sb.Append("var arrayValorConta = []; \n");
                sb.Append("var arrayLabel = []; \n");
                sb.Append("var arrayColor = []; \n");
                sb.Append("var arrayBorderColor = []; \n");
                foreach (BalancoModel balanco in contaAux.Balanco)
                {
                    sb.Append("arrayValorConta.push(" + balanco.Valor + "); \n");
                    sb.Append("arrayLabel.push('" + balanco.TipoGasto + "'); \n");
                    sb.Append("arrayColor.push('rgba(" + rnd.Next(0, 255) + "," + rnd.Next(0, 255) + "," + rnd.Next(0, 255) + ",0.5)'); \n");
                    sb.Append("arrayBorderColor.push('rgba(" + rnd.Next(0, 255) + "," + rnd.Next(0, 255) + "," + rnd.Next(0, 255) + ",1)'); \n");
                }

                ViewBag.ArrayContas = new HtmlString(sb.ToString());
                TempData["user"] = user.ID; 
                return View();
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
            
        }
        

        public IActionResult Relatorio(string id)
        {
            UsuarioRepository a = new UsuarioRepository(_context);
            UsuarioModel user = a.GetUsuarioById(Convert.ToInt32(id));
            List<ContaModel> userAccount = a.ContasUsuario(user.ID);

            if (TempData["user"] != null)
            {
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
                TempData["user"] = user.ID;
                return View();
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }


            
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

        public IActionResult Chat(string id)
        {
            ConversaRepository conRep = new ConversaRepository(_context);
            List<ConversaModel> conversas = conRep.GetConversaByUserID(Convert.ToInt32(id));

            UsuarioRepository useRep = new UsuarioRepository(_context);
            UsuarioModel user = useRep.GetUsuarioById(Convert.ToInt32(id));

            ViewBag.Usuario = user;
            ViewBag.Conversas = conversas;

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
        [HttpPost, ActionName("CadastrarBalancoPOST")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastrarBalancoPOST(string idUser, BalancoModel balanco)
        {
            ContaRepository conRep = new ContaRepository(_context);
            balanco.Conta = conRep.GetContaById(balanco.ContaID);

            if (ModelState.IsValid)
            {
                _context.Balancos.Add(balanco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CadastrarBalanco), new { id = idUser });
            }
            return RedirectToAction(nameof(CadastrarBalanco), new { id = idUser });
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
                contaModel.UsuarioID = Convert.ToInt32(idUser);
                contaModel.Balanco = new List<BalancoModel>();

                _context.Contas.Add(contaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CadastrarConta), new { id = idUser });
            }
            return View(nameof(CadastrarConta), new { id = idUser });
        }


        // POST: login/cadastrarBalanco
        [HttpPost, ActionName("ChatPOST")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChatPOST(string idUser, ConversaModel conversa)
        {
            ContaRepository conRep = new ContaRepository(_context);
            UsuarioRepository userRep = new UsuarioRepository(_context);
            conversa.Usuario = userRep.GetUsuarioById(Convert.ToInt32( idUser));
            conversa.IdUsuario = Convert.ToInt32(idUser);
            conversa.Horiario = DateTime.Now;

            _context.Conversas.Add(conversa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Chat), new { id = idUser });
        }
    }
}