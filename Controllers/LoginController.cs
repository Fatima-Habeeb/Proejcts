using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostMidProject.Models;

namespace PostMidProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly MyDbContext _context;
        public LoginController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginInfo(string username, string password)
        {
            var student = _context.Students.FirstOrDefault(s => s.RollNo == username);

            if (username.ToLower() == "admin" && password == "admin")
            {
                TempData["RollNo"] = "admin"; // Set admin identifier
                return RedirectToAction("Index", "Students"); // Redirect to admin profile
            }
            else if (student == null)
            {
                TempData["NullUserMessage"] = "Invalid Username!";
                return RedirectToAction("Index"); // Redirect back to the login view
            }
            else
            {
                if (student.Password == password)
                {
                    TempData["RollNo"] = student.RollNo;
                    return RedirectToAction("Index", "StudentProfile");
                }
                else
                {
                    TempData["ErrorMessage"] = "Incorrect password. Please try again!";
                    return RedirectToAction("Index"); // Redirect back to the login view
                }
            }
        }

    }
}
