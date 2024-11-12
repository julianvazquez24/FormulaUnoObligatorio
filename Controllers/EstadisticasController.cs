using Microsoft.AspNetCore.Mvc;

namespace FormulaUnoObligatorio.Controllers
{
    public class EstadisticasController : Controller
    {
        public IActionResult Index()
        {
            return View("Estadisticas");
        }
    }
}
