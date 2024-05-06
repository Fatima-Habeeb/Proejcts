using Microsoft.EntityFrameworkCore;
using PostMidProject.Models;
namespace PostMidProject.Repositories
{
    public class StudentRepo
    {
        private readonly MyDbContext _context;

        public StudentRepo(MyDbContext context)
        {
            _context = context;
        }

        public Students GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public IEnumerable<Students> GetAll()
        {
            return _context.Students.ToList();
        }

        public void Add(Students  student)
        {
            student.CreatedAt = DateTime.Now;
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Update(Students student)
        {
            student.ModifiedAt = DateTime.Now;
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        public List<string> GetTop5Interests()
        {
            return _context.Students
                .GroupBy(s => s.Interest)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => g.Key)
                .ToList();
        }

        public List<string> GetBottom5Interests()
        {
            return _context.Students
                .GroupBy(s => s.Interest)
                .OrderBy(g => g.Count())
                .Take(5)
                .Select(g => g.Key)
                .ToList();
        }

        public int GetDistinctInterestsCount()
        {
            return _context.Students.Select(s => s.Interest).Distinct().Count();
        }

        public Dictionary<string, int> GetCityDistribution()
        {
            return _context.Students
                .GroupBy(s => s.City)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public List<int> GetSubmissionChart()
        {
            DateTime thirtyDaysAgo = DateTime.Now.AddDays(-30);

            return _context.Students
                .Where(s => s.CreatedAt >= thirtyDaysAgo)
                .GroupBy(s => s.CreatedAt.Date)
                .OrderBy(g => g.Key)
                .Select(g => g.Count())
                .ToList();
        }
        public Dictionary<int, int> GetAgeDistribution()
        {
            // Fetch all students from the database first
            var students = _context.Students.ToList(); // Fetching all students to perform client-side operations

            // Perform age calculation on the client side using LINQ-to-Objects
            var ageDistribution = students
                .Select(s => CalculateAge(s.DateOfBirth)) // Calculate age from date of birth
                .Where(age => age >= 0) // Ensure the age is valid (non-negative)
                .GroupBy(age => age)
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Count());

            return ageDistribution;
        }

        // Helper method to calculate age from DateOnly date of birth
        private int CalculateAge(DateOnly dateOfBirth)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            int age = today.Year - dateOfBirth.Year;
            if (today.Month < dateOfBirth.Month || (today.Month == dateOfBirth.Month && today.Day < dateOfBirth.Day))
            {
                age--; // Decrement age if the birthday hasn't occurred yet this year
            }
            return age;
        }
        public Dictionary<string, int> GetDepartmentDistribution()
                {
                    return _context.Students
                        .GroupBy(s => s.Department)
                        .ToDictionary(g => g.Key, g => g.Count());
                }

                public Dictionary<string, int> GetDegreeDistribution()
                {
                    return _context.Students
                        .GroupBy(s => s.Degree)
                        .ToDictionary(g => g.Key, g => g.Count());
                }

        public Dictionary<string, int> GetGenderDistribution()
        {
            return _context.Students
                .GroupBy(s => s.Gender)
                .Select(g => new { Gender = g.Key, Count = g.Count() })
                .ToDictionary(x => x.Gender, x => x.Count);
        }


        public Dictionary<string, int> GetStudentStatusData()
        {
            var now = DateOnly.FromDateTime(DateTime.Today);

            return new Dictionary<string, int>
    {
        { "Currently Studying", _context.Students.Count(s =>
            s.StartDate <= now && (s.EndDate == null || s.EndDate > now)) },

        { "Recently Enrolled", _context.Students.Count(s =>
            s.StartDate > now.AddDays(-90) && s.StartDate <= now)}, // Assuming recently enrolled within the last 90 days

        { "About to Graduate", _context.Students.Count(s =>
            s.EndDate != null && s.EndDate > now && s.EndDate <= now.AddMonths(6)) }, // Assuming about to graduate within the next 6 months

        { "Graduated", _context.Students.Count(s =>
            s.EndDate != null && s.EndDate <= now) }
    };
        }




        public List<int> GetLast30DaysActivityChart()
        {
            DateTime thirtyDaysAgo = DateTime.Now.AddDays(-30);

            return _context.ActivityLog
                .Where(a => a.Timestamp >= thirtyDaysAgo)
                .GroupBy(a => a.Timestamp.Date)
                .OrderBy(g => g.Key)
                .Select(g => g.Count())
                .ToList();
        }
        /*public List<int> GetLast24HoursActivityChart()
        {
            DateTime twentyFourHoursAgo = DateTime.Now.AddHours(-24);

            return _context.ActivityLog
                .Where(a => a.Timestamp >= twentyFourHoursAgo)
                .GroupBy(a => a.Timestamp.Date)
                .OrderBy(g => g.Key)
                .Select(g => g.Count())
                .ToList();
        }*/
        public class ActivityCount
        {
            public DateTime Period { get; set; }
            public int Count { get; set; }
        }

        public List<ActivityCount> GetLast24HoursActivityChart()
        {
            var endTime = DateTime.UtcNow;
            var startTime = endTime.AddHours(-24);

            return _context.ActivityLog
                .Where(a => a.Timestamp >= startTime && a.Timestamp <= endTime)
                .AsEnumerable() // Materialize the query to use C# functions for grouping
                .GroupBy(a => new
                {
                    a.Timestamp.Year,
                    a.Timestamp.Month,
                    a.Timestamp.Day,
                    a.Timestamp.Hour,
                    QuarterHour = (a.Timestamp.Minute / 15) * 15
                })
                .Select(g => new ActivityCount
                {
                    Period = new DateTime(g.Key.Year, g.Key.Month, g.Key.Day, g.Key.Hour, g.Key.QuarterHour, 0),
                    Count = g.Count()
                })
                .OrderBy(a => a.Period)
                .ToList();
        }




        // ...

        /*public class ActivityCount
        {
            public DateTime PeriodStart { get; set; }
            public int Count { get; set; }
        }

        public List<ActivityCount> GetLast24HoursActivityChart()
        {
            var endTime = DateTime.UtcNow;
            var startTime = endTime.AddHours(-24);

            var activities = _context.ActivityLog
                .Where(a => a.Timestamp >= startTime && a.Timestamp <= endTime)
                .AsEnumerable() // Fetch the data into memory first
                .GroupBy(a => new
                {
                    PeriodStart = new DateTime(a.Timestamp.Year, a.Timestamp.Month, a.Timestamp.Day, a.Timestamp.Hour, a.Timestamp.Minute / 15 * 15, 0),
                })
                .Select(g => new ActivityCount
                {
                    PeriodStart = g.Key.PeriodStart,
                    Count = g.Count()
                })
                .OrderBy(a => a.PeriodStart)
                .ToList();

            return activities;
        }*/


        // ...


        /* public List<int> GetLast24HoursActivityChart()
         {
             var endTime = DateTime.UtcNow;
             var startTime = endTime.AddHours(-24);

             var activities = _context.ActivityLogs
                 .Where(a => a.Timestamp >= startTime && a.Timestamp <= endTime)
                 .GroupBy(a => DbFunctions.AddMinutes(DbFunctions.CreateDateTime(a.Timestamp.Year, a.Timestamp.Month, a.Timestamp.Day, a.Timestamp.Hour, a.Timestamp.Minute / 15 * 15, 0), 0))
                 .Select(g => new ActivityCount
                 {
                     Period = g.Key.Value,
                     Count = g.Count()
                 })
                 .OrderBy(a => a.Period)
                 .ToList();

             return activities;
         }*/




        /*public List<int> GetLast24HoursActivityChart()
        {
            DateTime twentyFourHoursAgo = DateTime.Now.AddHours(-24);

            return _context.ActivityLog
                .Where(a => a.Timestamp >= twentyFourHoursAgo)
                .GroupBy(a => a.Timestamp.Minute / 15)
                .OrderBy(g => g.Key)
                .Select(g => g.Count())
                .ToList();
        }*/



        public class HourActivityCount
        {
            public int Hour { get; set; }
            public int Count { get; set; }
        }

        public List<HourActivityCount> GetMostActiveHoursLast30Days()
        {
            DateTime thirtyDaysAgo = DateTime.Now.AddDays(-30);

            // Get the counts of activity logs grouped by hour over the last 30 days
            var activityCountsByHour = _context.ActivityLog
                .Where(a => a.Timestamp >= thirtyDaysAgo)
                .GroupBy(a => a.Timestamp.Hour)
                .Select(g => new HourActivityCount
                {
                    Hour = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(h => h.Count) // Order by the most activity first
                .ToList();

            return activityCountsByHour;
        }


        public List<int> GetLeastActiveHoursLast30Days()
        {
            DateTime thirtyDaysAgo = DateTime.Now.AddDays(-30);

            // Get all logs from the last 30 days
            var last30DaysLogs = _context.ActivityLog
                .Where(a => a.Timestamp >= thirtyDaysAgo)
                .ToList();

            // Group by hour, count the entries for each hour, and then order by the count ascending
            var leastActiveHours = last30DaysLogs
                .GroupBy(a => a.Timestamp.Hour)
                .OrderBy(g => g.Count())
                .Select(g => g.Key) // Select just the hour part
                .ToList();

            return leastActiveHours;
        }



        public List<int> GetDeadHoursLast30Days()
        {
            DateTime thirtyDaysAgo = DateTime.Now.AddDays(-30);

            return _context.ActivityLog
                .Where(a => a.Timestamp >= thirtyDaysAgo)
                .GroupBy(a => a.Timestamp.Hour)
                .OrderBy(g => g.Count())
                .Select(g => g.Key)
                .ToList();
        }

    }
}
