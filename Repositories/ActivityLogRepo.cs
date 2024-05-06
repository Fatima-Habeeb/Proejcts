using PostMidProject.Models;

namespace PostMidProject.Repositories
{
    public class ActivityLogRepo
    {
        private readonly MyDbContext _context;

        public ActivityLogRepo(MyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ActivityLog> GetAllLogs()
        {
            return _context.ActivityLog.ToList();
        }

        public ActivityLog GetLogByTimestamp(DateTime timestamp)
        {
            return _context.ActivityLog.FirstOrDefault(log => log.Timestamp == timestamp);
        }

        public void AddLog(ActivityLog log)
        {
            log.Timestamp = DateTime.Now; // Set the timestamp to the current time
            _context.ActivityLog.Add(log);
            _context.SaveChanges();
        }

        public void UpdateLog(ActivityLog log)
        {
            var logToUpdate = _context.ActivityLog.FirstOrDefault(l => l.Timestamp == log.Timestamp);
            if (logToUpdate != null)
            {
                logToUpdate.ActionType = log.ActionType; // Update the ActionType
                _context.SaveChanges();
            }
        }

        public void DeleteLog(DateTime timestamp)
        {
            var logToDelete = _context.ActivityLog.FirstOrDefault(l => l.Timestamp == timestamp);
            if (logToDelete != null)
            {
                _context.ActivityLog.Remove(logToDelete);
                _context.SaveChanges();

            }
        }
    }
}
