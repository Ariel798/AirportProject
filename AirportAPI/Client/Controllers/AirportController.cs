using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class AirportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
