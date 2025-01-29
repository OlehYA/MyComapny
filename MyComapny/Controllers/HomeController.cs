using Microsoft.AspNetCore.Mvc;

namespace MyComapny.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
