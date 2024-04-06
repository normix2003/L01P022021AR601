using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L01P022021AR601.Models;

namespace L01P022021AR601.Controllers
{
    public class departamentosController : Controller
    {
        private readonly db_notasDbContext _context;

        public departamentosController(db_notasDbContext context)
        {
            _context = context;
        }

        // GET: departamentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.departamentos.ToListAsync());
        }

        // GET: departamentos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentos = await _context.departamentos
                .FirstOrDefaultAsync(m => m.departamento == id);
            if (departamentos == null)
            {
                return NotFound();
            }

            return View(departamentos);
        }

        // GET: departamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: departamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("departamento")] departamentos departamentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departamentos);
        }

        // GET: departamentos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentos = await _context.departamentos.FindAsync(id);
            if (departamentos == null)
            {
                return NotFound();
            }
            return View(departamentos);
        }

        // POST: departamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("departamento")] departamentos departamentos)
        {
            if (id != departamentos.departamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!departamentosExists(departamentos.departamento))
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
            return View(departamentos);
        }

        // GET: departamentos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentos = await _context.departamentos
                .FirstOrDefaultAsync(m => m.departamento == id);
            if (departamentos == null)
            {
                return NotFound();
            }

            return View(departamentos);
        }

        // POST: departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var departamentos = await _context.departamentos.FindAsync(id);
            if (departamentos != null)
            {
                _context.departamentos.Remove(departamentos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool departamentosExists(string id)
        {
            return _context.departamentos.Any(e => e.departamento == id);
        }
    }
}
