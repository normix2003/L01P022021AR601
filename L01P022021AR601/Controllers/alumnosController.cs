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
    public class alumnosController : Controller
    {
        private readonly db_notasDbContext _context;

        public alumnosController(db_notasDbContext context)
        {
            _context = context;
        }

        // GET: alumnos
        public async Task<IActionResult> Index()
        {
            return View(await _context.alumnos.ToListAsync());
        }

        // GET: alumnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnos = await _context.alumnos
                .FirstOrDefaultAsync(m => m.codigo == id);
            if (alumnos == null)
            {
                return NotFound();
            }

            return View(alumnos);
        }

        // GET: alumnos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: alumnos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("codigo,nombre,apellidos,dui,estado")] alumnos alumnos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumnos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alumnos);
        }

        // GET: alumnos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnos = await _context.alumnos.FindAsync(id);
            if (alumnos == null)
            {
                return NotFound();
            }
            return View(alumnos);
        }

        // POST: alumnos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("codigo,nombre,apellidos,dui,estado")] alumnos alumnos)
        {
            if (id != alumnos.codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumnos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!alumnosExists(alumnos.codigo))
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
            return View(alumnos);
        }

        // GET: alumnos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnos = await _context.alumnos
                .FirstOrDefaultAsync(m => m.codigo == id);
            if (alumnos == null)
            {
                return NotFound();
            }

            return View(alumnos);
        }

        // POST: alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alumnos = await _context.alumnos.FindAsync(id);
            if (alumnos != null)
            {
                _context.alumnos.Remove(alumnos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool alumnosExists(int id)
        {
            return _context.alumnos.Any(e => e.codigo == id);
        }
    }
}
