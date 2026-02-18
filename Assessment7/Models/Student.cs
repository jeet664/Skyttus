using System.ComponentModel.DataAnnotations;

namespace Assessment7.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Marks { get; set; }

        [Required]
        public string Department { get; set; } = string.Empty;
    }
}
