using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PostMidProject.Models;
using PostMidProject.Repositories;
using System.Drawing.Printing;
using System.Linq;

namespace PostMidProject.Controllers
{
    public class StudentsController : Controller
    {

        private readonly MyDbContext _context;
        public StudentsController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [HttpPost]
        public IActionResult Index(string sortColumn = "Id", string sortOrder = "asc", int pageNumber = 1, int pageSize = 5)
        {
            AddLog("Changing View");

            var students = _context.Students.AsQueryable();

            // Sorting logic
            switch (sortColumn.ToLower())
            {
                case "name":
                    AddLog("Sorting");
                    students = sortOrder.ToLower() == "asc" ?
                        students.OrderBy(s => s.FullName) :
                        students.OrderByDescending(s => s.FullName);
                    break;
                case "rollno":
                    students = sortOrder.ToLower() == "asc" ?
                        students.OrderBy(s => s.RollNo) :
                        students.OrderByDescending(s => s.RollNo);
                    break;
                case "department":
                    students = sortOrder.ToLower() == "asc" ?
                        students.OrderBy(s => s.Department) :
                        students.OrderByDescending(s => s.Department);
                    break;
                case "degree":
                    students = sortOrder.ToLower() == "asc" ?
                        students.OrderBy(s => s.Degree) :
                        students.OrderByDescending(s => s.Degree);
                    break;
                case "city":
                    students = sortOrder.ToLower() == "asc" ?
                        students.OrderBy(s => s.City) :
                        students.OrderByDescending(s => s.City);
                    break;
                case "interests":
                    students = sortOrder.ToLower() == "asc" ?
                        students.OrderBy(s => s.Interest) :
                        students.OrderByDescending(s => s.Interest);
                    break;
                case "dob":
                    students = sortOrder.ToLower() == "asc" ?
                        students.OrderBy(s => s.DateOfBirth) :
                        students.OrderByDescending(s => s.DateOfBirth);
                    break;
                default:
                    students = sortOrder.ToLower() == "asc" ?
                        students.OrderBy(s => s.Id) :
                        students.OrderByDescending(s => s.Id);
                    break;
            }

            // Pagination logic
            
            var student = Pagination(students.ToList(), pageSize, pageNumber);
            List<Students> firstFiveStudentss = student.Take(5).ToList();

            foreach (Students s in firstFiveStudentss)
            {
                Console.WriteLine($"Student ID: {s.Id}, Name: {s.FullName}, Age: {s.RollNo} ");
                // Display other properties as needed
            }

            return View(student);
        }

        private List<Students> Pagination(List<Students> studentData, int pageSize, int pageNumber)
        {           
            Console.WriteLine("\n");
            int totalRecordsCount = studentData.Count();
            int totalPage = (int)Math.Ceiling((decimal)((double)totalRecordsCount / pageSize));
            var pager = new Pager(totalRecordsCount, pageNumber, pageSize);

            int skipRows = ((pageNumber - 1) * pageSize);

            var students = studentData
                .Skip(skipRows)
                .Take(pager.PageSize)
                .ToList();

            List<Students> firstFiveStudents = students.Take(5).ToList();

            foreach (Students s in firstFiveStudents)
            {
                Console.WriteLine($"Student ID: {s.Id}, Name: {s.FullName}, Age: {s.RollNo}");
                // Display other properties as needed
            }
            Console.WriteLine("\n");
            ViewBag.Pager = pager;
            ViewBag.PageSize = pageSize;
            return students;
        }

        public IActionResult AddStudents()
        {
            AddLog("Changing View");
            var existingInterests = _context.Students.Select(s => s.Interest).Distinct().ToList();
            ViewBag.ExistingInterests = existingInterests;
            return View();
        }

        public IActionResult StudentProfile(string rollNo)
        {
            AddLog("Changing View");
            var student = _context.Students.FirstOrDefault(s => s.RollNo == rollNo);
            return View(student);
        }

        public IActionResult EditStudents(string rollNo)
        {
            AddLog("Changing View");
            var existingInterests = _context.Students.Select(s => s.Interest).Distinct().ToList();
            ViewBag.ExistingInterests = existingInterests;
            var student = _context.Students.FirstOrDefault(s => s.RollNo == rollNo);
            return View(student);
        }

        public IActionResult Dashboard()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetTop5Interests()
        {
            StudentRepo _repo = new StudentRepo(_context);
            var topInterestData = _repo.GetTop5Interests();
            return Json(topInterestData);
        }


        [HttpGet]
        public IActionResult GetBottom5Interests()
        {
            StudentRepo _repo = new StudentRepo(_context);
            var bottomInterestData = _repo.GetBottom5Interests();
            return Json(bottomInterestData);
        }

        [HttpGet]
        public IActionResult GetDistinctInterests()
        {
            StudentRepo _repo = new StudentRepo(_context);
            var data = _repo.GetDistinctInterestsCount();
            return Json(data);
        }

        [HttpGet]
        public IActionResult GetCityDistributionData()
        {
            StudentRepo _repo = new StudentRepo(_context);
            var cityDistributionData = _repo.GetCityDistribution();
            return Json(cityDistributionData);
        }

        [HttpGet]
        public IActionResult GetSubmissionChartData()
        {
            StudentRepo _repo = new StudentRepo(_context);
            var submissionData = _repo.GetSubmissionChart();
            return Json(submissionData);
        }

        [HttpGet]
        public IActionResult GetAgeDistributionData()
        {
            StudentRepo _repo = new StudentRepo(_context);
            var ageDistributionData = _repo.GetAgeDistribution();
            return Json(ageDistributionData);
        }

        [HttpGet]
        public IActionResult GetDepartmentDistributionData()
        {
            StudentRepo _repo = new StudentRepo(_context);
            var departmentDistributionData = _repo.GetDepartmentDistribution();
            return Json(departmentDistributionData);
        }

        [HttpGet]
        public IActionResult GetDegreeDistributionData()
        {
            StudentRepo _repo = new StudentRepo(_context);
            var degreeDistributionData = _repo.GetDegreeDistribution();
            return Json(degreeDistributionData);
        }
        [HttpGet]
        public IActionResult GetStudentStatusData()
        {
            StudentRepo _repo = new StudentRepo(_context);
            var studentStatusData = _repo.GetStudentStatusData();
            return Json(studentStatusData);
        }

        [HttpGet]
        public IActionResult GetGenderDistributionData()
        {
            StudentRepo _repo = new StudentRepo(_context);
            var genderDistributionData = _repo.GetGenderDistribution();
            return Json(genderDistributionData);
        }

        [HttpGet]
        public IActionResult GetLast30DaysActivityData()
        {
            StudentRepo _repo = new StudentRepo(_context);
            var activityData = _repo.GetLast30DaysActivityChart();
            return Json(activityData);
        }
        [HttpGet]
        public IActionResult GetLast24HoursActivityData()
        {
            StudentRepo _repo = new StudentRepo(_context);
            var activityData = _repo.GetLast24HoursActivityChart();
            return Json(activityData);
        }

        [HttpGet]
        public IActionResult GetMostActiveHoursLast30DaysData()
        {
            StudentRepo _repo = new StudentRepo(_context);
            var activityData = _repo.GetMostActiveHoursLast30Days();
            return Json(activityData);
        }

        [HttpGet]
        public IActionResult GetLeastActiveHoursLast30DaysData()
        {
            StudentRepo _repo = new StudentRepo(_context);
            var activityData = _repo.GetLeastActiveHoursLast30Days();
            return Json(activityData);
        }

        [HttpGet]
        public IActionResult GetDeadHoursLast30DaysData()
        {
            StudentRepo _repo = new StudentRepo(_context);
            var activityData = _repo.GetDeadHoursLast30Days();
            return Json(activityData);
        }



        [HttpPost]
        public IActionResult AddStudents(string fullName, string rollNo, string email, string gender, string city, string interest, string newInterest, string department, string degree, string subject, DateOnly DOB, DateOnly startDate, DateOnly endDate)
        {
            AddLog("CRUD");

            // Check if newInterest is null or if it exists in the student's interest column
            Students existingInterest = null;
            if (newInterest!= null)
            {
                existingInterest = _context.Students.FirstOrDefault(s => s.Interest.ToLower() == newInterest.ToLower());
            }
            

            // Create a new student object and set its properties
            Students student = new Students()
            {
                FullName = fullName,
                RollNo = rollNo,
                Email = email,
                Gender = gender,
                DateOfBirth = DOB,
                City = city,
                Interest = "",
                Department = department,
                Degree = degree,
                Subject = subject,
                StartDate = startDate,
                EndDate = endDate,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            if (newInterest != null && existingInterest == null)
            {
                // If newInterest is not null and doesn't exist in the database, add it to the student's interest
                student.Interest = newInterest;
            }
            else if (interest != null)
            {
                // If newInterest is null but interest is provided, add it to the student's interest
                student.Interest = interest;
            }

            // Add the student to the database
            _context.Students.Add(student);
            _context.SaveChanges();

            return RedirectToAction("Index"); // Redirect to a success page or another view

        }

        [HttpPost]
        public IActionResult DeleteStudent(int id)
        {
            StudentRepo _repo = new StudentRepo(_context);
            AddLog("CRUD");

            try
            {
                _repo.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to delete the student."); 
            }


        }


        public IActionResult EditStudent(Students updatedStudent)
        {
            AddLog("CRUD");
            StudentRepo _repo = new StudentRepo(_context);

            var existingStudent = _context.Students.FirstOrDefault(s => s.RollNo == updatedStudent.RollNo);
            existingStudent.FullName = updatedStudent.FullName;
            existingStudent.Email = updatedStudent.Email;
            existingStudent.RollNo = updatedStudent.RollNo;
            existingStudent.Gender = updatedStudent.Gender;
            existingStudent.City = updatedStudent.City;
            existingStudent.Interest = updatedStudent.Interest;
            existingStudent.Department = updatedStudent.Department;
            existingStudent.Degree = updatedStudent.Degree; 
            existingStudent.DateOfBirth = updatedStudent.DateOfBirth;
            existingStudent.StartDate = updatedStudent.StartDate;
            existingStudent.EndDate = updatedStudent.EndDate;

            _repo.Update(existingStudent);
            return RedirectToAction("Index", existingStudent);
        }
        public void AddLog(string actionType)
        {
            var activitylog = new ActivityLog
            {
                ActionType = actionType,
                Timestamp = DateTime.Now,
            };
            var activityLogRepo = new ActivityLogRepo(_context);
            activityLogRepo.AddLog(activitylog);
        }
        [HttpPost]
        public ActionResult SortData(string columnName, string order, int currentPage, int pageSize)
        {
            /*AddLog("Sorting");*/
            var students = _context.Students.AsQueryable();
            switch (columnName.ToLower())
            {
                case "id":
                    students = order.ToLower() == "asc" ?
                        students.OrderBy(s => s.Id) :
                        students.OrderByDescending(s => s.Id);
                    break;
                case "name":
                    students = order.ToLower() == "asc" ?
                        students.OrderBy(s => s.FullName) :
                        students.OrderByDescending(s => s.FullName);
                    break;
                case "roll no":
                    students = order.ToLower() == "asc" ?
                        students.OrderBy(s => s.RollNo) :
                        students.OrderByDescending(s => s.RollNo);
                    break;
                case "department":
                    students = order.ToLower() == "asc" ?
                        students.OrderBy(s => s.Department) :
                        students.OrderByDescending(s => s.Department);
                    break;
                case "degree":
                    students = order.ToLower() == "asc" ?
                        students.OrderBy(s => s.Degree) :
                        students.OrderByDescending(s => s.Degree);
                    break;
                case "city":
                    students = order.ToLower() == "asc" ?
                        students.OrderBy(s => s.City) :
                        students.OrderByDescending(s => s.City);
                    break;
                case "interests":
                    students = order.ToLower() == "asc" ?
                        students.OrderBy(s => s.Interest) :
                        students.OrderByDescending(s => s.Interest);
                    break;
                case "dob":
                    students = order.ToLower() == "asc" ?
                        students.OrderBy(s => s.DateOfBirth) :
                        students.OrderByDescending(s => s.DateOfBirth);
                    break;
                default:
                    students = students.OrderBy(s => s.Id);
                    break;
            }


            var sortedData = students.ToList();
            var paginatedData = Pagination(sortedData, pageSize, currentPage);

            return RedirectToAction("Index", paginatedData);
        }

    }
}
