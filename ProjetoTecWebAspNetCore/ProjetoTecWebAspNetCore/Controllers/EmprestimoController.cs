using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoTecWebAspNetCore.Models;

namespace ProjetoTecWebAspNetCore.Controllers
{
    public class EmprestimoController : Controller
    {
        private readonly AppContextModel _context;

        public EmprestimoController(AppContextModel context)
        {
            _context = context;
        }

        // GET: Emprestimo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Emprestimos.ToListAsync());
        }

        // GET: Emprestimo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimoModel = await _context.Emprestimos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (emprestimoModel == null)
            {
                return NotFound();
            }

            return View(emprestimoModel);
        }

        // GET: Emprestimo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Emprestimo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDInvestidor,IDTomador,Valor,Parcela,QuantidadeParcela,Horario,Autorizacao")] EmprestimoModel emprestimoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emprestimoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emprestimoModel);
        }

        // GET: Emprestimo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimoModel = await _context.Emprestimos.FindAsync(id);
            if (emprestimoModel == null)
            {
                return NotFound();
            }
            return View(emprestimoModel);
        }

        // POST: Emprestimo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDInvestidor,IDTomador,Valor,Parcela,QuantidadeParcela,Horario,Autorizacao")] EmprestimoModel emprestimoModel)
        {
            if (id != emprestimoModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emprestimoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmprestimoModelExists(emprestimoModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(emprestimoModel);
        }

        // GET: Emprestimo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimoModel = await _context.Emprestimos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (emprestimoModel == null)
            {
                return NotFound();
            }

            return View(emprestimoModel);
        }

        // POST: Emprestimo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emprestimoModel = await _context.Emprestimos.FindAsync(id);
            _context.Emprestimos.Remove(emprestimoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmprestimoModelExists(int id)
        {
            return _context.Emprestimos.Any(e => e.ID == id);
        }
    }
}
