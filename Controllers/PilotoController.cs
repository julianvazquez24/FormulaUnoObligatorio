using FormulaUnoObligatorio.Data;
using FormulaUnoObligatorio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

namespace FormulaUnoObligatorio.Controllers
{
    public class PilotoController : Controller
    {
        private readonly AppDbContext _context; // AppDbContext permite que la aplicación interactúe con la base de datos.

        public PilotoController(AppDbContext context)
        {
            _context = context; // _context es la variable que usas en el controlador para acceder a las tablas de la base de datos y realizar operaciones CRUD.
        }

        public IActionResult Index()
        {
            var appDbContext = _context.Pilotos.Include(p => p.EscuderiaPiloto);
             return View("Index", appDbContext.ToList());
        }


        // Details (Ver los detalles de un Piloto)
        public IActionResult Details(int? idPiloto)
        {
            if (idPiloto == null)
            {
                return NotFound();
            }

            var piloto = _context.Pilotos
                .Include(p => p.EscuderiaPiloto)
                .FirstOrDefault(m => m.IdPiloto == idPiloto);
            if (piloto == null)
            {
                return NotFound();
            }
            return View(piloto);
        }

        // Get Create
        public IActionResult Create()
        {
            return View(new Piloto());
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("NombrePiloto, ApellidoPiloto, PaisPiloto, FechaNacimiento, EscuderiaPilotoId")] Piloto piloto)
        {
            if (ModelState.IsValid)
            {
                int totalPilotos = _context.Pilotos.Count();
                if (totalPilotos >= 20)
                {
                    ModelState.AddModelError(string.Empty, "No se puede agregar más de 20 pilotos.");
                    return View(piloto);
                }

                
                var escuderia = _context.Escuderias
                    .FirstOrDefault(e => e.IdEscuderia == piloto.IdEscuderia);

                if (escuderia != null)
                {
                    piloto.EscuderiaPiloto = escuderia;  
                }

                _context.Add(piloto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Escuderia = new SelectList(_context.Escuderias, "IdEscuderia", "NombreEscuderia");
            return View(piloto);
        }


        // Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piloto = _context.Pilotos.Find(id);
            if (piloto == null)
            {
                return NotFound();
            }
            
            ViewData["IdEscuderia"] = new SelectList(_context.Escuderias, "IdEscuderia", "Nombre", piloto.IdEscuderia);

            return View(piloto);
        }


        // Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int idPiloto, [Bind("IdPiloto,NombrePiloto,FechaNacimiento,PaisPiloto,PuntosTotales,EscuderiaId")] Piloto piloto)
        {
            if (idPiloto != piloto.IdPiloto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Actualizar el piloto en el contexto
                    _context.Update(piloto);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Verificar si el piloto sigue existiendo en la base de datos
                    if (!PilotoExists(piloto.IdPiloto))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // Redirigir a la acción Index después de guardar correctamente los cambios
                return RedirectToAction(nameof(Index));
            }
            return View(piloto);
        }

        // Get Delete
        public IActionResult Delete(int? idPiloto)
        {
            if (idPiloto == null)
            {
                return NotFound();
            }

            var piloto = _context.Pilotos
                .Include(p => p.EscuderiaPiloto)
                .FirstOrDefault(m => m.IdPiloto == idPiloto);
            if (piloto == null)
            {
                return NotFound();
            }

            return View(piloto);
        }

        // Post Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int idPiloto)
        {
            var piloto = _context.Pilotos.Find(idPiloto);
            if (piloto != null)
            {
                _context.Pilotos.Remove(piloto);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public bool PilotoExists(int idPiloto)
        {
            return _context.Pilotos.Any(e => e.IdPiloto == idPiloto);
        }
    }
}

