using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Website.Controllers
{
    public class HomeController : Controller
    {
        // 
        // GET: /HelloWorld/
        public string Index()
        {
            return "This is my default action...";
        }
        // 
        // GET: /HelloWorld/Welcome/ 
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}
