using Microsoft.AspNetCore.Mvc;

namespace webproject.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
