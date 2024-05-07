using Microsoft.AspNetCore.Mvc;

namespace ASPNETAssignment1.WebApp.Areas.NashTech.Controllers
{
    public class PersonController : Controller
    {
        [Area("NashTech")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
