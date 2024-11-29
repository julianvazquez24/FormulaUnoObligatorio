using FormulaUnoObligatorio.Data;
using FormulaUnoObligatorio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public IActionResult Crear( int? idCarrera)
        {
            ViewBag.IdCarrera = new SelectList(_context.Carreras, "IdCarrera", "NombreCarrera");
            ViewBag.IdPilotos = new SelectList(_context.Pilotos, "IdPiloto", "NombrePiloto");
            ViewBag.PosicionesSalida = Enumerable.Range(1, 20).ToList();
            ViewBag.PosicionesLlegada = Enumerable.Range(1, 20).ToList();

            if (idCarrera.HasValue)
            {
            List <Resultado> resultadosOcupados = _context.Resultados
                    .Where(resultado => resultado.IdCarrera == idCarrera.Value)
                    .ToList();


                List<int> posicionesOcupadasSalida = resultadosOcupados
                    .Select(resultado => resultado.PosicionSalida).ToList();

                List<int> posicionesOcupadasLlegada = resultadosOcupados
                    .Select(resultado => resultado.PosicionLlegada).ToList();

                ViewBag.PosicionesSalida = Enumerable.Range(1, 20).Except(posicionesOcupadasSalida).ToList();
                ViewBag.PosicionesLlegada= Enumerable.Range(1, 20).Except(posicionesOcupadasLlegada).ToList();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear([Bind("IdCarrera, IdPiloto, PosicionSalida, PosicionLlegada")] Resultado resultado)
        {
            if (ModelState.IsValid)
            {
                List<Resultado> resultadosExistentes = _context.Resultados
                    .Where(resultado => resultado.IdCarrera == resultado.IdCarrera).ToList();

                if(resultadosExistentes.Any( resultado => resultado.PosicionSalida == resultado.PosicionSalida))
                {
                    ModelState.AddModelError("PosicionSalida", "La posicion de salida ya esta ocupada");
                }
                if (resultadosExistentes.Any(resultado => resultado.PosicionLlegada == resultado.PosicionLlegada))
                {
                    ModelState.AddModelError("PosicionLlegada", "PosicionLlegada ya esta ocupada");
                }
                if (ModelState.IsValid)
                {
                    _context.Add(resultado);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }


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
