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
    public class ConversaController : Controller
    {
        private readonly AppContextModel _context;

        public ConversaController(AppContextModel context)
        {
            _context = context;
        }

        // GET: Conversa
        public async Task<IActionResult> Index()
        {
            return View(await _context.Conversas.ToListAsync());
        }

        // GET: Conversa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conversaModel = await _context.Conversas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (conversaModel == null)
            {
                return NotFound();
            }

            return View(conversaModel);
        }

        // GET: Conversa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conversa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IdUsuario,Mensagem,Horiario")] ConversaModel conversaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conversaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conversaModel);
        }

        // GET: Conversa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conversaModel = await _context.Conversas.FindAsync(id);
            if (conversaModel == null)
            {
                return NotFound();
            }
            return View(conversaModel);
        }

        // POST: Conversa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IdUsuario,Mensagem,Horiario")] ConversaModel conversaModel)
        {
            if (id != conversaModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conversaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConversaModelExists(conversaModel.ID))
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
            return View(conversaModel);
        }

        // GET: Conversa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conversaModel = await _context.Conversas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (conversaModel == null)
            {
                return NotFound();
            }

            return View(conversaModel);
        }

        // POST: Conversa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conversaModel = await _context.Conversas.FindAsync(id);
            _context.Conversas.Remove(conversaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConversaModelExists(int id)
        {
            return _context.Conversas.Any(e => e.ID == id);
        }
    }
}
