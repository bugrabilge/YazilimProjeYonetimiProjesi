using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static YazilimProjeYonetimiProjesi.Constants;

namespace YazilimProjeYonetimiProjesi.Controllers
{
    public class Page2Controller : Controller
    {
        [Authorize(Roles = "Admin, Moderator, Officer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
