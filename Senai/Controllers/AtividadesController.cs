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
    public class AtividadesController : Controller
    {
        private readonly SenaiContext _context;

        public AtividadesController(SenaiContext context)
        {
            _context = context;
        }

        // GET: Atividades
        public async Task<IActionResult> Index()
        {
            var senaiContext = _context.Atividades.Include(a => a.Turma);
            return View(await senaiContext.ToListAsync());
        }

        // GET: Atividades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Atividades == null)
            {
                return NotFound();
            }

            var atividades = await _context.Atividades
                .Include(a => a.Turma)
                .FirstOrDefaultAsync(m => m.id == id);
            if (atividades == null)
            {
                return NotFound();
            }

            return View(atividades);
        }

        // GET: Atividades/Create
        public IActionResult Create()
        {
            ViewData["id_turma"] = new SelectList(_context.Turmas, "id", "nome_turma");
            return View();
        }

        // POST: Atividades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nome,id_turma")] Atividades atividades)
        {
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            //foreach (var error in errors)
            //{
            //    Console.WriteLine(error.ErrorMessage);
            //    var idTurmaSelecionada = atividades.id_turma;
            //}
            if (ModelState.IsValid)
            {
                
                _context.Add(atividades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_turma"] = new SelectList(_context.Turmas, "id", "nome_turma", atividades.id_turma);
            return View(atividades);
        }

        // GET: Atividades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Atividades == null)
            {
                return NotFound();
            }

            var atividades = await _context.Atividades.FindAsync(id);
            if (atividades == null)
            {
                return NotFound();
            }
            ViewData["id_turma"] = new SelectList(_context.Turmas, "id", "nome_turma", atividades.id_turma);
            return View(atividades);
        }

        // POST: Atividades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("nome,id_turma")] Atividades atividades)
        {
            if (id != atividades.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atividades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtividadesExists(atividades.id))
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
            ViewData["id_turma"] = new SelectList(_context.Turmas, "id", "nome_turma", atividades.id_turma);
            return View(atividades);
        }

        // GET: Atividades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Atividades == null)
            {
                return NotFound();
            }

            var atividades = await _context.Atividades
                .Include(a => a.Turma)
                .FirstOrDefaultAsync(m => m.id == id);
            if (atividades == null)
            {
                return NotFound();
            }

            return View(atividades);
        }

        // POST: Atividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Atividades == null)
            {
                return Problem("Entity set 'SenaiContext.Atividades'  is null.");
            }
            var atividades = await _context.Atividades.FindAsync(id);
            if (atividades != null)
            {
                _context.Atividades.Remove(atividades);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtividadesExists(int id)
        {
          return (_context.Atividades?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
