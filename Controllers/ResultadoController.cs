using FormulaUnoObligatorio.Data;
using FormulaUnoObligatorio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            var resultados = _context.Resultados
                                     .Include(r => r.CarreraResultado) 
                                     .Include(r => r.PilotoResultado)  
                                     .ToList();  

            return View(resultados);  
        }


        public IActionResult Crear(int? idCarrera)
        {
            ViewBag.IdCarrera = new SelectList(_context.Carreras, "IdCarrera", "NombreCarrera");
            ViewBag.IdPilotos = new SelectList(_context.Pilotos, "IdPiloto", "NombrePiloto");
            ViewBag.PosicionesSalida = Enumerable.Range(1, 20).ToList();
            ViewBag.PosicionesLlegada = Enumerable.Range(1, 20).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear([Bind("IdCarrera, IdPiloto, PosicionSalida, PosicionLlegada")] Resultado resultado)
        {
            if (ModelState.IsValid)
            {
                if(!_context.Carreras.Any(carrera => carrera.IdCarrera == resultado.IdCarrera))
                {
                    ModelState.AddModelError("IdCarrera", " La carrera seleccionada no existe ");
                }
                
                var resultadosOcupados = _context.Resultados
                    .Where(resultados => resultados.IdCarrera == resultado.IdCarrera)
                    .ToList();

                if (resultadosOcupados.Any(r => r.PosicionSalida == resultado.PosicionSalida))
                {
                    ModelState.AddModelError("PosicionSalida", "La posición de salida ya está ocupada.");
                }
                if (resultadosOcupados.Any(r => r.PosicionLlegada == resultado.PosicionLlegada))
                {
                    ModelState.AddModelError("PosicionLlegada", "La posición de llegada ya está ocupada.");
                }

                if (ModelState.IsValid)
                {
                    _context.Add(resultado);
                    _context.SaveChanges();
                    ActualizarPuntajesPilotos();
                    return RedirectToAction("Index");
                }

                ViewBag.IdCarrera = new SelectList(_context.Carreras, "IdCarrera", "NombreCarrera", resultado.IdCarrera);
                ViewBag.IdPilotos = new SelectList(_context.Pilotos, "IdPiloto", "NombrePiloto", resultado.IdPiloto);
                ViewBag.PosicionesSalida = Enumerable.Range(1, 20).ToList();
                ViewBag.PosicionesLlegada = Enumerable.Range(1, 20).ToList();

                return View(resultado);



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

        public IActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var resultado = _context.Resultados
                .Include(r => r.CarreraResultado)
                .Include(r => r.PilotoResultado)
                .FirstOrDefault(m => m.IdResultado == id);
            if (resultado == null)
            {
                return NotFound();
            }
            return View(resultado);
        }
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
       
        
        public IActionResult EliminarConfirmada(int id)
        {
            var resultado = _context.Resultados.Find(id);
            if (resultado != null)
            {
                _context.Resultados.Remove(resultado);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var resultado = _context.Resultados.Find(id);
            if (resultado == null)
            {
                return NotFound();
            }

            ViewBag.NombreCarrera = _context.Carreras
                .Where(c => c.IdCarrera == resultado.IdCarrera)
                .Select(c => c.NombreCarrera)
                .FirstOrDefault();

            ViewBag.NombrePiloto = _context.Pilotos
                .Where(p => p.IdPiloto == resultado.IdPiloto)
                .Select(p => p.NombrePiloto)
                .FirstOrDefault();

            ViewBag.PosicionesSalida = Enumerable.Range(1, 20).ToList();
            ViewBag.PosicionesLlegada = Enumerable.Range(1, 20).ToList();

            return View(resultado);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int idResultado, [Bind("IdResultado, IdCarrera, IdPiloto, PosicionSalida, PosicionLlegada")] Resultado resultado)
        {
            if (idResultado != resultado.IdResultado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultado);
                    _context.SaveChanges();
                    ActualizarPuntajesPilotos();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultadoExiste(resultado.IdResultado))
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



            ViewBag.IdCarrera = new SelectList(_context.Carreras, "IdCarrera", "NombreCarrera", resultado.IdCarrera);
            ViewBag.IdPilotos = new SelectList(_context.Pilotos, "IdPiloto", "NombrePiloto", resultado.IdPiloto);
            ViewBag.PosicionesSalida = Enumerable.Range(1, 20).ToList();
            ViewBag.PosicionesLlegada = Enumerable.Range(1, 20).ToList();

            return View(resultado);
        }

        public bool ResultadoExiste(int idResultado)
        {
            return _context.Resultados.Any(c => c.IdResultado == idResultado);
        }

        private void ActualizarPuntajesPilotos()
        {
            var pilotos = _context.Pilotos.Include(p => p.Resultados).ToList();

            foreach (var piloto in pilotos)
            {
                piloto.PuntajePiloto = piloto.Resultados
                    .Where(r => r.PosicionLlegada > 0) // Asegurarse de que tengan posición válida
                    .Sum(r => CalcularPuntaje(r.PosicionLlegada));

                _context.Pilotos.Update(piloto);
            }

            _context.SaveChanges();
        }

        private int CalcularPuntaje(int posicion)
        {
            switch (posicion)
            {
                case 1: return 25;
                case 2: return 18;
                case 3: return 15;
                case 4: return 12;
                case 5: return 10;
                case 6: return 8;
                case 7: return 6;
                case 8: return 4;
                case 9: return 2;
                case 10: return 1;
                default: return 0;
            }
        }

    }
}
