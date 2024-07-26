using AppWebMonolitico.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppWebMonolitico.Controllers
{
    public class Clases : Controller
    {
        private readonly AppDbContext _context;
        public Clases(AppDbContext context)
        {

            _context = context;

        }

        // GET: Clase
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clase.ToListAsync());
        }

        // GET: Clase/Details/5
        public async Task<IActionResult> Detalles(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _context.Clase.FirstOrDefaultAsync(m => m.id == id);
            if (clase == null)
            {
                return NotFound();
            }

            return View(clase);
        }

        // GET: Gastos/Create
        public IActionResult AgregarClase()
        {
            return View();
        }

        // POST: Gastos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarClase([Bind("id,Nombre,Fecha,Pago")] Clase clase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clase);
        }

        // GET: Gastos/Edit/5
        public async Task<IActionResult> ActualizarClase(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _context.Clase.FindAsync(id);
            if (clase == null)
            {
                return NotFound();
            }
            return View(clase);
        }

        // POST: Gastos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarClase(int id, [Bind("id,Nombre,Fecha,Pago")] Clase clase)
        {
            if (id != clase.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GastoExists(clase.id))
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
            return View(clase);
        }

        // GET: Gastos/Delete/5
        public async Task<IActionResult> EliminarClase(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _context.Clase.FirstOrDefaultAsync(m => m.id == id);
            if (clase == null)
            {
                return NotFound();
            }

            // Eliminar directamente y redirigir a la lista de gastos
            _context.Clase.Remove(clase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GastoExists(int id)
        {
            return _context.Clase.Any(e => e.id == id);
        }
    }
}
