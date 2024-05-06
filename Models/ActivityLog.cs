using System.ComponentModel.DataAnnotations;

namespace PostMidProject.Models
{
    public class ActivityLog
    {
        [Key]
        public int Id { get; set; }
        public string ActionType { get; set; } // Type of action performed
        public DateTime Timestamp { get; set; } // Time of the action
    }
}
