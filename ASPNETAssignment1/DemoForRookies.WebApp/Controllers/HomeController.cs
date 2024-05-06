using ASPNETAssignment1.BusinessLogic;
using ASPNETAssignment1.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPNETAssignment1.WebApp.Controllers
{
    public class HomeController : PersonController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(IPersonBusinessLogic personBusinessLogic) : base(personBusinessLogic)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
