using Microsoft.AspNetCore.Mvc;

namespace YazilimProjeYonetimiProjesi.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
