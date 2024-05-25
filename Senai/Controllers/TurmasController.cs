using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Senai.Data;
using Senai.Models;

namespace Senai.Controllers
{
    public class TurmasController : Controller
    {
        private readonly SenaiContext _context;

        public TurmasController(SenaiContext context)
        {
            _context = context;
        }

        // GET: Turmas
        public async Task<IActionResult> Index()
        {
              return _context.Turmas != null ? 
                          View(await _context.Turmas.ToListAsync()) :
                          Problem("Entity set 'SenaiContext.Turmas'  is null.");
        }

        // GET: Turmas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Turmas == null)
            {
                return NotFound();
            }

            var turmas = await _context.Turmas
                .FirstOrDefaultAsync(m => m.id == id);
            if (turmas == null)
            {
                return NotFound();
            }

            return View(turmas);
        }

        // GET: Turmas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome_turma")] Turmas turmas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turmas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(turmas);
        }

        // GET: Turmas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Turmas == null)
            {
                return NotFound();
            }

            var turmas = await _context.Turmas.FindAsync(id);
            if (turmas == null)
            {
                return NotFound();
            }
            return View(turmas);
        }

        // POST: Turmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome_turma")] Turmas turmas)
        {
            if (id != turmas.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turmas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmasExists(turmas.id))
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
            return View(turmas);
        }

        // GET: Turmas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Turmas == null)
            {
                return NotFound();
            }

            var turmas = await _context.Turmas
                .FirstOrDefaultAsync(m => m.id == id);
            if (turmas == null)
            {
                return NotFound();
            }

            return View(turmas);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Turmas == null)
            {
                return Problem("Entity set 'SenaiContext.Turmas'  is null.");
            }
            var turmas = await _context.Turmas.FindAsync(id);
            if (turmas != null)
            {
                _context.Turmas.Remove(turmas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmasExists(int id)
        {
          return (_context.Turmas?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
