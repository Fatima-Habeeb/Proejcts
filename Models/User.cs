using System.ComponentModel.DataAnnotations;

namespace webproject.Models
{
    public class User
    {
        [Key]
        public string email { get; set; }
        public string name { get; set; }

    }
}
