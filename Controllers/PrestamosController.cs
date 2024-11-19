using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App_Libreria.Models.DB;

namespace App_Libreria.Controllers
{
    public class PrestamosController : Controller
    {
        private readonly LibreriaContext _context;

        public PrestamosController(LibreriaContext context)
        {
            _context = context;
        }

        // GET: Prestamoes
        public async Task<IActionResult> Index()
        {
            var libreriaContext = _context.Prestamos.Include(p => p.IdLectorNavigation).Include(p => p.IdLibroNavigation);
            return View(await libreriaContext.ToListAsync());
        }

        // GET: Prestamoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prestamos == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.IdLectorNavigation)
                .Include(p => p.IdLibroNavigation)
                .FirstOrDefaultAsync(m => m.IdPrestamo == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // GET: Prestamoes/Create
        public IActionResult Create()
        {
            ViewData["IdLector"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante");
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "IdLibro");
            return View();
        }

        // POST: Prestamoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrestamo,IdLector,IdLibro,FechaPrestamo,FechaDevolucion,Devuelto")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLector"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante", prestamo.IdLector);
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "IdLibro", prestamo.IdLibro);
            return View(prestamo);
        }

        // GET: Prestamoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prestamos == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }
            ViewData["IdLector"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante", prestamo.IdLector);
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "IdLibro", prestamo.IdLibro);
            return View(prestamo);
        }

        // POST: Prestamoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPrestamo,IdLector,IdLibro,FechaPrestamo,FechaDevolucion,Devuelto")] Prestamo prestamo)
        {
            if (id != prestamo.IdPrestamo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoExists(prestamo.IdPrestamo))
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
            ViewData["IdLector"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante", prestamo.IdLector);
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "IdLibro", prestamo.IdLibro);
            return View(prestamo);
        }

        // GET: Prestamoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prestamos == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.IdLectorNavigation)
                .Include(p => p.IdLibroNavigation)
                .FirstOrDefaultAsync(m => m.IdPrestamo == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // POST: Prestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prestamos == null)
            {
                return Problem("Entity set 'LibreriaContext.Prestamos'  is null.");
            }
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo != null)
            {
                _context.Prestamos.Remove(prestamo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestamoExists(int id)
        {
          return (_context.Prestamos?.Any(e => e.IdPrestamo == id)).GetValueOrDefault();
        }
    }
}
