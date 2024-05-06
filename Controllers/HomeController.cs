using Microsoft.AspNetCore.Mvc;

namespace webproject.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
