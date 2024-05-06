namespace webproject
{
    public class Audit
    {
        public string CreatedBy { get; set; } = "Admin";
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}
