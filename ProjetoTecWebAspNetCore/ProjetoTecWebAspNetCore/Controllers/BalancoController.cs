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
    public class BalancoController : Controller
    {
        private readonly AppContextModel _context;

        public BalancoController(AppContextModel context)
        {
            _context = context;
        }

        // GET: Balanco
        public async Task<IActionResult> Index()
        {
            var appContextModel = _context.Balancos.Include(b => b.Conta);
            return View(await appContextModel.ToListAsync());
        }

        // GET: Balanco/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var balancoModel = await _context.Balancos
                .Include(b => b.Conta)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (balancoModel == null)
            {
                return NotFound();
            }

            return View(balancoModel);
        }

        // GET: Balanco/Create
        public IActionResult Create()
        {
            ViewData["ContaID"] = new SelectList(_context.Contas, "ID", "ID");
            return View();
        }

        // POST: Balanco/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ContaID,Valor,TipoGasto,Data")] BalancoModel balancoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(balancoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContaID"] = new SelectList(_context.Contas, "ID", "ID", balancoModel.ContaID);
            return View(balancoModel);
        }

        // GET: Balanco/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var balancoModel = await _context.Balancos.FindAsync(id);
            if (balancoModel == null)
            {
                return NotFound();
            }
            ViewData["ContaID"] = new SelectList(_context.Contas, "ID", "ID", balancoModel.ContaID);
            return View(balancoModel);
        }

        // POST: Balanco/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ContaID,Valor,TipoGasto,Data")] BalancoModel balancoModel)
        {
            if (id != balancoModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(balancoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BalancoModelExists(balancoModel.ID))
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
            ViewData["ContaID"] = new SelectList(_context.Contas, "ID", "ID", balancoModel.ContaID);
            return View(balancoModel);
        }

        // GET: Balanco/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var balancoModel = await _context.Balancos
                .Include(b => b.Conta)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (balancoModel == null)
            {
                return NotFound();
            }

            return View(balancoModel);
        }

        // POST: Balanco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var balancoModel = await _context.Balancos.FindAsync(id);
            _context.Balancos.Remove(balancoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BalancoModelExists(int id)
        {
            return _context.Balancos.Any(e => e.ID == id);
        }
    }
}
