using FormulaUnoObligatorio.Data;
using FormulaUnoObligatorio.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormulaUnoObligatorio.Controllers
{
    public class ResultadoController : Controller
    {
        private readonly AppDbContext _context;
        public ResultadoController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View("Index", _context.Resultados.ToList()); ;
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear([Bind("IdCarrera, IdPiloto, PosicionSalida, PosicionLLegada")] Resultado resultado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultado);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(resultado);
        }

        public IActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultado = _context.Resultados
                .FirstOrDefault(m => m.IdResultado == id);

            if (resultado == null)
            {
                return NotFound();
            }
            return View(resultado);
        }
    }
}
