using System.ComponentModel.DataAnnotations;

namespace PostMidProject;
public class Students
{
    [Key]
    public int Id { get; set; }
    public required string FullName { get; set; }
    public required string RollNo { get; set; }
    public required string Email { get; set; }
    public required string Gender { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public required string City { get; set; }
    public required string Interest { get; set; }
    public required string Department { get; set; }
    public required string Degree { get; set; }
    public required string Subject { get; set; } 
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string Password { get; set; } = "12345";
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }


}