using Microsoft.AspNetCore.Mvc;
using PostMidProject.Models;

namespace PostMidProject.Controllers
{
    public class StudentProfileController : Controller
    {
        private readonly MyDbContext _context;
        public StudentProfileController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.RollNo = TempData["RollNo"] as string;
            var rollNum = TempData["RollNo"] as string;
            var student = _context.Students.FirstOrDefault(s => s.RollNo == rollNum);

            return View(student);

        }
        public IActionResult StudentsDashboard()
        {
           return View();
        }


    }
}
