using Microsoft.AspNetCore.Mvc;
using FormulaUnoObligatorio.Models;
using FormulaUnoObligatorio.Data;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FormulaUnoObligatorio.Controllers
{
    public class CarreraController : Controller
    {
        private readonly AppDbContext _context;
        public CarreraController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Index", _context.Carreras.ToList());
        }

        public IActionResult Detalles(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var carrera = _context.Carreras
                .FirstOrDefault(m => m.IdCarrera == id);

            if(carrera == null)
            {
                return NotFound();
            }
            return View(carrera);
        }

        public IActionResult Crear()
        {
            ViewBag.Carreras = new SelectList(_context.Carreras, "IdCarrera", "NombreCarrera");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear([Bind("IdCarrera, NombreCarrera, CiudadCarrera, FechaCarrera")] Carrera carrera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrera);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(carrera);
        }

        public IActionResult Editar(int? id) 
        {
            if(id == null)
            {
                return NotFound();
            }
            var carrera = _context.Carreras.Find(id);
            if(carrera == null)
            {
                return NotFound();
            }
            return View(carrera);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int idCarrera, [Bind("IdCarrera, NombreCarrera, CiudadCarrera, FechaCarrera")] Carrera carrera)
        {
            if (idCarrera != carrera.IdCarrera)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrera);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarreraExiste(carrera.IdCarrera))
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
            return View(carrera);
        }

        public IActionResult Eliminar(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var carrera = _context.Carreras
                .FirstOrDefault(m => m.IdCarrera == id);
            if (carrera == null)
            {
                return NotFound();
            }
            return View(carrera);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmada(int id)
        {
            var carrera = _context.Carreras.Find(id);
            if(carrera != null)
            {
                _context.Carreras.Remove(carrera);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public bool CarreraExiste(int idcarrera)
        {
            return _context.Carreras.Any(c => c.IdCarrera == idcarrera);
        }
    }
}
