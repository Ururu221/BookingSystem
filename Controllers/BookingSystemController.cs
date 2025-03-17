using Microsoft.AspNetCore.Mvc;

namespace BookingSystem_web_api.Controllers
{
    public class BookingSystemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
