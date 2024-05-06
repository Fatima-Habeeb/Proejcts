using Microsoft.AspNetCore.Mvc;
using webproject.Models;


namespace webproject.Controllers
{
    public class SubscribeController : Controller
    {
        public IActionResult Index()
        {

            return View();

        }

        public IActionResult Success()
        {

            return View("Success");

        }

        public IActionResult Fail()
        {

            return View("Fail");

        }

        public IActionResult Profile()
        {

            return View("Profile");
        }


        [HttpGet]
        public IActionResult SubscribeForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubscribeForm(string name, string email)
        {
            if (!HttpContext.Request.Cookies.ContainsKey("username"))
            {
                HttpContext.Response.Cookies.Append("username", name);
            }

            /*HttpContext.Response.Cookies.Delete("username");

      
            HttpContext.Response.Cookies.Append("username", name);*/

            User user = new User();
            user.name = name;
            user.email = email;
            TeamContext tc = new TeamContext();
            bool isEmailTaken = tc.Users.Any(u => u.email == user.email);

            if (!isEmailTaken)
            {
                if (ModelState.IsValid)
                {
                    using (var dbContext = new TeamContext())
                    {
                        dbContext.Users.Add(user);
                        dbContext.SaveChanges();
                    }
                    return RedirectToAction("Success");
                }

                return View(user);
            }

            if (isEmailTaken && HttpContext.Request.Cookies["username"] == name)
            {
                ViewBag.UserName = HttpContext.Request.Cookies["username"];

                HttpContext.Session.SetString("ProfilePageExpiration", DateTime.Now.AddSeconds(30).ToString());

                return View("Profile");
            }

            if (isEmailTaken)
            {
                HttpContext.Response.Cookies.Delete("username"); // Remove the existing "username" cookie
                return View("Fail");
            }

            return View("Index");
        }


    }
}
