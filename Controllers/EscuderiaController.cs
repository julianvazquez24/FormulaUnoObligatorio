using FormulaUnoObligatorio.Data;
using FormulaUnoObligatorio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FormulaUnoObligatorio.Controllers
{
    public class EscuderiaController : Controller
    {
        private readonly AppDbContext _context;
        public EscuderiaController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           
            return View("Index", _context.Escuderias.ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escuderia = _context.Escuderias
                                    .Include(e => e.Pilotos)
                                    .FirstOrDefault(m => m.IdEscuderia == id);

            if (escuderia == null)
            {
                return NotFound();
            }

            return View(escuderia);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("IdEscuderia, NombreEscuderia, SponsorOficial, PaisEscuderia")] Escuderia escuderia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escuderia);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(escuderia);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var escuderia = _context.Escuderias.Find(id);
            if (escuderia == null)
            {
                return NotFound();
            }

            return View(escuderia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int idEscuderia, [Bind("NombreEscuderia, SponsorOficial, PaisEscuderia")] Escuderia escuderia)
        {
            if(idEscuderia != escuderia.IdEscuderia)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escuderia);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscuderiaExists(escuderia.IdEscuderia))
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
            return View(escuderia);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                Console.WriteLine("IdEscuderia es null");
                return NotFound();
            }
            var escuderia = _context.Escuderias
                .Include(e => e.Pilotos)
                .FirstOrDefault(m => m.IdEscuderia == id);
            if (escuderia == null)
            {
                return NotFound();
            }
            return View(escuderia);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var escuderia = _context.Escuderias.Find(id);
            if (escuderia != null)
            {
                _context.Escuderias.Remove(escuderia);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }



        public bool EscuderiaExists(int idEscuderia)
        {
            return _context.Escuderias.Any(e => e.IdEscuderia == idEscuderia);
        }
    }
}
