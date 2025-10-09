using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebAPI.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
