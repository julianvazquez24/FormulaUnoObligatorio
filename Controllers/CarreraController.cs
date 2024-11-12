using Microsoft.AspNetCore.Mvc;
using FormulaUnoObligatorio.Models;

namespace FormulaUnoObligatorio.Controllers
{
    public class CarreraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
